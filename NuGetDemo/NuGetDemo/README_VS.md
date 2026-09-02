# Classroom Demo: Creating and Consuming a Local NuGet Package (Visual Studio Edition)

This guide demonstrates how to create a simple .NET Class Library, package it as a NuGet package (`.nupkg`), and consume it locally in a separate application—all entirely within Visual Studio.

---

## Part 1: Create the NuGet Package Project

### 1. Create a New Project
1. Open Visual Studio and select **Create a new project**.
2. Search for **Class Library**, select the C# template, and click **Next**.
3. Name the project `MySimpleLogger` and click **Next**.
4. Choose **.NET 8.0 (Long-term support)** (or your current classroom version) and click **Create**.

### 2. Add Code to Your Package
1. In the *Solution Explorer*, right-click `Class1.cs` and rename it to `Logger.cs`. Select **Yes** when asked to rename all references.
2. Replace the file contents with the following code:
```csharp
namespace MySimpleLogger;

public class Logger
{
    public void LogMessage(string message)
    {
        Console.WriteLine($"[INFO] {DateTime.Now}: {message}");
    }
}
```

### 3. Configure Package Metadata
1. In the *Solution Explorer*, **double-click** the project name (`MySimpleLogger`) to open its project configuration file (`.csproj`).
2. Inside the `<PropertyGroup>` tags, paste the mandatory NuGet metadata fields:
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
3. Save the file (**Ctrl + S**).

### 4. Build and Pack the Project
1. In the top toolbar, change the build configuration dropdown from **Debug** to **Release**.
2. Right-click the `MySimpleLogger` project name in the *Solution Explorer* and select **Pack**.
3. Look at the *Output Window* at the bottom. It will show that it successfully created a file named `YourName.MySimpleLogger.1.0.0.nupkg`.

---

## Part 2: Publish Your Package Locally

To make this package accessible to your other projects without publishing to the public internet, place it in a local directory:

1. Right-click your project name in *Solution Explorer* and choose **Open Folder in File Explorer**.
2. Navigate into the **bin** folder, then into the **Release** folder. You will see your `.nupkg` file there.
3. Create a dedicated folder on your computer to host your local packages (e.g., `C:\LocalNuGet`).
4. **Copy** your `.nupkg` file from the project's folder and **paste** it directly into `C:\LocalNuGet`.

---

## Part 3: Consume the Package in a Test App

### 1. Create a Test Project
1. Open a new instance of Visual Studio (or add a new project to your existing solution).
2. Create a new **Console App** project.

### 2. Add an Automatic NuGet Configuration File
To ensure Visual Studio automatically finds your local package folder without manual clicking, create a configuration file:
1. Right-click your Console App project name in the *Solution Explorer*, select **Add**, and choose **New Item**.
2. Search for **text file**, name it `nuget.config`, and click **Add**.
3. Replace the entire content of the file with this configuration text:
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
4. Save and close the file.
5. **Important:** Close this Visual Studio window and reopen your project. This forces Visual Studio to process the new configuration file.

### 3. Install the Local Package
1. Right-click your Console App project in the *Solution Explorer* and select **Manage NuGet Packages...**.
2. Look at the top-right **Package source** dropdown. Notice that `ClassroomLocalSource` is automatically available. **Select it**.
3. Click the **Browse** tab in the top left.
4. Select `YourName.MySimpleLogger` from the list and click **Install** on the right side panel. Click **Apply** if prompted.

### 4. Run and Test the Code
1. Open `Program.cs` in your test application and replace its content with the following code:
```csharp
using MySimpleLogger;

// Instantiate the class from your custom NuGet package
Logger logger = new Logger();
logger.LogMessage("Hello from the local NuGet package demo!");
```
2. Press **F5** (or click the green Play button) to run the application. 

You will see your custom formatted log message output directly to the console window:
```text
[INFO] 10/24/2023 2:30:15 PM: Hello from the local NuGet package demo!
```
