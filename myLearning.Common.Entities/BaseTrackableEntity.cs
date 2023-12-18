namespace myLearning.Common.Entities
{
    public class BaseTrackableEntity : BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public int CreatedByUserId { get; set; }
        public int UpdatedByUserId { get; set; }
    }
}
