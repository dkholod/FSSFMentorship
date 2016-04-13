System.IO.Directory.SetCurrentDirectory (__SOURCE_DIRECTORY__)
#I @"..\packages\FsCheck.2.2.4\lib\net45"
#r @"FsCheck.dll"

open System
open FsCheck

let getOne g = 
    g
    |> Gen.sample 1 1    
    |> List.exactlyOne

// select random number from list
let chooseFromList xs = 
  gen { 
        let! i = Gen.choose (0, List.length xs-1) 
        return (xs |> List.item i) 
        }

chooseFromList [5;6;3;5;6;7]
|> getOne

type Color =
    | Red
    | Green
    | Blue

Gen.oneof [ gen { return Red }; gen { return Green }; gen { return Blue } ]
|> getOne

// cjoose from 0 to 10 and give me up to 10 elements
fun s -> Gen.choose (0, s)
|> Gen.sized
|> Gen.sample 100 10