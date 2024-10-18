using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace http5125_assignment_2_gabicatalan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class j1_winningscore : ControllerBase
    {

        /// <summary>
        /// Receives an array of integers where the first three lines correspond to the apples team's scores, while the last three correspond to the bananas team's score (3-point, 2-point, 1-point),
        /// then calculates each of their total score based on the types of shot they made
        /// then compares their scores with each other,
        /// and then returns a single character string  (either A, B, or T) to indicate the winning outcome of the game
        /// </summary>
        ///
        /// <parameter="[ApplesThree, ApplesTwo, ApplesOne, BananasThree, BananasTwo, BananasOne]">an array of integers where the first three lines correspond to the apples team's scores, while the last three correspond to the bananas team's score</parameter>
        /// 
        /// paramater will be an integer between 0-100, inclusive
        /// 
        /// <returns>returns a single chracter string  (either A, B, or T) to indicate the winning outcome of the game</returns>
        /// 
        /// <example>
        /// POST : curl -H "Content-Type: application/json" -d "[10, 3, 7, 8, 9, 100]" "https://localhost:7251/api/j1_winningscore/winningscore" -> B
        /// POST : curl -H "Content-Type: application/json" -d "[20, 13, 7, 8, 9, 50]" "https://localhost:7251/api/j1_winningscore/winningscore" - A
        /// POST : curl -H "Content-Type: application/json" -d "[20, 13, 7, 10, 15, 33]" "https://localhost:7251/api/j1_winningscore/winningscore" -> T
        /// </example>

        [HttpPost(template: "winningScore")]
        [Consumes("application/json")]

        public string winningScore([FromBody] int[] scores) 
        {
            /// declare variables
            int threePointShot = 3;
            int fieldGoal = 2;
            int freeThrow = 1;


            /// validate all inputs are integers between 0-100, inclusive
            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] < 0 || scores[i] > 100)
                {
                    return ("All score counts must be between 0 and 100.");
                }
            }

            /// calculate the scores of team apples and team bananas
                int applesScore = (threePointShot * scores[0]) + (fieldGoal * scores[1]) + (freeThrow * scores[2]);
                int bananasScore = (threePointShot * scores[3]) + (fieldGoal * scores[4]) + (freeThrow * scores[5]);

            // compare the scores
            // return A if team apples won, B if team bananas won, and T if the game is tied
                if (applesScore > bananasScore) {
                    return ("A");

                }
                else if (bananasScore > applesScore) {
                    return ("B");

                }
                else
                {
                    return ("T");
                }
            
        }
    }
}
