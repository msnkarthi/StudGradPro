using StudGradPro.Data;
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

namespace StudGradPro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UniversityDataManager dataManager { private set; get; }
        public List<Student> Students;

        public MainWindow()
        {
            

            InitializeComponent();

            dataManager = new UniversityDataManager();
            Students = dataManager.Students.ToList();
        }

        private void btnLoadStudents_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateGrade_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
