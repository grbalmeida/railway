namespace Railway.Controllers

open Microsoft.AspNetCore.Mvc
open Services

[<Route("api/[controller]/[action]")>]
type CustomersController() =
    inherit Controller()

    [<HttpGet>]
    member this.GetAll() =
        CustomerService.getAll()

    [<HttpGet>]
    member this.GetById(id) =
        CustomerService.getById id

    [<HttpGet>]
    member this.GetByCpf(cpf) =
        CustomerService.getByCpf cpf
    
    [<HttpGet>]
    member this.GetByName(name) =
        CustomerService.getByName name

    [<HttpPost>]
    member this.Add(customer) =
        CustomerService.addCustomer customer

    [<HttpDelete>]
    member this.Delete(id) =
        CustomerService.deleteCustomer id

    [<HttpPut>]
    member this.Update(customer) =
        CustomerService.updateCustomer customer