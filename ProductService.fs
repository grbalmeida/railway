module ProductService

open Operators
open Domain
open Persistence
open Transport.Filters

let getProducts() =
    getContext().Products

let updateProductTable functionToReceiveNewData =
    getProducts()
    |> ServiceEntity.updateTable functionToReceiveNewData

let filterProductTableBy filter =
    getProducts().Data
    |> List.filter filter

let getNoProductWithId id (list : Product list) =
    list
    |> List.filter (fun product -> product.Id <> id)

let deleteProduct id =
    updateProductTable (fun table -> getNoProductWithId id table.Data)

let addProduct product =
    updateProductTable (fun table -> product :: table.Data)

let updateProduct product =
    let removeAndAdd table =
        product :: (getNoProductWithId product.Id table.Data)

    updateProductTable (removeAndAdd)

let getAll() =
    getProducts().Data

let getById id =
    getProducts().Data
    |> List.tryFind (fun product -> product.Id = id)

let getBy (filter : ProductFilter) =
    filterProductTableBy
        (fun product ->
            product.Description <~ filter.Description
            && (filter.MaximumPrice = 0.0 || product.Price <= filter.MaximumPrice))