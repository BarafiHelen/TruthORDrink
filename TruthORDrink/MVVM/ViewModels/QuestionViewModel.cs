using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthORDrink.Models;

namespace TruthORDrink.MVVM.ViewModel
{
    public class QuestionViewModel
    {
        private DatabaseRepository _repository;

        public ObservableCollection<Question> Questions { get; set; }

        public QuestionViewModel(DatabaseRepository repository, string category)
        {
            _repository = repository;
            Questions = new ObservableCollection<Question>();
            LoadQuestions(category);
        }

        private void LoadQuestions(string category= "")
        {
            var questions = _repository.GetQuestionsByCategory(category);
            Questions = new ObservableCollection<Question>(questions);
        }

        public void AddQuestion(string content, string category, string level)
        {
            var question = new Question { Content = content, Category = category, Level = level };
            _repository.SaveQuestion(question);
            LoadQuestions(category);
        }

        public void DeleteQuestion(Question question)
        {
            _repository.DeleteQuestion(question);
            LoadQuestions();
        }
    }
}
