using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.RealEstateService.Dto
{
    public class RealEstateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Developer { get; set; }
        public string? Type { get; set; }
        public decimal Price { get; set; }
        public float Square { get; set; }
        public int RoomsCount { get; set; }
        public AddressDto? Address { get; set; }

    }
}
