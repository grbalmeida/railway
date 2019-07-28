namespace Services

open Domain
open Persistence

module CustomerService =
    let getCustomers() =
        getContext().Customers
    
    let updateCustomersTable functionToReceiveNewData =
        let table = getCustomers()
        let data = functionToReceiveNewData table
        saveTable {table with Data = data}

    let addCustomer customer =
        updateCustomersTable (fun table -> customer :: table.Data)

    let rec deleteCustomerById id idsAlreadyCovered (customerList : Customer list) =
        match customerList with
            | head::tail when head.Id = id -> idsAlreadyCovered @ tail
            | head::tail -> deleteCustomerById id tail (head::idsAlreadyCovered)
            | [] -> idsAlreadyCovered

    let deleteCustomer id =
        updateCustomersTable (fun table ->
            deleteCustomerById id [] table.Data)