using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using TemperaturyAPI.Database;
using TemperaturyAPI.middleware;
using TemperaturyAPI.Models;

namespace TemperaturyAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
        });
        builder.Services.AddDbContext<PgsqlDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("Pgsql"));
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();
        app.UseMiddleware<apikeymiddleware>();

        app.UseAuthorization();


        app.MapControllers();
   
        app.Run();
    }
}
public class DateOnlyJsonConverter : JsonConverter<DateOnly>
{
    private const string Format = "yyyy-MM-dd";

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateOnly.ParseExact(reader.GetString()!, Format, CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
    }
}
