using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class BaseEntity
    {
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; } = 0;
        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; } = 0;
    }
}
