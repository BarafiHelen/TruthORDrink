using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthORDrink.Models
{
    [Table("Questions")]
    public class Question
    {
        [PrimaryKey,AutoIncrement]
        public int QuestionId { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public string Level{ get; set; }

        public Question() { }
         
        public Question(int id, string content, string category, string level)
        {
            QuestionId = id;
            Content = content;
            Category = category;
            Level = level;
        }
        public void DisplayQuestion()
        {
            
        }
    }
}
