[<AutoOpen>]
module InternalDsl

let bind f x =
        match x with 
        | None -> None
        | Some arg -> Some (f arg)

let (>>=) inp f = bind f inp
