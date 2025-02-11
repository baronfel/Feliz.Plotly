﻿[<RequireQualifiedAccess>]
module Samples.MultipleChartTypes.LineAndBar

open Feliz
open Feliz.Plotly

let chart () : ReactElement =
    Plotly.plot [
        plot.traces [
            traces.scatter [
                scatter.x [ 0 .. 5 ]
                scatter.y [ 1.5; 1.; 1.3; 0.7; 0.8; 0.9 ]
            ]
            traces.bar [
                bar.x [ 0 .. 5 ]
                bar.y [ 1.; 0.5; 0.7; -1.2; 0.3; 0.4 ]
            ]
        ]
    ]
