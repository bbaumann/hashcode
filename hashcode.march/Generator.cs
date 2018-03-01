using System;
using System.Collections.Generic;
using System.Text;

namespace hashcode.march
{
    interface IGenerator
    {
        bool CalcOrders();
    }

    class Generator : IGenerator
    {
        public bool CalcOrders()
        {
            return true;
        }
    }
}
