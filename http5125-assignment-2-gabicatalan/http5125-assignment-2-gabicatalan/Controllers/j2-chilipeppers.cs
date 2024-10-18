using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace http5125_assignment_2_gabicatalan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class j2_chilipeppers : ControllerBase
    {

        /// <summary>
        /// receives a list of pepper ingredients, then calculates the total spiciness measure if the chili, based on scoville heat units that are known for each pepper
        /// </summary>
        /// 
        /// <parameter=pepper1, pepper2, pepper3...>each item on the list is a type of pepper whose scoville heat units are known</parameter>
        /// 
        /// <returns>a total value of scoville heat units based on all the pepper ingredients inputted (added to the chili)</returns>
        /// 
        /// <example>
        /// GET : /api/j2_chilipeppers/ChiliPeppers?peppersAdded=habanero,serrano -> 140500
        /// GET : /api/j2_chilipeppers/ChiliPeppers?peppersAdded=Mirasol,cayenne,thai -> 121000
        /// GET : /api/j2_chilipeppers/ChiliPeppers?peppersAdded=poblano,poblano -> 3000
        /// </example>

        [HttpGet(template:"ChiliPeppers")]
        public int chiliSpiciness(string peppersAdded)
        {
            /// declare a comma as a separator char
            /// declare an array containing the ingredients split with a separator
            /// remove empty entries and trip white space
            /// declare variable for individual peppers, total spiciness
            char delimiter = ',';
            string[] peppers = peppersAdded.Split(delimiter, StringSplitOptions.RemoveEmptyEntries |StringSplitOptions.TrimEntries);
            string pepper = peppers[0];
            int chiliSpiciness = 0;
            int shu = 0;


            /// a loop that goes through the array of peppers
            /// use string.equals and ordinal ignore case to ignore case 
            /// reference this: https://learn.microsoft.com/en-us/dotnet/csharp/how-to/compare-strings
            for (int i = 0; i < peppers.Length; i++) 
            {
                pepper = peppers[i];

                if (string.Equals(pepper, "Poblano", StringComparison.OrdinalIgnoreCase))
                {
                    shu = 1500;
                }
                else if (string.Equals(pepper, "Mirasol", StringComparison.OrdinalIgnoreCase))
                {
                    shu = 6000;
                }
                else if (string.Equals(pepper, "Serrano", StringComparison.OrdinalIgnoreCase))
                {
                    shu = 15500;
                }
                else if (string.Equals(pepper, "Cayenne", StringComparison.OrdinalIgnoreCase))
                {
                    shu = 40000;
                }
                else if (string.Equals(pepper, "Thai", StringComparison.OrdinalIgnoreCase))
                {
                    shu = 75000;
                }
                else if (string.Equals(pepper, "Habanero", StringComparison.OrdinalIgnoreCase))
                {
                    shu = 125000;
                }

                // calculate and return the total spicness (in shu) of the chili based on all the peppers added

                chiliSpiciness += shu;
            }

            return chiliSpiciness;





        }
    }
}
