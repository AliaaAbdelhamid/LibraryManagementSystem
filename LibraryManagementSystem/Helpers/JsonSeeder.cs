using System.Text.Json;

namespace LibraryManagementSystem.Helpers
{
	internal static class JsonSeeder
	{
		public static List<T> LoadFromJson<T>(string filePath)
		{
			if (!File.Exists(filePath))
				throw new FileNotFoundException($"File not found: {filePath}");

			string json = File.ReadAllText(filePath);
			return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
		}
	}
}
