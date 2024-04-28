using System.ComponentModel.DataAnnotations;

namespace Labb3_API.Models
{
    public class Link
    {
        [Key]
        public int LinkID { get; set; }

        public int PersonInterestID { get; set; }

        public string Url { get; set; }

        public PersonInterest PersonInterest { get; set; }
    }
}

