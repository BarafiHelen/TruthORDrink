
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthORDrink.Models
{
    [Table("Players")]
    public class Player
    {
        [PrimaryKey, AutoIncrement]
        public int PlayerId { get; set; }
        [MaxLength(100)]
        public string PlayerName { get; set; }
        public int Score { get; set; }
     

        public Player() { }

        public Player(string playerName)
        {
            PlayerName = playerName;
            Score = 0;
        }

        public void AnswerQuestion(bool isTruth)
        {
            if (isTruth)
            {
                Score += 10;
            }
        }
    }
}
