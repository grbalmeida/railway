module CustomerService

open Operators
open Domain
open Persistence
open Transport.Filters
open Transport.Responses

module CustomerService =
    let getCustomers() =
        getContext().Customers

    let transformListIntoResponse =
        List.map (CustomerResponse.Transform)

    let getFromDatabaseById id =
        getCustomers().Data
        |> List.tryFind (fun customer -> customer.Id = id)
    
    let updateCustomersTable functionToReceiveNewData =
        getCustomers()
        |> ServiceEntity.updateTable functionToReceiveNewData

    let addCustomer customer =
        updateCustomersTable (fun table -> customer :: table.Data)

    let deleteCustomerById id (customersList : Customer list) =
        customersList
        |> List.filter (fun customer -> customer.Id <> id)

    let updateCustomer customer =
        let removeAndAdd table =
            customer ::
            (deleteCustomerById
                customer.Id
                table.Data)

        updateCustomersTable (removeAndAdd)

    let getAllDataFromDatabase() =
        getCustomers().Data

    let getNoCustomerWithId id (list : Customer list) =
        list
        |> List.filter
            (fun customer -> customer.Id <> id)

    let deleteCustomerFromDatabase id =
        updateCustomersTable
            (fun table -> getNoCustomerWithId id table.Data)

    let deleteCustomer =
        deleteCustomerFromDatabase
        >> transformListIntoResponse

    let getAll =
        getAllDataFromDatabase
        >> transformListIntoResponse

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
        getFromDatabaseById
        >> Option.map (CustomerResponse.Transform)

    let getFromDatabaseByFilter (filter : CustomerFilter) =
        filterCustomersTableBy
            (fun customer ->
                (!!filter.CPF || customer.CPF = filter.CPF)
                && (customer.Name <~ filter.Name || customer.LastName <~ filter.Name)
                && (filter.Age = 0 || customer.Age = filter.Age))

    let getBy =
        getFromDatabaseByFilter
        >> transformListIntoResponse