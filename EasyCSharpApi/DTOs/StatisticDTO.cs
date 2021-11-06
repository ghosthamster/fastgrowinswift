using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCSharpApi.DTOs
{
    public class StatisticDTO
    {
        public string Title { get; set; }
        public double Mark { get; set; }
        public int AttemptSequence { get; set; }
        public DateTime? DateOfAnswer { get; set; }
        public List<StatisticItemDTO> StatisticItems { get; set; }
    }
}
