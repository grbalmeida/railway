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

    let deleteCustomerById id (customersList : Customer list) =
        customersList
        |> List.filter (fun customer -> customer.Id <> id)

    let deleteCustomer id =
        updateCustomersTable (fun table ->
            deleteCustomerById id table.Data)

    let updateCustomer customer =
        let removeAndAdd table =
            customer ::
            (deleteCustomerById
                customer.Id
                table.Data)

        updateCustomersTable (removeAndAdd)

    let getAll() =
        getCustomers().Data

    let filterCustomersTableBy filter =
        getCustomers().Data
        |> List.filter filter

    let getCustomerByCpf cpf =
        filterCustomersTableBy
            (fun customer -> customer.CPF = cpf)

    let getCustomerByName name =
        filterCustomersTableBy
            (fun customer -> customer.Name = name)

    let getById id =
        getCustomers().Data
        |> List.tryFind (fun customer -> customer.Id = id)