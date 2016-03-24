[<AutoOpen>]
module Memoize

open System.Collections.Concurrent

let memoizeAsync f =
    let dict = ConcurrentDictionary()
    fun x -> async {
            match dict.TryGetValue x with
            | true, result -> return result
            | false, _ ->
                let! result = f x
                dict.TryAdd(x, result) |> ignore
                return result
        }

let memoize f =
    let dict = ConcurrentDictionary()
    fun x ->
        match dict.TryGetValue(x) with
        | (true, v) -> v
        | _ ->
            let result = f x
            dict.TryAdd(x, result) |> ignore
            result