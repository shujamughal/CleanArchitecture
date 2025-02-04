using Domain.Common;

namespace Domain
{
    public class Group : BaseEntity
    {
        public string GroupName { get; set; } = string.Empty;
        public List<SubGroup>? SubGroups { get; set; }
    }
}
