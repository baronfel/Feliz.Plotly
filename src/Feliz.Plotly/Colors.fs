namespace Feliz.Plotly

open Fable.Core
open System.ComponentModel

module colors =
    let hsl (hue: float, saturation: float, lightness: float) = 
        sprintf "hsl(%s,%s%c,%s%c)" (unbox<string> hue) (unbox<string> saturation) '%' (unbox<string> lightness) '%'

module ColorScales =
    open Feliz.colors

    type ColorScale =
        /// Scales colors in order equally
        | Sequential
        /// Scales colors in reverse order equally
        | SequentialMinus
        /// Scales color around divergence point
        | Diverging of float

    /// TODO
    let custom (scale: ColorScale) (colors: string list) =
        match scale with
        | Sequential -> ()
        | SequentialMinus -> ()
        | Diverging mid -> ()

    /// How to represent float,string array in F#?
    let greys =
        [ rgb (0, 0, 0)
          rgb (255, 255, 255) ]

    let ylGnBu =
        [ rgb (8, 29, 88)
          rgb (37, 52, 148)
          rgb (34, 94, 168)
          rgb (29, 145, 192)
          rgb (65, 182, 196)
          rgb (127, 205, 187)
          rgb (199, 233, 180)
          rgb (237, 248, 217)
          rgb (255, 255, 217) ]

    let greens =
        [ rgb (0, 68, 27)
          rgb (0, 109, 44)
          rgb (35, 139, 69)
          rgb (65, 171, 93)
          rgb (116, 196, 118)
          rgb (161, 217, 155)
          rgb (199, 233, 192)
          rgb (229, 245, 224)
          rgb (247, 252, 245) ]

    let ylOrRd =
        [ rgb (128, 0, 38)
          rgb (189, 0, 38)
          rgb (227, 26, 28)
          rgb (252, 78, 42)
          rgb (253, 141, 60)
          rgb (254, 178, 76)
          rgb (254, 217, 118)
          rgb (255, 237, 160)
          rgb (255, 255, 204) ]

    let bluered =
        [ rgb (0, 0, 255)
          rgb (255, 0, 0) ]

    /// modified RdBu based on
    ///
    /// http://www.kennethmoreland.com/color-maps/
    let rdBu =
        [ rgb (5, 10, 172)
          rgb (106, 137, 247)
          rgb (190, 190, 190)
          rgb (220, 170, 132)
          rgb (230, 145, 90)
          rgb (178, 10, 28) ]

    let reds =
        [ rgb (220, 220, 220)
          rgb (245, 195, 157)
          rgb (245, 160, 105)
          rgb (178, 10, 28) ]

    let blues =
        [ rgb (5, 10, 172)
          rgb (40, 60, 190)
          rgb (70, 100, 245)
          rgb (90, 120, 245)
          rgb (106, 137, 247)
          rgb (220, 220, 220) ]

    let picnic =
        [ rgb (0, 0, 255)
          rgb (51, 153, 255)
          rgb (102, 204, 255)
          rgb (153, 204, 255)
          rgb (204, 204, 255)
          rgb (255, 255, 255)
          rgb (255, 204, 255)
          rgb (255, 153, 255)
          rgb (255, 102, 204)
          rgb (255, 102, 102)
          rgb (255, 0, 0) ]

    let rainbow =
        [ rgb (150, 0, 90)
          rgb (0, 0, 200)
          rgb (0, 25, 255)
          rgb (0, 152, 255)
          rgb (44, 255, 150)
          rgb (151, 255, 0)
          rgb (255, 234, 0)
          rgb (255, 111, 0)
          rgb (255, 0, 0) ]

    let portland =
        [ rgb (12, 51, 131)
          rgb (10, 136, 186)
          rgb (242, 211, 56)
          rgb (242, 143, 56)
          rgb (217, 30, 30) ]

    let jet =
        [ rgb (0, 0, 131)
          rgb (0, 60, 170)
          rgb (5, 255, 255)
          rgb (255, 255, 0)
          rgb (250, 0, 0)
          rgb (128, 0, 0) ]

    let hot =
        [ rgb (0, 0, 0)
          rgb (230, 0, 0)
          rgb (255, 210, 0)
          rgb (255, 255, 255) ]

    let blackbody =
        [ rgb (0, 0, 0)
          rgb (230, 0, 0)
          rgb (230, 210, 0)
          rgb (255, 255, 255)
          rgb (160, 200, 255) ]

    let earth =
        [ rgb (0, 0, 130)
          rgb (0, 180, 180)
          rgb (40, 210, 40)
          rgb (230, 230, 50)
          rgb (120, 70, 20)
          rgb (255, 255, 255) ]

    let electric =
        [ rgb (0, 0, 0)
          rgb (30, 0, 100)
          rgb (120, 0, 100)
          rgb (160, 90, 0)
          rgb (230, 200, 0)
          rgb (255, 250, 220) ]

    let viridis =
        [ "#440154"
          "#48186a"
          "#472d7b"
          "#424086"
          "#3b528b"
          "#33638d"
          "#2c728e"
          "#26828e"
          "#21918c"
          "#1fa088"
          "#28ae80"
          "#3fbc73"
          "#5ec962"
          "#84d44b"
          "#addc30"
          "#d8e219"
          "#fde725" ]

    let cividis =
        [ rgb (0, 32, 76)
          rgb (0, 42, 102)
          rgb (0, 52, 110)
          rgb (39, 63, 108)
          rgb (60, 74, 107)
          rgb (76, 85, 107)
          rgb (91, 95, 109)
          rgb (104, 106, 112)
          rgb (117, 117, 117)
          rgb (131, 129, 120)
          rgb (146, 140, 120)
          rgb (161, 152, 118)
          rgb (176, 165, 114)
          rgb (192, 177, 109)
          rgb (209, 191, 102)
          rgb (225, 204, 92)
          rgb (243, 219, 79)
          rgb (255, 233, 69) ]
