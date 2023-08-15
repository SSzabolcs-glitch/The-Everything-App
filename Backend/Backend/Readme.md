Running the docker:
docker build -t your-image-name .
docker run -p 8080:80 your-image-name

Making migrations: dotnet ef migrations add InitialCreate
dotnet ef database update

making docker for database: 
docker pull mcr.microsoft.com/mssql/server
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 --memory="1g" --name sqlserver-container -d mcr.microsoft.com/mssql/server
{
"ConnectionStrings": {
"DefaultConnection": "Server=localhost,1433;Database=YourDatabase;User=sa;Password=yourStrong(!)Password;"
}
}
create network: docker network create backend-network
docker run --network=backend-network -p 8080:80 --name your-image-name -d  your-image-name
docker run --network=backend-network --name sqlserver-container -d mcr.microsoft.com/mssql/server
