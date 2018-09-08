namespace MvcTiggy.Models
{
    public class AdventureMember
    {
        public int AdventureId { get; set; }
        public Adventure Adventure { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
