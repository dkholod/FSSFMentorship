System.IO.Directory.SetCurrentDirectory (__SOURCE_DIRECTORY__)
#I @"..\packages\FsCheck.2.2.4\lib\net45"
#r @"FsCheck.dll"

open System
open FsCheck

type Tree =
    | Node of string * Tree list
 
let prefMid = seq { yield "├─"; while true do yield "│ " }
let prefEnd = seq { yield "└─"; while true do yield "  " }
let prefNone = seq { while true do yield "" }
let c2 x y = Seq.map2 (fun u v -> String.concat "" [u; v]) x y

let visualize tree = 
    let rec visualize' (Node (label, children)) pre =
        seq {
            yield (Seq.head pre) + label
            if children <> [] then
                let preRest = Seq.skip 1 pre
                let last = Seq.last (List.toSeq children)
                for e in children do
                    if e = last then yield! visualize' e (c2 preRest prefEnd)
                    else yield! visualize' e (c2 preRest prefMid)
        }

    visualize' tree prefNone |> Seq.iter (printfn "%s")

let getOne s g = 
    g
    |> Gen.sample s 1    
    |> List.exactlyOne

let treeGen size =
    let rec tree' s =
        match s with
        | 0 -> Gen.map (fun x -> Node (x.ToString(), List.empty)) Arb.generate<int>
        | n when n > 0 ->
            let subTree = Gen.sample n n (tree' (n/2))
            Gen.map (fun x -> Node (x.ToString(), subTree)) Arb.generate<int> 
        | _ -> invalidArg "s" "Only positive arguments are allowed"
    Gen.sized tree'
    |> getOne size
    
treeGen 6
|> visualize

let treeBinaryGen size =
    let rec tree' s =
        match s with
        | 0 -> Gen.map (fun x -> Node (x.ToString(), List.empty)) Arb.generate<int>
        | n when n > 0 ->
            let subTree = Gen.sample 2 2 (tree' (n - 1))
            Gen.map (fun x -> Node (x.ToString(), subTree)) Arb.generate<int> 
        | _ -> invalidArg "s" "Only positive arguments are allowed"
    tree' size
    |> getOne size

treeBinaryGen 3
|> visualize