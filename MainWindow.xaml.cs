using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_SignIn_Click(object sender, RoutedEventArgs e)
        {
            string email = tbox_email.Text;
            string password = pbox_password.Password;
            var lastTime = DateTime.Now;

            User user1 = new User();
            user1.Email = email;
            user1.Password = password;
            user1.LastTime = lastTime;

            var json = JsonConvert.SerializeObject(user1);

            if (!Directory.Exists(@"D:\\WPF projects\\Lessons\\WpfApp1\\Users\\"))
            {
                Directory.CreateDirectory(@"D:\\WPF projects\\Lessons\\WpfApp1\\Users\\");
            }
            //var path = Directory.GetCurrentDirectory();

            File.WriteAllText("D:\\WPF projects\\Lessons\\WpfApp1\\Users\\" + lastTime.GetHashCode() + ".json", json);
            MessageBox.Show("Saqlandi");
            tbox_email.Clear();
            pbox_password.Clear();
        }
    }
    class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime LastTime { get; set; }
    }
}
