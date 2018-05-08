using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Web;

namespace project_1.Models
{
	public class DataAccess
	{
		project1Entities db = new project1Entities();

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
			catch
			{
				// log an error here
			}
		}

		public IEnumerable<restuarant> GetRestuarants()
		{
			return db.restuarants.ToList();
		}

		public void UpdateRest(restuarant rest)
		{
			try
			{
				var entity = db.restuarants.SingleOrDefault(x => x.id == rest.id);
				entity.name = rest.name;
				entity.address = rest.address;
				db.restuarants.Attach(entity);
				db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
				db.SaveChanges();

			}
			catch
			{
				// couldn't update, look into it
			}
		}

		public void DeleteRestuarant(int id)
		{
			var entity = db.restuarants.SingleOrDefault(x => x.id == id);
			db.restuarants.Attach(entity);
			db.restuarants.Remove(entity);
			db.SaveChanges();
		}

		public void AddReview(string _name, int _score, string _message, int _rest_id)
		{
			try
			{
				db.reviews.Add(new review
				{
					name = _name,
					score = _score,
					message = _message,
					rest_id = _rest_id
					
				});
				db.SaveChanges();
			}
			catch
			{
				// log an error here
			}
		}

		public IEnumerable<review> GetReviews(int id)
		{
			// search to see if restuarant exist
			var result = new List<review>();
			foreach (var temp in db.reviews.ToList())
			{
				if (temp.rest_id == id)
				{
					result.Add(temp);
				}
			}
			return result;
		}

		public void UpdateDB()
		{
			// not working, fix quickly
			var rest = db.restuarants.ToList();
			var rev = db.reviews.ToList();

			foreach(var rest_item in rest)
			{
				foreach(var review_item in rev)
				{

				}
			}
			
		}

	}
}