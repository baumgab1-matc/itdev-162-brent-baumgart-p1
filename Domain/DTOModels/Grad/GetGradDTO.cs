using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTOModels.Grad;

namespace Domain.DTOModels
{
    public class GetGradDTO : GradDTO
    {
        public int Id { get; set; }
    }
}