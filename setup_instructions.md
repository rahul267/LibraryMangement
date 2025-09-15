# Setup Instructions

## Restore Dependencies
Run the following command to restore dependencies for the solution:
```
dotnet restore
```

## Build Solution
Build the solution to ensure there are no errors:
```
dotnet build --configuration Release
```

## Run Tests
Execute the tests to establish a baseline:
```
dotnet test --no-build --verbosity minimal
```

## Generate Coverage Report
Run the following command to generate a coverage report:
```
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
```