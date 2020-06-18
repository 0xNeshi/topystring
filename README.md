# ToPyString

ToPyString is a .NET System.Collections extension for converting collections to a string in Python format. 

The reason this small project exists is because it's a shame that C# doesn't have an in-built way of stringifying collections (like many other languages do) and although created a quick ToString method for your collections isn't big work, you shouldn't be spending time reinventing the wheel on every project... especially on ones you want to quickly try something and Console.WriteLine the output.

The extension is covered with unit tests, so you can be sure it will perform acceptably in 99.9% of cases. If you stumble upon the 0.1% when it behaves strangely, please let me know either directly or by creating an issue.

## Summary

  - [Getting Started](#getting-started)
    - [Prerequisites](#prerequisites)
    - [Installing](#installing)
  - [Using ToPyString](#using-topystring)
    - [Using ToPyString on dynamic type](#using-topystring-on-dynamic-type)
  - [Runing the tests](#running-the-tests)
    - [Break down of unit tests](#break-down-of-unit-tests)
  - [Contributing](#contributing)
  - [Versioning](#versioning)
  - [Authors](#authors)
  - [License](#license)

## Getting Started

These instructions will get you a copy of the project up and running on
your local machine for development and testing purposes. 

### Prerequisites

This package supports the .NET Standard 2.0, so any you will need .NET Core or .NET Framework versions that support the standard. You can find the .NET download page [here](https://dotnet.microsoft.com/download)

### Installing

You can get ToPyString by installing the [Collections.Extensions.ToPyString NuGet package](https://www.nuget.org/packages/Collections.Extensions.ToPyString):

```
Install-Package Collections.Extensions.ToPyString
```

Or via the .NET Core command line interface:

```
dotnet add package Collections.Extensions.ToPyString
```

## Using ToPyString

ToPyString is an extension method so you use it as such:

```csharp
var list = new List<object> { 11, "john", "doe" };

Console.WriteLine(list.ToPyString());
```

The output of the above will be:

```
[11, 'john', 'doe']
```

The extension mthod works for every C# type.

### Using ToPyString on `dynamic` type

If you are trying to print out an object of type `dynamic` or a collection that contains an object of the `dynamic` type then use `ToPyString` as a regular static method, otherwise the Runtime will throw an exception.

Example:

```csharp
dynamic dynObject = new { SomeField = 1 };

var list = new List<object> { 11, "some string", dynObject };

Console.WriteLine(Extensions.ToPyString(dynObject));
Console.WriteLine(Extensions.ToPyString(list));
```

The output will be:

```
{ SomeField = 1 }
[11, 'some string', { SomeField = 1 }]
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

## Contributing

Please read [CONTRIBUTING.md](CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to the project.

## Versioning

[SemVer](http://semver.org/) is used for versioning. For the versions available, see the [tags on this repository](https://github.com/misicnenad/dotnet-collections-extensions-topystring/tags).

## Authors

* **Nenad Misic** - *Initial work* - [misicnenad](https://github.com/misicnenad)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
