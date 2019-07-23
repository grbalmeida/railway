namespace Wrappers

open Newtonsoft.Json

module Json =
    let serialize object =
        JsonConvert.SerializeObject(object)

    let deserialize<'a> json =
        JsonConvert.DeserializeObject<'a>(json)
      
module File =
    open System.IO

    let save path content =
        File.WriteAllText(path, content)

    let openFile path =
        File.ReadAllText(path)

    let exists path =
        File.Exists(path)