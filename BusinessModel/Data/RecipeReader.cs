using System.Text.Json.Serialization;
using System.Text.Json;
using BusinessModel.Models;
using BusinessLogic.Models.Enums;

namespace BusinessModel.Data
{
    public class RecipeReader
    {
        public static List<Recipe> FromJsonFile(string filename = "Data\\RecipeData.json")
        {
            try
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
                var json = File.ReadAllText(path);
                var options = new JsonSerializerOptions
                {
                    Converters =
                    {
                        new StringArrayConverter(),
                        new JsonStringEnumConverter<Difficulty>(),
                        new JsonStringEnumConverter<MealType>(),
                    },
                    PropertyNameCaseInsensitive = true
                };

                return JsonSerializer.Deserialize<List<Recipe>>(json, options);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to read {filename}", ex);
            }

            return null;
        }
    }

    public class StringArrayConverter : JsonConverter<string>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartArray)
            {
                var values = new List<string>();
                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                {
                    values.Add(reader.GetString());
                }
                return string.Join(";", values);
            }
            else
            {
                return reader.GetString();
            }
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }
}
