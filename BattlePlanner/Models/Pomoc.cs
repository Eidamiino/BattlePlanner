using System.Collections.Generic;

namespace BattlePlanner
{
	public class Pomoc
	{
		public Resource resource { get; private set; }
		public int amount { get; }
		
		private static List<Pomoc> pomocList=new List<Pomoc>();

		public Pomoc(Resource resource, int amount)
		{
			this.resource = resource;
			this.amount = amount;
			pomocList.Add(this);
		}

		public List<Pomoc> getPomocList()
		{
			return pomocList;
		}
	}
}