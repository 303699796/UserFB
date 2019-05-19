using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserFB.Model
{
   public class ReplyEX:Reply
    {
        
        public Feedback Feedback { get; set; }
        public Users Users  { get; set; }
    }
}
