using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCSharpApi.DTOs
{
    public class AnswerItemDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? Order { get; set; }
        public decimal? CorrectnessPercent { get; set; }
        public int? AnswerOptionId { get; set; }
        public int AnswerId { get; set; }
    }
}
