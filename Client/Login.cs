using Client.Module;
using Client.Services;

namespace Client
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
            CenterControls();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void buttonLogin_App(object sender, EventArgs e)
        {
            string phoneNumber = txtPhoneNumber.Text;
            this.Hide();

            // check user xem có tồn tại sdt chưa
            // chưa thì redirect sang form 2,rồi thì hiển thị user profile
            UserService userService = new UserService();
            var profile = await userService.getUserByPhone(phoneNumber);
            if (profile == null)
            {
                MessageBox.Show("Số điện thoại chưa đăng kí, Vui lòng đăng kí", "Popup Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UserInfoForm formInput = new UserInfoForm();
                formInput.Show();
            }
            else
            {
                ProfileForm formProfile = new ProfileForm(profile.UserName, profile.Phone);
                formProfile.Show();
            }
        }

        private async void buttonClose_App(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
