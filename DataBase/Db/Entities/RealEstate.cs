using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Db.Entities
{
    public class RealEstate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RealEstateId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public int TypeId { get; set; }
        public int DeveloperId { get; set; }
        public decimal Price { get; set; }
        public float Square { get; set; }
        public int RoomsCount { get; set; }
        public int? AddressId { get; set; }

        // Навигационные свойства
        public RealEstateType Type { get; set; }
        public Developer Developer { get; set; }
        public Address? Address { get; set; }
    }
}
