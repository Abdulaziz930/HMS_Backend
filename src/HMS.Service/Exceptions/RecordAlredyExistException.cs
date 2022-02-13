using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Service.Exceptions
{
    public class RecordAlredyExistException : Exception
    {
        public RecordAlredyExistException(string message) : base(message)
        {
        }
    }
}
