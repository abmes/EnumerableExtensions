MsBuild .\Abmes.EnumerableExtensions\Abmes.EnumerableExtensions.csproj /verbosity:minimal

NuGet pack Abmes.EnumerableExtensions.nuspec -Version $env:PackageVersion

if (-not (Test-Path "build"))
{
    mkdir build
}

Copy-Item .\*.nupkg .\build
