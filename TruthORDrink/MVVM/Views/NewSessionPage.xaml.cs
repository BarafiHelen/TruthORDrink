using TruthORDrink.Models;
using TruthORDrink.MVVM.ViewModel;

namespace TruthORDrink.MVVM.Views;

public partial class NewSessionPage : ContentPage
{
    private DatabaseRepository Repository { get; }
    public NewSessionPage(DatabaseRepository repository)
    {
        InitializeComponent();
        Repository = repository;
    }

    private void OnManagePlayersClicked(object sender, EventArgs e)
    {
        // Navigeren naar PlayerPage voor spelersbeheer
        var playerViewModel = new PlayerViewModel(Repository);
        Navigation.PushAsync(new PlayerPage(playerViewModel));
    }

    private void OnManageQuestionsClicked(object sender, EventArgs e)
    {
        // Haal de repository op vanuit de Dependency Injection-service
        var questionViewModel = new QuestionViewModel(Repository, "");
        Navigation.PushAsync(new QuestionPage(questionViewModel));
    }

    private void OnStartGameClicked(object sender, EventArgs e)
    {
        // Haal sessiedetails op uit invoervelden
        string sessieNaam = SessieNaam.Text;
        string categorie = (string)CategoriePicker.SelectedItem;
        int niveau = (int)NiveauSlider.Value;

        // Controleer of de vereiste invoer is ingevuld
        if (string.IsNullOrEmpty(sessieNaam) || string.IsNullOrEmpty(categorie))
        {
            DisplayAlert("Fout", "Vul alle velden in om verder te gaan.", "OK");
            return;
        }

        // Maak een nieuwe sessie aan
        var gameSession = new GameSession(sessieNaam, 10, categorie) // Max spelers: 10 als voorbeeld
        {
            Level = categorie
        };

        // Ga naar de GamePage en geef de sessie door
        Navigation.PushAsync(new GamePage());
    }
}