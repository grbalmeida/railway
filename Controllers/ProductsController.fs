namespace Railway.Controllers

open Microsoft.AspNetCore.Mvc

[<Route("api/[controller]/[action]")>]
type ProductsController() =
    inherit Controller()

    [<HttpGet>]
    member this.GetAll() =
        ProductService.getAll()

    [<HttpGet>]
    member this.GetById(id) =
        ProductService.getById id
    
    [<HttpGet>]
    member this.GetBy([<FromQuery>] filter) =
        ProductService.getBy filter

    [<HttpPost>]
    member this.Add(product) =
        ProductService.addProduct product

    [<HttpPut>]
    member this.Update(product) =
        ProductService.updateProduct product

    [<HttpDelete>]
    member this.Delete(id) =
        ProductService.deleteProduct id