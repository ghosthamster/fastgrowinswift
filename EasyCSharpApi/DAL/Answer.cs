using System;
using System.Collections.Generic;

#nullable disable

namespace EasyCSharpApi.DAL
{
    public partial class Answer :IEntity<int>
    {
        public Answer()
        {
            AnswerItems = new HashSet<AnswerItem>();
        }

        public int Id { get; set; }
        public DateTime? DateOfAnswer { get; set; }
        public int? TimeOfExecution { get; set; }
        public decimal? CorrectnessPercent { get; set; }
        public int UserId { get; set; }
        public int AttemtpSequence { get; set; }
        public int TaskId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<AnswerItem> AnswerItems { get; set; }
        public virtual Task Task { get; set; }
    }
}
