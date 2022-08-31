using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace TestTaskWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> ages;
        private List<int> birthYears;
        private List<int> yearsExperience;

        public MainWindow()
        {
            Ages = GetSequence(18, 50);
            Ages.Add(0);
            Ages.Sort();

            BirthYears = GetSequence(1950, 2005);
            BirthYears.Add(0);
            BirthYears.Sort();

            YearsExperience = GetSequence(1, 10);
            YearsExperience.Add(-1);
            YearsExperience.Sort();

            InitializeComponent();
        }
        public List<int> Ages { get => ages; set => ages = value; }
        public List<int> BirthYears { get => birthYears; set => birthYears = value; }
        public List<int> YearsExperience { get => yearsExperience; set => yearsExperience = value; }

        private List<int> GetSequence(int start, int end)
        {
            List<int> sequence = new List<int>();
            for (int i = start; i <= end; i++)
                sequence.Add(i);

            return sequence;
        }

        private void ButtonAddData_Click(object sender, RoutedEventArgs e)
        {
            ContextMenuAddData.IsOpen = true;
        }

        private void ButtonDelData_Click(object sender, RoutedEventArgs e)
        {
            if (TreeViewData.SelectedItem == null)
                MessageBox.Show("Данные для удаления не выбраны.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
