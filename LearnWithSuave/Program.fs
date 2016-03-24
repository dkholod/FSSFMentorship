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

let queryWebPart p f : WebPart = fun (x : HttpContext) -> 
    async {
            match x.request.queryParam p with
            | Choice2Of2 msg -> return! BAD_REQUEST msg x
            | Choice1Of2 v -> let! result = f v
                              return! result |> toOK x
    }

let getPageAsync (url:string) = async {
    return! httpClient.GetStringAsync(url) |> Async.AwaitTask
}

let getPageLengthAsync (url:string) = async {
    let! content = getPageAsync url
    return content.Length
}

let echo = queryWebPart "msg" (fun it -> async { return it })
let proxy = queryWebPart "url" (getPageAsync |> memoizeAsync)
let count = queryWebPart "url" (getPageLengthAsync |> memoizeAsync)

let app =
  choose
    [ GET >=> choose
        [ 
            path "/healthcheck" >=> OK "OK"
            path "/echo" >=> echo
            path "/count" >=> count
            path "/proxy" >=> proxy
        ]
    ]

[<EntryPoint>]
let main argv = 
    printfn "Starting web server..."
    startWebServer defaultConfig app
    0