using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Interface
{
    public interface IElement
    {
        void Accept(IVisitor aVisitor);
    }
}
