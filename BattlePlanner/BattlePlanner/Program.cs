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
			var jsonLoaded=false;
			BattlePlan battlePlan = null;

			var path = GetPath(args);
			var fileHelpers = new FileHelpers(path);


			if (fileHelpers.CheckIfJsonExists())
			{
				Console.WriteLine("Json loaded!");

				battlePlan= JsonFileManip();
				jsonLoaded =true;
			}
				

			PhaseOne();

			PhaseTwo();

			if (jsonLoaded)
				 battlePlan = PhaseThreeSwitch(battlePlan);
			else
				battlePlan = PhaseThreeSwitch();

			battlePlan.CalculateSummary();
			PrintHelpers.PrintSummary(battlePlan);

			FileHelpers.GetPathAndSave(battlePlan);
		}


		private static BattlePlan PhaseThreeSwitch()
		{
			BattlePlan battlePlan = new BattlePlan(Helpers.ReadNumber());
			PrintHelpers.PrintPhase3Header();
			PhaseThree(battlePlan);
			return battlePlan;
		}
		private static BattlePlan PhaseThreeSwitch(BattlePlan battlePlan)
		{
			PrintHelpers.PrintPhase3Header();
			PhaseThree(battlePlan);
			return battlePlan;
		}

		private static void PhaseThree(BattlePlan battlePlan)
		{
			int input;
			do
			{
				PrintHelpers.PrintPhaseThree();
				input = Helpers.ReadNumber();
				Helpers.PhaseThreeUserInput(input, battlePlan);
			} while (input != PrintHelpers.NextPhase);
		}

		private static void PhaseTwo()
		{
			int input;
			PrintHelpers.PrintPhase2Header();

			do
			{
				PrintHelpers.PrintPhaseTwo();
				input = Helpers.ReadNumber();
				Helpers.PhaseTwoUserInput(input);
			} while (input != PrintHelpers.NextPhase);
		}

		private static void PhaseOne()
		{
			int input;
			PrintHelpers.PrintPhase1Header();

			do
			{
				PrintHelpers.PrintPhaseOne();
				input = Helpers.ReadNumber();
				Helpers.PhaseOneUserInput(input);
			} while (input != PrintHelpers.NextPhase);
		}

		private static BattlePlan JsonFileManip()
		{
			int input;
			BattlePlan plan = FileHelpers.LoadBattlePlan(@$"{FileHelpers.DefaultPath}{FileHelpers.FileName}");
			do
			{
				PrintHelpers.PrintLoadOptions();
				input = Helpers.ReadNumber();
				Helpers.LoadPlanUserInput(input, plan);
			} while (input != PrintHelpers.NextPhase);

			return plan;
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
