namespace LifeRoutineV0.Api.Endpoints;

public static class AppExtension
{
    public static void AdicionarSwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}