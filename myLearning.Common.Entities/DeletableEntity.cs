using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myLearning.Common.Entities
{
    public class DeletableEntity: BaseEntity
    {
        public bool IsDeleted { get; set; }
    }
}
