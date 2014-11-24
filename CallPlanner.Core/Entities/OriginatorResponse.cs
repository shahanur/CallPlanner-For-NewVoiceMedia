namespace CallPlanner.Core.Entities
{
    public class OriginatorResponse
    {
        public virtual int ResponseNumber { get; set; }
        public virtual ResponseTypeEnumerator.ResponseType ResponseType { get; set; }
        public virtual CpEnumerators.InteractionType InteractionType { get; set; }
        public virtual string ResponseMessage { get; set; }
    }
}