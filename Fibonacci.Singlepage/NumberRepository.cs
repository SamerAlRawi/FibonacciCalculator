using System.Collections.Generic;
using Fibonacci.Singlepage.Models;

namespace Fibonacci.Singlepage
{
    //no database backend, simple singleton class, 
    public class NumberRepository
    {
        private static NumberRepository instance;

        private NumberRepository() { }

        public static NumberRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NumberRepository();
                }
                return instance;
            }
        }

        static List<FibonacciCalculation> _resultCalculations = new List<FibonacciCalculation>();

        public List<FibonacciCalculation> GetAll()
        {
            return _resultCalculations;
        }

        public void Add(FibonacciCalculation calculation)
        {
            _resultCalculations.Add(calculation);
        }
    }
}