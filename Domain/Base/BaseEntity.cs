using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreateOn { get; set; }

        public int CreatedById { get; set; }

        //2nd time
        public DateTime ModifiedOn { get; set; }
        public int ModifiedById { get; set; }

        public int Version { get; set; }

        //create & modify
        public string ModifyIP { get; set; }
        public string CreatedIP { get; set; }

        public string ModifyAgent { get; set; }
        public string CratetdAgent { get; set; }

    }
}
