using ProjectEuler.Challenges;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace ProjectEuler
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        Stopwatch _timer;

        public Home()
        {
            InitializeComponent();
            PopulateComboItems();
        }

        void PopulateComboItems()
        {
            int[] challenges = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            ChallengeSelector.ItemsSource = challenges;
        }

        void SolveChallenge_Click(object sender, RoutedEventArgs e)
        {
            _timer = Stopwatch.StartNew();
            int selected = ChallengeSelector.SelectedIndex + 1;

            if (selected > 0 && selected <= 10)
                Solution.Text = OneToTen.Solution(selected).ToString();
            if (selected > 10 && selected <= 20)
                Solution.Text = ElevenToTwenty.Solution(selected).ToString();
            _timer.Stop();
            SpeedTimer.Content = string.Format("Time Taken: {0}ms", _timer.ElapsedMilliseconds);
            SpeedTimer.Visibility = Visibility.Visible;
        }
    }
}
