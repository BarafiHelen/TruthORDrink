using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthORDrink.Models;
using TruthORDrink;

namespace TruthORDrink.MVVM.ViewModel
{
    public class GameViewModel
    {
        private readonly DatabaseRepository _repository;

        public ObservableCollection<Player> Players { get; set; }
        public ObservableCollection<Question> Questions { get; set; }

        public GameViewModel(DatabaseRepository repository)
        {
            _repository = repository;
            LoadPlayers();
            LoadQuestions();
        }

        private void LoadPlayers()
        {
            var players = _repository.GetAllPlayers();
            Players = new ObservableCollection<Player>(players);
        }

        private void LoadQuestions()
        {
            var questions = _repository.GetQuestionsByCategory();
            Questions = new ObservableCollection<Question>(questions);
        }
    }
}
