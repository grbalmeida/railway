module Settings

open Microsoft.Extensions.Configuration
open System.IO

let constructor = ConfigurationBuilder()
let directoryConstructor = constructor.SetBasePath(Directory.GetCurrentDirectory())
let jsonFile = directoryConstructor.AddJsonFile("appsettings.json")
let configuration = jsonFile.Build()
let getConfiguration (configurationName : string) =
    configuration.[configurationName]
let tablesDirectory = getConfiguration "TablesDirectory"