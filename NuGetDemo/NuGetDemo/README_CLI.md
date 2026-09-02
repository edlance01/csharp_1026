# Classroom Demo: Creating and Consuming a Local NuGet Package

This guide demonstrates how to create a simple .NET Class Library, package it as a NuGet package (`.nupkg`), and consume it locally in a separate application using Visual Studio.

---

## Part 1: Create the NuGet Package

### 1. Create the Project
Open your terminal and run the following commands to create a new Class Library:
```bash
dotnet new classlibrary -n MySimpleLogger
cd MySimpleLogger
```

### 2. Add Code to Your Package
Open the project in your code editor. Rename the default `Class1.cs` file to `Logger.cs` and add the following code:
```csharp
namespace MySimpleLogger;

public class Logger
{
    public void LogMessage(string message)
    {
        Console.WriteLine(\$"[INFO] {DateTime.Now}: {message}");
    }
}
```

### 3. Configure Package Metadata
Open the `MySimpleLogger.csproj` file. Inside the `<PropertyGroup>` tags, add the mandatory NuGet package metadata attributes:
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>

    <!-- NuGet Metadata -->
    <PackageId>YourName.MySimpleLogger</PackageId>
    <Version>1.0.0</Version>
    <Authors>YourName</Authors>
    <Company>YourCompany</Company>
    <Description>A simple console logging utility NuGet package.</Description>
    <PackageLicenseExpression>MIT</PackageLicenseExpression>
  </PropertyGroup>

</Project>
```

### 4. Pack the Project
Generate the `.nupkg` package file by running the following command in your project directory:
```bash
dotnet pack -c Release
```
This builds your project and creates the package file at:  
`bin/Release/YourName.MySimpleLogger.1.0.0.nupkg`

---

## Part 2: Publish Your Package Locally

To make this package accessible to your other projects without publishing to the public internet, follow these steps:

1. Create a dedicated folder on your computer to host your local packages (e.g., `C:\LocalNuGet`).
2. Copy the generated `.nupkg` file from your project's `bin/Release/` folder directly into `C:\LocalNuGet`.

---

## Part 3: Consume the Package in a Test App

### 1. Create a Test Project
Create a new **Console App** project in Visual Studio.

### 2. Add an Automatic NuGet Configuration File
To ensure Visual Studio automatically finds your local package folder, create a new file named `nuget.config` in the root folder of your test app (right next to your `.sln` or `.csproj` file). 

Paste the following configuration inside it:
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <!-- Keep the default public nuget repository -->
    <add key="nuget.org" value="https://nuget.org" protocolVersion="3" />
    
    <!-- Add your classroom local folder source -->
    <add key="ClassroomLocalSource" value="C:\LocalNuGet" />
  </packageSources>
</configuration>
```

> **Note:** If Visual Studio was already open, save your files, close Visual Studio, and reopen the project to force it to load the new config file.

### 3. Install the Local Package
1. Right-click your test project in the *Solution Explorer* and select **Manage NuGet Packages...**.
2. Look at the top right **Package source** dropdown. Notice that `ClassroomLocalSource` is automatically available. Select it.
3. Click the **Browse** tab.
4. Select `YourName.MySimpleLogger` and click **Install**.

### 4. Run and Test the Code
Open `Program.cs` in your test application and replace its content with the following code to run your custom library:
```csharp
using MySimpleLogger;

// Instantiate the class from your custom NuGet package
Logger logger = new Logger();
logger.LogMessage("Hello from the local NuGet package demo!");
```

Press **F5** to run the app. You will see your custom formatted log message output directly to the console window.
