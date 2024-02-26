module FlangeAssemblyBOM.Dir

open System.IO

let thisPath = __SOURCE_DIRECTORY__

let solutionPath = DirectoryInfo(thisPath).Parent.FullName

//let projPath = Path.Combine(solutionPath,"FslexFsyacc")
