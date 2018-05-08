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
				var t = new review
				{
					name = _name,
					score = _score,
					message = _message,
					rest_id = _rest_id

				};
				db.reviews.Add(t);
				db.SaveChanges();
			}
			catch
			{
				// log an error here
			}
		}

		public void UpdateDB()
		{
			db.Configuration.ProxyCreationEnabled = false;

			var rest = GetRestuarants();
			var rev = GetReviews();
			float sum = 0;
			float count = 0;
			foreach (var rest_item in rest)
			{
				foreach(var rev_item in rev)
				{
					sum += rev_item.score;
					count++;
				}
				try
				{
					rest_item.rating = sum / count;
					db.SaveChanges();
				}
				catch
				{

				}
				sum = 0;
				count = 0;
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