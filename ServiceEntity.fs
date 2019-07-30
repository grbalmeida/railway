module ServiceEntity

open Persistence

let updateTable functionToReceiveNewData table =
    let data = functionToReceiveNewData table
    saveTable {table with Data = data} |> ignore
    data