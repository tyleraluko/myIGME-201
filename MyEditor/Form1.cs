﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Tyler Aluko
 * IGME.201 - Tutorial #1
 * I haven't a clue what's goin on here, but I'll act like I do!
 * * I figured out what's going on here (kinda)! 
 */
namespace MyEditor {

    public partial class Form1 : Form {
        
        public Form1() {
            
            InitializeComponent();
            
            //event handlers on mouse click for menu items
            
            //file
            this.newToolStripMenuItem.Click += new EventHandler(NewToolStripMenuItem__Click); //new option
            this.openToolStripMenuItem.Click += new EventHandler(OpenToolStripMenuItem__Click); //open option
            this.saveToolStripMenuItem.Click += new EventHandler(SaveToolStripMenuItem__Click); //save option
            this.exitToolStripMenuItem.Click += new EventHandler(ExitToolStripMenuItem__Click); //exit option

            //edit
            this.copyToolStripMenuItem.Click += new EventHandler(CopyToolStripMenuItem__Click); //copy option
            this.cutToolStripMenuItem.Click += new EventHandler(CutToolStripMenuItem__Click); //cut option
            this.pasteToolStripMenuItem.Click += new EventHandler(PasteToolStripMenuItem__Click); //paste option

            //context tool tip
            this.boldToolStripMenuItem.Click += new EventHandler(BoldToolStripMenuItem__Click); //bold
            this.italicsToolStripMenuItem.Click += new EventHandler(ItalicsToolStripMenuItem__Click); //italics
            this.underlineToolStripMenuItem.Click += new EventHandler(UnderlineToolStripMenuItem__Click); //underline

            //font menu items
            this.mSSansSerifToolStripMenuItem.Click += new EventHandler(MSSansSerifToolStripMenuItem__Click);
            this.timesNewRomanToolStripMenuItem.Click += new EventHandler(TimesNewRomanToolStripMenuItem__Click);

            //tool strip
            this.toolStrip.ItemClicked += new ToolStripItemClickedEventHandler(ToolStrip__ItemClicked);

            this.richTextBox.SelectionChanged += new EventHandler(RichTextBox__SelectionChanged);

            this.Text = "MyEditor";
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            //empty VS-generated method must be left alone :(
        }
        
        private void NewToolStripMenuItem__Click(object sender, EventArgs e) {
            
            //clears rich text box contents
            richTextBox.Clear();
            this.Text = "MyEditor"; //then reset text

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
            richTextBox.Copy();
        }

        private void CutToolStripMenuItem__Click(object sender, EventArgs e) {
            richTextBox.Cut();
        }

        private void PasteToolStripMenuItem__Click(object sender, EventArgs e) {
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

    }

}
