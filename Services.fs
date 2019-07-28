namespace Services

open Operators
open Domain
open Persistence
open Transport.Filters

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

    let getByCpf cpf =
        filterCustomersTableBy
            (fun customer -> customer.CPF = cpf)

    let getByName name =
        filterCustomersTableBy
            (fun customer -> customer.Name = name)

    let getById id =
        getCustomers().Data
        |> List.tryFind (fun customer -> customer.Id = id)

    let getBy filter =
        filterCustomersTableBy
            (fun customer ->
                (!!customer.CPF || customer.CPF = filter.CPF)
                && (customer.Name <~ filter.Name
                    || customer.LastName <~ filter.Name)
                && customer.Age = 0 || customer.Age = filter.Age)