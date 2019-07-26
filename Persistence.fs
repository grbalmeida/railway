module Persistence

open Domain
open Operators
open Wrappers

type Table<'e> = {
    File: string
    Data: 'e list
}

type Context = {
    Customers: Table<Customer>
    Products: Table<Product>
    Purchases: Table<Purchase>
}

let saveTable table =
    Json.serialize table.Data
    |> File.save table.File
    table

let initializeTable baseDirectory file initialData =
    let table = {
        File = baseDirectory ^ file
        Data = initialData
    }

    saveTable table

let loadTable<'e> file =
    let data = File.openFile file
               |> Json.deserialize<'e list>
    {
        File = file
        Data = data
    }

let createTableForApplication<'e> baseDirectory file initialData =
    let fullFile = baseDirectory ^ file
    let fileExists = File.exists fullFile
    match fileExists with
    | true -> loadTable<'e> fullFile
    | false -> initializeTable baseDirectory fullFile initialData

let initialCustomers = 
    [
        {
            Id = 1
            Age = 23
            Name = "John"
            LastName = "Silva"
            CPF = "021.231.231-21"
            Email = "john@test.com"
            Phone = "99887766"
            Address = "John Address"
        };
        {
            Id = 2
            Age = 21
            Name = "Maria"
            LastName = "Souza"
            CPF = "123.321.123-21"
            Email = "maria@test.com"
            Phone = "99881122"
            Address = "Maria Address"
        }
    ]

let getContext() =
    let baseDirectory = Settings.tablesDirectory
    {
        Customers = createTableForApplication
                        baseDirectory
                        "/Customers.json"
                        initialCustomers
        
        Products = createTableForApplication
                        baseDirectory
                        "/Products.json"
                        []
        
        Purchases = createTableForApplication
                        baseDirectory
                        "/Purchases.json"
                        []
    }