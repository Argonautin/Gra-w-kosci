using Kosci.Models;

namespace Kosci
{
    public partial class MainPage : ContentPage
    {
        int total;

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

            int[] rolls = { dice1, dice2, dice3, dice4, dice5 };

            oneDice.Source = diceFaces[dice1].ImageSource;
            twoDice.Source = diceFaces[dice2].ImageSource;
            threeDice.Source = diceFaces[dice3].ImageSource;
            fourDice.Source = diceFaces[dice4].ImageSource;
            fiveDice.Source = diceFaces[dice5].ImageSource;

            int onesCount = rolls.Count(x => x == 0);
            int fivesCount = rolls.Count(x => x == 4);

            if (onesCount >= 3)
            {
                total += onesCount switch
                {
                    3 => 100,
                    4 => 200,
                    _ => 1000
                };
            }
            else
            {
                total += onesCount * 10;

                if (fivesCount == 1)
                {
                    total += 5;
                }
                else if (fivesCount == 2)
                {
                    total += 10;
                }

                foreach (var face in diceFaces.Skip(1)) 
                {
                    int count = rolls.Count(idx => idx != 0 && diceFaces[idx] == face);
                    if (count == 3)
                    {
                        total += face.Value * 10;
                    }
                    else if (count == 4)
                    {
                        total += face.Value * 20;
                    }
                    else if (count == 5)
                    {
                        total += 1000;
                    }
                }
            }

            resultLabel.Text = $"Wynik: {total}";

        }
    }
}
