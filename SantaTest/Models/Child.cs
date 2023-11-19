using HotChocolate;

namespace SantaTest.Models
{
    public class Child
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public List<Gift> Gifts { get; set; }

        public int FamilyId { get; set; }

        public Family Family { get; set; }
    }
}
