using System;
using System.Collections.Generic;
namespace DocuSign
{
	class MainClass
	{
		
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");


			Clothing footwear = new Clothing();
			Clothing headwear = new Clothing();
			Clothing socks = new Clothing();
			Clothing shirt = new Clothing();
			Clothing jacket = new Clothing();
			Clothing pants = new Clothing();

			//initialize the values of the clothing and the commands
			footwear.set("footwear", 1,"sandals","boots");
			headwear.set("headwear", 2,"sun visor","hat");
			socks.set("socks", 3,"fail","socks");
			shirt.set("shirt", 4,"t-shirt","shirt");
			jacket.set("jacket", 5,"fail","jacket");
			pants.set("pants", 6,"shorts","pants");


			List<Clothing> options = new List<Clothing>();

			//Add the clothing items to a list to pass it to the function
			options.Add(footwear);
			options.Add(headwear);
			options.Add(socks);
			options.Add(shirt);
			options.Add(jacket);
			options.Add(pants);

			//initialize commands
			int[] commands={8, 6, 6};
			//initialize weather
			string weather = "hot";

			checkRules(commands,options,weather);

		}

		static void checkRules(int [] commands, List<Clothing> options ,string weather )
		{
			HashSet<string> previous = new HashSet<string>(); 
			// if first command not to remove pyjamas --> fail
			if(commands[0]!= 8)
				return ;
			Console.Write ("Removing PJ's, ");
			int i;
			for( i=1;(i<commands.Length && (commands[i]!=7));i++)
			{
				int current = commands[i];

				//Check validity of command
				if (current > 6 || current < 1) {
					Console.WriteLine ("fail");
					return;
				}

				Clothing cloth = options[commands[i]-1];
				string category = cloth.getCategory();

				if (previous.Contains (category)) {
					Console.WriteLine ("fail");
					return ;
				}
				else
				{
					if (weather.Equals ("hot")) {
						if (category.Equals ("socks") || category.Equals ("jacket")) {

							Console.WriteLine ("fail");
							return;
						}

					} else if (category.Equals ("footear") && !previous.Contains ("socks")) {
						Console.WriteLine ("fail");
						return;
					}
					if (category.Equals ("headwear") && !previous.Contains ("shirt")) {
						Console.WriteLine ("fail");
						return ;
					}
					previous.Add(category);
					Console.Write (cloth.getName(weather));
					Console.Write (", ");
				}

			}

				//Check if all clothing is worn before leaving
			if (weather.Equals("cold")){
				if (previous.Count != 6 || i >= commands.Length) {
					
					Console.WriteLine ("fail");
						return;
				}
				 else
					Console.WriteLine ("leaving house");
					return;
			}

			else if (weather.Equals("hot") ) {
				if(previous.Count!=4 || i>=commands.Length){
					
				Console.WriteLine ("fail");
						return;
			} else
				Console.WriteLine ("leaving house");
					return;
		
			}
				else
				return;

	}
}
}
