using System.ComponentModel.DataAnnotations;

namespace Labb3_API.Models
{
    public class Interest
    {
        [Key]
        public int InterestID { get; set; }

        public string InterestName { get; set; }

        public string InterestDescription { get; set; }

        public ICollection<PersonInterest> PersonInterest { get; set; }
    }
}
