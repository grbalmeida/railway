namespace Wrappers

open Newtonsoft.Json

module Json =
    let serialize object =
        JsonConvert.SerializeObject(object)

    let deserialize<'a> json =
        JsonConvert.DeserializeObject<'a>(json)