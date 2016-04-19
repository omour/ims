using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImsForPresentation.Models
{
    public class House : IdentityUsed
    {
        public int Id { get; set; }
        public int HouseTypeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string WebSiteUrl { get; set; }

        [ForeignKey("HouseTypeId")]
        public HouseType HouseType { get; set; }

    }
}