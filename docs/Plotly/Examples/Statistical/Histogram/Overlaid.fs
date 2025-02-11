﻿[<RequireQualifiedAccess>]
module Samples.Histogram.Overlaid

open Feliz
open Feliz.Plotly
open System

let rng = Random()

let chart () : ReactElement =
    Plotly.plot [
        plot.traces [
            traces.histogram [
                histogram.x ([ 0 .. 499 ] |> List.map (fun _ -> rng.NextDouble()))
                histogram.opacity 0.5
                histogram.marker [
                    marker.color color.green
                ]
            ]
            traces.histogram [
                histogram.x ([ 0 .. 499 ] |> List.map (fun _ -> rng.NextDouble() + 0.1))
                histogram.opacity 0.6
                histogram.marker [
                    marker.color color.red
                ]
            ]
        ]
        plot.layout [
            layout.barmode.overlay
        ]
    ]
