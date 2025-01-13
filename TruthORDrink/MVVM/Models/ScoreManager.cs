using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthORDrink.Models;
namespace TruthORDrink.Models
{
    public class _ScoreManager
    {
        public int TotalPoints { get; private set; } = 0;

        public void CalculatePoints(Player player, int points)
        {
            player.Score += points;
            TotalPoints += points;
        }

        public int GetPlayerScore(Player player)
        {
            return player.Score;
        }

        public int GetTotalScore()
        {
            return TotalPoints;
        }
    }
}