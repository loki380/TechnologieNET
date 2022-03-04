using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Interface
{
    public interface IVisitor
    {
        void Visit(ProductPrice element);
    }
}
