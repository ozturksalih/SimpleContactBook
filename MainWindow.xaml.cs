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
    ///
    ///
    /// will be added
    /// DON'T FORGET ABOUT IT
    /// <DataGridTemplateColumn Header="LastName">
    //<DataGridTemplateColumn.CellTemplate>
    //    <DataTemplate>
    //    <DatePicker SelectedDate = "{Binding LastName}" BorderThickness="0" />
    //    </DataTemplate>
    //    </DataGridTemplateColumn.CellTemplate>
    //    </DataGridTemplateColumn>
    public partial class MainWindow : Window
    {
        private IPersonDal _personDal;
        private List<Person> persons;
        public MainWindow()
        {
            InitializeComponent();
            this._personDal = new PersonDal();
            persons = _personDal.GetAllPersons();
            dgPersons.ItemsSource = persons;
        }

        private void RefreshPersons()
        {
            persons =_personDal.GetAllPersons();
        }
        private void ButtonAddName_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !dgPersons.Items.Contains(txtName.Text))
            {
                Person personToAdd = new Person { Name = txtName.Text , Surname = txtLastName.Text ,Email = txtEmail.Text, TelephoneNumber = txtTelNumber.Text};
                _personDal.Add(personToAdd);
                RefreshPersons();
                txtName.Clear();
                dgPersons.ItemsSource = null;
                dgPersons.ItemsSource = persons;

            }

        }

        private void lstPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string selectedPerson =lstPersons.SelectedItem.ToString();
            //string aga = " ";
            //string[] person = selectedPerson.Split(aga.ToCharArray());
            //foreach (var i in person)
            //{
            //    Console.WriteLine(i);
            //}


            //txtName.Text = person[0];
            //txtLastName.Text = person[1];
            //txtEmail.Text = person[2];
            
        }

        private void dgPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Person selectedPerson = (Person) dgPersons.SelectedItem;
            txtName.Text = selectedPerson.Name;
            txtLastName.Text = selectedPerson.Surname;
            txtEmail.Text = selectedPerson.Email;
            txtTelNumber.Text = selectedPerson.TelephoneNumber;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            var personToDelete =  persons.Find(p=>p.Email == email);
            persons.Remove(personToDelete);
            RefreshPersons();
            dgPersons.ItemsSource = null;
            dgPersons.ItemsSource = persons;
        }
    }
}
