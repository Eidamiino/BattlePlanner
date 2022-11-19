using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace BattlePlanner
{
	public class Unit
	{
		public string Name { get; }
		public string UnitId { get; private set; }
		private static List<string> unitIds = new List<string>();
		private static List<Unit> unitList = new List<Unit>();
		[JsonProperty] private List<Pomoc> pomocList=new List<Pomoc>();
		//[JsonProperty] private Dictionary<Resource, int> resourcesList = new Dictionary<Resource, int>();
		public Unit(string name)
		{
			Name = name;
			UnitId = GetId(unitIds);
			AddToUnitList();
		}
		public List<Pomoc> GetResourcesList()
		{
			return pomocList;
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
			Pomoc pomoc = new Pomoc(resource, capacity);
			pomocList.Add(pomoc);
		}

		public Pomoc FindPomocByResource(Resource resource)
		{
			return pomocList.Find(x => x.resource.Equals(resource));
		}

		public void RemoveResource(Resource resource)
		{
			Pomoc pomoc = FindPomocByResource(resource);
			pomocList.Remove(pomoc);
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
			foreach (var item in pomocList)
			{
				resources += ($"{item.resource}\n");
			}
			return ($"{UnitId} - {Name}\n{resources}");
		}
	}
}