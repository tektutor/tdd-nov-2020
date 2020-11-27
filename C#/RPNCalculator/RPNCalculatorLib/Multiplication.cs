using System;
using System.Collections.Generic;
using System.Text;

namespace TekTutor
{
    public class Multiplication : IMathOperator
    {
        public double compute(double firstInput, double secondInput)
        {
            return firstInput * secondInput;
        }
    }
}
