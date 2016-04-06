[<AutoOpen>]
module Aspects

open System 
open System.Diagnostics

open Common.Logging;

open Suave

let log = LogManager.GetLogger("mySuaveTestLogger");

let trackExecTime (webPart: WebPart) =
    fun (ctx : HttpContext) ->
        async {
            let watch = Stopwatch()
            watch.Start()
            
            let! res = webPart ctx
            return res >>= fun x ->
                           watch.Stop()
                           printfn "Operation duration: %d (ms)" watch.ElapsedMilliseconds
                           x
        }

let trace (webPart : WebPart) =
    fun (ctx : HttpContext) ->
        async {
            let! res = webPart ctx
            return res >>= fun x ->
                           log.DebugFormat("Request url: {0}, Response status: {1}", x.request.url, x.response.status.code)
                           x
        }

//let cache (webPart : WebPart) =
//    (fun (ctx : HttpContext) -> webPart ctx) |> memoize

let commonInfrastructure =
    trace >> trackExecTime