using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace project_1.Models
{
	public class DataAccess
	{
		private project1Entities1 db = new project1Entities1();

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

		public void UpdateReview(review rev)
		{
			try
			{
				var entity = db.reviews.Where(x => x.id == rev.id).First();
				entity.name = rev.name;
				entity.message = rev.message;
				entity.rest_id = rev.rest_id;
				db.reviews.Attach(entity);
				db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
				db.SaveChanges();

			}
			catch
			{
				// couldn't update, look into it
			}
		}

		public void DeleteReview(int id)
		{
			var entity = db.reviews.SingleOrDefault(x => x.id == id);
			db.reviews.Attach(entity);
			db.reviews.Remove(entity);
			db.SaveChanges();
		}

		public void UpdateDB()
		{
			var rest_temp = db.restuarants.ToList();
			var review_temp = db.reviews.ToList();
			int sum = 0;
			int count = 0;
			foreach (var i in rest_temp)
			{
				foreach(var j in review_temp)
				{
					if (j.rest_id == i.id)
					{
						sum += j.score;
						count++;
					}
					try
					{
						i.rating = sum / count;
						db.SaveChanges();
					}
					catch
					{

					}
				}
			}
		}
		public IEnumerable<review> GetReviews()
		{
			return db.reviews.ToList();
		}
		public IEnumerable<review> GetReviews(int _id)
		{
			return db.reviews.Where(x => x.rest_id == _id);
		}


	}
}