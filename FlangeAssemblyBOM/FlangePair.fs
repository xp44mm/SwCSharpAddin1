module FlangeAssemblyBOM.FlangePair
open System

//垫片厚度
let gasket = 3.0

//法兰表，和紧固件表,连接(join)
let getTbl pn dn =
    let flange =
        Flange.fromTsv()
        |> Array.find(fun x -> x.PN = pn && x.DN = dn)
    let m = flange.M

    let thread =
        ScrewFastener.fromTsv()
        |> Array.find(fun x -> x.M = m)
    flange,thread

//计算用于连接法兰的螺栓长度
let boltLength pn dn =    
    let flange, thread = getTbl pn dn
    let y =
        flange.C * 2.0 + gasket + thread.t + thread.p * 3.0 + thread.z

    Math.Ceiling(y/5.0)*5.0
