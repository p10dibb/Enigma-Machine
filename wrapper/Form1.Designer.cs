namespace wrapper
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Encrypt_Button = new System.Windows.Forms.Button();
            this.Phrase_Input_E = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Phrase_Input_D = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.Ring_Input_E = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.key_Input_E = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.Rottor_Input_E = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.Plug_Input_E = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Encrypt_Button
            // 
            this.Encrypt_Button.Location = new System.Drawing.Point(22, 219);
            this.Encrypt_Button.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Encrypt_Button.Name = "Encrypt_Button";
            this.Encrypt_Button.Size = new System.Drawing.Size(135, 38);
            this.Encrypt_Button.TabIndex = 0;
            this.Encrypt_Button.Text = "Encrypt";
            this.Encrypt_Button.UseVisualStyleBackColor = true;
            this.Encrypt_Button.Click += new System.EventHandler(this.Encrypt_Button_Click);
            // 
            // Phrase_Input_E
            // 
            this.Phrase_Input_E.Location = new System.Drawing.Point(43, 41);
            this.Phrase_Input_E.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Phrase_Input_E.Name = "Phrase_Input_E";
            this.Phrase_Input_E.Size = new System.Drawing.Size(169, 20);
            this.Phrase_Input_E.TabIndex = 2;
            this.Phrase_Input_E.Text = "HELLO WORL";
            this.Phrase_Input_E.TextChanged += new System.EventHandler(this.Phrase_Input_E_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(4, 41);
            this.textBox2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(40, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "phrase";
            // 
            // Phrase_Input_D
            // 
            this.Phrase_Input_D.Location = new System.Drawing.Point(48, 188);
            this.Phrase_Input_D.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Phrase_Input_D.Name = "Phrase_Input_D";
            this.Phrase_Input_D.Size = new System.Drawing.Size(169, 20);
            this.Phrase_Input_D.TabIndex = 4;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(4, 100);
            this.textBox5.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(69, 20);
            this.textBox5.TabIndex = 7;
            this.textBox5.Text = "Ring Setting";
            // 
            // Ring_Input_E
            // 
            this.Ring_Input_E.Location = new System.Drawing.Point(80, 100);
            this.Ring_Input_E.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Ring_Input_E.Name = "Ring_Input_E";
            this.Ring_Input_E.Size = new System.Drawing.Size(49, 20);
            this.Ring_Input_E.TabIndex = 6;
            this.Ring_Input_E.Text = "AAA";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(4, 126);
            this.textBox7.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(69, 20);
            this.textBox7.TabIndex = 9;
            this.textBox7.Text = "Key Setting";
            // 
            // key_Input_E
            // 
            this.key_Input_E.Location = new System.Drawing.Point(80, 126);
            this.key_Input_E.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.key_Input_E.Name = "key_Input_E";
            this.key_Input_E.Size = new System.Drawing.Size(49, 20);
            this.key_Input_E.TabIndex = 8;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(4, 155);
            this.textBox6.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(71, 20);
            this.textBox6.TabIndex = 11;
            this.textBox6.Text = "Rottor Amount";
            // 
            // Rottor_Input_E
            // 
            this.Rottor_Input_E.Location = new System.Drawing.Point(80, 155);
            this.Rottor_Input_E.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Rottor_Input_E.Name = "Rottor_Input_E";
            this.Rottor_Input_E.Size = new System.Drawing.Size(49, 20);
            this.Rottor_Input_E.TabIndex = 10;
            this.Rottor_Input_E.Text = "3";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(4, 65);
            this.textBox8.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(69, 20);
            this.textBox8.TabIndex = 13;
            this.textBox8.Text = "Plug Setting";
            // 
            // Plug_Input_E
            // 
            this.Plug_Input_E.Location = new System.Drawing.Point(80, 65);
            this.Plug_Input_E.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Plug_Input_E.Multiline = true;
            this.Plug_Input_E.Name = "Plug_Input_E";
            this.Plug_Input_E.Size = new System.Drawing.Size(132, 18);
            this.Plug_Input_E.TabIndex = 12;
            this.Plug_Input_E.Text = "JN MC DY GS KA EF IW PR HB XU QV TL OZ ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(4, 188);
            this.textBox1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(40, 20);
            this.textBox1.TabIndex = 23;
            this.textBox1.Text = "Output";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(217, 41);
            this.button1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 22);
            this.button1.TabIndex = 26;
            this.button1.Text = "rand data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(217, 75);
            this.button2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 22);
            this.button2.TabIndex = 27;
            this.button2.Text = "clear all";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 246);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.Plug_Input_E);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.Rottor_Input_E);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.key_Input_E);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.Ring_Input_E);
            this.Controls.Add(this.Phrase_Input_D);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Phrase_Input_E);
            this.Controls.Add(this.Encrypt_Button);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Encrypt_Button;
        private System.Windows.Forms.TextBox Phrase_Input_E;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox Phrase_Input_D;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox Ring_Input_E;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox key_Input_E;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox Rottor_Input_E;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox Plug_Input_E;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

