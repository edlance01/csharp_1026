
Lab: Introduction to Behavior-Driven Development (BDD) with Reqnroll and C#
This introductory lab guides you step-by-step through setting up, writing, and executing your first Behavior-Driven Development (BDD) test suite in C# using Reqnroll (the modern successor to SpecFlow) and xUnit.

📋 Prerequisites
Visual Studio 2022 (or Visual Studio Code) with the .NET SDK installed (.NET 8.0 or later).

Basic understanding of C# classes, methods, and properties.

📁 Final Project Structure
Upon completing this lab, your project structure will match the following layout:

Plaintext
CucumberBDDDemo/
├── CucumberBDDDemo.sln (or .slnx)
└── CucumberBDDDemo/
    ├── Calculator.cs                 # Domain / Application logic
    ├── Calculator.feature            # Gherkin human-readable feature specification
    ├── CalculatorStepDefinition.cs   # C# BDD step bindings & assertions
    ├── CucumberBDDDemo.csproj        # Project configuration & NuGet dependencies
    └── reqnroll.json                 # Reqnroll framework configuration
🚀 Step-by-Step Instructions
Step 1: Create the Project
Open Visual Studio.

Select Create a new project.

Choose xUnit Test Project (.NET) and click Next.

Set the Project name to CucumberBDDDemo.

Name the Solution CucumberBDDDemo and click Create.

💡 Note: You can delete the default UnitTest1.cs file created by Visual Studio.

Step 2: Configure Project Dependencies (CucumberBDDDemo.csproj)
In Solution Explorer, double-click CucumberBDDDemo.csproj to open the project file.

Replace its entire contents with the following configuration:

XML
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.11.1" />
    <PackageReference Include="Reqnroll" Version="2.2.1" />
    <PackageReference Include="Reqnroll.xUnit" Version="2.2.1" />
    <PackageReference Include="Reqnroll.Tools.MsBuild.Generation" Version="2.2.1" />
    <PackageReference Include="xunit" Version="2.9.2" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.8.2">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
  </ItemGroup>

</Project>
Press Ctrl + S to save the file. Visual Studio will automatically restore the required NuGet packages.

Step 3: Create the Application Logic (Calculator.cs)
Right-click the CucumberBDDDemo project in Solution Explorer.

Select Add ➔ Class...

Name the file Calculator.cs and click Add.

Paste the following C# code into Calculator.cs:

C#
namespace CucumberBDDDemo;

public class Calculator
{
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }

    public int Add()
    {
        return FirstNumber + SecondNumber;
    }
}
Step 4: Write the Feature File (Calculator.feature)
Right-click the CucumberBDDDemo project in Solution Explorer.

Select Add ➔ New Item...

Select Text File, name it Calculator.feature, and click Add.

Paste the following Gherkin specification into Calculator.feature:

Gherkin
Feature: Basic Calculator
  As a user
  I want to add two numbers together
  So that I can avoid doing mental math

  Scenario: Add two positive numbers
    Given I have entered 50 into the calculator
    And I have entered 70 into the calculator
    When I press add
    Then the result should be 120
Step 5: Implement Step Definitions (CalculatorStepDefinition.cs)
Right-click the CucumberBDDDemo project in Solution Explorer.

Select Add ➔ Class...

Name the file CalculatorStepDefinition.cs and click Add.

Add the following step binding code:

C#
using Reqnroll;
using Xunit;

namespace CucumberBDDDemo;

[Binding]
public class CalculatorStepDefinition
{
    private readonly Calculator _calculator = new Calculator();
    private int _result;

    [Given(@"I have entered {int} into the calculator")]
    public void GivenIHaveEnteredIntoTheCalculator(int number)
    {
        if (_calculator.FirstNumber == 0)
        {
            _calculator.FirstNumber = number;
        }
        else
        {
            _calculator.SecondNumber = number;
        }
    }

    [When(@"I press add")]
    public void WhenIPressAdd()
    {
        _result = _calculator.Add();
    }

