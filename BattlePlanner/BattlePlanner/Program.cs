using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BattlePlanner
{
    internal class Program
	{
		static void Main(string[] args)
		{
			var path = GetPath(args);
			var fileHelpers = new FileHelpers(path);


			var input = 1;

			if (fileHelpers.CheckIfJsonExists())
			{
				BattlePlan plan = FileHelpers.LoadBattlePlan(@$"{FileHelpers.DefaultPath}{FileHelpers.FileName}");
				do
				{
					//PrintHelpers.PrintLoadOptions();
					input = Helpers.ReadNumber();
					Helpers.LoadPlanUserInput(input, plan);
				} while (input!= PrintHelpers.NextPhase);
			}

			PrintHelpers.PrintPhase1Header();

			do
			{
				PrintHelpers.PrintPhaseOne();
				input = Helpers.ReadNumber();
				Helpers.PhaseOneUserInput(input);
			} while (input != PrintHelpers.NextPhase);

			PrintHelpers.PrintPhase2Header();

			do
			{
				PrintHelpers.PrintPhaseTwo();
				input = Helpers.ReadNumber();
				Helpers.PhaseTwoUserInput(input);
			} while (input != PrintHelpers.NextPhase);

			PrintHelpers.PrintPhase3Header();
			BattlePlan battlePlan = new BattlePlan(Helpers.ReadNumber());

			do
			{
				PrintHelpers.PrintPhaseThree();
				input = Helpers.ReadNumber();
				Helpers.PhaseThreeUserInput(input, battlePlan);
			} while (input != PrintHelpers.NextPhase);

			battlePlan.CalculateSummary();
			PrintHelpers.PrintSummary(battlePlan);

			FileHelpers.GetPathAndSave(battlePlan);
		}

		private static string GetPath(string[] args)
		{
			string path;
			if (args.Length != 0)
				path = args[0];
			else
				path = FileHelpers.DefaultPath;
			return path;
		}
	}
}
