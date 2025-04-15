using System.Windows;
using Pract1_Florich_I223.Logic;

namespace Pract1_Florich_I223
{
    public partial class AuthWindow : Window
    {
        private IAuthService _authService;

        public AuthWindow()
        {
            InitializeComponent();
            _authService = new AuthService();
            
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            string login = tbxlogin.Text;
            string pass = tbxPass.Text;

            MessageBox.Show(login,pass);

            if (_authService.CheckData(login,pass))
            {
                DataGrid dataGridWindow = new DataGrid();
                dataGridWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка, проверьте правильность введённых данных в полях");
            }
        }
    }
}
