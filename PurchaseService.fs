module PurchaseService

open Operators
open Domain
open Persistence

let getPurchases() =
    getContext().Purchases

let updatePurchaseTable functionToReceiveNewData =
    getPurchases()
    |> ServiceEntity.updateTable functionToReceiveNewData

let getNoPurchaseWithId id (list : Purchase list) =
    list
    |> List.filter (fun purchase -> purchase.Id <> id)

let deletePurchase id =
    updatePurchaseTable (fun table -> getNoPurchaseWithId id table.Data)

let addPurchase purchase =
    let removeAndAdd table =
        purchase :: (getNoPurchaseWithId purchase.Id table.Data)

    updatePurchaseTable (removeAndAdd)

let getAll() =
    getPurchases().Data

let getById id =
    getPurchases().Data
    |> List.tryFind (fun purchase -> purchase.Id = id)