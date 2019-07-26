namespace Services

open Domain
open Persistence

module CustomerService =
    let getCustomers() =
        getContext().Customers
    
    let addCustomer customer =
        let table = getCustomers()
        let data = customer :: table.Data
        saveTable { table with Data = data }
