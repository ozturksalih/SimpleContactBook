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
using FinalProjectSalihOzturk.DataAccess;
using FinalProjectSalihOzturk.Entities;

namespace FinalProjectSalihOzturk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IPersonDal _personDal;
        public MainWindow()
        {
            this._personDal = new PersonDal();
            InitializeComponent();
            setPersons();
        }

        private void setPersons()
        {
            foreach (var person in _personDal.GetAllPersons())
            {
                lstPersons.Items.Add(person.Name +" " + person.Surname +" " + person.Email);
            }
        }
        private void ButtonAddName_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !lstPersons.Items.Contains(txtName.Text))
            {
                Person personToAdd = new Person{Name = txtName.Text};
                _personDal.Add(personToAdd);
                lstPersons.Items.Clear();
                setPersons();
                txtName.Clear();
            }
        }

        private void lstPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedPerson =lstPersons.SelectedItem.ToString();
            string aga = " ";
            string[] person = selectedPerson.Split(aga.ToCharArray());
            foreach (var i in person)
            {
                Console.WriteLine(i);
            }


            txtName.Text = person[0];
            txtLastName.Text = person[1];
            txtEmail.Text = person[2];
            
        }
    }
}
