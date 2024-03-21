using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveLater.Domain.Common;

namespace SaveLater.Domain.Entities
{
    public class Category : AuditableEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
