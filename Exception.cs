using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class NegativeElement : Exception
    {
        public NegativeElement() : base() { }
        public NegativeElement(string Message) : base(Message)
        {

        }
    }
}
