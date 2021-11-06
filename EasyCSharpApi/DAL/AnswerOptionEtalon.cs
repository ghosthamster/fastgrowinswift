using System;
using System.Collections.Generic;

#nullable disable

namespace EasyCSharpApi.DAL
{
    public partial class AnswerOptionEtalon : IEntity<int>
    {
        public AnswerOptionEtalon()
        {
            AnswerItems = new HashSet<AnswerItem>();
            ProgresItems = new HashSet<ProgressItem>();
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public int? Order { get; set; }
        public int TaskId { get; set; }

        public virtual Task Task { get; set; }
        public virtual ICollection<AnswerItem> AnswerItems { get; set; }
        public virtual ICollection<ProgressItem> ProgresItems { get; set; }
    }
}
