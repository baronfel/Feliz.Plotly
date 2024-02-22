﻿[<RequireQualifiedAccess>]
module Samples.Pie.Basic

open Feliz
open Feliz.Plotly

let chart () : ReactElement =
    Plotly.plot [
        plot.traces [
            traces.pie [
                pie.values [ 19; 26; 55]
                pie.labels [ "Residential"; "Non-Residential"; "Utility" ]
            ]
        ]
        plot.layout [
            layout.height 400
            layout.width 500
        ]
    ]
