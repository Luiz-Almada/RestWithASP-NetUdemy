using Microsoft.AspNetCore.Mvc;
using System;

namespace AspNetCoreDockerMysql.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        // GET api/values/sum/5/5
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (String.IsNullOrEmpty(firstNumber) || String.IsNullOrEmpty(secondNumber))
            {
                return BadRequest("Numbers Invalid");
            }
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            
            return BadRequest("Invalid Input");
        }

        // GET api/values/subtraction/5/5
        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (String.IsNullOrEmpty(firstNumber) || String.IsNullOrEmpty(secondNumber))
            {
                return BadRequest("Numbers Invalid");
            }
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var subtraction = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(subtraction.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // GET api/values/division/5/5
        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (String.IsNullOrEmpty(firstNumber) || String.IsNullOrEmpty(secondNumber))
            {
                return BadRequest("Numbers Invalid");
            }
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber) )
            {
                decimal numberSecondNumber;
                decimal.TryParse(secondNumber, out numberSecondNumber);

                if (numberSecondNumber == 0)
                {
                    return BadRequest("Invalid division by 0");
                }

                var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(division.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // GET api/values/multiplication/5/5
        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (String.IsNullOrEmpty(firstNumber) || String.IsNullOrEmpty(secondNumber))
            {
                return BadRequest("Numbers Invalid");
            }
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(multiplication.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // GET api/values/average/5/5
        [HttpGet("average/{firstNumber}/{secondNumber}")]
        public IActionResult Average(string firstNumber, string secondNumber)
        {
            if (String.IsNullOrEmpty(firstNumber) || String.IsNullOrEmpty(secondNumber))
            {
                return BadRequest("Numbers Invalid");
            }
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var average = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(average.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // GET api/values/square-root/5
        [HttpGet("square-root/{number}")]
        public IActionResult SquareRoot(string number)
        {
            if (String.IsNullOrEmpty(number))
            {
                return BadRequest("Number Invalid");
            }
            if (IsNumeric(number) )
            {
                var squareRoot = Math.Sqrt((double)ConvertToDecimal(number));
                return Ok(squareRoot.ToString());
            }

            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;
            if (decimal.TryParse(number, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }
    }
}
