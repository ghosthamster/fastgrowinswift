using System;
using System.Collections.Generic;

#nullable disable

namespace EasyCSharpApi.DAL
{
    public partial class Title : IEntity<int>
    { 
        public Title()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string TitleName { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
