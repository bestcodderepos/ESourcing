using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ordering.Domain.Entities.Base
{
    public abstract class Entity : IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; protected set; }

        public Entity Clone()
        {
            return (Entity)this.MemberwiseClone();
        }
    }
}
