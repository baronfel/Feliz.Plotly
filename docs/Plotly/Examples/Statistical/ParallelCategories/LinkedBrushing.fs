﻿[<RequireQualifiedAccess>]
module Samples.ParallelCategories.LinkedBrushing

open Fable.SimpleHttp
open Feliz
open Feliz.Plotly

type CarData =
    { Headers: string []
      HighwayMPG: int []
      Horsepower: int option []
      BodyStyle: string []
      DriveWheels: string []
      FuelType: string [] }
    member this.AddDataSet (data: string []) : CarData =
        { this with
            HighwayMPG = [| yield! this.HighwayMPG; (data[23] |> int) |]
            Horsepower =
                match data[21] with
                | hp when hp |> string = "NA" -> None
                | hp -> hp |> int |> Some
                |> Array.singleton
                |> Array.append this.Horsepower
            BodyStyle = [| yield! this.BodyStyle; data[6] |]
            DriveWheels = [| yield! this.DriveWheels; data[7] |]
            FuelType = [| yield! this.FuelType; data[3] |]
        }

module CarData =
    let empty : CarData =
        { Headers = [||]
          HighwayMPG = [||]
          Horsepower = [||]
          BodyStyle = [||]
          DriveWheels = [||]
          FuelType = [||] }

type State =
    { Data: IPlotProperty option
      Layout: IPlotProperty option }

[<ReactComponent>]
let Plot (input: {| carData: CarData |}) : ReactElement =
    let (plotState, setPlotState) = React.useState({ Data = None; Layout = None })

    let plotColors = input.carData.Horsepower |> Array.map (fun _ -> 0)

    let plotData (selectedPoints: int []) (selectedPlotColors: int []) : IPlotProperty =
        plot.traces [
            traces.scatter [
                scatter.x input.carData.Horsepower
                scatter.y input.carData.HighwayMPG
                scatter.mode.markers
                scatter.marker [
                    marker.color color.gray
                ]
                scatter.selectedpoints selectedPoints
                scatter.selected [
                    selected.marker [
                        marker.color color.fireBrick
                    ]
                ]
                scatter.unselected [
                    unselected.marker [
                        marker.opacity 0.3
                    ]
                ]
            ]
            traces.parcats [
                parcats.dimensions [
                    dimensions.dimension [
                        dimension.label "Body Style"
                        dimension.values input.carData.BodyStyle
                    ]
                    dimensions.dimension [
                        dimension.label "Drive Wheels"
                        dimension.values input.carData.DriveWheels
                    ]
                    dimensions.dimension [
                        dimension.label "Fuel Type"
                        dimension.values input.carData.FuelType
                    ]
                ]
                parcats.domain [
                    domain.y [ 0.; 0.4 ]
                ]
                parcats.line [
                    line.color selectedPlotColors
                    line.colorscale (
                        [ color.gray; color.fireBrick ]
                        |> color.colorscale.sequential
                    )
                    line.cmin 0
                    line.cmax 1
                    line.shape.hspline
                ]
                parcats.labelfont [
                    labelfont.size 14
                ]
            ]
        ]

    let plotLayout =
        plot.layout [
            layout.width 600
            layout.height 800
            layout.xaxis [
                xaxis.title [
                    title.text "Horsepower"
                ]
            ]
            layout.yaxis [
                yaxis.domain [ 0.6; 1. ]
                yaxis.title [
                    title.text "MPG"
                ]
            ]
            layout.dragmode.lasso
            layout.hovermode.closest
        ]

    let initPlot () = setPlotState({ Data = plotData [||] plotColors |> Some; Layout = Some plotLayout })

    React.useEffect(initPlot, [| input.carData :> obj |])

    let updatePoints (points: ResizeArray<Events.PlotDatum>) =
        let points = points |> Array.ofSeq

        let colorPre,selections =
            points
            |> Array.choose (fun datum ->
                match datum.pointNumber with
                | Some n -> Some(n,n)
                | _ -> None)
            |> Array.unzip
        let colors =
            plotColors
            |> Array.mapi (fun i _ ->
                if Array.contains i colorPre then 1
                else 0)

        { plotState with Data = plotData selections colors |> Some }
        |> setPlotState

    Plotly.plot [
        if plotState.Data.IsSome then plotState.Data.Value
        if plotState.Layout.IsSome then plotState.Layout.Value
        plot.onSelected <| fun o -> o.points |> updatePoints
        plot.onClick <| fun o -> o.points |> updatePoints
    ]

[<ReactComponent>]
let Chart (centeredSpinner: ReactElement) : ReactElement =
    let isLoading, setLoading = React.useState false
    let error, setError = React.useState<Option<string>> None
    let content, setContent = React.useState CarData.empty
    let path = "https://raw.githubusercontent.com/plotly/datasets/master/imports-85.csv"

    let loadDataset() =
        setLoading(true)
        async {
            let! (statusCode, responseText) = Http.get path
            setLoading(false)
            if statusCode = 200 then
                let fullData =
                    responseText.Trim().Split('\n')
                    |> Array.map _.Split(',')

                fullData
                |> Array.tail
                |> Array.fold (fun (state: CarData) (values: string []) -> state.AddDataSet values) content
                |> fun newContent -> { newContent with Headers = fullData |> Array.head }
                |> setContent
                setError(None)
            else
                setError(Some $"Status {statusCode}: could not load {path}")
        }
        |> Async.StartImmediate

    React.useEffect(loadDataset, [| path :> obj |])

    match isLoading, error with
    | true, _ -> centeredSpinner
    | false, None ->
        Plot {| carData = content |}
    | _, Some error ->
        Html.h1 [
            prop.style [ style.color.crimson ]
            prop.text error
        ]
