using System.Text.RegularExpressions;

namespace task
{
    class Task
    {
        const String expression = @"[\+\-\*\/]";
        const String numberExpression = @"\D";
        const String delemiterExpression = @"[^\+\-\*\/]";

        static void Main()
        {
            String input = "gdfgdf234dg54gf*23oP42";

            List<int> elements = Regex.Split(input, expression)
                .Select(el => Int32.Parse(Regex.Replace(el, numberExpression, ""))).ToList();
            
            String delemiter = Regex.Replace(input, delemiterExpression, "");
            
            if (elements.Count == 2)
            {
                Console.WriteLine(getValue(elements, delemiter));
            }
            else
            {
                Console.WriteLine("Не верный формат ввода");
            }
        }

        private static float getValue(List<int> digits, String delemiter)
        {
            int firstElement = digits[0];
            int secondElement = digits[1];
            switch (delemiter)
            {
                case "+":
                    return firstElement + secondElement;
                case "-":
                    return firstElement - secondElement;
                case "*":
                    return firstElement * secondElement;
                default:
                    return firstElement / secondElement;
            }
        }
    }

}