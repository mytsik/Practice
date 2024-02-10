namespace _1301
{
    partial class EntryForm
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
            LoginButton = new Button();
            SignUpButton = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // LoginButton
            // 
            LoginButton.Location = new Point(243, 177);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(140, 23);
            LoginButton.TabIndex = 0;
            LoginButton.Text = "Вход";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // SignUpButton
            // 
            SignUpButton.Location = new Point(243, 206);
            SignUpButton.Name = "SignUpButton";
            SignUpButton.Size = new Size(140, 23);
            SignUpButton.TabIndex = 1;
            SignUpButton.Text = "Зарегистрироваться";
            SignUpButton.UseVisualStyleBackColor = true;
            SignUpButton.Click += SignUpButton_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(211, 124);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(203, 23);
            textBox1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(211, 106);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 3;
            label1.Text = "Введите пароль:";
            // 
            // EntryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(619, 332);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(SignUpButton);
            Controls.Add(LoginButton);
            Name = "EntryForm";
            Text = "EntryForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LoginButton;
        private Button SignUpButton;
        private TextBox textBox1;
        private Label label1;
    }
}