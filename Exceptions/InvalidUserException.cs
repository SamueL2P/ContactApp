﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Exceptions
{
    internal class InvalidUserException:Exception
    {
        public InvalidUserException(string message):base(message)
        {
            
        }
    }
}
