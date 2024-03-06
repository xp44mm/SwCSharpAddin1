namespace rec FSharp.SolidWorks

type RouteComponent =
    {
        refid: string
        specific: RouteComponentSpecific
    }

type RouteComponentSpecific =
    | RouteAssembly of title:string * children:RouteComponent list
    | ComponentAssembly of title:string * refconfig:string * children:RouteComponent list
    | ComponentPart of title:string * refconfig:string

    //一般管件
    | Pipe  of dn:float * length:float
    | Elbow of dn:float * angle:float

    | Tee    of dn:float
    | Flange of dn:float

    | Reducer          of dn1:float * dn2:float
    | EccentricReducer of dn1:float * dn2:float
    | ReducingTee      of dn1:float * dn2:float

    // 配件fittings
    | BallValve of dn:float
    | WaferButterflyValve of dn:float
    | WaferCheckValve     of dn:float
    | Expansion           of dn:float
    | Flowmeter           of dn:float
    | MagneticFilter      of dn:float

    // 装配体配件AssemblyFittings
    | SingleFlange               of dn:float * children:RouteComponent list
    | Flanges                    of dn:float * children:RouteComponent list
    | BallValveFlanges           of dn:float * children:RouteComponent list
    | BallValveSolo              of dn:float * children:RouteComponent list
    | WaferButterflyValveFlanges of dn:float * children:RouteComponent list
    | WaferButterflyValveSolo    of dn:float * children:RouteComponent list
    | WaferCheckValveFlanges     of dn:float * children:RouteComponent list
    | ExpansionFlanges           of dn:float * children:RouteComponent list
    | ExpansionSolo              of dn:float * children:RouteComponent list
    | FlowmeterFlanges           of dn:float * children:RouteComponent list
    | MagneticFilterFlanges      of dn:float * children:RouteComponent list



