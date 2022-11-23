using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BattlePlanner
{
	public class Helpers
	{
		public const int NextPhase = 0;
		public const string FileName = @"\battleplan.json";
		public const string DefaultPath = @"C:\Users\Adam\Desktop\battlePlannerTest";
		public static int GetRandom(int min, int max)
		{
			Random rand = new Random();
			return rand.Next(min, max);
		}
		public static void PrintUserInput()
		{
			Console.Write("\nPick an option>");
		}
		public static void PrintUserInput(string inputText)
		{
			Console.Write($"\n{inputText}>");
		}

		public static string GetPathSave()
		{
			PrintUserInput("Where would you like to save your battle plan (path)");
			return ReadText();
		}

		public static void SaveBattlePlan(string plan,string path)
		{
			path+=($"{FileName}");
			File.WriteAllText(@$"{path}", plan);
		}

		public static BattlePlan LoadBattlePlan(string path)
		{
			BattlePlan plan = JsonConvert.DeserializeObject<BattlePlan>(File.ReadAllText(path));
			return plan;
		}

		public static bool CheckIfJsonExists()
		{
			return File.Exists(@$"{DefaultPath}{FileName}");
		}

		public static void GetPathAndSave(BattlePlan battlePlan)
		{
			string jsonString = JsonConvert.SerializeObject(battlePlan, Formatting.Indented);
			SaveBattlePlan(jsonString, GetPathSave());
		}
		public static void PrintSummary(BattlePlan plan)
		{
			Console.WriteLine($"\nBattle Plan: {plan.AmountOfDays} days");
			PrintList(plan.summary, (item) => $"{item.Key} - {item.Value}");
		}
		public static void PrintList<T>(IEnumerable<T> list)
		{
			foreach (var item in list)
			{
				Console.WriteLine(item);
			}
		}
		public static void PrintList<T>(IEnumerable<T> list, Func<T, string> printFunc)
		{
			foreach (var item in list)
			{
				Console.WriteLine(printFunc(item));
			}
		}
		public static void PrintPhase1Header()
		{
			Console.WriteLine("Battle Planner 3000!\n" +
			                  "Phase 1: Resource Config");
		}
		public static void PrintPhase2Header()
		{
			Console.WriteLine("\nPhase 2: Unit Config");
		}
		public static void PrintPhase3Header()
		{
			Console.WriteLine("\nPhase 3: Battle plan");
			Console.WriteLine("Enter the amount of days:");
		}
		public static void PrintLoadOptions()
		{
			Console.WriteLine($"\n{NextPhase}: Continue\n" +
			                  $"1: Clear all data\n" +
			                  $"2: Clear units\n" +
			                  $"3: Clear resources\n");
			PrintUserInput();
		}
		public static void PrintFurtherLoadOptions()
		{
			Console.WriteLine($"\n1: Delete with definitions\n" +
			                  $"2: Leave definitions\n");
			PrintUserInput();
		}
		public static void PrintPhaseOne()
		{
			Console.WriteLine($"\n{NextPhase}: Next phase\n" +
			                  "1: List all resources\n" +
			                  "2: Add a new resource\n" +
			                  "3: Edit a resource\n" +
			                  "4: Remove a resource");
			PrintUserInput();
		}

		public static void PrintPhaseTwo()
		{
			Console.WriteLine($"\n{NextPhase}: Next phase\n" +
			                  "1: List all units\n" +
			                  "2: Add a new unit\n" +
			                  "3: Add resource to unit\n" +
			                  "4: Remove a resource from unit\n" +
			                  "5: Remove a unit");
			PrintUserInput();
		}
		public static void PrintPhaseThree()
		{
			Console.WriteLine($"\n{NextPhase}: Next phase\n" +
			                  "1: List current units\n" +
			                  "2: Add a unit\n" +
			                  "3: Add all\n" +
			                  "4: Remove a unit");
			PrintUserInput();
		}

		public static void LoadUserInput(int input, BattlePlan battlePlan)
		{
			switch (input)
			{
				case 1:
				{
					battlePlan = null;//nefunguje
					break;
				}
				case 2:
				{
					PrintFurtherLoadOptions();
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
					break;
				}
				case 3:
				{
					PrintFurtherLoadOptions();
					switch (ReadNumber())
					{
						case 1:
						{
							battlePlan.unitsList.ForEach(x => x.resourceList.Clear());
							Resource.resourceList.ForEach(x=>x.requirementsList.Clear());
							break;
						}
						case 2:
						{
							battlePlan.unitsList.ForEach(x => x.resourceList.Clear());
							break;
						}
					}
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
					PrintList(battlePlan.unitsList);
					break;
				}
				case 2:
				{
					PrintList(Unit.unitList);
					PrintUserInput("ID of a unit to add");
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
					PrintList(battlePlan.unitsList);
					PrintUserInput("ID of a unit to remove");
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
					PrintList(Unit.unitList);
					break;
				}
				case 2:
				{
					PrintUserInput("Name of the unit");
					Unit unit = new Unit(ReadText());
					break;
				}
				case 3:
				{
					PrintList(Unit.unitList);
					PrintUserInput("ID of the unit to add the resource to");
					Unit unit = Unit.FindUnitById(ReadText());

					PrintList(Resource.resourceList);
					PrintUserInput("Name of the resource to add");
					var resource = Resource.FindResourceByName(ReadText());
					PrintUserInput("Amount of resource");
					var resourceAmount = ReadNumber();

					unit.AddToResourceList(resource, resourceAmount);
					break;
				}
				case 4:
				{
					PrintList(Unit.unitList);
					PrintUserInput("ID of the unit to remove the resource from");
					Unit unit = Unit.FindUnitById(ReadText());
					Console.WriteLine(unit);

					PrintUserInput("Name of the resource to delete");
					unit.RemoveResource(Resource.FindResourceByName(ReadText()));
					break;
				}
				case 5:
				{
					PrintList(Unit.unitList);
					PrintUserInput("ID of the unit to remove");
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
					PrintList(Resource.resourceList);
					break;
				}
				case 2:
				{
					PrintUserInput("Name of the resource");
					Resource resource = new Resource(ReadText());
					break;
				}
				case 3:
					{
						PrintList(Resource.resourceList);
						PrintUserInput("Pick a resource to edit");
						EditResource(ReadText());
						break;
				}
				case 4:
				{
					PrintList(Resource.resourceList);
					PrintUserInput("Pick a resource to remove");
					Resource.RemoveResource(Resource.FindResourceByName(ReadText()));
					break;
				}
			}
		}
		public static void EditResource(string nameToEdit)
		{
			Resource resource = Resource.FindResourceByName(nameToEdit);
			PrintEditOptions();
			switch (ReadNumber())
			{
				case 1:
				{
					PrintList(resource.requirementsList);
					break;
				}
				case 2:
				{
					PrintUserInput("Name of the requirement");
					var name = ReadText();
					PrintUserInput("Amount of requirement");
					var amount = ReadNumber();
					resource.AddRequirement(name, amount);
					break;
				}
				case 3:
				{
					PrintList(resource.requirementsList);
					PrintUserInput("Name of the requirement to remove");
					resource.RemoveRequirement(ReadText());
					break;
				}
			}
		}

		public static void PrintEditOptions()
		{
			Console.WriteLine("1:List Current Requirements\t2: Add Requirement\t3: Remove Requirement\t");
			PrintUserInput();
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