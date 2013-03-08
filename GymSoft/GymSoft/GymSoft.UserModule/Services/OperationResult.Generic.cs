using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymSoft.UserModule.Services
{
    public class OperationResult<T> : OperationResult, IOperationResult<T>
    {
        public T Result
        {
            get;
            protected internal set;
        }
    }
}
