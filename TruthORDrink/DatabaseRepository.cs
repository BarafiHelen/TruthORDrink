using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthORDrink.Models;

namespace TruthORDrink
{
    public class DatabaseRepository
    {
        private readonly SQLiteConnection _database;

        public DatabaseRepository(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Player>();
            _database.CreateTable<Question>();
            _database.CreateTable<GameSession>();
        }

        // Players
        public List<Player> GetAllPlayers() => _database.Table<Player>().ToList();
        public void SavePlayer(Player player) => _database.Insert(player);
        public void UpdatePlayer(Player player) => _database.Update(player);
        public void DeletePlayer(Player player) => _database.Delete(player);

        // Questions
        public List<Question> GetQuestionsByCategory(string category= "")
        {
            if (string.IsNullOrEmpty(category))
                return _database.Table<Question>().ToList();
            return _database.Table<Question>().Where(q => q.Category == category).ToList();
        }
        public void SaveQuestion(Question question) => _database.Insert(question);
        public void UpdateQuestion(Question question) => _database.Update(question);
        public void DeleteQuestion(Question question) => _database.Delete(question);

        // Game Sessions
        public List<GameSession> GetAllGameSessions() => _database.Table<GameSession>().ToList();
        public void SaveSession(GameSession session) => _database.Insert(session);
        public void UpdateSession(GameSession session) => _database.Update(session);
        public void DeleteSession(GameSession session) => _database.Delete(session);
    }
}
