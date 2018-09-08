using System;
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

        [NotMapped]
        public string ImageSource
        {
            get
            {
                string mimeType = "image/jpeg";
                string base64 = Convert.ToBase64String(Image);
                return string.Format("data:{0};base64,{1}", mimeType, base64);
            }
        }
    }
}
