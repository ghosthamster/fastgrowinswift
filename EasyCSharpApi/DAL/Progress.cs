using System;
using System.Collections.Generic;

#nullable disable

namespace EasyCSharpApi.DAL
{
    public partial class Progress : IEntity<int>
    {
        public Progress()
        {
            ProgresItems = new HashSet<ProgressItem>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? SavingDate { get; set; }
        public int? TimeOfExecution { get; set; }
        public int TaskId { get; set; }

        public virtual User User { get; set; }
        public virtual Task Task { get; set; }
        public virtual ICollection<ProgressItem> ProgresItems { get; set; }
    }
}
