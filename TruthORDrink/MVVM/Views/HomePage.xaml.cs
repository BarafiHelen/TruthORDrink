namespace TruthORDrink.MVVM.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private void OnStartNewSessie_Clicked(object sender, EventArgs e)
    {
        // Haal de DatabaseRepository op uit Dependency Injection
        var repository = App.Services.GetService<DatabaseRepository>();

        // Controleer of de repository niet null is
        if (repository == null)
        {
            DisplayAlert("Fout", "Database niet beschikbaar.", "OK");
            return;
        }

        // Navigeer naar NewSessionPage met de repository
        Navigation.PushAsync(new NewSessionPage(repository));
    }

    private void OnShareQrCode_Clicked(object sender, EventArgs e)
    {

    }
}
