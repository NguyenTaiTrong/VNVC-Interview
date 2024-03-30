namespace Client
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        // private Button button1;
        private TextBox txtPhoneNumber;
        private Label lblPhoneNumber;
        private Button btnSubmit;
         private Button btnClose;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // private void InitializeComponent()
        // {
        //     button1 = new Button();
        //     SuspendLayout();
        //     // button1
        //     button1.Location = new Point(0, 0);
        //     button1.Name = "button1";
        //     button1.Size = new Size(75, 23);
        //     button1.TabIndex = 0;
        //     button1.Text = "Login";
        //     button1.UseVisualStyleBackColor = true;
        //     button1.Click += button1_Click;

        //     // Login
        //     AutoScaleDimensions = new SizeF(7F, 15F);
        //     AutoScaleMode = AutoScaleMode.Font;
        //     ClientSize = new Size(800, 450);
        //     Controls.Add(button1);
        //     Name = "Login";
        //     Text = "Rooster Lottery";
        //     Load += Login_Load;
        //     ResumeLayout(false);
        // }
        private void InitializeComponent()
        {
            this.txtPhoneNumber = new TextBox();
            this.lblPhoneNumber = new Label();
            this.btnSubmit = new Button();
            this.btnClose = new Button();
            this.SuspendLayout();
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new Point(120, 50);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new Size(200, 20);
            this.txtPhoneNumber.TabIndex = 0;
            this.txtPhoneNumber.Validating += TxtPhoneNumber_Validating;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new Point(30, 53);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new Size(84, 13);
            this.lblPhoneNumber.TabIndex = 1;
            this.lblPhoneNumber.Text = "Phone Number:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new Point(120, 100);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new Size(75, 23);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Access with your phone number";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.buttonLogin_App);

            this.btnClose.Location = new Point(200, 100);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close App";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.buttonClose_App);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(354, 177);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.btnClose);
            this.Name = "Form1";
            this.Text = "Phone Input Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void TxtPhoneNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("Phone number cannot be empty.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; // Cancel the event to prevent focus change
            }
        }

        private void CenterControls()
        {
            // Centering controls when form is resized
            int horizontalOffset = (this.ClientSize.Width - lblPhoneNumber.Width - txtPhoneNumber.Width) / 3;
            int verticalOffset = (this.ClientSize.Height - lblPhoneNumber.Height - btnSubmit.Height) / 3;
            lblPhoneNumber.Location = new Point(horizontalOffset, verticalOffset);
            txtPhoneNumber.Location = new Point(horizontalOffset + lblPhoneNumber.Width, verticalOffset);
            btnSubmit.Location = new Point(horizontalOffset, verticalOffset + lblPhoneNumber.Height + 10);
            // Adjust button width based on text
            btnSubmit.Width = TextRenderer.MeasureText(btnSubmit.Text, btnSubmit.Font).Width + 20;
        }
    }
}
