using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArcitexture.Domain.Common.Interfaces
{
    public interface IAuditableEntity:IEntity
    {
        int? CreateBy { get; set; } 
        DateTime? CreateDate { get; set; }
        int? UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }
    }
}
