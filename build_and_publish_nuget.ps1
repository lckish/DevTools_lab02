dotnet pack PowerCollections\PowerCollections\PowerCollections.csproj -c Release

$packages = Get-ChildItem PowerCollections\PowerCollections\bin\Release\*.nupkg | Sort-Object LastWriteTime

dotnet nuget push $packages[-1].fullname --api-key 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 --source "github_lckish"