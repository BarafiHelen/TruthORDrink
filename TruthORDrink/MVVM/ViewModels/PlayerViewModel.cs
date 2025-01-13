using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using TruthORDrink.Models;
using System.Windows.Input;

namespace TruthORDrink.MVVM.ViewModel
{
    public class PlayerViewModel
    {
        private DatabaseRepository _repository;


        public ObservableCollection<Player> Players { get; set; }

        public ICommand OnEditPlayerCommand { get; }
        public ICommand OnDeletePlayerCommand { get; }

        public PlayerViewModel(DatabaseRepository repository)
        {
            _repository = repository;
            Players = new ObservableCollection<Player>();
            LoadPlayers();

            // Commandos definiëren
            OnEditPlayerCommand = new Command<Player>(EditPlayer);
            OnDeletePlayerCommand = new Command<Player>(DeletePlayer);
        }


        private void LoadPlayers()
        {
            var players = _repository.GetAllPlayers();
            Players = new ObservableCollection<Player>(players);
        }

        public void AddPlayer(string name)
        {
            Player player = new Player { PlayerName = name, Score = 0 };
            _repository.SavePlayer(player);
            LoadPlayers();
        }
        private async void EditPlayer(Player player)
        {
            if (player != null)
            {
                // Vraag de nieuwe naam van de speler
                string nieuweNaam = await App.Current.MainPage.DisplayPromptAsync(
                    "Bewerk Speler",
                    "Voer de nieuwe naam in:",
                    initialValue: player.PlayerName
                );

                if (!string.IsNullOrWhiteSpace(nieuweNaam))
                {
                    player.PlayerName = nieuweNaam;
                    _repository.UpdatePlayer(player);
                    LoadPlayers();
                }
            }
        }

        private async void DeletePlayer(Player player)
        {
            if (player != null)
            {
                // Bevestiging vragen voordat je verwijdert
                bool bevestiging = await App.Current.MainPage.DisplayAlert(
                    "Bevestiging",
                    $"Weet je zeker dat je {player.PlayerName} wilt verwijderen?",
                    "Ja",
                    "Nee"
                );

                if (bevestiging)
                {
                    _repository.DeletePlayer(player);
                    LoadPlayers();
                }
            }
        }
    }
}
