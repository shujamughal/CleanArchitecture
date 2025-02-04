using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SubGroup : BaseEntity
    {
        public string SubGroupName { get; set; } = string.Empty;
        //Foreign key
        public int GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
