﻿[<RequireQualifiedAccess>]
module Samples.Histogram.Cumulative

open Feliz
open Feliz.Plotly
open System

let rng = Random()

let chart () : ReactElement =
    Plotly.plot [
        plot.traces [
            traces.histogram [
                histogram.x ([ 0 .. 499 ] |> List.map (fun _ -> rng.NextDouble()))
                histogram.cumulative [
                    cumulative.enabled true
                ]
            ]
        ]
    ]
