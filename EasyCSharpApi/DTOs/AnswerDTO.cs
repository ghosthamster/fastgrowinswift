using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCSharpApi.DTOs
{
    public class AnswerDTO
    {
        public int Id { get; set; }
        public DateTime? DateOfAnswer { get; set; }
        public int? TimeOfExecution { get; set; }
        public decimal? CorrectnessPercent { get; set; }
        public int UserId { get; set; }
        public int AttemtpSequence { get; set; }
        public int? TaskId { get; set; }
        public List<AnswerItemDTO> AnswerItems { get; set; }
    }
}
