using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace BattlePlanner
{
	public class Unit
	{
		public string Name { get; }
		public string UnitId { get;}
		public static List<string> unitIds { get; private set; } = new List<string>();
		public static List<Unit> unitList { get; private set; } = new List<Unit>();
		[JsonProperty] public List<ResourceAmount> resourceList { get; private set; } = new List<ResourceAmount>();
		public Unit(string name)
		{
			Name = name;
			UnitId = GetId(unitIds);
			AddToUnitList();
		}
		public void AddToUnitList()
		{
			unitList.Add(this);
		}
		public void RemoveUnit()
		{
			unitList.Remove(this);
		}
		public static Unit FindUnitById(string id)
		{
			return unitList.Find(x => x.UnitId.Equals(id));
		}
		public void AddToResourceList(Resource resource, int capacity)
		{
			ResourceAmount resourceAmount = new ResourceAmount(resource, capacity);
			resourceList.Add(resourceAmount);
		}
		public ResourceAmount FindResourceInList(Resource resource)
		{
			return resourceList.Find(x => x.resource.Equals(resource));
		}

		public void RemoveResource(Resource resource)
		{
			ResourceAmount resourceAmount = FindResourceInList(resource);
			resourceList.Remove(resourceAmount);
		}
		public bool CheckIfIdExists(string id)
		{
			return unitIds.Contains(id);
		}
		public string GetId(List<string> list)
		{
			Random rand = new Random();
			string id;
			do
			{
				int one = rand.Next(1, 10);
				int two = rand.Next(10, 100);
				id = one + "-" + two;
			} while (CheckIfIdExists(id));

			list.Add(id);
			return id;
		}

		public override string ToString()
		{
			string resources = null;
			foreach (var item in resourceList)
			{
				resources += ($"{item.resource}\n");
			}
			return ($"{UnitId} - {Name}\n{resources}");
		}
	}
}