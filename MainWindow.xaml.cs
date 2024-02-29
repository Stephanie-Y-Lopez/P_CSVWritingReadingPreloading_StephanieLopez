using System.Globalization;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CsvHelper;

namespace P_CSVWritingReadingPreloading_StephanieLopez
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Creature> creatures = new List<Creature>();
        public MainWindow()
        {
            InitializeComponent();
            //PreLoad();
            PreloadData("creatures.csv");

            LV_Display.ItemsSource = creatures;
        }

        //Creating a preload method!
        public void PreloadData(string filePath)
        {
            {
                creatures.Add(new Creature("Centaur", "Fire", "Flame arrows"));
                creatures.Add(new Creature("Goblin", "Earth", "Dirt"));
                creatures.Add(new Creature("Fairy", "Water", "Water Manipulation"));
                creatures.Add(new Creature("Vampire", "Unknown..", "Blood Manipulation"));
                SaveData<Creature>(creatures, filePath);
            };
        }

        //Creating a save method!
        public void SaveData<T>(List<T> creatures, string filePath)
        {
            CultureInfo ci = CultureInfo.InvariantCulture;

            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(creatures);
            }
        }

        //Creating a load method!
        public List<T> LoadCSV<T>(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            using (CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<T>().ToList();
            }
        }

        //Buttons
        private void B_AddCreature_Click(object sender, RoutedEventArgs e)
        {
            // Add a new creature to the list
            string type = TB_Creature.Text;
            string element = TB_Element.Text;
            string weapon=  TB_Weapon.Text;

            creatures.Add(new Creature(type, element, weapon));

            LV_Display.Items.Refresh();
        }

        //public void PreLoad()
        //{
        //    creatures.Add(new Creature("Dragon", "Fire", "Fiery Breath"));
        //    creatures.Add(new Creature("Goblin", "Earth", "Dirt"));
        //    creatures.Add(new Creature("Phoenix", "Fire", "Fire Balls"));
        //    creatures.Add(new Creature("Fairy", "Air", "Wind arrows"));
        //    creatures.Add(new Creature("Centaur", "Fire", "Flame arrows"));
        //}

        private void B_Preload_Click(object sender, RoutedEventArgs e)
        {
            // Preload some sample creatures
            creatures.Clear();
            PreloadData ("creatures.csv");
            LV_Display.Items.Refresh();
            MessageBox.Show("Sample creatures preloaded successfully.");
        }

        private void B_Save_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("creatures.csv"))
            using (CsvWriter csv = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(creatures);
            }
            MessageBox.Show("Creatures saved to CSV successfully.");
        }

        private void B_Load_Click(object sender, RoutedEventArgs e)
        {
            // Load creatures from the CSV file
            try
            {
                creatures = LoadCSV<Creature>("creatures.csv");
                LV_Display.ItemsSource = creatures;
                LV_Display.Items.Refresh();
                MessageBox.Show("Creatures loaded from CSV successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading creatures from CSV: " + ex.Message);
            }
        }
    }
}