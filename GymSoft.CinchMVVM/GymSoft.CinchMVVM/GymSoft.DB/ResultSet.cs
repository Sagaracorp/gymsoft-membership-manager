using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymSoft.DB
{
    /// <summary>
    /// All database quires and procedures will return a class of this type
    /// This keeps track of weather the txn was successful or not
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultSet<T>
    {
        private readonly T data;
        private readonly Exception exception;

        public T Data { get { return data; }  }
        public Exception Exception { get { return exception; } }

        public ResultSet(T data, Exception exception)
        {
            this.data = data;
            this.exception = exception;
        }
    }
}
