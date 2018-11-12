dotnet publish -c Release 

cp dockerfile ./bin/release/netcoreapp2.1/publish

docker build -t cohort-x-cartoons-image ./bin/release/netcoreapp2.1/publish

docker tag cohort-x-cartoons-image registry.heroku.com/cohort-x-cartoons/web

docker push registry.heroku.com/cohort-x-cartoons/web

heroku container:release web -a cohort-x-cartoons