# ToPyString

<a href="https://github.com/misicnenad/topystring/actions?query=workflow%3ABuild" target="_blank"><img src="https://img.shields.io/github/workflow/status/misicnenad/topystring/Build" alt="download" /></a>
<a href="https://github.com/misicnenad/topystring/actions?query=workflow%3ATests" target="_blank"><img src="https://img.shields.io/github/workflow/status/misicnenad/topystring/Test?label=Tests&logo=github" alt="download" /></a>
<a href="https://www.nuget.org/packages/Collections.Extensions.ToPyString" target="_blank"><img src="https://img.shields.io/nuget/v/Collections.Extensions.ToPyString?logo=nuget" alt="download" /></a>
<a href="https://opensource.org/licenses/MIT" target="_blank"><img src="https://img.shields.io/github/license/misicnenad/topystring?color=yellow" alt="download" /></a>
<a href="https://github.com/misicnenad/topystring/issues" target="_blank"><img src="assets/contributions.svg" alt="contributions" /></a>

ToPyString is a .NET System.Collections extension for converting collections to a string in Python format. Actually you can use the extension to turn any .NET type into a Python format!

The reason this small project exists is because it's a shame that C# doesn't have an in-built way of stringifying collections (like many other languages do). Although creating a ToString method for your collections isn't difficult, you shouldn't be wasting time implementing rudimentary things on every project... especially on projects you're using to just quickly try something out and Console.WriteLine the output.

The extension is covered with unit tests, so you can be sure it will perform acceptably in 99.9% of cases. If you stumble upon the 0.1% of cases when it behaves strangely, please let me know either directly or by creating an issue.

## Summary

- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installing](#installing)
- [Using ToPyString](#using-topystring)
- [Runing the tests](#running-the-tests)
- [Break down of unit tests](#break-down-of-unit-tests)
- [Contact](#contact)
- [Contributing](#contributing)
- [Versioning](#versioning)
- [Authors](#authors)
- [License](#license)

## Getting Started

Follow these instructions to see how simple it is to use ToPyString.

### Prerequisites

This package supports the .NET Standard 2.0, so you will need any of the .NET Core or .NET Framework versions that support the standard ([here](https://docs.microsoft.com/en-us/dotnet/standard/net-standard#net-implementation-support) is a table of supported versions).

You can find the .NET download page [here](https://dotnet.microsoft.com/download).

These are prerequisistes to using ToPyString whether you want to simply use the package in you projects or you want to download ToPyString on your local machine for development and testing purposes.

### Installing

You can get ToPyString by installing the [Collections.Extensions.ToPyString](https://www.nuget.org/packages/Collections.Extensions.ToPyString) NuGet package:

```
Install-Package Collections.Extensions.ToPyString
```

Or via the .NET Core command line interface:

```
dotnet add package Collections.Extensions.ToPyString
```

## Using ToPyString

ToPyString is an extension method so you should use it as such:

```csharp
var list = new List<object> { 11, "john", "doe" };

Console.WriteLine(list.ToPyString()); // Output: [11, 'john', 'doe']
```

The extension method works for every C# type.

---

### Be careful when using ToPyString with `dynamic` type

Because of the way `dynamic` type is implemented the CLR will throw a RuntimeBinderException if you try to call the ToPyString extensions method directly on a `dynamic` object. To get around this issue simply use `ToPyString` as a regular static method.

**_Wrong use with `dynamic`:_**

```csharp
dynamic dynObject = new { SomeField = 1 };

Console.WriteLine(dynObject.ToPyString()); // --> will throw a RuntimeBinderException
```

**_Correct use:_**

```csharp
dynamic dynObject = new { SomeField = 1 };

Console.WriteLine(Extensions.ToPyString(dynObject)); // Output: { SomeField = 1 }
```

If you have a collection that contains a `dynamic` object, you can use the ToPyString as usual:

```csharp
dynamic dynObject = new { SomeField = 1 };
var list = new List<object> { dynObject };

Console.WriteLine(list.ToPyString()); // Output: [{ SomeField = 1 }]
```

## Running the tests

To run the tests using the command line use:

```
dotnet test
```

Alternatively, if you're using Visual Studio you have a button that runs the tests for you, so you can also use that.

### Break down of unit tests

The tests are mainly testing whether both C# Collections and non-collection types are converted to string in the expected Python format

```csharp
[Fact]
public void Prints_List_Of_Ints()
{
    var list = new List<int> { 1, 2, -3, 100 };
    var expectedResult = "[1, 2, -3, 100]";

    var result = list.ToPyString();

    Assert.Equal(expectedResult, result);
}
```

## Contact

Have a question or an issue about ToPyString? Create an [issue](https://github.com/misicnenad/topystring/issues/new)!

## Contributing

Please read [CONTRIBUTING.md](CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to the project.

If you found this extension helpfull then do give it a star and share it with others!

## Authors

- **Nenad Misic** - [misicnenad](https://github.com/misicnenad)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
