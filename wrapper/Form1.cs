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

            this.Output_E.Text = m.Run(this.Phrase_Input_E.Text);

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            m = new Machine(this.Key_Input_D.Text, this.Rottor_Input_D.Text, Ring_Input_D.Text, Plug_Input_D.Text);

            this.Output_D.Text = m.Run(this.Phrase_Input_D.Text);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string s = m.Generate_PlugBoard();
            this.Plug_Input_D.Text = s;
            this.Plug_Input_E.Text = s;
        }
    }
}
