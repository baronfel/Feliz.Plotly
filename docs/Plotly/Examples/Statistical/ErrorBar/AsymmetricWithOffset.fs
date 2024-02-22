﻿[<RequireQualifiedAccess>]
module Samples.ErrorBar.AsymmetricWithOffset

open Feliz
open Feliz.Plotly

let chart () : ReactElement =
    Plotly.plot [
        plot.traces [
            traces.scatter [
                scatter.x [ 1; 2; 3; 4 ]
                scatter.y [ 2; 1; 3; 4 ]
                scatter.errorY [
                    errorY.type'.percent
                    errorY.symmetric false
                    errorY.value 15
                    errorY.valueminus 25
                ]
            ]
        ]
    ]
