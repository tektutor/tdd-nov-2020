using System;
using System.Collections.Generic;
using System.Text;

namespace TekTutor
{
    public class MathFactory
    {

        public static IMathOperator getMathObject( string mathOperation )
        {
            IMathOperator mathOperator = null;

            if (mathOperation.Equals("+"))
                mathOperator = new Addition();
            else if (mathOperation.Equals("-"))
                mathOperator = new Subtraction();
            else if (mathOperation.Equals("*"))
                mathOperator = new Multiplication();
            else if (mathOperation.Equals("/"))
                mathOperator = new Division();

            return mathOperator;
        }

    }
}
