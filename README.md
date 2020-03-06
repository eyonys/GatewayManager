# GatewayManager
GatewayManager is REST Api service for storing information about gateways and their peripheral devices. It provides services for saving and displaying gateways, displaying detailed info about a specific gateway and also add or remove a device from a gateway.

## Technological Specs

The services were developed and implemented using C# and ASP.NET Core 3.0 in Visual Studio 2019. An in-memory database was used for storing data. Basic UI to interact with services was developed using Angular.
For the implementation of services, the architectural pattern of choice was MVC (Model-View-Controller) with the principle of design Separation of Concerns. Other designs patterns such as Unit of Work and Dependency Injection were used to provide more flexibility and scalability to the solution.

## Execution of Services
REST Services will be executed (in debugging mode) in port 25374 of localhost, with “/api/gateways/  as address for gateways, and “/api/peripheraldevices/” for peripherals. The UI has this address atached to it.
