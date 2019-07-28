namespace Railway.Controllers

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

    [<HttpDelete>]
    member this.Delete(id) =
        CustomerService.deleteCustomer id

    [<HttpPut>]
    member this.Update(customer) =
        CustomerService.updateCustomer customer