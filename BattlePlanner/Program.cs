using System;

namespace BattlePlanner
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Helpers.PrintPhase1Header();

			var input=1;
			do
			{
				Helpers.PrintPhaseOne();
				input = Helpers.ReadNumber();
				Helpers.PhaseOneUserInput(input);
			} while (input != Helpers.NextPhase);
			input = 1;

			Helpers.PrintPhase2Header();

			do
			{
				Helpers.PrintPhaseTwo();
				input = Helpers.ReadNumber();
				Helpers.PhaseTwoUserInput(input);
			} while (input != Helpers.NextPhase);
			input = 1;

			Helpers.PrintPhase3Header();
			BattlePlan battlePlan = new BattlePlan(Helpers.ReadNumber());

			do
			{
				Helpers.PrintPhaseThree();
				input = Helpers.ReadNumber();
				Helpers.PhaseThreeUserInput(input, battlePlan);
			} while (input != Helpers.NextPhase);
			input = 1;
			
			battlePlan.CalculateSummary();
			battlePlan.PrintSummary();

		}
	}
}
