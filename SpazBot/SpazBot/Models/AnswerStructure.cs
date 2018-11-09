using SpazBot.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpazBot.Models
{

    public class AnswerStructure 
    {
        public List<string> Questions { get; set; }
        public string Answer { get; set; }
        public decimal Score { get; set; }
        public int ID { get; set; }
        public string Source { get; set; }

    }
}
