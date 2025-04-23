namespace Lab3
{
    partial class fMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbP = new TextBox();
            tbQ = new TextBox();
            PLabel = new Label();
            QLabel = new Label();
            btnCalculate = new Button();
            lbD = new Label();
            tbD = new TextBox();
            lbR = new Label();
            tbR = new TextBox();
            tbFunction = new TextBox();
            lbFunction = new Label();
            lbE = new Label();
            tbE = new TextBox();
            rbEncrypt = new RadioButton();
            rbDecrypt = new RadioButton();
            lbSource = new Label();
            tbSource = new TextBox();
            lbOutput = new Label();
            tbOutput = new TextBox();
            btnEncrypt = new Button();
            menuStrip1 = new MenuStrip();
            mFile = new ToolStripMenuItem();
            mOpen = new ToolStripMenuItem();
            mEncrypt = new ToolStripMenuItem();
            mDecrypt = new ToolStripMenuItem();
            mSave = new ToolStripMenuItem();
            mSaveSource = new ToolStripMenuItem();
            mSaveEncrypt = new ToolStripMenuItem();
            btnClear = new Button();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tbP
            // 
            tbP.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tbP.Location = new Point(88, 40);
            tbP.Name = "tbP";
            tbP.Size = new Size(185, 29);
            tbP.TabIndex = 0;
            // 
            // tbQ
            // 
            tbQ.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tbQ.Location = new Point(88, 83);
            tbQ.Name = "tbQ";
            tbQ.Size = new Size(185, 29);
            tbQ.TabIndex = 1;
            // 
            // PLabel
            // 
            PLabel.AutoSize = true;
            PLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            PLabel.Location = new Point(37, 40);
            PLabel.Name = "PLabel";
            PLabel.Size = new Size(22, 21);
            PLabel.TabIndex = 2;
            PLabel.Text = "P:";
            // 
            // QLabel
            // 
            QLabel.AutoSize = true;
            QLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            QLabel.Location = new Point(37, 81);
            QLabel.Name = "QLabel";
            QLabel.Size = new Size(25, 21);
            QLabel.TabIndex = 3;
            QLabel.Text = "Q:";
            // 
            // btnCalculate
            // 
            btnCalculate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCalculate.Location = new Point(88, 132);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(185, 29);
            btnCalculate.TabIndex = 4;
            btnCalculate.Text = "Рассчитать";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // lbD
            // 
            lbD.AutoSize = true;
            lbD.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lbD.Location = new Point(325, 42);
            lbD.Name = "lbD";
            lbD.Size = new Size(101, 21);
            lbD.TabIndex = 5;
            lbD.Text = "Константа D:";
            // 
            // tbD
            // 
            tbD.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tbD.Location = new Point(459, 44);
            tbD.Name = "tbD";
            tbD.Size = new Size(184, 29);
            tbD.TabIndex = 6;
            // 
            // lbR
            // 
            lbR.AutoSize = true;
            lbR.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lbR.Location = new Point(360, 104);
            lbR.Name = "lbR";
            lbR.Size = new Size(23, 21);
            lbR.TabIndex = 7;
            lbR.Text = "R:";
            // 
            // tbR
            // 
            tbR.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tbR.Location = new Point(459, 87);
            tbR.Multiline = true;
            tbR.Name = "tbR";
            tbR.ReadOnly = true;
            tbR.Size = new Size(184, 55);
            tbR.TabIndex = 8;
            // 
            // tbFunction
            // 
            tbFunction.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tbFunction.Location = new Point(791, 35);
            tbFunction.Multiline = true;
            tbFunction.Name = "tbFunction";
            tbFunction.ReadOnly = true;
            tbFunction.Size = new Size(164, 55);
            tbFunction.TabIndex = 9;
            // 
            // lbFunction
            // 
            lbFunction.AutoSize = true;
            lbFunction.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lbFunction.Location = new Point(708, 46);
            lbFunction.Name = "lbFunction";
            lbFunction.Size = new Size(38, 21);
            lbFunction.TabIndex = 10;
            lbFunction.Text = "f(R):";
            // 
            // lbE
            // 
            lbE.AutoSize = true;
            lbE.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lbE.Location = new Point(687, 117);
            lbE.Name = "lbE";
            lbE.Size = new Size(98, 21);
            lbE.TabIndex = 11;
            lbE.Text = "Константа E:";
            // 
            // tbE
            // 
            tbE.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tbE.Location = new Point(791, 117);
            tbE.Name = "tbE";
            tbE.ReadOnly = true;
            tbE.Size = new Size(164, 29);
            tbE.TabIndex = 12;
            // 
            // rbEncrypt
            // 
            rbEncrypt.AutoSize = true;
            rbEncrypt.Checked = true;
            rbEncrypt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            rbEncrypt.Location = new Point(84, 214);
            rbEncrypt.Name = "rbEncrypt";
            rbEncrypt.Size = new Size(123, 25);
            rbEncrypt.TabIndex = 13;
            rbEncrypt.TabStop = true;
            rbEncrypt.Text = "Шифрование";
            rbEncrypt.UseVisualStyleBackColor = true;
            rbEncrypt.CheckedChanged += rbEncrypt_CheckedChanged;
            // 
            // rbDecrypt
            // 
            rbDecrypt.AutoSize = true;
            rbDecrypt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            rbDecrypt.Location = new Point(84, 254);
            rbDecrypt.Name = "rbDecrypt";
            rbDecrypt.Size = new Size(140, 25);
            rbDecrypt.TabIndex = 14;
            rbDecrypt.Text = "Дешифрование";
            rbDecrypt.UseVisualStyleBackColor = true;
            rbDecrypt.CheckedChanged += rbDecrypt_CheckedChanged;
            // 
            // lbSource
            // 
            lbSource.AutoSize = true;
            lbSource.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lbSource.Location = new Point(445, 214);
            lbSource.Name = "lbSource";
            lbSource.Size = new Size(127, 21);
            lbSource.TabIndex = 15;
            lbSource.Text = "Исходный текст:";
            // 
            // tbSource
            // 
            tbSource.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tbSource.Location = new Point(378, 254);
            tbSource.Multiline = true;
            tbSource.Name = "tbSource";
            tbSource.ReadOnly = true;
            tbSource.ScrollBars = ScrollBars.Vertical;
            tbSource.Size = new Size(265, 118);
            tbSource.TabIndex = 16;
            // 
            // lbOutput
            // 
            lbOutput.AutoSize = true;
            lbOutput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lbOutput.Location = new Point(778, 216);
            lbOutput.Name = "lbOutput";
            lbOutput.Size = new Size(103, 21);
            lbOutput.TabIndex = 17;
            lbOutput.Text = "Шифротекст:";
            // 
            // tbOutput
            // 
            tbOutput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tbOutput.Location = new Point(701, 268);
            tbOutput.Multiline = true;
            tbOutput.Name = "tbOutput";
            tbOutput.ReadOnly = true;
            tbOutput.ScrollBars = ScrollBars.Vertical;
            tbOutput.Size = new Size(265, 104);
            tbOutput.TabIndex = 18;
            // 
            // btnEncrypt
            // 
            btnEncrypt.Enabled = false;
            btnEncrypt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnEncrypt.Location = new Point(88, 336);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(174, 36);
            btnEncrypt.TabIndex = 19;
            btnEncrypt.Text = "Шифровать";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { mFile });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(978, 24);
            menuStrip1.TabIndex = 20;
            menuStrip1.Text = "menuStrip1";
            // 
            // mFile
            // 
            mFile.DropDownItems.AddRange(new ToolStripItem[] { mOpen, mSave });
            mFile.Name = "mFile";
            mFile.Size = new Size(48, 20);
            mFile.Text = "Файл";
            // 
            // mOpen
            // 
            mOpen.DropDownItems.AddRange(new ToolStripItem[] { mEncrypt, mDecrypt });
            mOpen.Name = "mOpen";
            mOpen.Size = new Size(135, 22);
            mOpen.Text = "Открыть";
            // 
            // mEncrypt
            // 
            mEncrypt.Name = "mEncrypt";
            mEncrypt.Size = new Size(177, 22);
            mEncrypt.Text = "Для шифрования";
            mEncrypt.Click += mEncrypt_Click;
            // 
            // mDecrypt
            // 
            mDecrypt.Name = "mDecrypt";
            mDecrypt.Size = new Size(177, 22);
            mDecrypt.Text = "Для расшифровки";
            mDecrypt.Click += mDecrypt_Click;
            // 
            // mSave
            // 
            mSave.DropDownItems.AddRange(new ToolStripItem[] { mSaveSource, mSaveEncrypt });
            mSave.Name = "mSave";
            mSave.Size = new Size(135, 22);
            mSave.Text = "Сохранить ";
            // 
            // mSaveSource
            // 
            mSaveSource.Name = "mSaveSource";
            mSaveSource.Size = new Size(201, 22);
            mSaveSource.Text = "Исходный текст";
            mSaveSource.Click += mSaveSource_Click;
            // 
            // mSaveEncrypt
            // 
            mSaveEncrypt.Name = "mSaveEncrypt";
            mSaveEncrypt.Size = new Size(201, 22);
            mSaveEncrypt.Text = "Зашифрованный текст";
            mSaveEncrypt.Click += mSaveEncrypt_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnClear.Location = new Point(88, 395);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(174, 35);
            btnClear.TabIndex = 21;
            btnClear.Text = "Очистить";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // fMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 450);
            Controls.Add(btnClear);
            Controls.Add(btnEncrypt);
            Controls.Add(tbOutput);
            Controls.Add(lbOutput);
            Controls.Add(tbSource);
            Controls.Add(lbSource);
            Controls.Add(rbDecrypt);
            Controls.Add(rbEncrypt);
            Controls.Add(tbE);
            Controls.Add(lbE);
            Controls.Add(lbFunction);
            Controls.Add(tbFunction);
            Controls.Add(tbR);
            Controls.Add(lbR);
            Controls.Add(tbD);
            Controls.Add(lbD);
            Controls.Add(btnCalculate);
            Controls.Add(QLabel);
            Controls.Add(PLabel);
            Controls.Add(tbQ);
            Controls.Add(tbP);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "fMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RSA система";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbP;
        private TextBox tbQ;
        private Label PLabel;
        private Label QLabel;
        private Button btnCalculate;
        private Label lbD;
        private TextBox tbD;
        private Label lbR;
        private TextBox tbR;
        private TextBox tbFunction;
        private Label lbFunction;
        private Label lbE;
        private TextBox tbE;
        private RadioButton rbEncrypt;
        private RadioButton rbDecrypt;
        private Label lbSource;
        private TextBox tbSource;
        private Label lbOutput;
        private TextBox tbOutput;
        private Button btnEncrypt;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem mFile;
        private ToolStripMenuItem mOpen;
        private ToolStripMenuItem mSave;
        private Button btnClear;
        private ToolStripMenuItem mEncrypt;
        private ToolStripMenuItem mDecrypt;
        private ToolStripMenuItem mSaveSource;
        private ToolStripMenuItem mSaveEncrypt;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
    }
}
