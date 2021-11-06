using System;
using System.Collections.Generic;

#nullable disable

namespace EasyCSharpApi.DAL
{
    public partial class ProgressItem : IEntity<int>
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? Order { get; set; }
        public int ProgresId { get; set; }
        public int? AnswerOptionId { get; set; }

        public virtual AnswerOptionEtalon AnswerOption { get; set; }
        public virtual Progress Progres { get; set; }
    }
}
