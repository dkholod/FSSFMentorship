open System 

open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful
open Suave.RequestErrors

let echo =
    request (fun r ->
        match r.queryParam "msg" with
        | Choice1Of2 toEcho -> OK toEcho
        | Choice2Of2 msg -> BAD_REQUEST msg)

let app =
  choose
    [ GET >=> choose
        [ 
            path "/healthcheck" >=> OK "OK"
            path "/echo" >=> echo 
        ]
    ]

[<EntryPoint>]
let main argv = 
    
    printfn "Starting web server..."
    
    startWebServer defaultConfig app
    0