using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace nothinbutdotnetstore
{
    public interface ICalculate
    {
        int add(int first, int second);
    }
    
    public class Calculator : ICalculate
    {
        public int add(int first, int second)
        {
           
            ensure_all_are_positive(first, second);
            if (first <=0 || second <=0 )
            {
                throw new ArgumentException();
            }
            return first + second;
        }

        void ensure_all_are_positive(params int[] numbers)
        {
            if(numbers.All(x => x < 0))
            {
                throw new ArgumentException();
            }
            
          
        }
    }
}