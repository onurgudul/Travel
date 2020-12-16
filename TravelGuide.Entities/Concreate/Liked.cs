using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Entities.Concreate
{
    public class Liked
    {
        public int Id { get; set; }
        public virtual Note Note { get; set; }
        public virtual User LikedUser { get; set; }
    }
}
