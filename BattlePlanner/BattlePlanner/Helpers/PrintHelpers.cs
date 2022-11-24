using System;
using System.Collections.Generic;

namespace BattlePlanner
{
	public class PrintHelpers
	{
		public const int NextPhase = 0;
		public static void PrintUserInput()
		{
			Console.Write("\nPick an option>");
		}
		public static void PrintUserInput(string inputText)
		{
			Console.Write($"\n{inputText}>");
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
		public static void PrintEditOptions()
		{
			Console.WriteLine("1:List Current Requirements\t2: Add Requirement\t3: Remove Requirement\t");
			PrintUserInput();
		}
	}
}