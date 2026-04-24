# Movie Oscars API

Movie Oscars API is a beginner-friendly ASP.NET Core Web API project for learning:

- CRUD operations
- EF Core
- SQLite
- Swagger
- DTOs
- Services
- Controllers

It also includes a small homepage at `/` and a cinematic archive-style UI that reads from the API.

## Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI

## Features

- Create, read, update, and delete movies
- Store Oscar nominations and wins
- Track Best Picture winners
- Use DTOs for request and response models
- Use a service layer for business logic
- Use EF Core migrations for database updates
- Seed sample Oscar movie data on startup

## Project Structure

```text
Controllers/   API endpoints
Data/          EF Core DbContext
Dtos/          Request and response models
Migrations/    EF Core migration files
Models/        Entity models
Services/      Business logic layer
wwwroot/       Static homepage
```

## Running The Project

1. Clone the repository.
2. Open the project folder.
3. Run the database migration:

```powershell
dotnet ef database update
```

4. Start the app:

```powershell
dotnet run
```

## URLs

- Homepage: `http://localhost:5097/`
- Swagger: `http://localhost:5097/swagger`
- Movies API: `http://localhost:5097/api/Movies`

If you use the HTTPS launch profile, the app also runs on:

- `https://localhost:7082/`
- `https://localhost:7082/swagger`

## API Endpoints

- `GET /api/Movies`
- `GET /api/Movies/{id}`
- `POST /api/Movies`
- `PUT /api/Movies/{id}`
- `DELETE /api/Movies/{id}`

## Example Request Body

```json
{
  "title": "Oppenheimer",
  "releaseYear": 2023,
  "director": "Christopher Nolan",
  "genre": "Biography",
  "oscarNominations": 13,
  "oscarWins": 7,
  "bestPictureWinner": true
}
```

## Notes

- If you created the SQLite database before adding migrations, delete `movieoscars.db` once and run `dotnet ef database update` again.
- The app seeds sample movies only when the `Movies` table is empty.

## Next Ideas

- Add validation error responses
- Add actors and directors with relationships
- Add movie details pages on the frontend
- Add search and filtering
