namespace Assign3
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
            this.OutputBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ClassBox = new System.Windows.Forms.ComboBox();
            this.ServerBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ServerBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ServerBox3 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.RoleBox = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.MinUpDown = new System.Windows.Forms.NumericUpDown();
            this.MaxUpDown = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TypeBox = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DamageButton = new System.Windows.Forms.RadioButton();
            this.HealerButton = new System.Windows.Forms.RadioButton();
            this.TankButton = new System.Windows.Forms.RadioButton();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MinUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutputBox
            // 
            this.OutputBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputBox.FormattingEnabled = true;
            this.OutputBox.ItemHeight = 15;
            this.OutputBox.Location = new System.Drawing.Point(533, 32);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.Size = new System.Drawing.Size(727, 754);
            this.OutputBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(553, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Query";
            // 
            // ClassBox
            // 
            this.ClassBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClassBox.FormattingEnabled = true;
            this.ClassBox.Location = new System.Drawing.Point(24, 63);
            this.ClassBox.Name = "ClassBox";
            this.ClassBox.Size = new System.Drawing.Size(121, 21);
            this.ClassBox.TabIndex = 2;
            // 
            // ServerBox
            // 
            this.ServerBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServerBox.FormattingEnabled = true;
            this.ServerBox.Location = new System.Drawing.Point(151, 63);
            this.ServerBox.Name = "ServerBox";
            this.ServerBox.Size = new System.Drawing.Size(121, 21);
            this.ServerBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Class";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Server";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(244, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "All Class type from a single server";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(363, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Show Results";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(336, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Percentage of Each Race from a single Server";
            // 
            // ServerBox2
            // 
            this.ServerBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServerBox2.FormattingEnabled = true;
            this.ServerBox2.Location = new System.Drawing.Point(151, 159);
            this.ServerBox2.Name = "ServerBox2";
            this.ServerBox2.Size = new System.Drawing.Size(121, 21);
            this.ServerBox2.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(148, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Server";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(363, 157);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Show Results";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(406, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "All Role Types from a Single Server within a Level Range";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(148, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Server";
            // 
            // ServerBox3
            // 
            this.ServerBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServerBox3.FormattingEnabled = true;
            this.ServerBox3.Location = new System.Drawing.Point(151, 258);
            this.ServerBox3.Name = "ServerBox3";
            this.ServerBox3.Size = new System.Drawing.Size(121, 21);
            this.ServerBox3.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 242);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "RoleBox";
            // 
            // RoleBox
            // 
            this.RoleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RoleBox.FormattingEnabled = true;
            this.RoleBox.Location = new System.Drawing.Point(24, 258);
            this.RoleBox.Name = "RoleBox";
            this.RoleBox.Size = new System.Drawing.Size(121, 21);
            this.RoleBox.TabIndex = 15;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(363, 256);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "Show Results";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MinUpDown
            // 
            this.MinUpDown.Location = new System.Drawing.Point(24, 309);
            this.MinUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.MinUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinUpDown.Name = "MinUpDown";
            this.MinUpDown.Size = new System.Drawing.Size(39, 20);
            this.MinUpDown.TabIndex = 18;
            this.MinUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinUpDown.ValueChanged += new System.EventHandler(this.MinUpDown_ValueChanged);
            // 
            // MaxUpDown
            // 
            this.MaxUpDown.Location = new System.Drawing.Point(69, 309);
            this.MaxUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.MaxUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxUpDown.Name = "MaxUpDown";
            this.MaxUpDown.Size = new System.Drawing.Size(37, 20);
            this.MaxUpDown.TabIndex = 19;
            this.MaxUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxUpDown.ValueChanged += new System.EventHandler(this.MaxUpDown_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(66, 332);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Max";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 332);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Min";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 293);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Level Range";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(12, 362);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(188, 20);
            this.label13.TabIndex = 23;
            this.label13.Text = "All guilds of a certain type";
            // 
            // TypeBox
            // 
            this.TypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeBox.FormattingEnabled = true;
            this.TypeBox.Location = new System.Drawing.Point(24, 409);
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.Size = new System.Drawing.Size(121, 21);
            this.TypeBox.TabIndex = 24;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(363, 409);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(116, 23);
            this.button4.TabIndex = 25;
            this.button4.Text = "Show Results";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 393);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Type";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(20, 469);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(380, 20);
            this.label15.TabIndex = 27;
            this.label15.Text = "All Players Who Could Fill a Role But Presently Aren\'t";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DamageButton);
            this.groupBox1.Controls.Add(this.HealerButton);
            this.groupBox1.Controls.Add(this.TankButton);
            this.groupBox1.Location = new System.Drawing.Point(24, 515);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 50);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // DamageButton
            // 
            this.DamageButton.AutoSize = true;
            this.DamageButton.Location = new System.Drawing.Point(163, 19);
            this.DamageButton.Name = "DamageButton";
            this.DamageButton.Size = new System.Drawing.Size(65, 17);
            this.DamageButton.TabIndex = 31;
            this.DamageButton.TabStop = true;
            this.DamageButton.Text = "Damage";
            this.DamageButton.UseVisualStyleBackColor = true;
            // 
            // HealerButton
            // 
            this.HealerButton.AutoSize = true;
            this.HealerButton.Location = new System.Drawing.Point(83, 19);
            this.HealerButton.Name = "HealerButton";
            this.HealerButton.Size = new System.Drawing.Size(56, 17);
            this.HealerButton.TabIndex = 30;
            this.HealerButton.TabStop = true;
            this.HealerButton.Text = "Healer";
            this.HealerButton.UseVisualStyleBackColor = true;
            // 
            // TankButton
            // 
            this.TankButton.AutoSize = true;
            this.TankButton.Location = new System.Drawing.Point(6, 19);
            this.TankButton.Name = "TankButton";
            this.TankButton.Size = new System.Drawing.Size(50, 17);
            this.TankButton.TabIndex = 29;
            this.TankButton.TabStop = true;
            this.TankButton.Text = "Tank";
            this.TankButton.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(363, 528);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(116, 23);
            this.button5.TabIndex = 29;
            this.button5.Text = "Show Results";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1272, 810);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.TypeBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.MaxUpDown);
            this.Controls.Add(this.MinUpDown);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.RoleBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ServerBox3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ServerBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ServerBox);
            this.Controls.Add(this.ClassBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OutputBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.MinUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox OutputBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ClassBox;
        private System.Windows.Forms.ComboBox ServerBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ServerBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ServerBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox RoleBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown MinUpDown;
        private System.Windows.Forms.NumericUpDown MaxUpDown;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox TypeBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton DamageButton;
        private System.Windows.Forms.RadioButton HealerButton;
        private System.Windows.Forms.RadioButton TankButton;
        private System.Windows.Forms.Button button5;
    }
}
