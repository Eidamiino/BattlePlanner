using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BattlePlanner
{
	public class Helpers
	{
		public static void LoadPlanUserInput(int input, BattlePlan battlePlan)
		{
			switch (input)
			{
				case 1:
				{
					battlePlan.unitsList.Clear();
					Unit.unitList.Clear();
					battlePlan.unitsList.ForEach(x => x.resourceList.Clear());
					Resource.resourceList.ForEach(x => x.requirementsList.Clear());
					Resource.resourceList.Clear();

					break;
				}
				case 2:
				{
					PrintHelpers.PrintFurtherLoadOptions();
					ClearUnitsUserInput(battlePlan);

					break;
				}
				case 3:
				{
					PrintHelpers.PrintFurtherLoadOptions();
					ClearResourcesUserInput(battlePlan);

					break;
				}
			}
		}

		private static void ClearResourcesUserInput(BattlePlan battlePlan)
		{
			switch (ReadNumber())
			{
				case 1:
				{
					battlePlan.unitsList.ForEach(x => x.resourceList.Clear());
					Resource.resourceList.ForEach(x => x.requirementsList.Clear());
					Resource.resourceList.Clear();
					break;
				}
				case 2:
				{
					battlePlan.unitsList.ForEach(x => x.resourceList.Clear());
					break;
				}
			}
		}

		private static void ClearUnitsUserInput(BattlePlan battlePlan)
		{
			switch (ReadNumber())
			{
				case 1:
				{
					battlePlan.unitsList.Clear();
					Unit.unitList.Clear();
					break;
				}
				case 2:
				{
					battlePlan.unitsList.Clear();
					break;
				}
			}
		}

		public static void PhaseThreeUserInput(int input, BattlePlan battlePlan)
		{
			switch (input)
			{
				case 1:
				{
					PrintHelpers.PrintList(battlePlan.unitsList);
					break;
				}
				case 2:
				{
					PrintHelpers.PrintList(Unit.unitList);
					PrintHelpers.PrintUserInput("ID of a unit to add");
					battlePlan.AddUnit(Unit.FindUnitById(ReadText()));
					break;
				}
				case 3:
				{
					foreach (var unit in Unit.unitList)
					{
						battlePlan.AddUnit(unit);
					}

					break;
				}
				case 4:
				{
					PrintHelpers.PrintList(battlePlan.unitsList);
					PrintHelpers.PrintUserInput("ID of a unit to remove");
					battlePlan.RemoveUnit(Unit.FindUnitById(ReadText()));
					break;
				}
			}
		}

		public static void PhaseTwoUserInput(int input)
		{
			switch (input)
			{
				case 1:
				{
					PrintHelpers.PrintList(Unit.unitList);
					break;
				}
				case 2:
				{
					PrintHelpers.PrintUserInput("Name of the unit");
					Unit unit = new Unit(ReadText());
					break;
				}
				case 3:
				{
					PrintHelpers.PrintList(Unit.unitList);
					PrintHelpers.PrintUserInput("ID of the unit to add the resource to");
					Unit unit = Unit.FindUnitById(ReadText());

					PrintHelpers.PrintList(Resource.resourceList);
					PrintHelpers.PrintUserInput("Name of the resource to add");
					var resource = Resource.FindResourceByName(ReadText());
					PrintHelpers.PrintUserInput("Amount of resource");
					var resourceAmount = ReadNumber();

					unit.AddToResourceList(resource, resourceAmount);
					break;
				}
				case 4:
				{
					PrintHelpers.PrintList(Unit.unitList);
					PrintHelpers.PrintUserInput("ID of the unit to remove the resource from");
					Unit unit = Unit.FindUnitById(ReadText());
					Console.WriteLine(unit);

					PrintHelpers.PrintUserInput("Name of the resource to delete");
					unit.RemoveResource(Resource.FindResourceByName(ReadText()));
					break;
				}
				case 5:
				{
					PrintHelpers.PrintList(Unit.unitList);
					PrintHelpers.PrintUserInput("ID of the unit to remove");
					Unit unit = Unit.FindUnitById(ReadText());
					unit.RemoveUnit();
					break;
				}
			}
		}

		public static void PhaseOneUserInput(int input)
		{
			switch (input)
			{
				case 1:
				{
					PrintHelpers.PrintList(Resource.resourceList);
					break;
				}
				case 2:
				{
					PrintHelpers.PrintUserInput("Name of the resource");
					Resource resource = new Resource(ReadText());
					break;
				}
				case 3:
				{
					PrintHelpers.PrintList(Resource.resourceList);
					PrintHelpers.PrintUserInput("Pick a resource to edit");
					EditResource(ReadText());
					break;
				}
				case 4:
				{
					PrintHelpers.PrintList(Resource.resourceList);
					PrintHelpers.PrintUserInput("Pick a resource to remove");
					Resource.RemoveResource(Resource.FindResourceByName(ReadText()));
					break;
				}
			}
		}

		public static void EditResource(string nameToEdit)
		{
			Resource resource = Resource.FindResourceByName(nameToEdit);
			PrintHelpers.PrintEditOptions();
			switch (ReadNumber())
			{
				case 1:
				{
					PrintHelpers.PrintList(resource.requirementsList);
					break;
				}
				case 2:
				{
					PrintHelpers.PrintUserInput("Name of the requirement");
					var name = ReadText();
					PrintHelpers.PrintUserInput("Amount of requirement");
					var amount = ReadNumber();
					resource.AddRequirement(name, amount);
					break;
				}
				case 3:
				{
					PrintHelpers.PrintList(resource.requirementsList);
					PrintHelpers.PrintUserInput("Name of the requirement to remove");
					resource.RemoveRequirement(ReadText());
					break;
				}
			}
		}

		public static int ReadNumber()
		{
			return int.Parse(Console.ReadLine());
		}

		public static string ReadText()
		{
			return Console.ReadLine();
		}
	}
}