[<AutoOpen>]
module Aspects

open System 
open System.Diagnostics

open Common.Logging;

open Suave

let logger = LogManager.GetLogger("mySuaveTestLogger");

let trackExecTime (webPart: WebPart) =    
    let watch = Stopwatch()
    
    let track x =
        watch.Stop()
        logger.DebugFormat("Operation duration: {0} (ms)", watch.ElapsedMilliseconds)
        x
    
    fun (ctx : HttpContext) ->
        async {
            watch.Reset()
            watch.Start()
            let! res = webPart ctx
            return res >>= track
        }

let trace (webPart : WebPart) =
    let log x =
        logger.DebugFormat("Request url: {0}, Response status: {1}", x.request.url, x.response.status.code)
        x

    fun (ctx : HttpContext) ->
        async {
            let! res = webPart ctx
            return res >>= log
        }

let commonInfrastructure =
    trace >> trackExecTime