using System;
using System.Collections.Generic;
using System.Text;

namespace SpazBot.Domain
{
    public interface IAnswerStructure
    {
        List<string> Questions { get; set; }
        string Answer { get; set; }
        decimal Score { get; set; }
        int ID { get; set; }
        string Source { get; set; }
    }
}
