using System.ComponentModel.DataAnnotations.Schema;

namespace ImsForPresentation.Models
{
    public class Producer : IdentityUsed
    {
        public int Id { get; set; }
        public int DifferentProducerId { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Contact { get; set; }

        [ForeignKey("DifferentProducerId")]
        public DifferentProducer DifferentProducer { get; set; }
    }
}