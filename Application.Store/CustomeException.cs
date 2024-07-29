using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class CustomeException : Exception
    {
        public string _msg { get; set; }
        public CustomeException(string msg):base(msg)
        {
            _msg = msg; 
        }
    }
}
