// F# の詳細については、http://fsharp.net を参照してください
// 詳細については、'F# チュートリアル' プロジェクトを参照してください。
open System
open RaspiRobotNet
open RaspberryGPIOManager

[<EntryPoint>]
let main argv = 
    printfn "Hello RaspiRobotNet"

    let robot = new RaspiRobot()
    let mutable loop = true
    while loop do
      let key = Console.ReadKey()
      match key.KeyChar with
      | 'e' | 'q' -> loop <- false
      | 'f' -> robot.Forward(1.0f)
      | 'b' -> robot.Back(1.0f)
      | 'r' -> robot.Right(1.0f)
      | 'l' -> robot.Left(1.0f)
      | 's' -> robot.Stop()
      | '1' -> robot.SetLED1( robot.LED1.State = GPIOPinDriver.GPIOState.Low )
      | '2' -> robot.SetLED2( robot.LED2.State = GPIOPinDriver.GPIOState.Low )
      | '3' -> robot.SetOC1( robot.OC1.State = GPIOPinDriver.GPIOState.Low )
      | '4' -> robot.SetOC2( robot.OC2.State = GPIOPinDriver.GPIOState.Low )
      | _ -> ()


    0 // 整数の終了コードを返します
