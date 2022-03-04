using System;
using System.Collections.Generic;
using System.Text;

namespace Market
{
    public class CentralBank : IObservable<CentralBank>
    {
        private double _inflation;
        private List<IObserver<CentralBank>> _list = new List<IObserver<CentralBank>>();

        public CentralBank(){}
        public CentralBank(double inflation)
        {
            Inflation = inflation;
        }

        public double Inflation
        {
            get { return _inflation; }
            set
            {
                _inflation = value;
                Notify();
            }
        }
        public List<IObserver<CentralBank>> List
        {
            get { return _list; }
            set
            {_list = value;}
        }
        public void Attach(IObserver<CentralBank> obs)
        {
            _list.Add(obs);
        }

        public void Detach(IObserver<CentralBank> obs)
        {
            _list.Remove(obs);
        }

        public void Notify()
        {
            foreach (IObserver<CentralBank> p in _list)
            {
                p.Update(this);
            }
        }
    }
}
