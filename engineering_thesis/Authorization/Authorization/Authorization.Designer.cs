namespace Authorization
{
    partial class Authorization
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorization));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BTN_ADD_USER = new System.Windows.Forms.Button();
            this.BTN_Generate_CODE = new System.Windows.Forms.Button();
            this.TEXT_GENERATE_CODE = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_User_Password = new System.Windows.Forms.TextBox();
            this.TB_User_Surname = new System.Windows.Forms.TextBox();
            this.TB_User_Name = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TXT_DELETE_ACC_CODE = new System.Windows.Forms.TextBox();
            this.BTN_DELETE_CODE = new System.Windows.Forms.Button();
            this.BTN_DELETE_USER = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.TEXT_SURNAME_DELETE = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TEXT_NAME_DELETE = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TEXT_UID_DELETE = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvPERSONS = new System.Windows.Forms.DataGridView();
            this.BTN_CHECK_PERSONS = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.BTN_ENTREACE = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvPERSONS_TIME = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.BTN_OWN_SQL_STM = new System.Windows.Forms.Button();
            this.TB_OWN_SQL_STM = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPERSONS)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPERSONS_TIME)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(14, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1076, 746);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BTN_ADD_USER);
            this.tabPage1.Controls.Add(this.BTN_Generate_CODE);
            this.tabPage1.Controls.Add(this.TEXT_GENERATE_CODE);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.TB_User_Password);
            this.tabPage1.Controls.Add(this.TB_User_Surname);
            this.tabPage1.Controls.Add(this.TB_User_Name);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(1068, 713);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add user";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BTN_ADD_USER
            // 
            this.BTN_ADD_USER.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_ADD_USER.Location = new System.Drawing.Point(408, 482);
            this.BTN_ADD_USER.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTN_ADD_USER.Name = "BTN_ADD_USER";
            this.BTN_ADD_USER.Size = new System.Drawing.Size(288, 59);
            this.BTN_ADD_USER.TabIndex = 10;
            this.BTN_ADD_USER.Text = "ADD USER";
            this.BTN_ADD_USER.UseVisualStyleBackColor = true;
            this.BTN_ADD_USER.Click += new System.EventHandler(this.BTN_ADD_USER_Click);
            // 
            // BTN_Generate_CODE
            // 
            this.BTN_Generate_CODE.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Generate_CODE.Location = new System.Drawing.Point(646, 126);
            this.BTN_Generate_CODE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTN_Generate_CODE.Name = "BTN_Generate_CODE";
            this.BTN_Generate_CODE.Size = new System.Drawing.Size(288, 59);
            this.BTN_Generate_CODE.TabIndex = 9;
            this.BTN_Generate_CODE.Text = "Generate Code";
            this.BTN_Generate_CODE.UseVisualStyleBackColor = true;
            this.BTN_Generate_CODE.Click += new System.EventHandler(this.BTN_Generate_CODE_Click);
            // 
            // TEXT_GENERATE_CODE
            // 
            this.TEXT_GENERATE_CODE.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TEXT_GENERATE_CODE.Location = new System.Drawing.Point(646, 217);
            this.TEXT_GENERATE_CODE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TEXT_GENERATE_CODE.Name = "TEXT_GENERATE_CODE";
            this.TEXT_GENERATE_CODE.Size = new System.Drawing.Size(288, 41);
            this.TEXT_GENERATE_CODE.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(120, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 36);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(120, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 36);
            this.label2.TabIndex = 4;
            this.label2.Text = "Surname";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // TB_User_Password
            // 
            this.TB_User_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_User_Password.Location = new System.Drawing.Point(352, 313);
            this.TB_User_Password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TB_User_Password.Name = "TB_User_Password";
            this.TB_User_Password.Size = new System.Drawing.Size(214, 41);
            this.TB_User_Password.TabIndex = 2;
            // 
            // TB_User_Surname
            // 
            this.TB_User_Surname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_User_Surname.Location = new System.Drawing.Point(352, 217);
            this.TB_User_Surname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TB_User_Surname.Name = "TB_User_Surname";
            this.TB_User_Surname.Size = new System.Drawing.Size(214, 41);
            this.TB_User_Surname.TabIndex = 1;
            // 
            // TB_User_Name
            // 
            this.TB_User_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_User_Name.Location = new System.Drawing.Point(352, 126);
            this.TB_User_Name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TB_User_Name.Name = "TB_User_Name";
            this.TB_User_Name.Size = new System.Drawing.Size(214, 41);
            this.TB_User_Name.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.TXT_DELETE_ACC_CODE);
            this.tabPage2.Controls.Add(this.BTN_DELETE_CODE);
            this.tabPage2.Controls.Add(this.BTN_DELETE_USER);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.TEXT_SURNAME_DELETE);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.TEXT_NAME_DELETE);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.TEXT_UID_DELETE);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(1068, 713);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Delete user";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // TXT_DELETE_ACC_CODE
            // 
            this.TXT_DELETE_ACC_CODE.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_DELETE_ACC_CODE.Location = new System.Drawing.Point(633, 189);
            this.TXT_DELETE_ACC_CODE.Name = "TXT_DELETE_ACC_CODE";
            this.TXT_DELETE_ACC_CODE.Size = new System.Drawing.Size(305, 41);
            this.TXT_DELETE_ACC_CODE.TabIndex = 21;
            // 
            // BTN_DELETE_CODE
            // 
            this.BTN_DELETE_CODE.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_DELETE_CODE.Location = new System.Drawing.Point(633, 99);
            this.BTN_DELETE_CODE.Name = "BTN_DELETE_CODE";
            this.BTN_DELETE_CODE.Size = new System.Drawing.Size(305, 69);
            this.BTN_DELETE_CODE.TabIndex = 20;
            this.BTN_DELETE_CODE.Text = "Generate code";
            this.BTN_DELETE_CODE.UseVisualStyleBackColor = true;
            this.BTN_DELETE_CODE.Click += new System.EventHandler(this.BTN_DELETE_CODE_Click);
            // 
            // BTN_DELETE_USER
            // 
            this.BTN_DELETE_USER.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_DELETE_USER.Location = new System.Drawing.Point(400, 511);
            this.BTN_DELETE_USER.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTN_DELETE_USER.Name = "BTN_DELETE_USER";
            this.BTN_DELETE_USER.Size = new System.Drawing.Size(285, 72);
            this.BTN_DELETE_USER.TabIndex = 19;
            this.BTN_DELETE_USER.Text = "DELETE USER";
            this.BTN_DELETE_USER.UseVisualStyleBackColor = true;
            this.BTN_DELETE_USER.Click += new System.EventHandler(this.BTN_DELETE_USER_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(111, 299);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 36);
            this.label7.TabIndex = 18;
            this.label7.Text = "Surname";
            // 
            // TEXT_SURNAME_DELETE
            // 
            this.TEXT_SURNAME_DELETE.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TEXT_SURNAME_DELETE.Location = new System.Drawing.Point(279, 290);
            this.TEXT_SURNAME_DELETE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TEXT_SURNAME_DELETE.Name = "TEXT_SURNAME_DELETE";
            this.TEXT_SURNAME_DELETE.Size = new System.Drawing.Size(214, 41);
            this.TEXT_SURNAME_DELETE.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(111, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 36);
            this.label6.TabIndex = 16;
            this.label6.Text = "Name";
            // 
            // TEXT_NAME_DELETE
            // 
            this.TEXT_NAME_DELETE.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TEXT_NAME_DELETE.Location = new System.Drawing.Point(279, 189);
            this.TEXT_NAME_DELETE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TEXT_NAME_DELETE.Name = "TEXT_NAME_DELETE";
            this.TEXT_NAME_DELETE.Size = new System.Drawing.Size(214, 41);
            this.TEXT_NAME_DELETE.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(111, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 36);
            this.label5.TabIndex = 14;
            this.label5.Text = "User ID";
            // 
            // TEXT_UID_DELETE
            // 
            this.TEXT_UID_DELETE.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TEXT_UID_DELETE.Location = new System.Drawing.Point(279, 99);
            this.TEXT_UID_DELETE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TEXT_UID_DELETE.Name = "TEXT_UID_DELETE";
            this.TEXT_UID_DELETE.Size = new System.Drawing.Size(214, 41);
            this.TEXT_UID_DELETE.TabIndex = 13;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvPERSONS);
            this.tabPage3.Controls.Add(this.BTN_CHECK_PERSONS);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Size = new System.Drawing.Size(1068, 713);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Check users";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvPERSONS
            // 
            this.dgvPERSONS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPERSONS.Location = new System.Drawing.Point(84, 162);
            this.dgvPERSONS.Name = "dgvPERSONS";
            this.dgvPERSONS.RowTemplate.Height = 28;
            this.dgvPERSONS.Size = new System.Drawing.Size(900, 388);
            this.dgvPERSONS.TabIndex = 3;
            // 
            // BTN_CHECK_PERSONS
            // 
            this.BTN_CHECK_PERSONS.Location = new System.Drawing.Point(455, 594);
            this.BTN_CHECK_PERSONS.Name = "BTN_CHECK_PERSONS";
            this.BTN_CHECK_PERSONS.Size = new System.Drawing.Size(191, 71);
            this.BTN_CHECK_PERSONS.TabIndex = 2;
            this.BTN_CHECK_PERSONS.Text = "CHECK";
            this.BTN_CHECK_PERSONS.UseVisualStyleBackColor = true;
            this.BTN_CHECK_PERSONS.Click += new System.EventHandler(this.BTN_CHECK_PERSONS_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(243, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(605, 36);
            this.label4.TabIndex = 1;
            this.label4.Text = "All person authorized to enter to the room";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.BTN_ENTREACE);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.dgvPERSONS_TIME);
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1068, 713);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Check users entraces";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // BTN_ENTREACE
            // 
            this.BTN_ENTREACE.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_ENTREACE.Location = new System.Drawing.Point(431, 594);
            this.BTN_ENTREACE.Name = "BTN_ENTREACE";
            this.BTN_ENTREACE.Size = new System.Drawing.Size(191, 71);
            this.BTN_ENTREACE.TabIndex = 3;
            this.BTN_ENTREACE.Text = "CHECK";
            this.BTN_ENTREACE.UseVisualStyleBackColor = true;
            this.BTN_ENTREACE.Click += new System.EventHandler(this.BTN_ENTREACE_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(392, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(280, 36);
            this.label8.TabIndex = 2;
            this.label8.Text = "Entreace time board";
            // 
            // dgvPERSONS_TIME
            // 
            this.dgvPERSONS_TIME.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPERSONS_TIME.Location = new System.Drawing.Point(83, 171);
            this.dgvPERSONS_TIME.Name = "dgvPERSONS_TIME";
            this.dgvPERSONS_TIME.RowTemplate.Height = 28;
            this.dgvPERSONS_TIME.Size = new System.Drawing.Size(900, 388);
            this.dgvPERSONS_TIME.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.BTN_OWN_SQL_STM);
            this.tabPage5.Controls.Add(this.TB_OWN_SQL_STM);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Location = new System.Drawing.Point(4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1068, 713);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "SQL";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // BTN_OWN_SQL_STM
            // 
            this.BTN_OWN_SQL_STM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_OWN_SQL_STM.Location = new System.Drawing.Point(410, 553);
            this.BTN_OWN_SQL_STM.Name = "BTN_OWN_SQL_STM";
            this.BTN_OWN_SQL_STM.Size = new System.Drawing.Size(160, 73);
            this.BTN_OWN_SQL_STM.TabIndex = 2;
            this.BTN_OWN_SQL_STM.Text = "SEND";
            this.BTN_OWN_SQL_STM.UseVisualStyleBackColor = true;
            this.BTN_OWN_SQL_STM.Click += new System.EventHandler(this.BTN_OWN_SQL_STM_Click);
            // 
            // TB_OWN_SQL_STM
            // 
            this.TB_OWN_SQL_STM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_OWN_SQL_STM.Location = new System.Drawing.Point(139, 189);
            this.TB_OWN_SQL_STM.Multiline = true;
            this.TB_OWN_SQL_STM.Name = "TB_OWN_SQL_STM";
            this.TB_OWN_SQL_STM.Size = new System.Drawing.Size(748, 291);
            this.TB_OWN_SQL_STM.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(287, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(418, 36);
            this.label9.TabIndex = 0;
            this.label9.Text = "Write your own SQL statement";
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 776);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Authorization";
            this.Text = "Authorization";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPERSONS)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPERSONS_TIME)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button BTN_ADD_USER;
        private System.Windows.Forms.Button BTN_Generate_CODE;
        private System.Windows.Forms.TextBox TEXT_GENERATE_CODE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_User_Password;
        private System.Windows.Forms.TextBox TB_User_Surname;
        private System.Windows.Forms.TextBox TB_User_Name;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button BTN_DELETE_USER;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TEXT_SURNAME_DELETE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TEXT_NAME_DELETE;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TEXT_UID_DELETE;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BTN_CHECK_PERSONS;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button BTN_ENTREACE;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvPERSONS_TIME;
        private System.Windows.Forms.TextBox TXT_DELETE_ACC_CODE;
        private System.Windows.Forms.Button BTN_DELETE_CODE;
        private System.Windows.Forms.DataGridView dgvPERSONS;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button BTN_OWN_SQL_STM;
        private System.Windows.Forms.TextBox TB_OWN_SQL_STM;
        private System.Windows.Forms.Label label9;
    }
}