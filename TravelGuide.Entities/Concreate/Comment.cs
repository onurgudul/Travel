using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Entities.Concreate
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual Note Note { get; set; }
        public virtual User Owner { get; set; }

    }
}
