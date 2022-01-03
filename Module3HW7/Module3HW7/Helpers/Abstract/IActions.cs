using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HW7.Helpers.Abstract
{
    public interface IActions
    {
        public bool ErrorMethod();
        public bool InfoMethod();
        public bool WarningMethod();
    }
}
