using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace BattlePlanner
{
	public class BattlePlan
	{
		[JsonProperty] public List<Unit> unitsList { get; private set; } = new List<Unit>();
		public Dictionary<string, int> summary { get; private set; }= new Dictionary<string, int>();
		public int AmountOfDays { get; }

		public BattlePlan(int amountOfDays)
		{
			AmountOfDays = amountOfDays;
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
				foreach (var resource in unit.resourceList)
				{
					foreach (var requirement in resource.resource.requirementsList)
					{
						if (!summary.ContainsKey(requirement.Key))
							AddRequirementSummary(requirement.Key);
						
						var num = requirement.Value * resource.amount * AmountOfDays;
						AddAmountSummaryAt(requirement.Key, num);
					}
				}
			}
			
		}
		public void AddRequirementSummary(string requirement)
		{
			summary.Add(requirement, 0);
		}
		public void AddAmountSummaryAt(string requirement, int amount)
		{
			summary[requirement] += amount;
		}
	}
}