using Microsoft.EntityFrameworkCore;
using MovieOscarsApi.Data;
using MovieOscarsApi.Models;
using MovieOscarsApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMovieService, MovieService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
    SeedMovies(dbContext);
}

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();

static void SeedMovies(AppDbContext dbContext)
{
    if (dbContext.Movies.Any())
    {
        return;
    }

    dbContext.Movies.AddRange(
        new Movie
        {
            Title = "The Godfather",
            ReleaseYear = 1972,
            Director = "Francis Ford Coppola",
            Genre = "Crime",
            OscarNominations = 11,
            OscarWins = 3,
            BestPictureWinner = true
        },
        new Movie
        {
            Title = "Titanic",
            ReleaseYear = 1997,
            Director = "James Cameron",
            Genre = "Romance",
            OscarNominations = 14,
            OscarWins = 11,
            BestPictureWinner = true
        },
        new Movie
        {
            Title = "La La Land",
            ReleaseYear = 2016,
            Director = "Damien Chazelle",
            Genre = "Musical",
            OscarNominations = 14,
            OscarWins = 6,
            BestPictureWinner = false
        },
        new Movie
        {
            Title = "Parasite",
            ReleaseYear = 2019,
            Director = "Bong Joon Ho",
            Genre = "Thriller",
            OscarNominations = 6,
            OscarWins = 4,
            BestPictureWinner = true
        },
        new Movie
        {
            Title = "Oppenheimer",
            ReleaseYear = 2023,
            Director = "Christopher Nolan",
            Genre = "Biography",
            OscarNominations = 13,
            OscarWins = 7,
            BestPictureWinner = true
        });

    dbContext.SaveChanges();
}
