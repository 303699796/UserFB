using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserFB.Model
{
    public class feedbackEX:Feedback
    {
        public Users Users { get; set; }
        public Category Category { get; set; }

    }
}
