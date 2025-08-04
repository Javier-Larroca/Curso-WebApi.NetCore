using Microsoft.AspNetCore.Mvc;
using MiPrimerWebApi.Middlewares;

namespace MiPrimerWebApi.Api.Routes
{
    public static class ValuesRoute
    {
        public static List<string> Values = ["Value 1", "Value 2"];
        public static WebApplication MapValuesRoutes(this WebApplication app)
        {
            var group = app.MapGroup("minimalValues")
                .WithTags("Minimal Values")
                .AddEndpointFilter<MinimalLoggerFilter>();

            group.MapGet("/", Get);
            group.MapPost("/", Post);
            group.MapGet("/{indice}", GetOne);
            group.MapPut("/{indice}", Put);
            group.MapDelete("/{indice}", Delete);

            return app;
        }

        public static IResult Get()
        {
            return Results.Ok(Values);
        }

        public static IResult GetOne([FromRoute] int indice)
        {
            if (indice >= Values.Count)
            {
                return Results.BadRequest("Indice fuera de rango");
            }
            return Results.Ok(Values[indice]);
        }

        public static IResult Post()
        {
            var newValue = $"Value {Values.Count + 1}";
            Values.Add(newValue);
            return Results.Created();
        }

        public static IResult Put([FromRoute] int indice)
        {
            if (indice >= Values.Count)
            {
                return Results.BadRequest("Indice fuera de rango");
            }
            Values[indice] += " - Modificado";
            return Results.Ok(Values[indice]);
        }

        public static IResult Delete([FromRoute] int indice)
        {
            if (indice >= Values.Count)
            {
                return Results.BadRequest("Indice fuera de rango");
            }
            Values.RemoveAt(indice);
            return Results.NoContent();
        }

    }
}