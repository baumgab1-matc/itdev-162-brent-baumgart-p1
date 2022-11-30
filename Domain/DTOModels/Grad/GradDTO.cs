using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTOModels.Grad
{
    public abstract class GradDTO
    {
         public string? UserName { get; set; }

        public virtual List<GetItemDTO> ?Items { get; set; }
    }
}