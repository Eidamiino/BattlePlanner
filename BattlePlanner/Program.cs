using System;

namespace BattlePlanner
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Helpers.PrintPhase1Header();

			var input1=1;
			var input2=1;
			var input3=1;
			do
			{
				Helpers.PrintPhaseOne();
				input1 = Helpers.ReadNumber();
				Helpers.PhaseOneUserInput(input1);
			} while (input1 != 0);

			Helpers.PrintPhase2Header();

			do
			{
				Helpers.PrintPhaseTwo();
				input2 = Helpers.ReadNumber();
				Helpers.PhaseTwoUserInput(input2);
			} while (input2 != 0);

			Helpers.PrintPhase3Header();
			BattlePlan battlePlan = new BattlePlan(Helpers.ReadNumber());

			do
			{
				Helpers.PrintPhaseThree();
				input3 = Helpers.ReadNumber();
				Helpers.PhaseThreeUserInput(input3, battlePlan);
			} while (input3 != 0);

			battlePlan.CalculateSummary();
			battlePlan.PrintSummary();

		}
	}
}
