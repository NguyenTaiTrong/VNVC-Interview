using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;
using Client.Request;
using Client.Services;
using Microsoft.Extensions.Caching.Distributed;

namespace Client.Module
{
    public class SelectNumberForm : Form
    {
        private Label selectedNumberLabel;
        private ComboBox numberComboBox;
        private ComboBox eventComboBox;
        private Label slotInfoLabel;
        private Button placeBetButton;
        private Button previousButton;
        private readonly IDistributedCache _distributedCache;

        public SelectNumberForm()
        {
            InitializeComponent();
        }

        public SelectNumberForm(IDistributedCache distributedCache)
        {
            InitializeComponent();
            _distributedCache = distributedCache;
        }

        private void InitializeComponent()
        {
            this.selectedNumberLabel = new Label();
            this.numberComboBox = new ComboBox();
            this.eventComboBox = new ComboBox();
            this.slotInfoLabel = new Label();
            this.placeBetButton = new Button();
            this.previousButton = new Button();

            // selectedNumberLabel
            this.selectedNumberLabel.AutoSize = true;
            this.selectedNumberLabel.Location = new Point(20, 20);
            this.selectedNumberLabel.Text = "Select Number:";



            // numberComboBox
            this.numberComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.numberComboBox.Location = new Point(150, 20);
            this.numberComboBox.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });
            this.numberComboBox.SelectedIndex = 0;
            this.numberComboBox.SelectedIndexChanged += new EventHandler(numberComboBox_SelectedIndexChanged);

            // numberComboBox
            this.eventComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.eventComboBox.Location = new Point(200, 55);
            var item = DateTime.Today; // 14:00:00
            while (item < DateTime.Today.AddHours(24)) // 16:00:00
            {
                eventComboBox.Items.Add(item.ToString("HH:00"));
                item = item.AddHours(1);
            }
            this.eventComboBox.SelectedIndex = 0;
            this.eventComboBox.SelectedIndexChanged += new EventHandler(eventComboBox_SelectedIndexChanged); // Adding event handler


            // slotInfoLabel
            this.slotInfoLabel.AutoSize = true;
            this.slotInfoLabel.Location = new Point(20, 60);
            this.slotInfoLabel.Text = "Next Slot: " + DateTime.Now.AddHours(1).ToString("hh:00") + "- " + DateTime.Now.AddHours(2).ToString("hh:00");

            // placeBetButton
            this.placeBetButton.Location = new Point(100, 80);
            this.placeBetButton.Size = new Size(100, 30);
            this.placeBetButton.Text = "Place Bet";
            this.placeBetButton.Click += new EventHandler(placeBetButton_Click);

            // previousButton
            this.previousButton.Location = Location = new Point(200, 80);
            this.previousButton.Size = new Size(100, 30);
            this.previousButton.Text = "Previous";
            this.previousButton.Click += new EventHandler(previousButton_Click);

            // Add controls to the form
            this.Controls.Add(this.selectedNumberLabel);
            this.Controls.Add(this.numberComboBox);
            // this.Controls.Add(this.eventComboBox);
            this.Controls.Add(this.slotInfoLabel);
            this.Controls.Add(this.placeBetButton);
            this.Controls.Add(this.previousButton);

            // Other UI settings and configurations
            this.Text = "Select Number";
            this.ClientSize = new Size(300, 150);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // Event handler for Place Bet button click
        private async void placeBetButton_Click(object sender, EventArgs e)
        {
            var numberBet = numberComboBox.SelectedItem;
            // use get event by start,end -> eventId
            var startTimeBet = DateTime.Now.AddHours(1);
            var endTimeBet = DateTime.Now.AddHours(2);

            UserService userService = new UserService();
            var profile = await userService.getProfile();
            BetService betService = new BetService();
            var newBet = await betService.saveBet(new CreateBetRequest()
            {
                BetNumber = Int32.Parse(numberBet.ToString()),
                EventId = 1, // hardcode // nếu đúng rule sẽ check time để get ra event
                UserId = profile.Id,
                BetResultId = 1,// hardcode // nếu đúng rule sẽ check time để get ra BetResult
            });
            if (newBet == 0 || newBet == -1)
            {
                this.Hide();
                ProfileForm profileForm = new ProfileForm(profile.UserName, profile.Phone);
                profileForm.Show();
            }
            else
            {
                MessageBox.Show("Cannot bet");
            }

        }

        private void numberComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle the event here
            // For example, you can access the selected item using: numberComboBox.SelectedItem
            // and perform necessary actions
        }
        private void eventComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle the event here
            // For example, you can access the selected item using: numberComboBox.SelectedItem
            // and perform necessary actions
        }

        private async void previousButton_Click(object sender, EventArgs e)
        {

            UserService userService = new UserService();
            var profile = await userService.getProfile();
            if (profile == null)
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
            else
            {
                this.Hide();
                ProfileForm profileForm = new ProfileForm(profile.UserName, profile.Phone);
                profileForm.Show();
            }

        }
    }
}