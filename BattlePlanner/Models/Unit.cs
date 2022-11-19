using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace BattlePlanner
{
	public class Unit
	{
		public string Name { get; }
		private string UnitId { get; }
		private static List<string> unitIds = new List<string>();
		private static List<Unit> unitList = new List<Unit>();
		[JsonProperty] private Dictionary<Resource, int> resourcesList = new Dictionary<Resource, int>();
		public Unit(string name)
		{
			Name = name;
			UnitId = GetId(unitIds);
			AddToUnitList();
		}
		public Dictionary<Resource, int> GetResourcesList()
		{
			return resourcesList;
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
		public static void PrintAllUnits()
		{
			foreach (var item in unitList)
			{
				Console.WriteLine(item);
			}
		}

		public static List<Unit> GetUnitList()
		{
			return unitList;
		}
		public void AddToResourceList(Resource resource, int capacity)
		{
			resourcesList.Add(resource, capacity);
		}

		public void RemoveResource(Resource resource)
		{
			resourcesList.Remove(resource);
		}
		public bool CheckIfIdExists(string id)
		{
			return unitIds.Contains(id);
		}

		public string GetId(List<string> list)
		{
			string id;
			do
			{
				int one = Helpers.GetRandom(1, 10);
				int two = Helpers.GetRandom(10, 100);
				id = one + "-" + two;
			} while (CheckIfIdExists(id));

			list.Add(id);
			return id;
		}

		public override string ToString()
		{
			string resources = null;
			foreach (var resource in resourcesList)
			{
				resources += ($"{resource}\n");
			}
			return ($"{UnitId} - {Name}\n{resources}");
		}
	}
}