using System;
using System.Collections.Generic;

namespace TekTutor
{
    public class RPNCalculator
    {
        private double firstNumber, secondNumber, result;
        private Stack<double> numberStack = new Stack<double>();


        private bool isMathOperator(string token)
        {
            string mathOperators = "+-*/";
            return mathOperators.Contains(token);
        }

        public double compute(string rpnMathExpression)
        {
            string[] rpnTokens = rpnMathExpression.Split(' ');

            IMathOperator mathOperation = null;

            foreach ( string token in rpnTokens )
            {
                if ( isMathOperator(token) )
                {
                    mathOperation = MathFactory.getMathObject(token);
                    extractInputs();
                    result = mathOperation.compute(firstNumber, secondNumber);
                    numberStack.Push(result);
                }
                else
                {
                    numberStack.Push(Convert.ToDouble(token));
                }
            }

            return numberStack.Pop();
        }

        private void extractInputs()
        {
            secondNumber = numberStack.Pop();
            firstNumber = numberStack.Pop();
        }
    }
}
