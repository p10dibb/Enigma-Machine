using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Enigma;
namespace wrapper
{
    public partial class Form1 : Form
    {
        public Machine m=new Machine();

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void Encrypt_Button_Click(object sender, EventArgs e)
        {
            m = new Machine(this.key_Input_E.Text,this.Rottor_Input_E.Text,Ring_Input_E.Text,Plug_Input_E.Text);


            if (Phrase_Input_E.Text.Equals(""))
            {
                this.Phrase_Input_E.Text = m.decrypt(this.Phrase_Input_D.Text);
            }
            else
            {
                this.Phrase_Input_D.Text = m.encrypt(this.Phrase_Input_E.Text);
            }
            

        }

      

        private void Button1_Click(object sender, EventArgs e)
        {
            string s = m.Generate_PlugBoard();
      
            this.Plug_Input_E.Text = s;

            if (!Rottor_Input_E.Text.Equals(""))
            {
                s = m.Generate_RingSetting(Rottor_Input_E.Text);
           
                this.Ring_Input_E.Text = s;
            }
            else
            {
                this.Ring_Input_E.Text = "AAA";
            }
          

        }

        private void Phrase_Input_E_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.key_Input_E.Text = "";
            this.Phrase_Input_D.Text = "";
            this.Phrase_Input_E.Text = "";
            this.Rottor_Input_E.Text = "";
            this.Ring_Input_E.Text = "";
            this.Plug_Input_E.Text = "";
        }
    }
}
