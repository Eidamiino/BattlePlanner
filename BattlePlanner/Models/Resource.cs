using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace BattlePlanner
{
	public class Resource
	{
		public string Name { get; }
		private Dictionary<string, int> requirementsList = new Dictionary<string, int>();
		public static List<Resource> resourceList = new List<Resource>();

		public Resource(string enteredName)
		{
			Name = enteredName;
			AddToResources();
		}


		public Dictionary<string, int> GetRequirementsList()
		{
			return requirementsList;
		}

		public void AddToResources()
		{
			resourceList.Add(this);
		}
		public static void RemoveResource(Resource resource)
		{
			resourceList.Remove(resource);
		}

		public static Resource FindResourceByName(string name)
		{
			return resourceList.Find(x => x.Name.Equals(name));
		}

		public static void PrintAllResources()
		{
			Console.WriteLine("All resources:");
			foreach (var item in resourceList)
			{
				Console.WriteLine($"{item.Name}");
			}
		}

		public void AddRequirement(string name, int capacity)
		{
			requirementsList.Add(name, capacity);
		}

		public void RemoveRequirement(string name)
		{
			requirementsList.Remove(name);
		}

		public void PrintAllRequirements()
		{
			foreach (var item in requirementsList)
			{
				Console.WriteLine($"{item.Key}:{item.Value}");
			}
		}

		public override string ToString()
		{
			return ($"Name: {this.Name}");
		}
	}
}