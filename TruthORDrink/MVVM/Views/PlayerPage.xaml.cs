using TruthORDrink.MVVM.ViewModel;

namespace TruthORDrink.MVVM.Views
{
    public partial class PlayerPage : ContentPage
    {
        private readonly PlayerViewModel _viewModel;

        public PlayerPage(PlayerViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        private void OnAddPlayerClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PlayerNameEntry.Text))
            {
                _viewModel.AddPlayer(PlayerNameEntry.Text);
                PlayerNameEntry.Text = string.Empty;
            }
        }
       

        private async void OnBackClicked(object sender, EventArgs e)
        {
            // Ga terug naar de vorige pagina
            await Navigation.PopAsync();
        }
    }
}