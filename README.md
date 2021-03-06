# DotNetHelper.Serialization.Abstractions

#### *DotNetHelper.Serialization.Abstractions is a lightweight serialization library. One serializer/deserializer interface. This library come with an ISerializer interface and an implementation of a binary serializer* 

|| [**Documentation**][Docs] � [**API**][Docs-API] � [**Tutorials**][Docs-Tutorials] ||  [**Change Log**][Changelogs] � || [**View on Github**][Github]|| 

| Package  | Tests | Code Coverage |
| :-----:  | :---: | :------: |
| ![Build Status][nuget-downloads]  | ![Build Status][tests]  | [![codecov](https://codecov.io/gh/TheMofaDe/DotNetHelper.Serialization.Abstractions/branch/master/graph/badge.svg)](https://codecov.io/gh/TheMofaDe/DotNetHelper.Serialization.Abstractions) |


| Continous Integration | Windows | Linux | MacOS | 
| :-----: | :-----: | :-----: | :-----: |
| **AppVeyor** | [![Build status](https://ci.appveyor.com/api/projects/status/9mog32m4mejqyd3i?svg=true)](https://ci.appveyor.com/project/TheMofaDe/dotnethelper-database)  | | |
| **Azure Devops** | ![Build Status][azure-windows]  | ![Build Status][azure-linux]  | ![Build Status][azure-macOS] | 

## How to use
 ```csharp 
 var binarySerializer = new DataSourceBinary(); 
 ```

Now you have access to all the Apis you will ever need for a binary serializer  check them out
```csharp 
        
        //Serialize an object to the provided stream
        void SerializeToStream<T>(T obj, Stream stream, int bufferSize = 1024, bool leaveStreamOpen = false) where T : class;
        void SerializeToStream(object obj, Type type, Stream stream, int bufferSize = 1024, bool leaveStreamOpen = false);

        //Serialize an object to a new instance of a stream and returns the stream
        Stream SerializeToStream<T>(T obj, int bufferSize = 1024) where T : class;
        Stream SerializeToStream(object obj, Type type,  int bufferSize = 1024);

        //Serialize an object to a string
        string SerializeToString(object obj);
        string SerializeToString<T>(T obj) where T : class;

        //Retrieve a list of either generics,objects,or dynamics from either a stream or string
        List<dynamic> DeserializeToList(string content);
        List<dynamic> DeserializeToList(Stream stream, int bufferSize = 1024, bool leaveStreamOpen = false);
        List<T> DeserializeToList<T>(string content) where T : class;
        List<T> DeserializeToList<T>(Stream stream, int bufferSize = 1024, bool leaveStreamOpen = false) where T : class;
        List<object> DeserializeToList(string content, Type type);

        //Retrieve a dynamic object from String or stream
        dynamic Deserialize(string content);
        dynamic Deserialize(Stream stream, int bufferSize = 1024, bool leaveStreamOpen = false);

        //Retrieve a strongly type from a string or stream
        T Deserialize<T>(string content) where T : class;
        T Deserialize<T>(Stream stream, int bufferSize = 1024, bool leaveStreamOpen = false) where T : class;
        
        //Retrieve a object from a string or stream
        object Deserialize(string content, Type type);        
        object Deserialize(Stream stream, Type type, int bufferSize = 1024, bool leaveStreamOpen = false);
```


## Serialization with Json
[JSON LINK][Json]

## Serialization with Csv
[CSV LINK][Csv]

## Documentation
For more information, please refer to the [Officials Docs][Docs]

## Solution Template
[![badge](https://img.shields.io/badge/Built%20With-DotNet--Starter--Template-orange.svg)](https://github.com/TheMofaDe/DotNet-Starter-Template)


<!-- Links. -->
[Cake]: https://gist.github.com/davidfowl/ed7564297c61fe9ab814
[Azure DevOps]: https://gist.github.com/davidfowl/ed7564297c61fe9ab814
[AppVeyor]: https://gist.github.com/davidfowl/ed7564297c61fe9ab814
[GitVersion]: https://gitversion.readthedocs.io/en/latest/
[Nuget]: https://gist.github.com/davidfowl/ed7564297c61fe9ab814
[Chocolately]: https://gist.github.com/davidfowl/ed7564297c61fe9ab814
[WiX]: http://wixtoolset.org/
[DocFx]: https://dotnet.github.io/docfx/
[Github]: https://github.com/TheMofaDe/DotNetHelper.Serialization.Abstractions
[Json]: https://github.com/TheMofaDe/DotNetHelper.Serialization.Json
[Csv]: https://github.com/TheMofaDe/DotNetHelper.Serialization.Csv

[Docs]: https://themofade.github.io/DotNetHelper.Serialization.Abstractions/index.html
[Docs-API]: https://themofade.github.io/DotNetHelper.Serialization.Abstractions/api/DotNetHelper.Serialization.Abstractions.html
[Docs-Tutorials]: https://themofade.github.io/DotNetHelper.Serialization.Abstractions/tutorials/index.html
[Docs-samples]: https://dotnet.github.io/docfx/
[Changelogs]: https://dotnet.github.io/docfx/


[nuget-downloads]: https://img.shields.io/nuget/dt/DotNetHelper.Serialization.Abstractions.svg?style=flat-square
[tests]: https://img.shields.io/appveyor/tests/TheMofaDe/DotNetHelper.Serialization.Abstractions.svg?style=flat-square
[coverage-status]: https://dev.azure.com/Josephmcnealjr0013/DotNetHelper.Serialization.Abstractions/_apis/build/status/TheMofaDe.DotNetHelper.Serialization.Abstractions?branchName=master&jobName=Windows
[azure-windows]: https://dev.azure.com/Josephmcnealjr0013/DotNetHelper.Serialization.Abstractions/_apis/build/status/TheMofaDe.DotNetHelper.Serialization.Abstractions?branchName=master&jobName=Windows
[azure-linux]: https://dev.azure.com/Josephmcnealjr0013/DotNetHelper.Serialization.Abstractions/_apis/build/status/TheMofaDe.DotNetHelper.Serialization.Abstractions?branchName=master&jobName=Linux
[azure-macOS]: https://dev.azure.com/Josephmcnealjr0013/DotNetHelper.Serialization.Abstractions/_apis/build/status/TheMofaDe.DotNetHelper.Serialization.Abstractions?branchName=master&jobName=macOS
[app-veyor]: https://ci.appveyor.com/project/TheMofaDe/DotNetHelper.Serialization.Abstractions

