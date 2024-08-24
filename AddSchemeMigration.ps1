$MigrationName = Read-Host "Please, enter Migration name"

dotnet ef migrations add $MigrationName -c ForpostContextPostgres -o .\Migrations -s src/Store.Migrations  -v -- --CreateMigrationOnly

Read-Host -Prompt "Press Enter to exit"