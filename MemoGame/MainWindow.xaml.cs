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

namespace MemoGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();

        }

        private void SetUpGame()
        {
            // deklaracja listy i inicjalizacja jej elementów
            List<string> animalEmoji = new List<string>()
            {
                "🦓", "🦓",
                "🦁", "🦁",
                "🐼", "🐼",
                "🐻", "🐻",
                "🦒", "🦒",
                "🐺", "🐺",
                "🐼", "🐼",
                "🦍", "🦍"
            };

            // iteracja po każdy obiekcie typu TextBlock
            // wylosowanie dowolnego emoji z listy i przypisanie go do tymczasowej zmiennej
            // przypisanie wylosowanej wartości do właściwości obiektu
            // usunięcie elementu z listy
            Random rnd = new Random();
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                int index = rnd.Next(animalEmoji.Count);
                string nextEmoji = animalEmoji[index];
                textBlock.Text = nextEmoji;
                animalEmoji.RemoveAt(index);

            }
        }
    }
}
