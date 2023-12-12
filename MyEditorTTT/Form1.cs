using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

/*
 * Tyler Aluko
 * IGME.201 - Tutorial #1
 * I haven't a clue what's goin on here, but I'll act like I do!
 * * I figured out what's going on here (kinda)! 
 */
namespace MyEditor {

    public partial class Form1 : Form {

        //timer testing...
        //...
        
        //extra credit addition - test paragraph...
        private readonly string testParagraph = "Engineers, as practitioners of engineering, are people who invent, design, analyze, build, and test machines, systems, structures and materials to fulfill objectives and requirements while considering the limitations imposed by practicality, regulation, safety, and cost. The work of engineers forms the link between scientific discoveries and their subsequent applications to human and business needs and quality of life.";
        private int currentCharIndex; //track of current character user should type

        //maybe it's this?

        public Form1(MyEditorParent myEditorParent) {
            
            InitializeComponent();

            this.richTextBox.KeyPress += new KeyPressEventHandler(RichTextBox__KeyPress);

            //MDI parent
            this.MdiParent = myEditorParent;

            myEditorParent.openToolStripMenuItem.Click += new EventHandler(OpenToolStripMenuItem__Click); //handled by parent
            myEditorParent.saveToolStripMenuItem.Click += new EventHandler(SaveToolStripMenuItem__Click); //handled by parent

            myEditorParent.copyToolStripMenuItem.Click += new EventHandler(CopyToolStripMenuItem__Click);
            myEditorParent.cutToolStripMenuItem.Click += new EventHandler(CutToolStripMenuItem__Click);
            myEditorParent.pasteToolStripMenuItem.Click += new EventHandler(PasteToolStripMenuItem__Click);

            myEditorParent.closeAllToolStripMenuItem.Click += new EventHandler(CloseAllToolStripMenuItem__Click); //new addition: close all

            //context tool tip
            this.boldToolStripMenuItem.Click += new EventHandler(BoldToolStripMenuItem__Click); //bold
            this.italicsToolStripMenuItem.Click += new EventHandler(ItalicsToolStripMenuItem__Click); //italics
            this.underlineToolStripMenuItem.Click += new EventHandler(UnderlineToolStripMenuItem__Click); //underline

            //font menu items
            this.mSSansSerifToolStripMenuItem.Click += new EventHandler(MSSansSerifToolStripMenuItem__Click);
            this.timesNewRomanToolStripMenuItem.Click += new EventHandler(TimesNewRomanToolStripMenuItem__Click);

            this.testToolStripButton.Click += new EventHandler(TestToolStripButton__Click);

            //tool strip
            this.toolStrip.ItemClicked += new ToolStripItemClickedEventHandler(ToolStrip__ItemClicked);

            this.richTextBox.SelectionChanged += new EventHandler(RichTextBox__SelectionChanged);

            this.countdownLabel.Visible = false;

            this.timer.Tick += new EventHandler(Timer__Tick);

            this.Text = "MyEditor";

            //this.Show();

            this.FormClosing += new FormClosingEventHandler(Form1__FormClosing);
        }

        private void Form1__FormClosing(object sender, FormClosingEventArgs e)
        {
            MyEditorParent myEditorParent = (MyEditorParent)this.MdiParent;
            
            myEditorParent.openToolStripMenuItem.Click -= new EventHandler(OpenToolStripMenuItem__Click); //handled by parent
            myEditorParent.saveToolStripMenuItem.Click -= new EventHandler(SaveToolStripMenuItem__Click); //handled by parent

            myEditorParent.copyToolStripMenuItem.Click -= new EventHandler(CopyToolStripMenuItem__Click);
            myEditorParent.cutToolStripMenuItem.Click -= new EventHandler(CutToolStripMenuItem__Click);
            myEditorParent.pasteToolStripMenuItem.Click -= new EventHandler(PasteToolStripMenuItem__Click);

            myEditorParent.closeAllToolStripMenuItem.Click -= new EventHandler(CloseAllToolStripMenuItem__Click); //new addition: close all
        }

        private void CloseAllToolStripMenuItem__Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            //empty VS-generated method must be left alone :(
        }
        
        private void NewToolStripMenuItem__Click(object sender, EventArgs e) {
            
            //clears rich text box contents
            richTextBox.Clear();
            this.Text = "MyEditor"; //then reset text

        }

