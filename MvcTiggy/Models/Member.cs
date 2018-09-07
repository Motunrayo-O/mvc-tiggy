using System.ComponentModel.DataAnnotations.Schema;

namespace MvcTiggy.Models
{
    public class Member
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //[TalkPoint] - ignoring properties
        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }

        }

        public string About { get; set; }
        public byte[] Image { get; set; }
    }
}
