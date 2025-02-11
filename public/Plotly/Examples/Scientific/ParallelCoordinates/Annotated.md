# Feliz.Plotly - Parallel Coordinate Plots

Taken from [Plotly - Parallel Coordinate Plots](https://plot.ly/javascript/parallel-coordinates-plot/)

```fsharp:plotly-chart-parallelcoordinates-annotated
[<RequireQualifiedAccess>]
module Samples.ParallelCoordinates.Annotated

open Fable.SimpleHttp
open Feliz
open Feliz.Plotly

type IrisData =
    { Headers: string []
      SepalLength: float []
      SepalWidth: float []
      PetalLength: float []
      PetalWidth: float []
      Class: string [] }

    member this.AddDataSet (data: string []) : IrisData =
        { this with
            SepalLength = [| yield! this.SepalLength; (data[0] |> float) |]
            SepalWidth = [| yield! this.SepalWidth; (data[1] |> float) |]
            PetalLength = [| yield! this.PetalLength; (data[2] |> float) |]
            PetalWidth = [| yield! this.PetalWidth; (data[3] |> float) |]
            Class = [| yield! this.Class; data[4] |]
        }

module IrisData =
    let empty : IrisData =
        { Headers = [||]
          SepalLength = [||]
          SepalWidth = [||]
          PetalLength = [||]
          PetalWidth = [||]
          Class = [||] }

let render (data: IrisData) : ReactElement =
    let plotColors =
        data.Class
        |> Array.map (fun c ->
            match c.Trim() with
            | "Iris-setosa" -> 0.
            | "Iris-versicolor" -> 0.5
            | "Iris-virginica" -> 1.
            | _ -> failwith "Check your data")

    Plotly.plot [
        plot.traces [
            traces.parcoords [
                parcoords.line [
                    line.color plotColors
                    line.colorscale (
                        [ color.red; color.green; color.blue ]
                        |> color.colorscale.sequential
                    )
                ]
                parcoords.dimensions [
                    dimensions.dimension [
                        dimension.range [ 2.; 4.5 ]
                        dimension.label "sepal width"
                        dimension.values data.SepalWidth
                    ]
                    dimensions.dimension [
                        dimension.constraintrange [ 5; 6 ]
                        dimension.range [ 4; 8 ]
                        dimension.label "sepal length"
                        dimension.values data.SepalLength
                    ]
                    dimensions.dimension [
                        dimension.range [ 0.; 2.5 ]
                        dimension.label "petal width"
                        dimension.values data.PetalWidth
                    ]
                    dimensions.dimension [
                        dimension.range [ 1; 7 ]
                        dimension.label "petal length"
                        dimension.values data.PetalLength
                    ]
                ]
            ]
        ]
        plot.layout [
            layout.title [
                title.text "Iris Data set"
            ]
            layout.width 800
            layout.annotations [
                annotations.annotation [
                    annotation.showarrow false
                    annotation.text "Higher sepal width"
                    annotation.x 0
                    annotation.y 1
                    annotation.xref.paper
                    annotation.yref.paper
                ]
                annotations.annotation [
                    annotation.showarrow false
                    annotation.text "Lower petal width and length"
                    annotation.x 0.9
                    annotation.y 0.25
                    annotation.xref.paper
                    annotation.yref.paper
                ]
            ]
        ]
    ]

[<ReactComponent>]
let Chart (centeredSpinner: ReactElement) : ReactElement =
    let isLoading, setLoading = React.useState false
    let error, setError = React.useState<Option<string>> None
    let content, setContent = React.useState IrisData.empty
    let path = "https://raw.githubusercontent.com/plotly/datasets/master/iris-data.csv"

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
                |> Array.fold (fun (state: IrisData) (values: string []) -> state.AddDataSet values) content
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
    | false, None -> render content
    | _, Some error ->
        Html.h1 [
            prop.style [ style.color.crimson ]
            prop.text error
        ]

```