        //extra credit addition - checks if pressed key matches expected character in test paragraph
        private void RichTextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            if (currentCharIndex < testParagraph.Length && e.KeyChar == testParagraph[currentCharIndex])
            {
                currentCharIndex++;
            }
            else
            {
                e.Handled = true; //ignore key press if doesn't match expected character
            }
        }

        //troubleshooting...
        private void TestToolStripButton__Click(object sender, EventArgs e)
        {
            this.timer.Interval = 1000; //was 500

            this.toolStripProgressBar1.Value = 10; //60 secs

            this.countdownLabel.Text = "3";
            this.countdownLabel.Visible = true;
            this.richTextBox.Visible = false;

            //extra credit addition
            currentCharIndex = 0; //reset current character index
            this.richTextBox.Text = " "; //clear text box before test starts

            for (int i = 3; i > 0; i--)
            {
                this.countdownLabel.Text = i.ToString();
                this.Refresh();
                Thread.Sleep(1000);
            }

            this.countdownLabel.Visible = false;
            this.richTextBox.Visible = true;
            
            this.timer.Start();
            this.timer.Tick += new EventHandler(Timer__Tick);

        }

        private void Timer__Tick(object sender, EventArgs e)
        {
            if (this.toolStripProgressBar1.Value > 0)
            {
                this.toolStripProgressBar1.Value--;

                if (this.toolStripProgressBar1.Value == 0)
                {
                    this.timer.Stop();
                    CheckTypedText(); //checks typed text against test paragraph
                }
            }
            
            //--this.toolStripProgressBar1.Value;
            
            //if (this.toolStripProgressBar1.Value == 0)
            //{
                
            //    this.timer.Stop();

            //    /*
            //    string performance = "Congrats! You typed " + Math.Round(this.richTextBox.TextLength / 30.0, 2) + "letters per second.";
            //    MessageBox.Show(performance);
            //    */

            //    //extra credit addition
            //    CheckTypedText(); //checks typed text against test paragraph
            //}
        }

        //extra credit addition - checks typed text against test paragraph
        private void CheckTypedText()
        {
            string typedText = this.richTextBox.Text;

            int correctCharacters = 0;
            for (int i = 0; i < Math.Min(testParagraph.Length, typedText.Length); i++)
            {
                if (testParagraph[i] == typedText[i])
                {
                    correctCharacters++;
                }
            }

            double charactersPerSecond = correctCharacters / 30.0;
            string performance = $"Congrats! You typed {Math.Round(charactersPerSecond, 2)} letters per second.";
            MessageBox.Show(performance);
        }


        private void BoldToolStripMenuItem__Click(object sender, EventArgs e)
        {
            FontStyle fontStyle = FontStyle.Bold;
            Font selectionFont = null;
            
            selectionFont = richTextBox.SelectionFont;
            if(selectionFont == null)
            {
                selectionFont = richTextBox.Font;
            }

            SetSelectionFont(fontStyle, !selectionFont.Bold);

        }

        private void ItalicsToolStripMenuItem__Click(object sender, EventArgs e)
        {
            FontStyle fontStyle = FontStyle.Italic;
            Font selectionFont = null;

            selectionFont = richTextBox.SelectionFont;
            if (selectionFont == null)
            {
                selectionFont = richTextBox.Font;
            }

            SetSelectionFont(fontStyle, !selectionFont.Italic);

        }

        private void UnderlineToolStripMenuItem__Click(object sender, EventArgs e)
        {
            FontStyle fontStyle = FontStyle.Underline;
            Font selectionFont = null;

            selectionFont = richTextBox.SelectionFont;
            if (selectionFont == null)
            {
                selectionFont = richTextBox.Font;
            }

            SetSelectionFont(fontStyle, !selectionFont.Underline);

        }

        private void MSSansSerifToolStripMenuItem__Click(object sender, EventArgs e)
        {
            Font newFont = new Font("MS Sans Serif", richTextBox.SelectionFont.Size, richTextBox.SelectionFont.Style);
            richTextBox.SelectionFont = newFont;
        }

        private void TimesNewRomanToolStripMenuItem__Click(object sender, EventArgs e)
        {
            Font newFont = new Font("Times New Roman", richTextBox.SelectionFont.Size, richTextBox.SelectionFont.Style);
            richTextBox.SelectionFont = newFont;
        }

        private void RichTextBox__SelectionChanged(object sender, EventArgs e)
        {
            if(this.richTextBox.SelectionFont != null)
            {
                this.boldToolStripButton.Checked = richTextBox.SelectionFont.Bold;
                this.italicsToolStripButton.Checked = richTextBox.SelectionFont.Italic;
                this.underlineToolStripButton.Checked = richTextBox.SelectionFont.Underline;
            }

            this.colorToolStripButton.BackColor = richTextBox.SelectionColor;
        }

        private void OpenToolStripMenuItem__Click(object sender, EventArgs e) {
            
            if(this.MdiParent.ActiveMdiChild != this)
            {
                return;
            }
            
            //i have no idea what i'm doing tbh
            if(openFileDialog.ShowDialog() == DialogResult.OK) {
            
                RichTextBoxStreamType richTextBoxStreamType = RichTextBoxStreamType.RichText;
                
                if(openFileDialog.FileName.ToLower().Contains(".txt")) {
                    //if .txt, convert to plain text? - correct!
                    richTextBoxStreamType = RichTextBoxStreamType.PlainText;
                }
                
                richTextBox.LoadFile(openFileDialog.FileName, richTextBoxStreamType);

                //set to name of file being edited
                this.Text = "MyEditor (" + openFileDialog.FileName + ")";

            }

        }

        private void SaveToolStripMenuItem__Click(object sender, EventArgs e) {

            if (this.MdiParent.ActiveMdiChild != this)
            {
                return;
            }

            saveFileDialog.FileName = openFileDialog.FileName;

            //i have some idea of what i'm doing now, maybe?
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {

                RichTextBoxStreamType richTextBoxStreamType = RichTextBoxStreamType.RichText;

                if (saveFileDialog.FileName.ToLower().Contains(".txt")) {
                    //if .txt, convert to plain text? - correct (again)!
                    richTextBoxStreamType = RichTextBoxStreamType.PlainText;
                }

                richTextBox.SaveFile(saveFileDialog.FileName, richTextBoxStreamType);

                //set to name of file being edited
                this.Text = "MyEditor (" + saveFileDialog.FileName + ")";

            }

        }

        private void ExitToolStripMenuItem__Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void CopyToolStripMenuItem__Click(object sender, EventArgs e) {

            if (this.MdiParent.ActiveMdiChild != this)
            {
                return;
            }

            richTextBox.Copy();

        }

        private void CutToolStripMenuItem__Click(object sender, EventArgs e) {

            if (this.MdiParent.ActiveMdiChild != this)
            {
                return;
            }

            richTextBox.Cut();

        }

        private void PasteToolStripMenuItem__Click(object sender, EventArgs e) {

            if (this.MdiParent.ActiveMdiChild != this)
            {
                return;
            }

            richTextBox.Paste();

        }

        private void ToolStrip__ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            FontStyle fontStyle = FontStyle.Regular;

            ToolStripButton toolStripButton = null;

            if (e.ClickedItem == this.boldToolStripButton) {
                fontStyle = FontStyle.Bold;
                toolStripButton = this.boldToolStripButton;
            }
            else if (e.ClickedItem == this.italicsToolStripButton) {
                fontStyle = FontStyle.Italic;
                toolStripButton = this.italicsToolStripButton;
            }
            else if (e.ClickedItem == this.underlineToolStripButton) {
                fontStyle = FontStyle.Underline;
                toolStripButton = this.underlineToolStripButton;
            }
            else if (e.ClickedItem == this.colorToolStripButton) {
                if (colorDialog.ShowDialog() == DialogResult.OK) {
                    richTextBox.SelectionColor = colorDialog.Color;
                    colorToolStripButton.BackColor = colorDialog.Color;
                }
            }

            if (fontStyle != FontStyle.Regular) {
                toolStripButton.Checked = !toolStripButton.Checked;
                SetSelectionFont(fontStyle, toolStripButton.Checked);
            }

        }

        private void SetSelectionFont(FontStyle fontStyle, bool bSet) {
            
            Font newFont = null;
            Font selectionFont = null;

            selectionFont = richTextBox.SelectionFont;

            if (selectionFont == null) {
                selectionFont = richTextBox.Font;
            }

            if (bSet) {
                newFont = new Font(selectionFont, selectionFont.Style | fontStyle);
            }
            else {
                newFont = new Font(selectionFont, selectionFont.Style & ~fontStyle);
            }

            this.richTextBox.SelectionFont = newFont;

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }

}
