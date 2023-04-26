using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArcitexture.Domain.Common
{
    public abstract class BaseEvent:INotification
    {
        public DateTime DateOccurred { get; set; } = DateTime.UtcNow;
    }
}
