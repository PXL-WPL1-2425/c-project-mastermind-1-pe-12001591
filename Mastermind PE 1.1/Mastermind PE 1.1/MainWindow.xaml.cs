using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace c_project_mastermind_1_12001591
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private string color1, color2, color3, color4;
        private int attempts;
        public MainWindow()
        {
            
            InitializeComponent();

            
            Title = $"Poging {attempts}";
            StringBuilder sb = new StringBuilder();

            Random rnd = new Random();
            color1 = RandomColor(rnd);
            color2 = RandomColor(rnd);
            color3 = RandomColor(rnd);
            color4 = RandomColor(rnd);

           // Title = $"MasterMind({color1},{color2},{color3},{color4})";
        }
        private string RandomColor(Random rnd)
        {
            int randomNumber = rnd.Next(1, 7);
            switch (randomNumber)
            {
                case 1:
                    return "Blue";

                case 2:
                    return "Red";

                case 3:
                    return "White";

                case 4:
                    return "Yellow";

                case 5:
                    return "Orange";

                case 6:
                    return "Green";
                default: return "";
            }
        }
        private void NewLabelColor(Label label, string color)
        {
            switch (color)
            {
                case "Blue":
                    label.Background = new SolidColorBrush(Colors.Blue);
                    break;
                case "Red":
                    label.Background = new SolidColorBrush(Colors.Red);
                    break;
                case "White":
                    label.Background = new SolidColorBrush(Colors.White);
                    break;
                case "Yellow":
                    label.Background = new SolidColorBrush(Colors.Yellow);
                    break;
                case "Orange":
                    label.Background = new SolidColorBrush(Colors.Orange);
                    break;
                case "Green":
                    label.Background = new SolidColorBrush(Colors.Green);
                    break;
                default:
                    label.Background = new SolidColorBrush(Colors.Gray);
                    break;
            }
        }

        private void ComboBox1Color(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string newColor = (comboBox1.SelectedItem as ComboBoxItem).Content.ToString();
                NewLabelColor(colorLabel1, newColor);
            }

        }
        private void ComboBox2Color(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                string newColor = (comboBox2.SelectedItem as ComboBoxItem).Content.ToString();
                NewLabelColor(colorLabel2, newColor);
            }

        }

       

        private void ComboBox3Color(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                string newColor = (comboBox3.SelectedItem as ComboBoxItem).Content.ToString();
                NewLabelColor(colorLabel3, newColor);
            }

        }
        private void ComboBox4Color(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox4.SelectedItem != null)
            {
                string newColor = (comboBox4.SelectedItem as ComboBoxItem).Content.ToString();
                NewLabelColor(colorLabel4, newColor);
            }

        }
        DateTime startTime;
        private void Timer_Tick(object? sender, EventArgs e)
        {
            TimeSpan interval = DateTime.Now.Subtract(startTime);

            timerTextBox.Text = interval.ToString("ss\\:fff");
        }

        private void StartCountDown(object sender, RoutedEventArgs e)
        {
            
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
            startTime = DateTime.Now;
        }
        
        private void valideButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
            startTime = DateTime.Now;
            

            int attempts = +1;
            Title = $"Poging {attempts}";
            string comboBox1Color = (comboBox1.SelectedValue as ComboBoxItem)?.Content.ToString();
            string comboBox2Color = (comboBox2.SelectedValue as ComboBoxItem)?.Content.ToString();
            string comboBox3Color = (comboBox3.SelectedValue as ComboBoxItem)?.Content.ToString();
            string comboBox4Color = (comboBox4.SelectedValue as ComboBoxItem)?.Content.ToString();
            CompareCodeWithLabel(comboBox1Color, comboBox2Color, comboBox3Color, comboBox4Color);
        }
       
        private void SameColor(Label label, string ChosenColor, string correctColor, int place)
        {
            if (ChosenColor == correctColor)
            {
                label.BorderBrush = new SolidColorBrush(Colors.DarkRed);
                label.BorderThickness = new Thickness(5);
            }
            else if (ChosenColor == color1 || ChosenColor == color2 || ChosenColor == color3 || ChosenColor == color4)
            {
                label.BorderBrush = new SolidColorBrush(Colors.Wheat);
                label.BorderThickness = new Thickness(5);
            }
            else
            {
                label.BorderBrush = new SolidColorBrush(Colors.Transparent);
                label.BorderThickness = new Thickness(0);
            }


        }
        private void CompareCodeWithLabel(string input1, string input2, string input3, string input4)
        {

            SameColor(colorLabel1, input1, color1, 1);
            SameColor(colorLabel2, input2, color2, 2);
            SameColor(colorLabel3, input3, color3, 3);
            SameColor(colorLabel4, input4, color4, 4);
        }
    }
}
