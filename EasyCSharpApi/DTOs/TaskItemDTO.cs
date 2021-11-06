using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCSharpApi.DTOs
{
    public class TaskItemDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? Order { get; set; }
        public int TaskId { get; set; }
    }
}
