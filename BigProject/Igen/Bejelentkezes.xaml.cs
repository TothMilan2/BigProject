using BigProject.Model;
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
using System.Windows.Shapes;

namespace BigProject.Igen
{
    /// <summary>
    /// Interaction logic for Bejelentkezes.xaml
    /// </summary>
    public partial class Bejelentkezes : Window
    {
        public Bejelentkezes()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userName = felhasznaloTxt.Text;
            string password = jelszoTxt.Password;


            if (!string.IsNullOrEmpty(felhasznaloTxt.Text) || !string.IsNullOrEmpty(jelszoTxt.Password))
            {
                using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
                {
                    var user = connection.Table<Felhasznalo>().FirstOrDefault(u => u.FelhasznaloNev == userName);

                    if (user != null)
                    {
                        if (user.Jelszo == password)
                        {
                            M mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("Nono");
                        }
                    }
                    else
                    {
                        MessageBox.Show("still nono");
                    }

                }
            }
        }
    }
}
