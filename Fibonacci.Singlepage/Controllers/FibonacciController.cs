using System.Web.Mvc;
using System.Linq;
using Fibonacci.Singlepage.Models;

namespace Fibonacci.Singlepage.Controllers
{
    public class FibonacciController : Controller
    {
        private NumberRepository _numberRepository;

        public FibonacciController()
        {
            //didn't take the time to add an IOC framework, POC
            _numberRepository = NumberRepository.Instance;
        }
        
        public JsonResult Calculate(int number)
        {
            var calculation = new FibonacciCalculation
            {
                Number = number,
                FibonacciNumber = CalculateFibonacci(number),
                IpAddress = Request.ServerVariables["REMOTE_ADDR"]
            };

            _numberRepository.Add(calculation);

            return Json(calculation, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCalculations()
        {
            var reversed = _numberRepository.GetAll().ToList();
            reversed.Reverse();

            return Json(reversed.Take(10).ToList(), JsonRequestBehavior.AllowGet);
        }

        private int CalculateFibonacci(int n)
        {
            int firstnumber = 0, secondnumber = 1, result = 0;

            if (n == 0) return 0; //first Fibonacci number   
            if (n == 1) return 1; //Fibonacci number   
            
            for (int i = 2; i <= n; i++)
            {
                result = firstnumber + secondnumber;
                firstnumber = secondnumber;
                secondnumber = result;
            }

            return result;
        }
    }


}
