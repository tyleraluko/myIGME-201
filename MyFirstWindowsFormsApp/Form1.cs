using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstWindowsFormsApp {
    
    /* class houdiniForm
     * forms shows picture of houdini, and hides if mouse hovers over
     * restrictions: none
     */
    public partial class HoudiniForm : Form {
        
        //form constructor initializes control properties and event handlers
        public HoudiniForm() {

            //auto-gen method creates controls from Form Designer
            //InitializeComponent() defined in auto-generated file Form1.Designer.cs
            InitializeComponent(); //must be first statement in form constructor

            //every windows control has Tag field that can be used for any purpose
            //use to determine whether houdiniPictureBox is visible
            this.houdiniPictureBox.Tag = true;

            //sets URL of houdiniPictureBox image location
            this.houdiniPictureBox.ImageLocation = "https://people.rit.edu/dxsigm/Houdini.jpg";

            //sets event handler when mouse enters PictureBox to call HoudiniPictureBox__MouseEnterLeave
            this.houdiniPictureBox.MouseEnter += new EventHandler(HoudiniPictureBox__MouseEnterLeave);

            //sets event handler when mouse leaves PictureBox to call HoudiniPictureBox__MouseEnterLeave
            this.houdiniPictureBox.MouseLeave += new EventHandler(HoudiniPictureBox__MouseEnterLeave);

            //sets event handler when exitButton is clicked to call ExitButton__Click and exit app
            this.exitButton.Click += new EventHandler(ExitButton__Click);

        }

        //method HoudiniPictureBox__MouseEnterLeave
        //toggles between showing and hiding PictureBox when mouse enters or leaves
        private void HoudiniPictureBox__MouseEnterLeave(object sender, EventArgs e) {
            
            //PictureBox control passed as "sender" variable
            PictureBox pb = (PictureBox)sender;

            //negate current boolean value of houdiniPictureBox Tag property
            pb.Tag = !(bool)pb.Tag;

            //set visible property of houdiniPictureBox to current boolean value of Tag property
            pb.Visible = (bool)pb.Tag;

        }

        //method ExitButton__Click
        //exits app when exit button clicked
        private void ExitButton__Click(object sender, EventArgs e) {
            
            //exit application
            Application.Exit();

        }


    }
}
