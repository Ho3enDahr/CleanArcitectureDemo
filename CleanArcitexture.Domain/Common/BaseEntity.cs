using CleanArcitexture.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArcitexture.Domain.Common
{
    public class BaseEntity:IEntity
    {
        public readonly List<BaseEvent> _domainEvents = new();
        public int Id { get; set; }
        [NotMapped]
        public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();
        public void AddDomainEvent(BaseEvent domainEvent) => _domainEvents.Add(domainEvent);
        public void RemoveDomainEvent(BaseEvent domainevent) => _domainEvents.Remove(domainevent);
        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}
