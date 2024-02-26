module FlangeAssemblyBOM.Dir

open System.IO

//let thisPath = __SOURCE_DIRECTORY__
let databasePath = Path.Combine(__SOURCE_DIRECTORY__,"database")

let solutionPath = DirectoryInfo(__SOURCE_DIRECTORY__).Parent.FullName

let CommandDataPath = Path.Combine(solutionPath,"CommandData")

