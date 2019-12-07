<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        public TrackingIdRepetidoException(string message)
        :base(message)
        {

        }

        public TrackingIdRepetidoException(string message, Exception inner)
            : this(message + " " + inner.Message)
        {

        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        public TrackingIdRepetidoException(string message)
        :base(message)
        {

        }

        public TrackingIdRepetidoException(string message, Exception inner)
            : this(message + " " + inner.Message)
        {

        }
    }
}
>>>>>>> ee9bbf0cb6f34fe2b849ef010570f783045a7e22
