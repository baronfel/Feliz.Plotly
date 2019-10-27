namespace Feliz.Plotly

(*////////////////////////////////
/// THIS FILE IS AUTO-GENERATED //
////////////////////////////////*)

open Fable.Core
open Fable.Core.JsInterop
open Feliz

[<Erase>]
type table =
    /// Sets the trace name. The trace name appear as the legend item and on hover.
    static member inline name (value: string) = Interop.mkTableAttr "name" value
    /// Assign an id to this trace, Use this to provide object constancy between traces during animations and transitions.
    static member inline uid (value: string) = Interop.mkTableAttr "uid" value
    /// Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.
    static member inline ids (value: bool) = Interop.mkTableAttr "ids" (value |> Array.singleton)
    /// Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.
    static member inline ids (values: seq<bool>) = Interop.mkTableAttr "ids" (values |> Array.ofSeq)
    /// Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.
    static member inline ids (value: string) = Interop.mkTableAttr "ids" (value |> Array.singleton)
    /// Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.
    static member inline ids (values: seq<string>) = Interop.mkTableAttr "ids" (values |> Array.ofSeq)
    /// Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.
    static member inline ids (value: int) = Interop.mkTableAttr "ids" (value |> Array.singleton)
    /// Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.
    static member inline ids (values: seq<int>) = Interop.mkTableAttr "ids" (values |> Array.ofSeq)
    /// Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.
    static member inline ids (value: float) = Interop.mkTableAttr "ids" (value |> Array.singleton)
    /// Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.
    static member inline ids (values: seq<float>) = Interop.mkTableAttr "ids" (values |> Array.ofSeq)
    /// Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, *scatter* traces also appends customdata items in the markers DOM elements
    static member inline customdata (value: bool) = Interop.mkTableAttr "customdata" (value |> Array.singleton)
    /// Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, *scatter* traces also appends customdata items in the markers DOM elements
    static member inline customdata (values: seq<bool>) = Interop.mkTableAttr "customdata" (values |> Array.ofSeq)
    /// Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, *scatter* traces also appends customdata items in the markers DOM elements
    static member inline customdata (value: string) = Interop.mkTableAttr "customdata" (value |> Array.singleton)
    /// Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, *scatter* traces also appends customdata items in the markers DOM elements
    static member inline customdata (values: seq<string>) = Interop.mkTableAttr "customdata" (values |> Array.ofSeq)
    /// Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, *scatter* traces also appends customdata items in the markers DOM elements
    static member inline customdata (value: int) = Interop.mkTableAttr "customdata" (value |> Array.singleton)
    /// Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, *scatter* traces also appends customdata items in the markers DOM elements
    static member inline customdata (values: seq<int>) = Interop.mkTableAttr "customdata" (values |> Array.ofSeq)
    /// Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, *scatter* traces also appends customdata items in the markers DOM elements
    static member inline customdata (value: float) = Interop.mkTableAttr "customdata" (value |> Array.singleton)
    /// Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, *scatter* traces also appends customdata items in the markers DOM elements
    static member inline customdata (values: seq<float>) = Interop.mkTableAttr "customdata" (values |> Array.ofSeq)
    static member inline hoverlabel (properties: #IHoverlabelProperty list) = Interop.mkTableAttr "hoverlabel" (createObj !!properties)
    static member inline stream (properties: #IStreamProperty list) = Interop.mkTableAttr "stream" (createObj !!properties)
    /// Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.
    static member inline uirevision (value: bool) = Interop.mkTableAttr "uirevision" value
    /// Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.
    static member inline uirevision (values: seq<bool>) = Interop.mkTableAttr "uirevision" (values |> Array.ofSeq)
    /// Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.
    static member inline uirevision (value: string) = Interop.mkTableAttr "uirevision" value
    /// Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.
    static member inline uirevision (values: seq<string>) = Interop.mkTableAttr "uirevision" (values |> Array.ofSeq)
    /// Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.
    static member inline uirevision (value: int) = Interop.mkTableAttr "uirevision" value
    /// Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.
    static member inline uirevision (values: seq<int>) = Interop.mkTableAttr "uirevision" (values |> Array.ofSeq)
    /// Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.
    static member inline uirevision (value: float) = Interop.mkTableAttr "uirevision" value
    /// Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.
    static member inline uirevision (values: seq<float>) = Interop.mkTableAttr "uirevision" (values |> Array.ofSeq)
    static member inline domain (properties: #IDomainProperty list) = Interop.mkTableAttr "domain" (createObj !!properties)
    /// The width of columns expressed as a ratio. Columns fill the available width in proportion of their specified column widths.
    static member inline columnwidth (value: int) = Interop.mkTableAttr "columnwidth" value
    /// The width of columns expressed as a ratio. Columns fill the available width in proportion of their specified column widths.
    static member inline columnwidth (value: float) = Interop.mkTableAttr "columnwidth" value
    /// The width of columns expressed as a ratio. Columns fill the available width in proportion of their specified column widths.
    static member inline columnwidth (values: seq<int>) = Interop.mkTableAttr "columnwidth" (values |> Array.ofSeq)
    /// The width of columns expressed as a ratio. Columns fill the available width in proportion of their specified column widths.
    static member inline columnwidth (values: seq<float>) = Interop.mkTableAttr "columnwidth" (values |> Array.ofSeq)
    /// Specifies the rendered order of the data columns; for example, a value `2` at position `0` means that column index `0` in the data will be rendered as the third column, as columns have an index base of zero.
    static member inline columnorder (value: bool) = Interop.mkTableAttr "columnorder" (value |> Array.singleton)
    /// Specifies the rendered order of the data columns; for example, a value `2` at position `0` means that column index `0` in the data will be rendered as the third column, as columns have an index base of zero.
    static member inline columnorder (values: seq<bool>) = Interop.mkTableAttr "columnorder" (values |> Array.ofSeq)
    /// Specifies the rendered order of the data columns; for example, a value `2` at position `0` means that column index `0` in the data will be rendered as the third column, as columns have an index base of zero.
    static member inline columnorder (value: string) = Interop.mkTableAttr "columnorder" (value |> Array.singleton)
    /// Specifies the rendered order of the data columns; for example, a value `2` at position `0` means that column index `0` in the data will be rendered as the third column, as columns have an index base of zero.
    static member inline columnorder (values: seq<string>) = Interop.mkTableAttr "columnorder" (values |> Array.ofSeq)
    /// Specifies the rendered order of the data columns; for example, a value `2` at position `0` means that column index `0` in the data will be rendered as the third column, as columns have an index base of zero.
    static member inline columnorder (value: int) = Interop.mkTableAttr "columnorder" (value |> Array.singleton)
    /// Specifies the rendered order of the data columns; for example, a value `2` at position `0` means that column index `0` in the data will be rendered as the third column, as columns have an index base of zero.
    static member inline columnorder (values: seq<int>) = Interop.mkTableAttr "columnorder" (values |> Array.ofSeq)
    /// Specifies the rendered order of the data columns; for example, a value `2` at position `0` means that column index `0` in the data will be rendered as the third column, as columns have an index base of zero.
    static member inline columnorder (value: float) = Interop.mkTableAttr "columnorder" (value |> Array.singleton)
    /// Specifies the rendered order of the data columns; for example, a value `2` at position `0` means that column index `0` in the data will be rendered as the third column, as columns have an index base of zero.
    static member inline columnorder (values: seq<float>) = Interop.mkTableAttr "columnorder" (values |> Array.ofSeq)
    static member inline header (properties: #IHeaderProperty list) = Interop.mkTableAttr "header" (createObj !!properties)
    static member inline cells (properties: #ICellsProperty list) = Interop.mkTableAttr "cells" (createObj !!properties)
    /// Sets the source reference on plot.ly for  ids .
    static member inline idssrc (value: string) = Interop.mkTableAttr "idssrc" value
    /// Sets the source reference on plot.ly for  customdata .
    static member inline customdatasrc (value: string) = Interop.mkTableAttr "customdatasrc" value
    /// Sets the source reference on plot.ly for  meta .
    static member inline metasrc (value: string) = Interop.mkTableAttr "metasrc" value
    /// Sets the source reference on plot.ly for  hoverinfo .
    static member inline hoverinfosrc (value: string) = Interop.mkTableAttr "hoverinfosrc" value
    /// Sets the source reference on plot.ly for  columnwidth .
    static member inline columnwidthsrc (value: string) = Interop.mkTableAttr "columnwidthsrc" value
    /// Sets the source reference on plot.ly for  columnorder .
    static member inline columnordersrc (value: string) = Interop.mkTableAttr "columnordersrc" value

[<AutoOpen>]
module table =
    /// Determines whether or not this trace is visible. If *legendonly*, the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).
    [<Erase>]
    type visible =
        static member inline legendonly = Interop.mkTableAttr "visible" "legendonly"
        static member inline false' = Interop.mkTableAttr "visible" "false"
        static member inline true' = Interop.mkTableAttr "visible" "true"

    /// Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.
    [<Erase>]
    type hoverinfo =
        static member inline all = Interop.mkTableAttr "hoverinfo" "all"
        static member inline none = Interop.mkTableAttr "hoverinfo" "none"
        static member inline skip = Interop.mkTableAttr "hoverinfo" "skip"
        static member inline name = Interop.mkTableAttr "hoverinfo" "name"
        static member inline nameAndText = Interop.mkTableAttr "hoverinfo" "name+text"
        static member inline nameAndTextX = Interop.mkTableAttr "hoverinfo" "name+text+x"
        static member inline nameAndTextY = Interop.mkTableAttr "hoverinfo" "name+text+y"
        static member inline nameAndTextYX = Interop.mkTableAttr "hoverinfo" "name+text+y+x"
        static member inline nameAndTextZ = Interop.mkTableAttr "hoverinfo" "name+text+z"
        static member inline nameAndTextZX = Interop.mkTableAttr "hoverinfo" "name+text+z+x"
        static member inline nameAndTextZY = Interop.mkTableAttr "hoverinfo" "name+text+z+y"
        static member inline nameAndTextZYX = Interop.mkTableAttr "hoverinfo" "name+text+z+y+x"
        static member inline nameAndX = Interop.mkTableAttr "hoverinfo" "name+x"
        static member inline nameAndY = Interop.mkTableAttr "hoverinfo" "name+y"
        static member inline nameAndYX = Interop.mkTableAttr "hoverinfo" "name+y+x"
        static member inline nameAndZ = Interop.mkTableAttr "hoverinfo" "name+z"
        static member inline nameAndZX = Interop.mkTableAttr "hoverinfo" "name+z+x"
        static member inline nameAndZY = Interop.mkTableAttr "hoverinfo" "name+z+y"
        static member inline nameAndZYX = Interop.mkTableAttr "hoverinfo" "name+z+y+x"
        static member inline text = Interop.mkTableAttr "hoverinfo" "text"
        static member inline textAndX = Interop.mkTableAttr "hoverinfo" "text+x"
        static member inline textAndY = Interop.mkTableAttr "hoverinfo" "text+y"
        static member inline textAndYX = Interop.mkTableAttr "hoverinfo" "text+y+x"
        static member inline textAndZ = Interop.mkTableAttr "hoverinfo" "text+z"
        static member inline textAndZX = Interop.mkTableAttr "hoverinfo" "text+z+x"
        static member inline textAndZY = Interop.mkTableAttr "hoverinfo" "text+z+y"
        static member inline textAndZYX = Interop.mkTableAttr "hoverinfo" "text+z+y+x"
        static member inline x = Interop.mkTableAttr "hoverinfo" "x"
        static member inline y = Interop.mkTableAttr "hoverinfo" "y"
        static member inline yAndX = Interop.mkTableAttr "hoverinfo" "y+x"
        static member inline z = Interop.mkTableAttr "hoverinfo" "z"
        static member inline zAndX = Interop.mkTableAttr "hoverinfo" "z+x"
        static member inline zAndY = Interop.mkTableAttr "hoverinfo" "z+y"
        static member inline zAndYX = Interop.mkTableAttr "hoverinfo" "z+y+x"

