module FSharp.SolidWorks.Polar

open type System.Math

/// 与solidworks坐标系一致
let angle (x:float) (z:float) = 
    let y = -z
    match x,y with
    | 0.0, 0.0 -> failwith "0/0"
    | 0.0, _ ->
        if y > 0 then 90. else -90.
    | _, 0.0 ->
        if x < 0 then 180. else 0.
    | _ ->
        let angle = atan2 y x * 180. / PI
        round(angle*1e12)*1e-12 // 13 pass 14 reject
