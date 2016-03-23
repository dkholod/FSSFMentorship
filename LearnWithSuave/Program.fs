open System 

open System.Net.Http

open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful
open Suave.RequestErrors

// toOK: HttpContext-> 'a -> Async<HttpContext option>
let toOK (x:HttpContext) s = 
    OK (s.ToString()) x

let httpClient = new HttpClient()

let echo = request (fun r -> 
    match r.queryParam "msg" with
    | Choice1Of2 toEcho -> OK toEcho
    | Choice2Of2 msg -> BAD_REQUEST msg)

let count: WebPart = fun (x : HttpContext) -> async {
        match x.request.queryParam "url" with
        | Choice2Of2 msg -> return! BAD_REQUEST msg x
        | Choice1Of2 url -> let! page = httpClient.GetStringAsync(url) |> Async.AwaitTask
                            return! page.Length |> toOK x
}

let app =
  choose
    [ GET >=> choose
        [ 
            path "/healthcheck" >=> OK "OK"
            path "/echo" >=> echo
            path "/count" >=> count
        ]
    ]

[<EntryPoint>]
let main argv = 
    printfn "Starting web server..."
    startWebServer defaultConfig app
    0