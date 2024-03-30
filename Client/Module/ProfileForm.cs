using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Client.Services;

namespace Client.Module
{
    public class ProfileForm : Form
    {
        private Label lblName;
        private Label lblDateOfBirth;
        private Label lblPhoneNumber;
        private TextBox txtName;
        private DateTimePicker dtpDateOfBirth;
        private TextBox txtPhoneNumber;
        private Button btnSelectNumber;
        private Button btnLogout;
        private DataGridView dataGridView;

        public ProfileForm(string lblName, string lblPhoneNumber)
        {
            InitializeUserProfileComponent(lblName, lblPhoneNumber);
            InitializeDataGridView();
        }

        public void InitializeUserProfileComponent(string lblName, string lblPhoneNumber)
        {
            this.WindowState = FormWindowState.Normal; // Maximize the form
            this.FormBorderStyle = FormBorderStyle.None; // Remove border
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.lblName = new Label();
            this.lblDateOfBirth = new Label();
            this.lblPhoneNumber = new Label();
            this.txtName = new TextBox();
            this.dtpDateOfBirth = new DateTimePicker();
            this.txtPhoneNumber = new TextBox();
            this.btnSelectNumber = new Button();
            this.btnLogout = new Button();

            this.btnLogout.Text = "Logout";
            this.btnLogout.Location = new Point(100, 150);
            this.btnLogout.Size = new Size(100, 30);

            // Add event handler for click event
            this.btnLogout.Click += BtnLogout_Click;

            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Location = new Point(50, 50);
            this.lblName.Text = "Name:";

            // lblDateOfBirth
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new Point(50, 80);
            this.lblDateOfBirth.Text = "Date of Birth:";
            this.dtpDateOfBirth.Enabled = false;

            // lblPhoneNumber
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new Point(50, 110);
            this.lblPhoneNumber.Text = "Phone Number:";
            this.txtPhoneNumber.ReadOnly = true;

            // txtName
            txtName.Location = new Point(150, 50);
            txtName.Size = new Size(200, 20);
            txtName.Text = lblName;
            this.txtName.ReadOnly = true;

            // dtpDateOfBirth
            dtpDateOfBirth.Location = new Point(150, 80);

            // btnSave
            this.btnSelectNumber.Location = new Point(200, 150);
            this.btnSelectNumber.Size = new Size(100, 30);
            this.btnSelectNumber.Text = "Select number";
            this.btnSelectNumber.Click += btnSelect_Click;

            // txtPhoneNumber
            txtPhoneNumber.Location = new Point(150, 110);
            txtPhoneNumber.Size = new Size(200, 20);
            txtPhoneNumber.Text = lblPhoneNumber;
            this.Controls.Add(this.lblName);
            this.Controls.Add(lblDateOfBirth);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(txtName);
            this.Controls.Add(dtpDateOfBirth);
            this.Controls.Add(txtPhoneNumber);
            this.Controls.Add(btnSelectNumber);
            this.Controls.Add(btnLogout);

            Name = "UserProfileForm";
            Text = "User Profile";
        }
        private async void InitializeDataGridView()
        {
            // Create a new DataGridView
            dataGridView = new DataGridView();

            // Set DataGridView properties
            dataGridView.Location = new Point(50, 180); // Adjust the location as needed
            dataGridView.Size = new Size(600, 200);    // Adjust the size as needed
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ReadOnly = true;

            // Add columns to DataGridView
            dataGridView.Columns.Add("user_name", "UserName");
            dataGridView.Columns.Add("bet_number", "Bet Number");
            dataGridView.Columns.Add("number_bet", "Number Bet");
            dataGridView.Columns.Add("time_bet", "Time Bet");
            dataGridView.Columns.Add("bet_result", "Bet Result");


            BetService betService = new BetService();
            var bets = await betService.getAllBet();
            foreach (var bet in bets)
            {
                this.dataGridView.Rows.Add(bet.UserName, bet.UserPhone, bet.BetNumber, bet.EventStartTime + "-" + bet.EventEndTime, bet.Result);
            }

            // Add DataGridView to form's controls
            this.Controls.Add(dataGridView);
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectNumberForm selectForm = new SelectNumberForm();
            selectForm.Show();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            // call api tp del cache
            // to do handle
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}