namespace Railway.Controllers

open System
open System.Net.Http
open Microsoft.AspNetCore.Mvc
open Services

[<Route("api/[controller]/[action]")>]
type CustomersController() =
    inherit Controller()

    [<HttpGet>]
    member this.GetAll() =
        Persistence.getContext().Customers.Data

    [<HttpPost>]
    member this.Add(customer) =
        CustomerService.addCustomer customer