[< Back](../readme.md)

# Language-Integrated Query (LINQ)
**Language-Integrated Query (LINQ)** is the name for a set of technologies based on the integration of query capabilities directly into the C# language.</br>
For a developer who writes queries, the most visible "language-integrated" part of LINQ is the query expression. Query expressions are written in a declarative query syntax. By using query syntax, you can perform filtering, ordering, and grouping operations on data sources with a minimum of code.</br>
You can write LINQ queries in C# for SQL Server databases, XML documents, ADO.NET Datasets, and any collection of objects that supports `IEnumerable` or the generic `IEnumerable<T>` interface. LINQ support is also provided by third parties for many Web services and other database implementations.

</br>

### LINQ to Objects
---
The term "LINQ to Objects" refers to the use of LINQ queries with any `IEnumerable` or `IEnumerable<T>` collection directly, without the use of an intermediate LINQ provider or API.

</br>

### LINQ to XML
---
Provides an in-memory XML programming interface, using .NET capabilities, which is comparable to an updated, redesigned Document Object Model (DOM) XML programming interface.


</br>

### LINQ to ADO.NET 
---
- **LINQ to DataSet** </br>
	The DataSet has limited query capabilities. LINQ alows to build richer query capabilities into it.

- **LINQ to SQL** </br>
	It provides a run-time infrastructure for managing relational data as objects.

- **LINQ to Entities** </br>
	Through the Entity Data Model, relational data is exposed as objects in the .NET environment.

</br>

See more at: </br>
[Microsoft Docs - Language Integrated Query (LINQ)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq)
