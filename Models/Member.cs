
namespace wt_lab4_4mvc_talashkevich.Models
{
    public class Member
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public string MembershipType { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
