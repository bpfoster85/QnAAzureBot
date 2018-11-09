using SpazBot.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpazBot.Models
{
    public class Turn
    {
        public string Question { get; set; }
        public List<AnswerStructure> Answers { get; set; }

        public Turn(string question)
        {
            this.Question = question;
        }

    }

}
