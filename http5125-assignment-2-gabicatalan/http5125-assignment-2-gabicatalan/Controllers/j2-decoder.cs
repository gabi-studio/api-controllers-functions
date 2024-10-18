using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace http5125_assignment_2_gabicatalan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class j2_decoder : ControllerBase
    {
        /// <summary>
        /// receives input where the first line indicates the number of lines in the message
        /// and the next lines contain exactly 1 integer (n) greater than 0 and less than 80
        /// followed by one space, followed by any other character than is not a space
        /// THEN outputs as many lines as the number in line 1 indicates, 
        /// each line is the non-space character printed n times
        /// </summary>
        /// 
        /// <parameter="encodedMessage">an array where the first value is a number that indicates how many lines there will be in the output, the next values are a pair of number and symbol
        /// the number is the number of times the symbol will be printed
        /// </parameter>

        /// 
        /// <returns>lines of string where the first line is blank, and the next lines are symbols printed n number of times, where n represents the first integer on each line in the input (after index 0) </returns>
        /// 
        /// <example>
        /// POST : curl -H "Content-Type: application/json" -d "[\"2\", \"1 *\", \"2 +\"]" "https://localhost:7251/api/j2_decoder/decoder" 
        /// -> *
        ///    ++
        /// POST : curl -H "Content-Type: application/json" -d "[\"2\", \"1 *\", \"2 +\", \"3 !\"]" "https://localhost:7251/api/j2_decoder/decoder"
        /// -> *
        ///    ++
        ///    !!!
        /// POST : curl -H "Content-Type: application/json" -d "[\"5\", \"1 +\", \"2 +\", \"3 C\", \"4 8\", \"5 *\"]" "https://localhost:7251/api/j2_decoder/decoder"
        /// -> +
        ///    ++
        ///    CCC
        ///    8888
        ///    *****
        /// </example>
        /// 

        [HttpPost("decoder")]
        [Consumes("application/json")]
        public string decoder([FromBody] string[] encodedMessage)
        {
            /// declare the decoded message as an empty string to begin
            string decodedMessage = "";

            /// a loop that goes through each value (represents a line) of the encodedMessage array
            /// then use message.Split to split each line where a space exists
            /// then places the split parts in an array
            /// uses int.parse to assign the first value in the array into an int data type (use this for the loop that dictates how many times the symbol will be printed)
            /// and assign the second value in the array in a string variable
            for (int i = 0; i < encodedMessage.Length; i++)
            {
                string message = encodedMessage[i];
                string[] line = message.Split(' '); // this line will be split into parts where there is a space, then each part will be placed in an array called "line"
                int printCount = int.Parse(line[0]);
                string symbol= "";

                /// to ensure that it only puts the string symbol to print, not an integer 
                /// without this if statement, there was an index out of range exception
                /// for my reference: https://learn.microsoft.com/en-us/dotnet/api/system.indexoutofrangeexception?view=net-8.0
                if (line.Length > 1)
                {
                    symbol = line[1];
                }

     
            /// a loop to print the symbol of the current line printCount number of times, then adds that to the decodedmessage
                for (int j = 0; j < printCount && printCount > 0 && printCount < 80; j++)
                {
                    decodedMessage += symbol;
                    
                }

            ///  adds a new line after a line has been printed printCount number of times
                decodedMessage += "\n"; 
            }

            /// return decoded message after each line has been printed

            return decodedMessage;
        }


    }
}
