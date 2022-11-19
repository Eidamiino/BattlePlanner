using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace BattlePlanner
{
	public class BattlePlan
	{
		private List<Unit> unitsList = new List<Unit>();
		private Dictionary<string, int> summary = new Dictionary<string, int>();
		public int AmountOfDays { get; }

		public BattlePlan(int amountOfDays)
		{
			AmountOfDays = amountOfDays;
		}

		public void AddResourceSummary(string requirement)
		{
			summary.Add(requirement, 0);
		}
		public void AddAmountSummaryAt(string requirement, int amount)
		{
			summary[requirement] += amount;
		}

		public void PrintSummary()
		{
			Console.WriteLine($"\nBattle Plan: {AmountOfDays} days");
			foreach (var item in summary)
			{
				Console.WriteLine($"{item.Key} - {item.Value}");
			}
		}

		public void PrintAllUnits()
		{
			foreach (var unit in unitsList)
			{
				Console.WriteLine(unit);
			}
		}
		public void AddUnit(Unit unit)
		{
			unitsList.Add(unit);
		}

		public void RemoveUnit(Unit unit)
		{
			unitsList.Remove(unit);
		}

		public void CalculateSummary()
		{
			foreach (var unit in unitsList)
			{
				foreach (var resource in unit.GetResourcesList())
				{
					foreach (var requirement in resource.Key.GetRequirementsList())
					{
						if (!summary.ContainsKey(requirement.Key))
							AddResourceSummary(requirement.Key);
						
						var num = requirement.Value * resource.Value * AmountOfDays;
						AddAmountSummaryAt(requirement.Key, num);
					}
				}
			}
			
		}
	}
}