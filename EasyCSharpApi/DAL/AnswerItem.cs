using System;
using System.Collections.Generic;

#nullable disable

namespace EasyCSharpApi.DAL
{
    public partial class AnswerItem : IEntity<int>
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? Order { get; set; }
        public decimal? CorrectnessPercent { get; set; }
        public int? AnswerOptionId { get; set; }
        public int AnswerId { get; set; }
        

        public virtual Answer Answer { get; set; }
        public virtual AnswerOptionEtalon AnswerOption { get; set; }
     
    }
}
