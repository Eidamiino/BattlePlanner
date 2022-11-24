using System;
using System.Collections.Generic;

namespace BattlePlanner
{
	public class ResourceAmount
	{
		public Resource resource { get;}
		public int amount { get; }
		
		public static List<ResourceAmount> resourceAmountList { get; private set; } =new List<ResourceAmount>();

		public ResourceAmount(Resource resource, int amount)
		{
			this.resource = resource;
			this.amount = amount;
			resourceAmountList.Add(this);

			if (!Resource.resourceList.Contains(resource))
				Resource.AddResource(resource);
		}
	}
}