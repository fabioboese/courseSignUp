# Course SignUp

## Architectural Overview

The solution created was based on the Clean Architecture structure, using the API provided in https://github.com/chamatheapp/chama-backend-assignment-course-signup and adding the following componnets: Application, Domain, Infrastructure, and Tests.

The callings made by the Api are made to the Application component which is organized as a CRQS component. The command classes present in the Application component use Infrastrutcture and Domain data so it can access other resources like database, service bus or email service.

## Changes to implement the solution in a cloud provider
My experience using cloud solutions is greater with AWS. So, for this solution, I'd consider have a DynamoDb database, API Gateway (to expose API endpoints), Lambda (for Command, Queries, and e-mail service), CloudWatch (for logs) and SNS (in substitution of the infrastructure component messaging service).

I've studied about Azure to propose a solution for Azure, too, so I believe a good architecture would be using CosmosDb, Azure Functions to Commands, Queries, E-mail services and even to expose controllers (there is no need to be done by some other component), Application Insights for Logging, and to handle the messages and events Service Bus, Event Hub and Event Grid. 

According to the understaning I had aquired about Azure in this short period of time, Service Bus would have a Queue that will receive a new message on each SignUp Request. The event Hub would detect the new message comming and the Event Grid would have the configuration of what are the actions triggered on this event, for example, start an Azure function to persist the user if the course still have available seats. The same function could update statistisc of the course adding them to the DynamoDbRecord at the same time the number of Students in the course would be updated.

## Tools and technologies used
Following the source project, I keep using .NET Core 3.1, didn't use any cloud features, and keeps all the data in memory by creating a memory repository with a list containing all entities which is injected with Singleton scope.

I also use xUnit for tests, MediatR to implement the mediator pattern, Newtonsoft.Json to serialize and deserialize JSON objects, xUnit and TestHost for integration tests.

## What can be improved
Because of the time restrictions, some code is missing to let the solution at a minimum quality:
- Exception Handling: I use to create a general exception for each project which could be specialized. In the Api project, a class implementing IExceptionFilter is added so it can log the messages, wrap in a standard format and return as a status code of BadRequest.
- Logging: When there is no restriction to the use of PostSharp I use to develop an aspect called Loggable, which I use to decorate all the methods I want to log. The aspect can be configured to log the entry, exit, and/or exceptions ocurred during the execution of the method. When the PostSharp is not available, I use the ILogger interface.
- Unit Tests: There were no unit tests developed. When I started to create the Integration test, I've alread reached the 4 hours development time. 

