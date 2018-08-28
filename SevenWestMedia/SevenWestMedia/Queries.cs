using JsonHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWestMedia
{
    public class PeopleQueries
    {
        IList<Person> people;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="people"> List of people </param>
        public PeopleQueries(IList<Person> people)
        {
            this.people = people;
        }

        /// <summary>
        /// Gets person full name by id
        /// </summary>
        /// <param name="id"> Id of the person </param>
        /// <returns> Resturns list of people in string format </returns>
        public string PersonFullNameById(long id)
        {
            string result = string.Empty;
            StringBuilder rBuilder = new StringBuilder();
            
            var person = (from p in people
                          where p.Id == id
                          select new
                          {
                              First = p.First,
                              Last = p.Last
                          }).ToList();

            if (person != null)
                foreach (var item in person)
                {
                    rBuilder.Append("\n" + item.First + " " + item.Last);
                }
            result = rBuilder.ToString();
            return result;
        }

        /// <summary>
        /// Gets person by age
        /// </summary>
        /// <param name="age"> age parameter </param>
        /// <returns> returns string of people </returns>
        public string PersonByAge(long age)
        {

            string result = string.Empty;
            List<string> peopleList = new List<string>();
            
            var person = (from p in people
                          where p.Age == age
                          select new
                          {
                              First = p.First,
                              Last = p.Last
                          }).ToList();

            foreach (var item in person)
            {
                peopleList.Add(item.First + " ");
            }

            result = string.Join(",", peopleList.ToArray());
            return result;
        }

        /// <summary>
        /// Gets Genders per age
        /// </summary>
        /// <returns> Returns formatted string</returns>
        public string GendersPerAge()
        {

            string result = string.Empty;
            StringBuilder rBuilder = new StringBuilder();

            var person = (from p in people
                          group p.Age by p.Age into agegrp
                          orderby agegrp.Key
                          select new
                          {
                              Info = "Age :" + agegrp.Key + " Female : " + people.Where(v => v.Gender == "F" && v.Age == agegrp.Key).Count() +
                              " Male : " + people.Where(v => v.Gender == "M" && v.Age == agegrp.Key).Count()
                          }).ToList();

            foreach (var item in person)
            {
                rBuilder.Append("\n" + item.Info);
            }
            result = rBuilder.ToString();

            return result;
        }
    }
}
