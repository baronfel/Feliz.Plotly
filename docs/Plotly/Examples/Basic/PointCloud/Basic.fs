﻿[<RequireQualifiedAccess>]
module Samples.PointCloud.Basic

open Feliz
open Feliz.Plotly

let chart () : ReactElement =
    Plotly.plot [
        plot.traces [
            traces.pointcloud [
                pointcloud.xy [ 1; 2; 3; 4; 5; 6; 0; 4 ]
            ]
        ]
    ]
