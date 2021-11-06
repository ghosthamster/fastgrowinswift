using System;
using System.Collections.Generic;

#nullable disable

namespace EasyCSharpApi.DAL
{
    public partial class Type : IEntity<int>
    {
        public Type()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
