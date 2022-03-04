using System;
using System.Collections.Generic;
using System.Text;

namespace Market
{
    public interface IObserver<T>
    {
        public void Update(T element);
    }
}
