[<AutoOpen>]
module Memoize

open System.Collections.Concurrent

open Suave

let memoizeAsync f =
    let dict = ConcurrentDictionary<'a, 'b>()
    fun x -> async {
        //dict.GetOrAdd(x, fun k -> return res = f k)
        // return (dict.GetOrAdd(x, lazy(f x)).Force())

        match dict.TryGetValue x with
        | true, result -> return result
        | false, _ ->
            let! result = f x
            dict.TryAdd(x, result) |> ignore
            return result
    }

let memoize f =
    let dict = ConcurrentDictionary<'a, 'b>()
    fun x -> dict.GetOrAdd(x, fun _ -> f x)