using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using BinaryPack.Attributes;
using BinaryPack.Enums;
using Newtonsoft.Json;

namespace BattlePlanner
{
	[Serializable]
	public class Resource
	{
		[JsonProperty] public string Name { get;  set; }
		[JsonProperty] public Dictionary<string, int> requirementsList { get;  set; }= new Dictionary<string, int>();
		public static List<Resource> resourceList { get; private set; } = new List<Resource>();

		public Resource(string enteredName)
		{
			Name = enteredName;
			AddResource(this);
		}
		public static void AddResource(Resource resource)
		{
			resourceList.Add(resource);
		}
		public static void RemoveResource(Resource resource)
		{
			resourceList.Remove(resource);
		}

		public static Resource FindResourceByName(string name)
		{
			return resourceList.Find(x => x.Name.Equals(name));
		}

		public void AddRequirement(string name, int capacity)
		{
			requirementsList.Add(name, capacity);
		}

		public void RemoveRequirement(string name)
		{
			requirementsList.Remove(name);
		}

		public override string ToString()
		{
			string requirements = null;
			foreach (var requirement in requirementsList)
			{
				requirements += ($"\t{requirement.Key}-{requirement.Value}\n");
			}

			return ($"{Name}\n{requirements}");
		}
	}
}