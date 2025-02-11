# Feliz.Plotly - Parallel Categories

Taken from [Plotly - Parallel Categories](https://plot.ly/javascript/parallel-categories-diagram/)

```fsharp:plotly-chart-parallelcategories-multicolorlinkedbrushing
[<RequireQualifiedAccess>]
module Samples.ParallelCategories.MultiColorLinkedBrushing

open Elmish
open Fable.SimpleHttp
open Feliz
open Feliz.Plotly
open Feliz.UseElmish
open Zanaptak.TypedCssClasses

module Types =
    type Bulma = CssClasses<"https://cdn.jsdelivr.net/npm/bulma@0.9.4/css/bulma.min.css", Naming.PascalCase>
    type FA = CssClasses<"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css", Naming.PascalCase>

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

    [<RequireQualifiedAccess>]
    type ColorAction =
        | Erase
        | Red
        | Blue

    type State =
        { CarData: CarData
          ColorAction: ColorAction
          Colors: int []
          DataLoaded: bool
          Error: string option }

    type Msg =
        | LoadData of string
        | SetCarData of CarData
        | SetColorAction of ColorAction
        | SetColors of ResizeArray<Events.PlotDatum>
        | SetError of string option

module State =
    open Types

    let loadDataset (path: string) (state: State) (dispatch: Msg -> unit) : unit =
        async {
            let! (statusCode, responseText) = Http.get path
            if statusCode = 200 then
                let fullData =
                    responseText.Trim().Split('\n')
                    |> Array.map (fun s -> s.Split(','))

                fullData
                |> Array.tail
                |> Array.fold (fun (state: CarData) (values: string []) -> state.AddDataSet values) state.CarData
                |> fun newContent -> { newContent with Headers = fullData |> Array.head }
                |> SetCarData
                |> dispatch
            else
                dispatch <| SetError(Some $"Status {statusCode}: could not load {path}")
        }
        |> Async.StartImmediate

    let update (msg: Msg) (state: State) : State * Cmd<Msg> =
        match msg with
        | LoadData path -> state, Cmd.ofEffect (loadDataset path state)
        | SetCarData carData -> { state with CarData = carData; Colors = carData.Horsepower |> Array.map (fun _ -> 0);  DataLoaded = true; Error = None }, Cmd.none
        | SetColorAction colorAction -> { state with ColorAction = colorAction }, Cmd.none
        | SetColors points ->
            let colorPre =
                points
                |> Array.ofSeq
                |> Array.choose (fun pObj -> pObj.pointNumber)

            let colors =
                state.Colors
                |> Array.mapi (fun i origColor ->
                    if Array.contains i colorPre then
                        match state.ColorAction with
                        | ColorAction.Erase -> 0
                        | ColorAction.Red -> 1
                        | ColorAction.Blue -> 2
                    else origColor)

            { state with Colors = colors }, Cmd.none
        | SetError err -> { state with Error = err }, Cmd.none

    let init () : State * Cmd<Msg> =
        { CarData = CarData.empty
          ColorAction = ColorAction.Erase
          Colors = [| |]
          DataLoaded = false
          Error = None }, Cmd.ofMsg (LoadData "https://raw.githubusercontent.com/plotly/datasets/master/imports-85.csv")

module View =
    open Types

    let plotData (state: State) : IPlotProperty =
        let plotColorscale =
            [ color.gray
              color.gray
              color.fireBrick
              color.fireBrick
              color.blue
              color.blue ]
            |> color.colorscale.sequential

        plot.traces [
            traces.scatter [
                scatter.x state.CarData.Horsepower
                scatter.y state.CarData.HighwayMPG
                scatter.mode.markers
                scatter.marker [
                    marker.color state.Colors
                    marker.colorscale plotColorscale
                    marker.cmin -0.5
                    marker.cmax 2.5
                    marker.showscale true
                    marker.colorbar [
                        colorbar.tickmode.array
                        colorbar.tickvals [ 0; 1; 2 ]
                        colorbar.ticktext [ "None"; "Red"; "Blue" ]
                    ]
                ]
            ]
            traces.parcats [
                parcats.dimensions [
                    dimensions.dimension [
                        dimension.label "Body Style"
                        dimension.values state.CarData.BodyStyle
                    ]
                    dimensions.dimension [
                        dimension.label "Drive Wheels"
                        dimension.values state.CarData.DriveWheels
                    ]
                    dimensions.dimension [
                        dimension.label "Fuel Type"
                        dimension.values state.CarData.FuelType
                    ]
                ]
                parcats.domain [
                    domain.y [ 0.; 0.4 ]
                ]
                parcats.line [
                    line.color state.Colors
                    line.colorscale plotColorscale
                    line.cmin -0.5
                    line.cmax 2.5
                    line.shape.hspline
                ]
                parcats.labelfont [
                    labelfont.size 14
                ]
            ]
        ]

    [<ReactComponent>]
    let render () : ReactElement =
        let state,dispatch = React.useElmish(State.init(), State.update, [||])

        match state.DataLoaded, state.Error with
        | false, _ ->
            Html.div [
                prop.style [
                    style.textAlign.center
                    style.marginLeft length.auto
                    style.marginRight length.auto
                    style.marginTop 50
                ]
                prop.children [
                    Html.li [
                        prop.className [
                            FA.Fa
                            FA.FaRefresh
                            FA.FaSpin
                            FA.Fa3X
                        ]
                    ]
                ]
            ]
        | true, None ->
            Html.div [
                Plotly.plot [
                    plotData state
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
                    plot.onSelected <| fun o -> o.points |> SetColors |> dispatch
                    plot.onClick <| fun o -> o.points |> SetColors |> dispatch
                ]
                Html.div [
                    prop.className Bulma.Control
                    prop.style [
                        style.paddingLeft (length.em 8)
                        style.paddingBottom (length.em 1)
                    ]
                    prop.children [
                        Html.button [
                            prop.classes [ Bulma.Button; if state.ColorAction = ColorAction.Erase then yield! [ Bulma.IsActive; Bulma.HasBackgroundPrimary; Bulma.HasTextWhite ] ]
                            prop.onClick <| fun _ -> dispatch (SetColorAction ColorAction.Erase)
                            prop.text "Erase"
                        ]
                        Html.button [
                            prop.classes [ Bulma.Button; if state.ColorAction = ColorAction.Red then yield! [ Bulma.IsActive; Bulma.HasBackgroundPrimary; Bulma.HasTextWhite ] ]
                            prop.onClick <| fun _ -> dispatch (SetColorAction ColorAction.Red)
                            prop.text "Red"
                        ]
                        Html.button [
                            prop.classes [ Bulma.Button; if state.ColorAction = ColorAction.Blue then yield! [ Bulma.IsActive; Bulma.HasBackgroundPrimary; Bulma.HasTextWhite ] ]
                            prop.onClick <| fun _ -> dispatch (SetColorAction ColorAction.Blue)
                            prop.text "Blue"
                        ]
                    ]
                ]
            ]
        | _, Some error ->
            Html.h1 [
                prop.style [ style.color.crimson ]
                prop.text error
            ]

let inline chart () = View.render()

```
