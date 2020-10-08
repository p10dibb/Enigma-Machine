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
        public char selectedPlug1 = '\0';
        public char selectedPlug2 = '\0';


        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void Encrypt_Button_Click(object sender, EventArgs e)
        {
            m = new Machine(CombosTextBox.Text, Ring_Input.Text);

           Output_Text.Text= m.encryptMessage(Phrase_Input.Text);
        }

      

        private void Button1_Click(object sender, EventArgs e)
        {
     
          

        }

        private void Phrase_Input_E_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Output_Text.Text = "";
            this.Phrase_Input.Text = "";
            this.Ring_Input.Text = "";
        }

        private void buttonResetPlugs_Click(object sender, EventArgs e)
        {
            this.CombosTextBox.Text = "";
            EnableLetterButtons();
            selectedPlug1 = '\0';
            selectedPlug2 = '\0';
        }

        private void EnableLetterButtons()
        {
            this.buttonA.Enabled = true;
            this.buttonB.Enabled = true;
            this.buttonC.Enabled = true;
            this.buttonD.Enabled = true;
            this.buttonE.Enabled = true;
            this.buttonF.Enabled = true;
            this.buttonG.Enabled = true;
            this.buttonH.Enabled = true;
            this.buttonI.Enabled = true;
            this.buttonJ.Enabled = true;
            this.buttonK.Enabled = true;
            this.buttonL.Enabled = true;
            this.buttonM.Enabled = true;
            this.buttonN.Enabled = true;
            this.buttonO.Enabled = true;
            this.buttonP.Enabled = true;
            this.buttonQ.Enabled = true;
            this.buttonR.Enabled = true;
            this.buttonS.Enabled = true;
            this.buttonT.Enabled = true;
            this.buttonU.Enabled = true;
            this.buttonV.Enabled = true;
            this.buttonW.Enabled = true;
            this.buttonX.Enabled = true;
            this.buttonY.Enabled = true;
            this.buttonZ.Enabled = true;
        }

        private void handlePlugComboSelection()
        {
            addSelectedCombo();
            disableSelectedPlugs();
        }

        private void addSelectedCombo()
        {
            string tempCombos = this.CombosTextBox.Text;

            tempCombos = tempCombos + this.selectedPlug1 + this.selectedPlug2 + ' ';
            this.CombosTextBox.Text = tempCombos;
        }

        private bool IsLetterSelected(char letter)
        {
            return selectedPlug1 == letter || selectedPlug2 == letter;
        }

        private void disableSelectedPlugs()
        {
            int count = 2;

            while (count > 0)
            {
                if (IsLetterSelected('A'))
                {
                    this.buttonA.Enabled = false;
                    deselectPlug('A');
                }
                else if (IsLetterSelected('B'))
                {
                    this.buttonB.Enabled = false;
                    deselectPlug('B');
                }
                else if (IsLetterSelected('C'))
                {
                    this.buttonC.Enabled = false;
                    deselectPlug('C');
                }
                else if (IsLetterSelected('D'))
                {
                    this.buttonD.Enabled = false;
                    deselectPlug('D');
                }
                else if (IsLetterSelected('E'))
                {
                    this.buttonE.Enabled = false;
                    deselectPlug('E');
                }
                else if (IsLetterSelected('F'))
                {
                    this.buttonF.Enabled = false;
                    deselectPlug('F');
                }
                else if (IsLetterSelected('G'))
                {
                    this.buttonG.Enabled = false;
                    deselectPlug('G');
                }
                else if (IsLetterSelected('H'))
                {
                    this.buttonH.Enabled = false;
                    deselectPlug('H');
                }
                else if (IsLetterSelected('I'))
                {
                    this.buttonI.Enabled = false;
                    deselectPlug('I');
                }
                else if (IsLetterSelected('J'))
                {
                    this.buttonJ.Enabled = false;
                    deselectPlug('J');
                }
                else if (IsLetterSelected('K'))
                {
                    this.buttonK.Enabled = false;
                    deselectPlug('K');
                }
                else if (IsLetterSelected('L'))
                {
                    this.buttonL.Enabled = false;
                    deselectPlug('L');
                }
                else if (IsLetterSelected('M'))
                {
                    this.buttonM.Enabled = false;
                    deselectPlug('M');
                }
                else if (IsLetterSelected('N'))
                {
                    this.buttonN.Enabled = false;
                    deselectPlug('N');
                }
                else if (IsLetterSelected('O'))
                {
                    this.buttonO.Enabled = false;
                    deselectPlug('O');
                }
                else if (IsLetterSelected('P'))
                {
                    this.buttonP.Enabled = false;
                    deselectPlug('P');
                }
                else if (IsLetterSelected('Q'))
                {
                    this.buttonQ.Enabled = false;
                    deselectPlug('Q');
                }
                else if (IsLetterSelected('R'))
                {
                    this.buttonR.Enabled = false;
                    deselectPlug('R');
                }
                else if (IsLetterSelected('S'))
                {
                    this.buttonS.Enabled = false;
                    deselectPlug('S');
                }
                else if (IsLetterSelected('T'))
                {
                    this.buttonT.Enabled = false;
                    deselectPlug('T');
                }
                else if (IsLetterSelected('U'))
                {
                    this.buttonU.Enabled = false;
                    deselectPlug('U');
                }
                else if (IsLetterSelected('V'))
                {
                    this.buttonV.Enabled = false;
                    deselectPlug('V');
                }
                else if (IsLetterSelected('W'))
                {
                    this.buttonW.Enabled = false;
                    deselectPlug('W');
                }
                else if (IsLetterSelected('X'))
                {
                    this.buttonX.Enabled = false;
                    deselectPlug('X');
                }
                else if (IsLetterSelected('Y'))
                {
                    this.buttonY.Enabled = false;
                    deselectPlug('Y');
                }
                else if (IsLetterSelected('Z'))
                {
                    this.buttonZ.Enabled = false;
                    deselectPlug('Z');
                }
                count--;
            }
           
        }
        
        private void deselectPlug(char letter)
        {
            if (this.selectedPlug1 == letter)
            {
                this.selectedPlug1 = '\0';
            }
            else
            {
                this.selectedPlug2 = '\0';
            }
        }

        private void handlePlugClick(char letter)
        {
            if (this.selectedPlug1 == '\0')
            {
                this.selectedPlug1 = letter;
            }
            else if (this.selectedPlug1 == letter)
            {
                this.selectedPlug1 = '\0';
            }
            else
            {
                this.selectedPlug2 = letter;
                handlePlugComboSelection();
            }
        }

        private void buttonA_Click(object sender, EventArgs e)
        {
            handlePlugClick('A');
        }
        private void buttonB_Click(object sender, EventArgs e)
        {
            handlePlugClick('B');
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            handlePlugClick('C');
        }

        private void buttonD_Click(object sender, EventArgs e)
        {
            handlePlugClick('D');
        }

        private void buttonE_Click(object sender, EventArgs e)
        {
            handlePlugClick('E');
        }

        private void buttonF_Click(object sender, EventArgs e)
        {
            handlePlugClick('F');
        }

        private void buttonG_Click(object sender, EventArgs e)
        {
            handlePlugClick('G');
        }

        private void buttonH_Click(object sender, EventArgs e)
        {
            handlePlugClick('H');
        }

        private void buttonI_Click(object sender, EventArgs e)
        {
            handlePlugClick('I');
        }

        private void buttonJ_Click(object sender, EventArgs e)
        {
            handlePlugClick('J');
        }

        private void buttonK_Click(object sender, EventArgs e)
        {
            handlePlugClick('K');
        }

        private void buttonL_Click(object sender, EventArgs e)
        {
            handlePlugClick('L');
        }

        private void buttonM_Click(object sender, EventArgs e)
        {
            handlePlugClick('M');
        }

        private void buttonN_Click(object sender, EventArgs e)
        {
            handlePlugClick('N');
        }

        private void buttonO_Click(object sender, EventArgs e)
        {
            handlePlugClick('O');
        }

        private void buttonP_Click(object sender, EventArgs e)
        {
            handlePlugClick('P');
        }

        private void buttonQ_Click(object sender, EventArgs e)
        {
            handlePlugClick('Q');
        }

        private void buttonR_Click(object sender, EventArgs e)
        {
            handlePlugClick('R');
        }

        private void buttonS_Click(object sender, EventArgs e)
        {
            handlePlugClick('S');
        }

        private void buttonT_Click(object sender, EventArgs e)
        {
            handlePlugClick('T');
        }

        private void buttonU_Click(object sender, EventArgs e)
        {
            handlePlugClick('U');
        }

        private void buttonV_Click(object sender, EventArgs e)
        {
            handlePlugClick('V');
        }

        private void buttonW_Click(object sender, EventArgs e)
        {
            handlePlugClick('W');
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            handlePlugClick('X');
        }

        private void buttonY_Click(object sender, EventArgs e)
        {
            handlePlugClick('Y');
        }

        private void buttonZ_Click(object sender, EventArgs e)
        {
            handlePlugClick('Z');
        }

        private void CombosTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Decrypt_button_Click(object sender, EventArgs e)
        {
            m = new Machine(CombosTextBox.Text, Ring_Input.Text);

            Output_Text.Text = m.decryptMessage(Phrase_Input.Text);
        }
    }
}
