using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Db.Entities
{
    public class RealEstateType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RealEstateTypeId { get; set; }
        public string? Name { get; set; }

        public ICollection<RealEstate> RealEstates { get; set; }
    }
}
