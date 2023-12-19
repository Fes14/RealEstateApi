using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.RealEstateService.Dto
{
    public class AddressDto
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string? MetroStation { get; set; }
    }
}
