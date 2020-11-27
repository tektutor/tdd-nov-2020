using System;
using System.Collections.Generic;
using System.Text;

namespace TekTutor
{
    public class Division : IMathOperator
    {
        public double compute(double firstInput, double secondInput)
        {
            return firstInput / secondInput;
        }
    }
}
