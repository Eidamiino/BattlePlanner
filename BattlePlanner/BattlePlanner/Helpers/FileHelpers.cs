using System.IO;
using Newtonsoft.Json;

namespace BattlePlanner
{
	public class FileHelpers
	{
		public const string FileName = @"\battleplan.json";
		public const string DefaultPath = @"C:\Users\Default";
		public string FilePath { get; private set; }
		public FileHelpers(string filePath)
		{
			FilePath = filePath;
		}
		public static void GetPathAndSave(BattlePlan battlePlan)
		{
			var jsonString = JsonConvert.SerializeObject(battlePlan, Formatting.Indented);
			SaveBattlePlan(jsonString, GetPathSave());
		}
		public static string GetPathSave()
		{
			PrintHelpers.PrintUserInput("Where would you like to save your battle plan (path)");
			return Helpers.ReadText();
		}

		public static void SaveBattlePlan(string plan, string path)
		{
			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);

			path += $"{FileName}";
			File.WriteAllText(@$"{path}", plan);
		}


		public static BattlePlan LoadBattlePlan(string path)
		{
			BattlePlan plan = JsonConvert.DeserializeObject<BattlePlan>(File.ReadAllText(path));
			return plan;
		}

		public bool CheckIfJsonExists()
		{
			return File.Exists(@$"{FilePath}{FileName}");
		}
	}
}