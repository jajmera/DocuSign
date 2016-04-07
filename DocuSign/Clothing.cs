using System;

namespace DocuSign
{
	class Clothing
	{
		string category;
		int command;
		string hot;
		string cold;


		public void set(string newCategory, int command, string hot, string cold)
		{
			this.category = newCategory;
			this.command = command;
			this.hot = hot;
			this.cold = cold;
		}

		public string getCategory()
		{
			return this.category;
		}
		public int getCommand()
		{
			return this.command;
		}

		public string getName(String weather)
		{

			if (weather.Equals("hot"))
				return this.hot;
			else
				return this.cold;
		}

		public string getHot()
		{
			return this.hot;
		}
		public string getCold()
		{
			return this.cold;
		}
	}

}

