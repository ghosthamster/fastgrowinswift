using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCSharpApi.DTOs
{
    public class ProgressDTO
    {
        public int Id { get; set; }
        public DateTime? SavingDate { get; set; }
        public int? TimeOfExecution { get; set; }
        public int UserId { get; set; }
        public int TaskId { get; set; }

        public List<ProgressItemDTO> ProgressItems { get; set; }
    }
}
