module Persistence

open Operators
open Wrappers

type Table<'e> = {
    File: string
    Data: 'e list
}

type Context = {
    Integers: Table<int>
    Texts: Table<string>
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

let initialIntegers = [1 ; 2 ; 3]

let getContext() =
    let baseDirectory = Settings.tablesDirectory
    {
        Integers = createTableForApplication
                        baseDirectory
                        "/Integers.json"
                        initialIntegers

        Texts = createTableForApplication
                        baseDirectory
                        "/Texts.json"
                        ["Test" ; "Text"]
    }