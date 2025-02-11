﻿[<RequireQualifiedAccess>]
module Samples.FilledArea.Basic

open Feliz
open Feliz.Plotly

let chart () : ReactElement =
    Plotly.plot [
        plot.traces [
            traces.scatter [
                scatter.x [ 1; 2; 3; 4 ]
                scatter.y [ 0; 2; 3; 5 ]
                scatter.fill.tozeroy
            ]
            traces.scatter [
                scatter.x [ 1; 2; 3; 4 ]
                scatter.y [ 3; 5; 1; 7 ]
                scatter.fill.tonexty
            ]
        ]
    ]
