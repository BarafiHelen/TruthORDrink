using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthORDrink.Models
{
    [Table("GameSession")]
    public class GameSession
    {
        [PrimaryKey, AutoIncrement]
        public int SessionId { get; set; }
        public string HostName { get; set; }
        public DateTime StartTime { get; set; }
        public int MaxPlayers { get; set; }
        public string Level { get; set; }
     
        [Ignore]// Geen directe opslag in de database
        public List<Player> Players { get; set; } = new List<Player>();
        [Ignore]
        public List<Question> Questions { get; set; } = new List<Question>();

      
        public GameSession() { }

        public GameSession(string name, int maxPlayers, string level)
        {
            HostName = name;
            StartTime = DateTime.Now;
            MaxPlayers = maxPlayers;
            Level = level;
        }

        public void AddPlayer(Player player)
        {
            if (Players.Count < MaxPlayers)
            {
                Players.Add(player);
            }
        }
      
        public void StartSession()
        {
            StartTime = DateTime.Now;
        }
    }
}
