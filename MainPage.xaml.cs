using Kosci.Models;

namespace Kosci
{
    public partial class MainPage : ContentPage
    {
        Dice[] diceFaces = new[]
        {
            new Dice { ImageSource = "k1.png", Value = 10 },
            new Dice { ImageSource = "k2.png", Value = 2 },
            new Dice { ImageSource = "k3.png", Value = 3 },
            new Dice { ImageSource = "k4.png", Value = 4 },
            new Dice { ImageSource = "k5.png", Value = 5 },
            new Dice { ImageSource = "k6.png", Value = 6 }
        };

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnRollDices(object? sender, EventArgs e)
        {
            Random r = new Random();

            int dice1 = r.Next(0, 6);
            int dice2 = r.Next(0, 6);
            int dice3 = r.Next(0, 6);
            int dice4 = r.Next(0, 6);
            int dice5 = r.Next(0, 6);

            oneDice.Source = diceFaces[dice1].ImageSource;
            twoDice.Source = diceFaces[dice2].ImageSource;
            threeDice.Source = diceFaces[dice3].ImageSource;
            fourDice.Source = diceFaces[dice4].ImageSource;
            fiveDice.Source = diceFaces[dice5].ImageSource;

            int total = diceFaces[dice1].Value + diceFaces[dice2].Value
          + diceFaces[dice3].Value + diceFaces[dice4].Value + diceFaces[dice5].Value;
            resultLabel.Text = $"Wynik: {total}";

        }
    }
}
