using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.WorkDtos
{
    public class WorkCreateDto
    {
        [Required(ErrorMessage ="Definition Is Required")]
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
