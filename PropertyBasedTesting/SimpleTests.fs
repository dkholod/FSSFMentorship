open System
open FsCheck
open SimpleEditor.Services

type Command = 
    | Load
    | Save of string

type Result = 
    | LoadOp of string
    | SaveOp of unit

let playCommand (cmd: Command) (srv: IStorageService) = 
    match cmd with
    | Load -> LoadOp (srv.Load())
    | Save txt -> SaveOp (srv.Save(txt))

let ``should agrees with model implementation`` cmds =
    let model = ModelStorageService()
    let underTest = FragileStorageService()

    let modelResults = cmds |> List.map (fun cmd -> playCommand cmd model)
    let testResults = cmds |> List.map (fun cmd -> playCommand cmd underTest)

    modelResults = testResults

//let test = ``should agrees with model implementation`` [Command.Save "abc"; Command.Save "a"]

let config = { Config.Quick with  MaxTest = 100000 }
Check.One (config, ``should agrees with model implementation``)

(*
let cmdGenerator = Arb.generate<Command list>
printfn "%A" (Gen.sample 10 100 cmdGenerator)
printfn "%A" (Gen.sample 10 100 cmdGenerator)
*)

System.Console.ReadKey