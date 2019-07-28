namespace Railway.Controllers

open Microsoft.AspNetCore.Mvc

type PurchasesController() =
    inherit Controller()

    [<HttpGet>]
    member this.GetAll() =
        PurchaseService.getAll()

    [<HttpGet>]
    member this.GetById(id) =
        PurchaseService.getById id

    [<HttpPost>]
    member this.Add(purchase) =
        PurchaseService.addPurchase purchase
        
    [<HttpDelete>]
    member this.Delete(id) =
        PurchaseService.deletePurchase id