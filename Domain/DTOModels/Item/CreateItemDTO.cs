using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTOModels.Item
{
    public class CreateItemDTO : ItemDTO
    {
        [Required]
         public int GradId { get; set; }
        
    }
}