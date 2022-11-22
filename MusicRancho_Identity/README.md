# Music Rancho Identity

These are the available actions for Identity Database for Music Rancho project:

    Drop database
    Update database

Run the following commands in Nuget Package Console:

## Drop database

    dotnet ef database drop -c IdentityDbContext --project .\MusicRancho_Identity -f -v
    dotnet ef database drop  -c ApplicationDbContext --project .\MusicRancho_RanchoAPI -f -v

If no migrations exist or you deleted the migration folders on both projects and run the above commands to delete the database:

    dotnet ef migrations add InitialIdentity -c IdentityDbContext --project .\MusicRancho_Identity
    dotnet ef migrations add InitialApp -c ApplicationDbContext --project .\MusicRancho_RanchoAPI

## Update database

Then update to create the database

    dotnet ef database update -c IdentityDbContext --project .\MusicRancho_Identity
    dotnet ef database update -c ApplicationDbContext --project .\MusicRancho_RanchoAPI

Then on if (_roleManager.FindByNameAsync(SD.Admin).Result == null) the first time the app runs, let that pice of code to run.
