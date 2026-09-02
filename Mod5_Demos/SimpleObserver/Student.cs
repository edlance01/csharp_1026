using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleObserver
{
    internal class Student : IObserver<string>
    {
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            throw new NotImplementedException();
        }
    }
}
