namespace TechIo

open System
open System.IO
open Microsoft.VisualStudio.TestTools.UnitTesting
open Answer

[<TestClass>]
type UniverseTest () =
    // Display a custom message in a custom channel
    let PrintMessage = 
        printfn "TECHIO> message --channel \"%s\" \"%s\""

    // You can manually handle the success/failure of a testcase using this function
    let Success =
        printfn "TECHIO> success %b"

    let ExistsInFile path keyword =
        File.ReadAllText(path).Contains(keyword)


    let mutable shouldShowHint = false;

    [<TestMethod>]
    member this.VerifyCountAllStars () =
        shouldShowHint <- true
        Assert.AreEqual (6,   Exercise1.CountAllStars [ 1; 2; 3 ]);
        Assert.AreEqual (16,   Exercise1.CountAllStars [ 10; 3; 2; 1 ]);
        Assert.AreEqual (42,   Exercise1.CountAllStars [ 20; 20; 2 ]);
        shouldShowHint <- false

    [<TestCleanup()>]
    member this.Cleanup () =
        if shouldShowHint
        then
            PrintMessage "Hint 💡" "Did you properly accumulate all stars ?🤔"
        else 
            if ExistsInFile @"/project/target/Exercises/UniverseStub.fs" "List.sum(galaxies)"
            then
                PrintMessage "My personal Yoda, you are. 🙏" "* ● ¸ .　¸. :° ☾ ° 　¸. ● ¸ .　　¸.　:. • "
                PrintMessage "My personal Yoda, you are. 🙏" "           　★ °  ☆ ¸. ¸ 　★　 :.　 .   "
                PrintMessage "My personal Yoda, you are. 🙏" "__.-._     ° . .　　　　.　☾ ° 　. *   ¸ ."
                PrintMessage "My personal Yoda, you are. 🙏" "'-._\\7'      .　　° ☾  ° 　¸.☆  ● .　　　"
                PrintMessage "My personal Yoda, you are. 🙏" " /'.-c    　   * ●  ¸.　　°     ° 　¸.    "
                PrintMessage "My personal Yoda, you are. 🙏" " |  /T      　　°     ° 　¸.     ¸ .　　  "
                PrintMessage "My personal Yoda, you are. 🙏" "_)_/LI"
            else
                PrintMessage "Kudos 🌟" "Nice !"
                PrintMessage "Kudos 🌟" "You can try: List.sum(galaxies)"
