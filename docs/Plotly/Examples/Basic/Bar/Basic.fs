﻿[<RequireQualifiedAccess>]
module Samples.Bar.Basic

open Feliz
open Feliz.Plotly

let chart () : ReactElement =
    Plotly.plot [
        plot.traces [
            traces.bar [
                bar.x [ "giraffes"; "orangutans"; "monkeys" ]
                bar.y [ 20; 14; 23 ]
            ]
        ]
    ]
