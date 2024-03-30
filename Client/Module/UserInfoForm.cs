using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Client.Request;
using Client.Services;

namespace Client.Module
{
    public class UserInfoForm : Form
    {
        private Label lblName;
        private Label lblDateOfBirth;
        private Label lblPhoneNumber;
        private TextBox txtName;
        private DateTimePicker dtpDateOfBirth;
        private TextBox txtPhoneNumber;
        private Button btnSave;

        public UserInfoForm()
        {
            InitializeUserInfoComponent();
        }

        public void InitializeUserInfoComponent()
        {
            lblName = new Label();
            lblDateOfBirth = new Label();
            lblPhoneNumber = new Label();
            txtName = new TextBox();
            dtpDateOfBirth = new DateTimePicker();
            txtPhoneNumber = new TextBox();
            btnSave = new Button();

            SuspendLayout();

            // lblName
            lblName.AutoSize = true;
            lblName.Location = new Point(50, 50);
            lblName.Text = "Name:";

            // lblDateOfBirth
            lblDateOfBirth.AutoSize = true;
            lblDateOfBirth.Location = new Point(50, 80);
            lblDateOfBirth.Text = "Date of Birth:";

            // lblPhoneNumber
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(50, 110);
            lblPhoneNumber.Text = "Phone Number:";

            // txtName
            txtName.Location = new Point(150, 50);
            txtName.Size = new Size(200, 20);

            // dtpDateOfBirth
            dtpDateOfBirth.Location = new Point(150, 80);

            // txtPhoneNumber
            txtPhoneNumber.Location = new Point(150, 110);
            txtPhoneNumber.Size = new Size(200, 20);
            txtPhoneNumber.Validating += TxtPhoneNumber_Validating;

            // btnSave
            btnSave.Location = new Point(150, 150);
            btnSave.Size = new Size(75, 23);
            btnSave.Text = "Register";
            btnSave.Click += btnSave_Click;

            // UserInfoForm
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 200);
            Controls.Add(lblName);
            Controls.Add(lblDateOfBirth);
            Controls.Add(lblPhoneNumber);
            Controls.Add(txtName);
            Controls.Add(dtpDateOfBirth);
            Controls.Add(txtPhoneNumber);
            Controls.Add(btnSave);
            Name = "UserInfoForm";
            Text = "User Register";
            ResumeLayout(false);
            PerformLayout();
        }
        private void TxtPhoneNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string phoneNumber = txtPhoneNumber.Text.Trim();

            // Regular expression pattern for a phone number (example pattern)
            string pattern = @"^\d{10}$"; // Assuming a 10-digit phone number, adjust the pattern as needed

            // Validate the input against the pattern
            if (!Regex.IsMatch(phoneNumber, pattern))
            {
                MessageBox.Show("Invalid phone number format. Please enter a 10-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; // Cancel the event to prevent focus change
            }
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Implement logic to save user information
            string name = txtName.Text;
            DateTime dateOfBirth = dtpDateOfBirth.Value;
            string phoneNumber = txtPhoneNumber.Text;
            UserService userService = new UserService();
            CreateUserRequest inputUser = new CreateUserRequest();
            inputUser.UserName = name;
            inputUser.Phone = phoneNumber;
            inputUser.BirthDay = dateOfBirth;
            int isSuccess = await userService.saveUser(inputUser);
            this.Hide();
            if (isSuccess == 0 || isSuccess == -1)
            {
                MessageBox.Show("Đăng kí thành công", "Popup Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login login = new Login();
                login.Show();
            }
            else
            {
                MessageBox.Show("Đăng kí thất bại", "Popup Message", MessageBoxButtons.CancelTryContinue, MessageBoxIcon.Error);
                UserInfoForm userInfoForm = new UserInfoForm();
                userInfoForm.Show();
            }
        }
    }
}