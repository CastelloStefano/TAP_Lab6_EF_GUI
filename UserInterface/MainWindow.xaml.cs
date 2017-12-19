using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using BugReportFactory;
using Database;

namespace UserInterface
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BugReportContext Db;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void ButtonReset_Click1(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("|"+NewPwdField.Text+"|");
            Factory.InitializeBugTracking(null, NewPwdField.Text);
            NewPwdField.Clear();
        }

        private void ButtonConnect_Click1(object sender, RoutedEventArgs e)
        {
            Db = Factory.LoadBugTracking(null, Adminpwd.Password);
            DataBox.Document.Blocks.Clear();
            DataBox.AppendText("Connected !");
            UsrTable.Visibility = 0;
            Products.Visibility = 0;

            //var user1 = new Utente()
            //{
            //    Name = "Stefano",
            //    Surname = "Castello",
            //    Dob = new DateTime(93, 12, 12),
            //    CodFisc = "CSTSFN93D12D969U",
            //    Age = 24,
            //    LogIn = "pwd",
            //    Indirizzo = new Address() { Civico = 9, Interno = 2, Via = "viale Villa Chiesa" }
            //};
            //var user2 = new Utente()
            //{
            //    Name = "Giorgio",
            //    Surname = "Castello",
            //    Dob = new DateTime(60, 07, 20),
            //    CodFisc = "CSTGRG60L20D969A",
            //    Age = 57,
            //    LogIn = "pwwd",
            //    Indirizzo = new Address() { Civico = 9, Interno = 2, Via = "viale Villa Chiesa" }
            //};

            //db.Users.Add(user1);
            //db.Users.Add(user2);
            //db.SaveChanges();


        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            DataBox.Document.Blocks.Clear();
            var query = from u in Db.Users
                select new {u.Name, u.Surname, u.Dob, u.CodFisc, u.Indirizzo};
            foreach (var q in query)
                DataBox.AppendText(q.Name + "\t" + q.Surname + "\t" + q.CodFisc + "\t" + q.Dob + "\t" +
                                   q.Indirizzo.Via + "\t" + q.Indirizzo.Civico + "\t" + q.Indirizzo.Interno);

        }

        private void RadioButton_Checked2(object sender, RoutedEventArgs e)
        {
            DataBox.Document.Blocks.Clear();
            var query = from p in Db.Products
                select new {p.CommName, p.Id};
            foreach (var q in query)
                DataBox.AppendText(q.CommName + "\t" + q.Id);
        }
    }
}