    [Then(@"the result should be {int}")]
    public void ThenTheResultShouldBe(int expectedResult)
    {
        Assert.Equal(expectedResult, _result);
    }
}
Step 6: Add Reqnroll Configuration (reqnroll.json)
Right-click the project, select Add ➔ New Item...

Choose JSON File, name it reqnroll.json, and click Add.

Add the following content:

JSON
{
  "$schema": "https://schemas.reqnroll.net/reqnroll-config-latest.json",
  "language": {
    "feature": "en-US"
  }
}
🧪 Running the Tests
Method 1: Using Visual Studio Test Explorer (GUI)
Open Test Explorer: Go to Test ➔ Test Explorer (or press Ctrl + E, T).

Build the solution: Press Ctrl + Shift + B.

In Test Explorer, locate the scenario Add two positive numbers.

Click Run All (the green double arrow ▶▶).

Method 2: Using the Developer Terminal (CLI)
Open the terminal in Visual Studio: Go to View ➔ Terminal (or press Ctrl + `).

Ensure you are inside the project subfolder:

PowerShell
cd CucumberBDDDemo
Run the test command:

PowerShell
dotnet test
✅ Expected Result Output
When executed via dotnet test, you should see output similar to:

Plaintext
Passed!  - Failed: 0, Passed: 1, Skipped: 0, Total: 1, Duration: < 1 s



Your nTier Training chats aren’t used to improve our models. Gemini is AI and can make mistakes. Your privacy & GeminiOpens in a new window

# Lab: Introduction to Behavior-Driven Development (BDD) with Reqnroll and C#

This introductory lab guides you step-by-step through setting up, writing, and executing your first Behavior-Driven Development (BDD) test suite in C# using **Reqnroll** (the modern successor to SpecFlow) and **xUnit**.

---

## 📋 Prerequisites

* **Visual Studio 2022** (or Visual Studio Code) with the **.NET SDK** installed (.NET 8.0 or later).
* Basic understanding of C# classes, methods, and properties.

---

## 📁 Final Project Structure

Upon completing this lab, your project structure will match the following layout:

```text
CucumberBDDDemo/
├── CucumberBDDDemo.sln (or .slnx)
└── CucumberBDDDemo/
    ├── Calculator.cs                 # Domain / Application logic
    ├── Calculator.feature            # Gherkin human-readable feature specification
    ├── CalculatorStepDefinition.cs   # C# BDD step bindings & assertions
    ├── CucumberBDDDemo.csproj        # Project configuration & NuGet dependencies
    └── reqnroll.json                 # Reqnroll framework configuration
```

---

## 🚀 Step-by-Step Instructions

### Step 1: Create the Project

1. Open **Visual Studio**.
2. Select **Create a new project**.
3. Choose **xUnit Test Project (.NET)** and click **Next**.
4. Set the **Project name** to `CucumberBDDDemo`.
5. Name the **Solution** `CucumberBDDDemo` and click **Next**.
6. Select your target framework (e.g., **.NET 8.0** or **.NET 9.0/10.0**) and click **Create**.

> 💡 *Note: You can delete the default `UnitTest1.cs` file created by Visual Studio.*

---

### Step 2: Configure Project Dependencies (`CucumberBDDDemo.csproj`)

1. In **Solution Explorer**, double-click **`CucumberBDDDemo.csproj`** to open the project file.
2. Replace its entire contents with the following configuration:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.11.1" />
    <PackageReference Include="Reqnroll" Version="2.2.1" />
    <PackageReference Include="Reqnroll.xUnit" Version="2.2.1" />
    <PackageReference Include="Reqnroll.Tools.MsBuild.Generation" Version="2.2.1" />
    <PackageReference Include="xunit" Version="2.9.2" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.8.2">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
  </ItemGroup>

</Project>
```

3. Press **`Ctrl + S`** to save the file. Visual Studio will automatically restore the required NuGet packages.

---

### Step 3: Create the Application Logic (`Calculator.cs`)

1. Right-click the **`CucumberBDDDemo`** project in Solution Explorer.
2. Select **Add** ➔ **Class...**
3. Name the file **`Calculator.cs`** and click **Add**.
4. Paste the following C# code into `Calculator.cs`:

```csharp
namespace CucumberBDDDemo;

public class Calculator
{
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }

    public int Add()
    {
        return FirstNumber + SecondNumber;
    }
}
```

---

### Step 4: Write the Feature File (`Calculator.feature`)

1. Right-click the **`CucumberBDDDemo`** project in Solution Explorer.
2. Select **Add** ➔ **New Item...**
3. Select **Text File**, name it **`Calculator.feature`**, and click **Add**.
4. Paste the following Gherkin specification into `Calculator.feature`:

```gherkin
Feature: Basic Calculator
  As a user
  I want to add two numbers together
  So that I can avoid doing mental math

  Scenario: Add two positive numbers
    Given I have entered 50 into the calculator
    And I have entered 70 into the calculator
    When I press add
    Then the result should be 120
```

---

### Step 5: Implement Step Definitions (`CalculatorStepDefinition.cs`)

1. Right-click the **`CucumberBDDDemo`** project in Solution Explorer.
2. Select **Add** ➔ **Class...**
3. Name the file **`CalculatorStepDefinition.cs`** and click **Add**.
4. Add the following step binding code:

```csharp
using Reqnroll;
using Xunit;

namespace CucumberBDDDemo;

[Binding]
public class CalculatorStepDefinition
{
    private readonly Calculator _calculator = new Calculator();
    private int _result;

    [Given(@"I have entered {int} into the calculator")]
    public void GivenIHaveEnteredIntoTheCalculator(int number)
    {
        if (_calculator.FirstNumber == 0)
        {
            _calculator.FirstNumber = number;
        }
        else
        {
            _calculator.SecondNumber = number;
        }
    }

    [When(@"I press add")]
    public void WhenIPressAdd()
    {
        _result = _calculator.Add();
    }

    [Then(@"the result should be {int}")]
    public void ThenTheResultShouldBe(int expectedResult)
    {
        Assert.Equal(expectedResult, _result);
    }
}
```

---

### Step 6: Add Reqnroll Configuration (`reqnroll.json`)

1. Right-click the project, select **Add** ➔ **New Item...**
2. Choose **JSON File**, name it **`reqnroll.json`**, and click **Add**.
3. Add the following content:

```json
{
  "$schema": "https://schemas.reqnroll.net/reqnroll-config-latest.json",
  "language": {
    "feature": "en-US"
  }
}
```

---

## 🧪 Running the Tests

### Method 1: Using Visual Studio Test Explorer (GUI)

1. Open **Test Explorer**: Go to **Test** ➔ **Test Explorer** (or press `Ctrl + E, T`).
2. Build the solution: Press **`Ctrl + Shift + B`**.
3. In Test Explorer, locate the scenario `Add two positive numbers`.
4. Click **Run All** (the green double arrow `▶▶`).

---

### Method 2: Using the Developer Terminal (CLI)

1. Open the terminal in Visual Studio: Go to **View** ➔ **Terminal** (or press `` Ctrl + ` ``).
2. Ensure you are inside the project folder:
   ```powershell
   cd CucumberBDDDemo
   ```
3. Run the test command:
   ```powershell
   dotnet test
   ```

---

## ✅ Expected Result Output

When executed via `dotnet test`, you should see output similar to:

```text
Passed!  - Failed: 0, Passed: 1, Skipped: 0, Total: 1, Duration: < 1 s
```

---

## 💡 How It All Works Together

1. **`Calculator.feature`** defines business logic requirements using human-readable **Gherkin** syntax (`Given-When-Then`).
2. **`Reqnroll.Tools.MsBuild.Generation`** automatically converts `Calculator.feature` into a hidden C# class (`Calculator.feature.cs`) behind the scenes during compilation.
3. **`CalculatorStepDefinition.cs`** links the Gherkin steps to actual C# execution using `[Binding]`, `[Given]`, `[When]`, and `[Then]` attributes.
4. **xUnit** executes the test runner and asserts that the calculated result matches the expected outcome (`Assert.Equal`).
README.md
Displaying README.md.