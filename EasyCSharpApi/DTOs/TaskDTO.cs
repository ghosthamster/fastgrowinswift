using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCSharpApi.DTOs
{
    public class TaskDTO
    {
        public string Content { get; set; }
        public int Id { get; set; }
        public decimal? DificultyCoef { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public int TitleId { get; set; }
        public string TitleName { get; set; }

        public virtual List<TaskItemDTO> TaskItems { get; set; }
    }
}
