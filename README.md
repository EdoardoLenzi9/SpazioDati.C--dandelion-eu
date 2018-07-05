# SpazioDati.Dandelion-eu
This is a simple wrapper of Dandelion.eu API 

## Getting started

Create a Demo project:

```
    $ mkdir Demo && cd Demo
    $ dotnet new console
    $ dotnet add package SpazioDati.Dandelion
    $ dotnet restore
```

Launch the following code:


```
  using System;
  using System.Net.Http;
  using Newtonsoft.Json;
  using SpazioDati.Dandelion.Business;
  using SpazioDati.Dandelion.Domain.Models;
    
  namespace Demo
  {
    class Program
    {
      static void Main(string[] args)
      {
        var token = "<your-token>";
        var text = "the quick brown fox jumps over the lazy dog";
        var entities = DandelionUtils.GetEntitiesAsync(new EntityExtractionParameters{Token = token, Text = text, HttpMethod = HttpMethod.Post});
        Console.WriteLine(JsonConvert.SerializeObject(entities));
      }
    }
  }
```

```
    $ dotnet run
```

## Parameters 
You can specify more paramethers and call every end-point, see Documentation folder for more details.
