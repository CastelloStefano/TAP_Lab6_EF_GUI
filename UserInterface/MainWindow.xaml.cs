using System;
using System.Collections.Generic;
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
using BugReportFactory;
using Database;

namespace UserInterface
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }
    
        private void ButtonConnect_Click1(object sender, RoutedEventArgs e)
        {
            string pwd = Adminpwd.Password;

            Factory.InitializeBugTracking("","Password");

            using (var db = Factory.LoadBugTracking(null, pwd))
            {
                var user1 = new Utente()
                {
                    Name = "Stefano",
                    Surname = "Castello",
                    Dob = new DateTime(93, 12, 12),
                    CodFisc = "CSTSFN93D12D969U",
                    Age = 24,
                    LogIn = "pwd",
                    Indirizzo = new Address() { Civico = 9, Interno = 2, Via = "viale Villa Chiesa" }
                };
                var user2 = new Utente()
                {
                    Name = "Giorgio",
                    Surname = "Castello",
                    Dob = new DateTime(60, 07, 20),
                    CodFisc = "CSTGRG60L20D969A",
                    Age = 57,
                    LogIn = "pwwd",
                    Indirizzo = new Address() { Civico = 9, Interno = 2, Via = "viale Villa Chiesa" }
                };

                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();

                var query = from u in db.Users
                    select u.CodFisc;
                foreach (var q in query)
                {
                    //Console.WriteLine(q);
                    MessageBox.Show(q);
                }


            }
        }
    }
}
