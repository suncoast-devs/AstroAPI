
dotnet publish -c Release 

cp dockerfile ./bin/release/netcoreapp2.1/publish

docker build -t sdg-astro-api-image ./bin/release/netcoreapp2.1/publish

docker tag sdg-astro-api-image registry.heroku.com/sdg-astro-api/web

docker push registry.heroku.com/sdg-astro-api/web

heroku container:release web -a sdg-astro-api