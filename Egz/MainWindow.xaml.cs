using System.Diagnostics;
using System.Windows;
namespace Egz
{

    public partial class MainWindow : Window
    {
        protected Password passwd;
        protected bool correct=true;
        public MainWindow()
        {
            InitializeComponent();
            passwd = new Password();
        }

        private void SetPassButton_Click(object sender, RoutedEventArgs e)
        {
            string temp = SetPassBox.Text;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] < 48 || temp[i] > 122) { correct = false; SetPassBox.Text = "Incorrect data! Please restart."; break; }
            }
            if (String.IsNullOrEmpty(SetPassBox.Text)){correct = false; SetPassBox.Text = "Incorrect data! Please restart."; }
            if (correct) 
            {
                passwd.SetHash(SetPassBox.Text);
                passwd.SaveHash();
            }
            
        }

        private void BfPassButton_Click(object sender, RoutedEventArgs e)
        {
            if (correct)
            {
                PasswordCracker Bf = new PasswordCracker(passwd);
                var watch = Stopwatch.StartNew();
                Bf.BruteForce(1, 1);
                watch.Stop();
                BfPassBox.Text = Bf.cracked_password;
                BfTimeBox.Text = $"{watch.ElapsedMilliseconds}";
            }
        }
    }
}

