using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiPrimerWebApi.Contexto;
using MiPrimerWebApi.Entidades;

namespace MiPrimerWebApi.Routes
{
    public static class TodosRoute
    {
        public static WebApplication MapTodosRoutes(this WebApplication app)
        {
            var group = app.MapGroup("Todos")
                .WithTags("Todos");

            group.MapGet("/", Get);
            group.MapPost("/", Post);
            group.MapGet("/{id}", GetOne).WithName("GetOne");
            group.MapPut("/{id}", Put);
            group.MapDelete("/{id}", Delete);

            return app;
        }

        public static async Task<IResult> Get(TodoDbContext context)
        {
            var todos = await context.Todos.ToListAsync();
            return Results.Ok(todos);
        }

        public static async Task<IResult> GetOne(TodoDbContext context, [FromRoute] int id)
        {
            var todo = await context.Todos.FindAsync(id);

            if (todo == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(todo);
        }

        public static async Task<IResult> Post(TodoDbContext context, [FromBody] Todo todo)
        {
            context.Todos.Add(todo);
            await context.SaveChangesAsync();

            return Results.CreatedAtRoute(nameof(GetOne), new { id = todo.Id }, todo);
        }

        public static async Task<IResult> Put(TodoDbContext context, [FromRoute] int id, [FromBody] Todo todo)
        {
            if (id != todo.Id)
            {
                return Results.BadRequest();
            }

            context.Entry(todo).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!context.Todos.Any(todo=> todo.Id ==id))
                {
                    return Results.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Results.NoContent();
        }

        public static async Task<IResult> Delete(TodoDbContext context, [FromRoute] int id)
        {
            var todo = await context.Todos.FindAsync(id);
            if (todo == null)
            {
                return Results.NotFound();
            }

            context.Todos.Remove(todo);
            await context.SaveChangesAsync();

            return Results.NoContent();
        }

    }
}