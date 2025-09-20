using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LibraryManagementSystem.Helpers
{
	internal static class JsonSeeder
	{
		public static List<T> LoadFromJson<T>(string filePath)
		{
			if (!File.Exists(filePath))
				throw new FileNotFoundException($"File not found: {filePath}");
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};

			options.Converters.Add(new JsonStringEnumConverter());

			string json = File.ReadAllText(filePath);
			return JsonSerializer.Deserialize<List<T>>(json , options) ?? new List<T>();
		}
	}
}
