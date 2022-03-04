using System;
using System.Collections.Generic;
using System.Text;

namespace Market
{
    public interface IObservable<T>
    {
        public void Attach(IObserver<T> obs);
        public void Detach(IObserver<T> obs);
        public void Notify();
    }
}
