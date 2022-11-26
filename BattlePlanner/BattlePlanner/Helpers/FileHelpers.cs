using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using BinaryPack;
using Newtonsoft.Json;

namespace BattlePlanner
{
	public class FileHelpers
	{
		public const string FileNameJson = @"\battleplan.json";
		public const string FileNameDat = @"\DataFile.dat";
		public const string DefaultPath = @"C:\Users\Default";
		public string FilePath { get; private set; }
		public FileHelpers(string filePath)
		{
			FilePath = filePath;
		}
		public static void GetPathAndSave(BattlePlan battlePlan)
		{
			var jsonString = JsonConvert.SerializeObject(battlePlan, Formatting.Indented);
			SaveBattlePlanJson(jsonString, GetPathSave());
		}
		public static void GetPathAndSaveBinary(BattlePlan battlePlan)
		{
			SaveBattlePlanBinary(battlePlan, GetPathSave("Where would you like to save your battle plan (path)[binary]"));
		}
		public static string GetPathSave(string message = "Where would you like to save your battle plan (path)[json]")
		{
			PrintHelpers.PrintUserInput(message);
			return Helpers.ReadText();
		}

		public static void SaveBattlePlanJson(string plan, string path)
		{
			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);

			path += $"{FileNameJson}";
			File.WriteAllText(@$"{path}", plan);
		}
		public static void SaveBattlePlanBinary(BattlePlan battlePlan, string path)
		{
			path += $"{FileNameDat}";
			FileStream fs = new FileStream(path, FileMode.Create);
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(fs, battlePlan);
			//var planToSave=BinaryConverter.Serialize(battlePlan);
			//File.WriteAllBytes(path, planToSave);
		}

		public static BattlePlan LoadBattlePlanJson(string path)
		{
			BattlePlan plan = JsonConvert.DeserializeObject<BattlePlan>(File.ReadAllText(path));
			return plan;
		}
		public static BattlePlan LoadBattlePlanDat(string path)
		{
			FileStream fs = new FileStream(path, FileMode.Open);
			BinaryFormatter formatter = new BinaryFormatter();
			var plan = (BattlePlan)formatter.Deserialize(fs);
			//var plan = BinaryConverter.Deserialize<BattlePlan>(File.ReadAllBytes(path));
			return plan;
		}

		public bool CheckIfJsonExists()
		{
			return File.Exists(@$"{FilePath}{FileNameJson}");
		}
		public bool CheckIfDatExists()
		{
			return File.Exists(@$"{FilePath}{FileNameDat}");
		}
	}
}