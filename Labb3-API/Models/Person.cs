using System.ComponentModel.DataAnnotations;

namespace Labb3_API.Models
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }


        public ICollection<PersonInterest> PersonInterest { get; set; }
    }
}
