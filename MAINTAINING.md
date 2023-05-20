# Maintenance

```
dotnet pack OpenAlexNet -c Release /p:VersionSuffix=
dotnet nuget push OpenAlexNet\bin\Release\OpenAlexNet.0.0.4.nupkg -s nuget.org --api-key 
```