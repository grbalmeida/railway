module Persistence

open Operators

type Table<'e> = {
    File: string
    Data: 'e list
}

type Context = {
    Integers: Table<int>
    Texts: Table<string>
}

let initializeTable baseDirectory file initialData =
    let table = {
        File = baseDirectory ^ file
        Data = initialData
    }

    saveTable table

let saveTable table =
    Json.serialize table.Data
    |> File.save table.file
    table

let loadTable<'e> file =
    let data = File.openFile file
               |> Json.deserialize<'e list>
    {
        File = file
        Data = data
    }

let getContext baseDirectory =
    let context = {
        Integers = initializeTable
                        baseDirectory
                        "/Integers.json"
                        []

        Texts = initializeTable
                        baseDirectory
                        "/Texts.json"
                        []
    }

    context