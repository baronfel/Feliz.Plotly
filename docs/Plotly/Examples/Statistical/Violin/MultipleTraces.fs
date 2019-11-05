﻿[<RequireQualifiedAccess>]
module Samples.Violin.MultipleTraces

open Fable.Core
open Fable.SimpleHttp
open Feliz
open Feliz.Plotly

type ViolinData =
    { Headers: string []
      TotalBill: float [] 
      Tip: float []
      Sex: string []
      Smoker: string []
      Day: string []
      Time: string []
      Size: int [] }
    member this.AddDataSet (data: string []) =
        { this with
            TotalBill = Array.append this.TotalBill (data.[0] |> float |> Array.singleton)
            Tip = Array.append this.Tip (data.[1] |> float |> Array.singleton)
            Sex = Array.append this.Sex (data.[2] |> Array.singleton)
            Smoker = Array.append this.Smoker (data.[3] |> Array.singleton)
            Day = Array.append this.Day (data.[4] |> Array.singleton)
            Time = Array.append this.Time (data.[5] |> Array.singleton)
            Size = Array.append this.Size (data.[6] |> int |> Array.singleton) }

module ViolinData =
    let empty =
        { Headers = [||]
          TotalBill = [||]
          Tip = [||]
          Sex = [||]
          Smoker = [||]
          Day = [||]
          Time = [||]
          Size = [||] }

let render (data: ViolinData)  =
    let styleValue (color: string) =
        violin.line [
            line.color color
        ]
        |> List.singleton

    Plotly.plot [
        plot.traces [
            traces.violin [
                violin.x data.Day
                violin.y data.TotalBill
                violin.points.false'
                violin.showlegend true
                violin.box [
                    box.visible.true'
                ]
                violin.line [
                    line.color color.green
                ]
                violin.meanline [
                    meanline.visible true
                ]
                violin.transforms [
                    transforms.groupby [
                        groupby.groups data.Day
                        groupby.styles [
                            styles.style [
                                style.target "Sun"
                                style.value (styleValue color.blue)
                            ]
                            styles.style [
                                style.target "Sat"
                                style.value (styleValue color.orange)
                            ]
                            styles.style [
                                style.target "Thur"
                                style.value (styleValue color.green)
                            ]
                            styles.style [
                                style.target "Fri"
                                style.value (styleValue color.red)
                            ]
                        ]
                    ]
                ]
            ]
        ]
        plot.layout [
            layout.title [
                title.text "Multiple Traces Violin Plot"
            ]
            layout.yaxis [
                yaxis.zeroline false
            ]
        ]
    ]

let chart' = React.functionComponent (fun (input: {| centeredSpinner: ReactElement |}) ->
    let isLoading, setLoading = React.useState false
    let error, setError = React.useState<Option<string>> None
    let content, setContent = React.useState ViolinData.empty
    let path = "https://raw.githubusercontent.com/plotly/datasets/master/violin_data.csv"

    let loadDataset() = 
        setLoading(true)
        async {
            let! (statusCode, responseText) = Http.get path
            setLoading(false)
            if statusCode = 200 then
                let fullData =
                    responseText.Trim().Split('\n') 
                    |> Array.map (fun s -> s.Split(','))

                fullData
                |> Array.tail
                |> Array.fold (fun (state: ViolinData) (values: string []) -> state.AddDataSet values) content
                |> fun newContent -> { newContent with Headers = fullData |> Array.head }
                |> setContent
                setError(None)
            else
                setError(Some (sprintf "Status %d: could not load %s" statusCode path))
        }
        |> Async.StartImmediate

    React.useEffect(loadDataset, [| path :> obj |])

    match isLoading, error with
    | true, _ -> input.centeredSpinner
    | false, None -> render content
    | _, Some error ->
        Html.h1 [
            prop.style [ style.color.crimson ]
            prop.text error
        ])

let chart (centeredSpinner: ReactElement) = chart' {| centeredSpinner = centeredSpinner |}
