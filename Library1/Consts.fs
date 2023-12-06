module Consts


open System.IO

let solutionDir = DirectoryInfo(__SOURCE_DIRECTORY__).Parent.FullName

let TRAININGDIR = Path.Combine(solutionDir, "API Fundamentals")
let TEMPLATEDIR = Path.Combine(solutionDir, "Training Templates")
