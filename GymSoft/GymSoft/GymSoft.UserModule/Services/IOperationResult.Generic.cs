using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymSoft.UserModule.Services
{
    public interface IOperationResult<T> : IOperationResult
    {
        T Result { get; }
    }
}
