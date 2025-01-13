using Microsoft.Maui.Dispatching;

namespace TruthORDrink.MVVM.Views
{
    public partial class GamePage : ContentPage
    {
       public GamePage()
       {
           InitializeComponent();
           ToonVolgendeVraag();
       }

        private IDispatcherTimer timer;
        private int tijdResterend = 20;

        private readonly List<string> Vragen = new List<string>
        {
            "Wat is je grootste geheim?",
            "Wie vind je het knapst hier?",
            "Noem iets dat je nooit hardop zou zeggen.",
            "Wat was je eerste indruk van je partner?",
            "Wat is je favoriete herinnering samen?",
            "Wat is het meest romantische dat je ooit hebt gedaan?",
            "Wat is het gekste dat je ooit hebt gedaan?",
            "Heb je ooit een geheim voor iemand verborgen?",
            "Wat is je grootste angst?"
        };

        private readonly List<string> DrankOpties = new List<string>
        {
            "Drink een glas water met zout.",
            "Drink een drankje met citroen en azijn.",
            "Drink een mix van melk en cola.",
            "Eet een rare combinatie (bijv. koekjes en mosterd)."
        };

        private readonly List<string> Activiteiten = new List<string>
        {
            "Doe 10 push-ups.",
            "Dans als een kip gedurende 1 minuut.",
            "Spring 20 keer op en neer.",
            "Zing een liedje zonder te lachen."
        };

        private int VraagIndex = 0;


        private void OnTruthClicked(object sender, EventArgs e)
        {
            StartTimer();
        }

        private void OnDrinkClicked(object sender, EventArgs e)
        {
            OptiePicker.ItemsSource = DrankOpties;
            OptiePicker.IsVisible = true;
            StartTimer();
        }

        private void OnDoenClicked(object sender, EventArgs e)
        {
            OptiePicker.ItemsSource = Activiteiten;
            OptiePicker.IsVisible = true;
            StartTimer();
        }

        private void StartTimer()
        {
            tijdResterend = 20;
            TimerLabel.Text = $"Tijd: {tijdResterend} seconden";
            TimerLabel.IsVisible = true;

            timer = Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) =>
            {
                tijdResterend--;
                TimerLabel.Text = $"Tijd: {tijdResterend} seconden";

                if (tijdResterend <= 0)
                {
                    timer.Stop();
                    OptiePicker.IsVisible = false;
                    TimerLabel.Text = "Tijd om!";
                    ToonVolgendeVraag();
                }
            };
            timer.Start();
        }

        private void ToonVolgendeVraag()
        {
            
            OptiePicker.IsVisible = false;
            TimerLabel.IsVisible = false;

            if (VraagIndex < Vragen.Count)
            {
                VraagLabel.Text = Vragen[VraagIndex];
                VraagIndex++;
            }
            else
            {
                DisplayAlert("Einde", "Geen vragen meer!", "OK");
            }
        }
    }
}