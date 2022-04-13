using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace MemoGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // stworzenie zegara
        private DispatcherTimer timer = new DispatcherTimer();
        private int tenthsOfSecondElapsed;
        private int matchesFound;

        public MainWindow()
        {
            InitializeComponent();
            // konfiguracja zegara
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;

            // konfiguracja gry
            SetUpGame();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            tenthsOfSecondElapsed++;
            timeTextBlock.Text = (tenthsOfSecondElapsed / 10F).ToString("0.0s");
            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
            }
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
                "🦏", "🦏",
                "🦍", "🦍"
            };

            // iteracja po każdy obiekcie typu TextBlock
            // wylosowanie dowolnego emoji z listy i przypisanie go do tymczasowej zmiennej
            // przypisanie wylosowanej wartości do właściwości obiektu
            // usunięcie elementu z listy
            Random rnd = new Random();
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                if (textBlock.Name != "timeTextBlock")
                {
                    int index = rnd.Next(animalEmoji.Count);
                    string nextEmoji = animalEmoji[index];
                    textBlock.Text = nextEmoji;
                    animalEmoji.RemoveAt(index);
                }
            }
            timer.Start();
            tenthsOfSecondElapsed = 0;
            matchesFound = 0;
        }

        private TextBlock lastTextBlockClicked;
        private bool findingMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
            {
                SetUpGame();
            }
        }
    }
}