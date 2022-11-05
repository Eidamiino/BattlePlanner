using System;

namespace BattlePlanner
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Resource resource = new Resource("Soldier");
			resource.AddToList("diesel", 50);
			resource.AddToList("voda", 50);
			resource.PrintAllRequirements();

			resource.EditList("diesel", 100);
			resource.PrintAllRequirements();
		}
	}
}
