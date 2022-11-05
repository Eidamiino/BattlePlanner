using System;
using System.Collections.Generic;

namespace BattlePlanner
{
	public class Resource
	{
		public string Name { get; private set; }
		public Resource(string enteredName)
		{
			Name = enteredName;
		}
		private Dictionary<string, int> requirementsList = new Dictionary<string, int>();

		public bool AddToList(string name, int capacity)
		{
			requirementsList.Add(name, capacity);
			return true;
		}

		public bool EditList(string name, int capacity)
		{
			requirementsList[name] = capacity;
			return true;
		}

		public void PrintAllRequirements()
		{
			foreach (var requirement in requirementsList)
			{
				Console.WriteLine($"{requirement.Key}:{requirement.Value}");
			}
		}

	}
}