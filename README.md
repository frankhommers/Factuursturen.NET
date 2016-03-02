# LVMS.FactuurSturen.NET
Unofficial open source C# helper library for communication with the API of FactuurSturen.nl. 
All calls support the async/await model. Previous results are cached in-memory by default and overrides are available to force fresh data.
All calls use Polly, a transient fault handling framework. If calls fail due to transient errors, they are automatically retried.

This library is under development. Currently supported:
- Get list of clients
- Get list of products, create product, update product, delete product
- Get list of invoices, list of filtered invoices (e.g. paid invoices)
- More to come

This Portable Library is compatible with: (ASP).Net 4.0.3/4.5/4.6, Windows (Phone) 8.1 Universal Apps and Windows Phone 8.1 Silverlight. So you can use this library to automate your building(s) from desktop and web applications or from Windows Universal Apps.

## How to use?
Use the source code from this repository or download the NuGet package: [LVMS.FactuurSturenNet.Signed](https://www.nuget.org/packages/LVMS.FactuurSturenNet.Signed/). In this repo, you can find an example application named LVMS.FactuurSturenNet.NET.TestClient (ConsoleApplication1).
	
	var client = new FactuurSturenClient();
	await client.LoginAsync(credentials.UserName, credentials.Password);

The password is the API key that you can find under settings in the FactuurSturen.nl website.
	
To retrieve a list of clients:	

	var clients = await client.GetClients();


## Contributions

Contributions are welcome. Fork this repository and send a pull request if you have something useful to add.
