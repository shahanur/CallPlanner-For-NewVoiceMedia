namespace CallPlanner.Core.Entities
{
    public class Originator
    {
        public virtual string Name { get; set; }
        public virtual string Id { get; set; }
        public virtual string Email { get; set; }
        public virtual string PhoneNumber { get; set; }
    }
}