namespace CallPlanner.Core.Entities
{
    public class Agent
    {
        public string Name { get; set; }
        public GroupTypeEnumerator.GroupType Group { get; set; }
        public int Id { get; set; }
        public int TotalEmailAssignment { get; set; }
        public int TotalCallAssignment { get; set; }
    }
}