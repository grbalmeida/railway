namespace Railway

open System.IO
open Microsoft.AspNetCore
open Microsoft.AspNetCore.Hosting

module Program =
    let exitCode = 0

    let CreateWebHostBuilder args =
        WebHost
            .CreateDefaultBuilder(args)
            .UseStartup<Startup>();

    let initializeDatabase(baseDirectory) =
        Persistence.getContext(baseDirectory)
        |> ignore

    [<EntryPoint>]
    let main args =
        CreateWebHostBuilder(args).Build().Run()

        exitCode
