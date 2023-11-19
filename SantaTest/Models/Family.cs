namespace SantaTest.Models
{
    public class Family
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Child> Children { get; set; } = new List<Child>();

        public int? AddressId { get; set; }

        public Address? Address { get; set; }
    }
}
