using System.Collections.Generic;

namespace BattlePlanner
{
	public class ResourceAmount
	{
		public Resource resource { get;}
		public int amount { get; }
		
		private static List<ResourceAmount> resourceAmountList=new List<ResourceAmount>();

		public ResourceAmount(Resource resource, int amount)
		{
			this.resource = resource;
			this.amount = amount;
			resourceAmountList.Add(this);
		}
	}
}