using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class DataAccess
	{
		project0Entities db = new project0Entities();

		// add restuarant
		public void AddRestuarant(string _name, string _address)
		{
			try
			{
				db.restuarants.Add(new restuarant
				{
					name = _name,
					rating = null,
					address = _address
				});
				db.SaveChanges();
			}
			catch (Exception e)
			{
				Console.Write("\nSomething went terribly wrong.\n");
			}
		}

		// return all restuarants
		public IEnumerable<restuarant> GetRestuarants()
		{
			return db.restuarants.ToList();
		}

		// add review
		public void AddReview(string _name, int _score, string _message, int _id)
		{
			try
			{
				review test = new review();
				test.name = _name;
				test.score = _score;
				test.message = _message;
				test.id = _id;
				db.reviews.Add(test);
				db.SaveChanges();
			}
			catch
			{
			}

			// update restuarant rating afterwards
		}

		// get all reviews for a given restuarant
		public IEnumerable<review>GetReviews(int _id)
		{
			// search to see if restuarant exist
			List<review> result = new List<review>();
			foreach (var temp in db.reviews.ToList())
			{
				if (temp.id == _id)
				{
					result.Add(temp);
				}
			}
			return result;
		}
	}
}
