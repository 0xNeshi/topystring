# ToPyString

[![Build & Test .NET Library](https://github.com/0xNeshi/topystring/actions/workflows/build-dotnet-core.yml/badge.svg)](https://github.com/0xNeshi/topystring/actions/workflows/build-dotnet-core.yml)
[![NuGet](https://img.shields.io/nuget/v/Collections.Extensions.ToPyString?logo=nuget)](https://www.nuget.org/packages/Collections.Extensions.ToPyString)
[![License](https://img.shields.io/github/license/misicnenad/topystring?color=yellow)](https://opensource.org/licenses/MIT)
[![Contributions Welcome](https://img.shields.io/badge/contributions-welcome-brightgreen)](https://github.com/0xNeshi/topystring/issues)

ToPyString is a .NET System.Collections extension for converting collections to a string in Python format. Actually you can use the extension to turn any .NET type into a Python format!

The reason this small project exists is because it's a shame that C# doesn't have an in-built way of stringifying collections (like many other languages do). Although creating a ToString method for your collections isn't difficult, you shouldn't be wasting time implementing rudimentary things on every project... especially on projects you're using to just quickly try something out and Console.WriteLine the output.

## Summary

- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installing](#installing)
- [Using ToPyString](#using-topystring)
- [Runing the tests](#running-the-tests)
- [Break down of unit tests](#break-down-of-unit-tests)
- [Contact](#contact)
- [Contributing](#contributing)
- [Authors](#authors)
- [License](#license)

## Getting Started

Follow these instructions to see how simple it is to use ToPyString.

### Prerequisites

This package supports the .NET Standard 2.0, so you will need any of the .NET Core or .NET Framework [versions](https://docs.microsoft.com/en-us/dotnet/standard/net-standard#net-implementation-support) that support the standard.

You can find the .NET download page [here](https://dotnet.microsoft.com/download).

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

_ToPyString_ is an extension method that can be used on all .NET types.

_List:_

```csharp
var list = new List<object> { 11, "john", "doe" };

Console.WriteLine(list.ToPyString()); // Output: [11, 'john', 'doe']
```

_Self-containing List:_

```csharp
var list = new List<object> { 11 };
list.Add(list);

Console.WriteLine(list.ToPyString()); // Output: [11, [...]]
```

_Dictionary:_

```csharp
var dictionary = new Dictionary<object, object> { [1] = "key1", ["key2"] = 2, [new object()] = null };

Console.WriteLine(dictionary.ToPyString()); // Output: {1: 'key1', 'key2': 2, System.Object: null}
```

_Self-containing Dictionary:_

```csharp
var dictionary = new Dictionary<object, object> { [1] = "key1" };
dictionary.Add("self", dictionary);

Console.WriteLine(dictionary.ToPyString()); // Output: {1: 'key1', 'self': {...}}
```

_String and primitive types:_

```csharp
var str = "some string";
var intNum = 11;
var doubleNum = 1.012d;

Console.WriteLine(str.ToPyString()); // Output: some string
Console.WriteLine(intNum.ToPyString()); // Output: 11
Console.WriteLine(doubleNum.ToPyString()); // Output: 1.012
```
---

### Be careful when using ToPyString with _dynamic_ type

Because of the way _dynamic_ type is implemented the CLR will throw a _RuntimeBinderException_ if you try to call the _ToPyString_ extension method directly on a _dynamic_ object. To get around this issue simply use _ToPyString_ as a regular static method.

**_Wrong use with _dynamic_:_**

```csharp
dynamic dynObject = new { SomeField = 1 };

Console.WriteLine(dynObject.ToPyString()); // --> will throw a RuntimeBinderException
```

**_Correct use:_**

```csharp
dynamic dynObject = new { SomeField = 1 };

Console.WriteLine(CollectionExtensions.ToPyString(dynObject)); // Output: { SomeField = 1 }
```

If you have a collection that contains a _dynamic_ object, you can use the _ToPyString_ as usual:

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

## Authors

- **Nenad** - [0xNeshi](https://github.com/0xNeshi)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Final thoughts

If you found this extension helpfull then please give it a star 🌟 and share it with others, help them so they also NOT waste time on stringifying collections.

Finally, if you have any suggestions on refactoring the codebase to make it simpler, more extensible, more elegant - please let me know, I LOVE refactoring! 
