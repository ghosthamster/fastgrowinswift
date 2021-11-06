using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCSharpApi.DTOs
{
    public class StatisticItemDTO
    {
        public string TaskTitle { get; set; }
        public double DificultyCoef { get; set; }
        public double Mark { get; set; }
        public double MarkInfluence { get; set; }
        public int? TimeOfExecution { get; set; }
    }
}
