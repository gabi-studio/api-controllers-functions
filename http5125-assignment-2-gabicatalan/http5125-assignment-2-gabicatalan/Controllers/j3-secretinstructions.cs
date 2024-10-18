using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace http5125_assignment_2_gabicatalan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class j3_secretinstructions : ControllerBase
    {
        /// <summary>
        /// receives lines of 5 digit numbers where the sum of the first two numbers indicate where to turn (right if even sum, left if odd sum, the previous line's direction if zero)
        /// after finding a line of 99999, return an output where the direction is indicated, followed by space,
        /// then last three numbers, which indicates the number of steps to take
        /// </summary>
        /// 
        /// <parameter="instructions">an array made up of 5 digit numbers that will dictate direction and number of steps to take, with instructions to end process</parameter>
        /// 
        /// <returns> lines of string where the first part of each string indicates direction (right or left), 
        /// and the second part a three digit integer that signifies how many steps to take, 
        /// and the last line is blank </returns>
        /// 
        /// <example>
        /// POST : curl -H "Content-Type: application/json" -d "[\"57234\",\"00907\",\"34100\",\"99999\"]" "https://localhost:7251/api/j3_secretinstructions/secretInstructions" 
        /// -> right 234
        ///    right 907
        ///    left 100
        /// POST : curl -H "Content-Type: application/json" -d "[\"42834\",\"94907\",\"00118\", \"67178\", \"99999\"]" "https://localhost:7251/api/j3_secretinstructions/secretInstructions"
        /// -> right 834
        ///    left 907
        ///    left 118
        ///    left 178
        /// </example>
        /// 

        [HttpPost("secretInstructions")]
        [Consumes("application/json")]
        public string secretInstructions([FromBody] List<string> instructions)
        {
            /// initialize variables to store the output decodedInstructions, direction, and the last direction
            string decodedInstructions = "";  
            string lastDirection = "";
            string direction;


            /// a loop that goes through each line, uses .count instead of .length because we are counting the number of lines in the instructions list
            for (int i = 0; i < instructions.Count; i++)
            {
                string line = instructions[i];

                /// add a break to terminate process if we encounter instruction 99999
                if (line == "99999")
                {
                    break;
                }

                /// use this format to extract the first two digits and the last three digits:
                /// -> string.Substring (int startIndex, int length);
                /// 

                int firstTwo = int.Parse(line.Substring(0, 2));
                int lastThree = int.Parse(line.Substring(2, 3));

                /// isolate the each of the first two digits and find their sum
                /// divide by 10 to get the first digit
                /// use modulus to get the remainder after dividing by 10 -> second digit
                /// 

                int firstDigit = firstTwo / 10; /// ex: 89 -> 8
                int secondDigit = firstTwo % 10;/// ex: 89 -> 9
                int firstTwoSum = firstDigit + secondDigit;

                /// determine the direction based on if the sum of the first two digits are even (right) or odd (left)
                /// divide sum by two, if remainder % is zero, then it is even, otherwise odd
                /// if sum equals to zero, and it's not the first line (where there is no previous direction), the direction is the same as the previous one
                
                
                if (firstTwoSum == 0)
                {
                    direction = lastDirection;
                }
                else if (firstTwoSum % 2 == 0)
                {
                    direction = "right";
                }
                else
                {
                    direction = "left";
                }

                /// update the value of the "last direction" to the new one
                /// 

                lastDirection = direction;

                /// add each new line of (direction + last three digits) on the output decoded instructions
                decodedInstructions += direction + " " + lastThree + "\n";



            }

            

            return decodedInstructions;



        }
        


    }
}
