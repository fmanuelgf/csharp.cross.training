[< Back](../readme.md)

# Language-Integrated Query (LINQ)
**Language-Integrated Query (LINQ)** is the name for a set of technologies based on the integration of query capabilities directly into the C# language.</br>
For a developer who writes queries, the most visible "language-integrated" part of LINQ is the query expression. Query expressions are written in a declarative query syntax. By using query syntax, you can perform filtering, ordering, and grouping operations on data sources with a minimum of code.</br>
You can write LINQ queries in C# for SQL Server databases, XML documents, ADO.NET Datasets, and any collection of objects that supports `IEnumerable` or the generic `IEnumerable<T>` interface. LINQ support is also provided by third parties for many Web services and other database implementations.

</br>

### LINQ to Objects
---
The term "LINQ to Objects" refers to the use of LINQ queries with any `IEnumerable` or `IEnumerable<T>` collection directly, without the use of an intermediate LINQ provider or API.

Example:
```C#
	var result = this.personsList
		.Where(x => x.Age == 35)
		.OrderBy(x => x.Name);
```

</br>

### LINQ to XML
---
Provides an in-memory XML programming interface, using .NET capabilities, which is comparable to an updated, redesigned Document Object Model (DOM) XML programming interface.

Example:
```c#
    var xdoc = XDocument.Load("data.xml");

    var result = 
		from lv1 in xdoc.Descendants("level1")
		select new 
		{ 
			Header = lv1.Attribute("name").Value,
			Children = lv1.Descendants("level2")
		};
```

</br>

### LINQ to ADO.NET 
---
- **LINQ to DataSet** </br>
	The DataSet has limited query capabilities. LINQ alows to build richer query capabilities into it.

	Example:
	```C#
		var ds = new DataSet();
		// fill the dataset... 

		var products = ds.Tables["Product"];

		IEnumerable<DataRow> query =
			from product in products.AsEnumerable()
			select product;

		Console.WriteLine("Product Names:");
		foreach (DataRow p in query)
		{
			Console.WriteLine(p.Field<string>("Name"));
		}
	````

- **LINQ to SQL** </br>
	It provides a run-time infrastructure for managing relational data as objects.

	Example:
	```C#
		var companyNameQuery =
			from cust in nw.Customers
			where cust.City == "London"
			select cust.CompanyName;
	```

- **LINQ to Entities** </br>
	Through the Entity Data Model, relational data is exposed as objects in the .NET environment.

	Example:
	```C#
		var result = this.personsRepository.GetQueryable()
			.Where(x => x.Height >= 70 && x.Height <= 80)
			.OrderBy(x => x.Name);
	```
</br>

See more at: </br>
[Microsoft Docs - Language Integrated Query (LINQ)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq)
