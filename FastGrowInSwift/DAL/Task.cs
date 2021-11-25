using System;
using System.Collections.Generic;

#nullable disable

namespace EasyCSharpApi.DAL
{
    public partial class Task : IEntity<int>
    {
        public Task()
        {
            Answers = new HashSet<Answer>();
            AnswerOptionEtalons = new HashSet<AnswerOptionEtalon>();
            Progresses = new HashSet<Progress>();
        }

        public string Content { get; set; }
        public int Id { get; set; }
        public decimal? DificultyCoef { get; set; }
        public int TypeId { get; set; }
        public int TitleId { get; set; }

        public virtual Title Title { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Progress> Progresses { get; set; }
        public virtual ICollection<AnswerOptionEtalon> AnswerOptionEtalons { get; set; }
    }
}
