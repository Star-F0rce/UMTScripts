// Starts Weird Route by naming yourself SNOWGRAVE

EnsureDataLoaded();

ScriptMessage("This script makes it so that naming yourself \"SNOWGRAVE\"\nwill start you on the weird route.");

UndertaleModLib.Compiler.CodeImportGroup importGroup = new(Data);
if (Data.GeneralInfo.DisplayName.Content == "DELTARUNE Chapter 3")
{
var ch3 = Data.GameObjects.ByName("obj_ch3_PGS01A").EventHandlerFor(EventType.Step, Data);
// Import code
importGroup.QueueFindReplace(ch3,"con = 3", @"
con = 3
if (global.truename == ""SNOWGRAVE"" && global.flag[914] == 0) {
    global.flag[915] = 9;
    global.flag[457] = 0;
    global.flag[349] = 1;
    global.charweapon[4] = 13;
    global.chararmor2[1] = 14;
    global.chararmor2[4] = 10;
}");
}
if (Data.GeneralInfo.DisplayName.Content == "DELTARUNE Chapter 4")
{
var ch3 = Data.GameObjects.ByName("obj_ch4_PDC01A").EventHandlerFor(EventType.Step, Data);
importGroup.QueueFindReplace(ch3,"con = 4", @"
con = 4
if (global.truename == ""SNOWGRAVE"" && global.flag[914] == 0) {
    global.flag[915] = 9;
    global.flag[457] = 0;
    global.flag[349] = 1;
    global.charweapon[4] = 13;
    global.chararmor2[1] = 14;
    global.chararmor2[4] = 10;
}");
}

importGroup.Import();

ScriptMessage("Proceed.");

