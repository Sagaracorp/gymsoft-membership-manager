using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymSoft.UserModule.Services
{
    public class OperationResult : IOperationResult
    {
        public Exception Error
        {
            get;
            protected internal set;
        }
    }
}
