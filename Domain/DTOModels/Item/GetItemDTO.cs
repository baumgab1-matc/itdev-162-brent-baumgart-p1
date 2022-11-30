using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTOModels.Item;

namespace Domain.DTOModels
{
    public class GetItemDTO : ItemDTO
    {
        public int Id { get; set; }

        public int GradId { get; set; }

    }
}