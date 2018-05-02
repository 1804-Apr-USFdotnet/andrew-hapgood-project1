using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project0
{
	class Client
	{
		static void Main(string[] args)
		{
			string message = "|-------------------------|\n" +
							 "|1. Add Restuarant        |\n" +
							 "|2. Add Review            |\n" + 
							 "|3. Show all              |\n" + 
							 "|4. Top Restuarnts        |\n" +
							 "|5. Search                |\n" +
							 "|6. Read Reviews          |\n" +
							 "|7. Quit                  |\n" +
							 "|-------------------------|\n" +
							 ">> ";
			string input;

			InputHandler ih = new InputHandler();

			// mainloop
			for(; ; )
			{
				Console.Clear();
				Console.Write(message);
				input = Console.ReadLine();
				if (input == "7" || input.ToLower() == "quit" || input == "q")
					break;
				Console.Write(ih.ValidateInput(input));
				Console.ReadLine();
				Console.Clear();
			}
		}
	}
}
