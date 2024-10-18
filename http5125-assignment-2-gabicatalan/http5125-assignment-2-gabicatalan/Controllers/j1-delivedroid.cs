using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace http5125_assignment_2_gabicatalan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class j1_delivedroid : ControllerBase
    {

        /// <summary>
        /// calculates the final score of a delivery droid based on a point system, where different types of shots are worth different points
        /// </summary>
        /// <parameter="deliveries">The number of deliveries made by the droid</parameter>
        /// <parameter="collisions">The number of colissions made by the droid</parameter>
        /// <returns>the final score of the deliv-e-droid</returns>
        /// <example>
        /// POST : curl -H "Content-Type: application/x-www-form-urlencoded" -d "deliveries=10&collisions=2" "https://localhost:7251/api/j1_delivedroid/droidScore"  -> 980
        /// POST : curl -H "Content-Type: application/x-www-form-urlencoded" -d "deliveries=2&collisions=1" "https://localhost:7251/api/j1_delivedroid/droidScore"   -> 590
        /// </example>


        [HttpPost(template: "droidScore")]
        [Consumes("application/x-www-form-urlencoded")]
        public int droidScore([FromForm]int deliveries, [FromForm]int collisions)
        {
            /// calculating the base score:
            int finalScore = (deliveries * 50) - (collisions * 10);

            /// adding a bonus IF the deliveries > collisions

            if (deliveries > collisions)
            {
                finalScore += 500;
            }

            return finalScore;

        }

    }
}
