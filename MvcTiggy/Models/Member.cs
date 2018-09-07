using System.Collections.Generic;
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

        public  ICollection<AdventureMember> AdventureMembers { get; set; }
        public string About { get; set; }
        public byte[] Image { get; set; }
    }

    public class AdventureMember
    {
        public int AdventureId { get; set; }
        public Adventure Adventure { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
