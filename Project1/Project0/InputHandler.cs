using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

using ClientLibrary;

namespace Project0
{
	public class InputHandler
	{

		//creat instance for library
		MethodHandler mh = new MethodHandler();

		// references the business (library) layer
		public string ValidateInput(string input)
		{

			switch (input)
			{
				case "1":
					// uncomment this after testing
					// check if running in admin
					/*if (!IsAdmin())
						return "Admin required.\n";
					else
						AddRestuarant();*/
					AddRestuarant();
					break;
				case "2":
					// add review
					AddReview();
					break;
				case "3":
					// show all restuarants	
					ShowAll();
					break;
				case "4":
					// Get Top N reviews
					break;
				case "5":
					// Search for restuarants
					break;
				case "6":
					// read reviews (just use id = 2 for now)
					ReadReviews();
					break;
				default:
					return "Invalid input.\n";
			}
			return "Completed task.\n";
		}

		public void AddRestuarant()
		{
			Console.Clear();
			// passes along input to library
			string message = "|-------------------------|\n" +
							 "|Name:                    |\n" +
							 "|Adress:                  |\n";
			Console.Write(message);

			List<string> inputs = new List<string>();
			// all restuarants require a name, address and rating
			int[] i_coord_x = {7,9};
			int[] i_coord_y = {1,2};
			for (int i = 0; i <2; i++)
			{
				Console.SetCursorPosition(i_coord_x[i], i_coord_y[i]);
				inputs.Add(Console.ReadLine()); // verify correct inputs later
			}
			mh.AddRestuarant(inputs[0], inputs[1]);
		}

		public void AddReview()
		{
			// request for which restuarant
			Console.Clear();
			Console.WriteLine("|-------------------------|\n" +
							  "|Name:                    |\n" +	// 7
							  "|Score(1-5):              |\n" + // 13
							  "|Restuarant ID:           |\n" + // 16
							  "|-------------------------|\n" +
							  "Write Your Review.\n>> ");
			// have a restuarant picker later instead of picking by id
			List<string> inputs = new List<string>();
			int[] i_coord_x = {7,13,16,3};
			int[] i_coord_y = {1,2,3,6};
			for (int i = 0; i < 4; i++)
			{
				// move cursor to appropraite position
				Console.SetCursorPosition(i_coord_x[i],i_coord_y[i]);
				inputs.Add(Console.ReadLine());
			}
			mh.AddReview(inputs[0], inputs[1], inputs[2], inputs[3]);
		}

		public void ShowAll()
		{
			// make this one look good later
			List<string> restuarants_list = mh.GetAll();
			int i = 1;
			int count;
			string spaces;	//25
			foreach(var temp in restuarants_list)
			{
				if (i > 10)
				{
					count = temp.Length + 3;
				}
				else
				{
					count = temp.Length + 4;
				}
				spaces = new	String(' ', 25-count);
				Console.Write("|"	 + i++ + ". " + temp + spaces + " |\n");
			}
			Console.Write("|-------------------------|\n" + 
						  ">> ");
		}

		public void GetTopN()
		{

		}

		public void ReadReviews()
		{
			Console.WriteLine("|-------------------------|\n" + 
							  "|Which Restuarant do you  |\n" +
							  "|want to know aobut?      |");
			ShowAll();
			 

			List<string> temp = mh.GetReviews(2);
			foreach(var mess in temp)
			{
				Console.WriteLine(mess + "\n");
			}
			Console.ReadLine();
		}

		public void Search()
		{
			Console.Clear();
			string message = "|-------------------------|\n" + 
							 "|What are you looking for?|\n" + 
							 ">> ";
			Console.WriteLine(message);
			string input = Console.ReadLine();
		}

		public static bool IsAdmin()
		{
			var identity = WindowsIdentity.GetCurrent();
			var principal = new WindowsPrincipal(identity);
			return principal.IsInRole(WindowsBuiltInRole.Administrator);
		}
	}
}
