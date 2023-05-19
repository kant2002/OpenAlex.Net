# OpenAlex.Net

C# API for accessing [OpenAlex data](https://openalex.org).

# Maintenance

```
dotnet pack -c Release /p:VersionSuffix=
dotnet nuget push OpenAlexNet\bin\Release\OpenAlexNet.0.0.4.nupkg -s nuget.org --api-key 
```