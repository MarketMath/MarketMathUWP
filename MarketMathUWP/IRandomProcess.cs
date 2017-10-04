using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMathUWP
{
    public interface IRandomProcess
    {
        double GetValue(double deltaTime);
    }
}
