namespace CallPlanner.Core.Entities
{
    public class Interaction
    {
        public virtual string Input { get; set; }
        public virtual CpEnumerators.InteractionType InteractionType { get; set; }
    }
}