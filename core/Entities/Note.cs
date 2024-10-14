using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Entities
{
    public class Note : BaseEntity
    {
        public required string Title { get; set; }
        public required string Content { get; set; }
        public DateTime Time { get; set; }
    }
}
