az login --tenant christofle.com
az acr login -n christofle
$version=(minver -t v -v e -d preview)
dotnet restore --no-cache
cd ./Hexalith.Server.Dynamics365Finance
dotnet publish /t:PublishContainer -c Release -p ContainerRegistry="christofle.azurecr.io" -p ContainerImageTag=$version
pause
