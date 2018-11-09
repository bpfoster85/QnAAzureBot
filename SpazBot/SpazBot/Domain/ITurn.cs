using System;
using System.Collections.Generic;
using System.Text;

namespace SpazBot.Domain
{
    public interface ITurn
    {
        string Question { get; set; }
        List<IAnswerStructure> Answers { get; set; }
    }
  
}
