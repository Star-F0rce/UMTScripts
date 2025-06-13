using System;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using UndertaleModLib.Util;
EnsureDataLoaded();
UndertaleModLib.Compiler.CodeImportGroup importGroup = new(Data);

if (Data.GeneralInfo.DisplayName.Content != "DELTARUNE Chapter 3")
{
    ScriptError("This isn't Chapter 3.");
    return;
}

string dataPath = Path.Combine(Path.GetDirectoryName(ScriptPath), "chart");

QueueGMLFile(Path.Combine(dataPath, "gml_GlobalScript_scr_rhythmgame_notechart.gml"));
importGroup.QueueReplace("gml_GlobalScript_scr_rhythmgame_notechart","gml_GlobalScript_scr_rhythmgame_notechart.gml");

importGroup.Import(false);

var tenna = Data.Scripts.ByName("scr_rhythmgame_notechart");
bool doLoad = ScriptQuestion("Are you loading a chart?");

if (doLoad == true)
{
string chart = ScriptInputDialog("Chart Input","Paste your chart in here.","Chart","Cancel","Submit",true,false);
importGroup.QueueFindReplace(tenna.Code,"        scr_rhythmgame_addnote_range(0.41, 0, 0);",chart);
}

if (doLoad == false)
{
var init = Data.GameObjects.ByName("obj_initializer2").EventHandlerFor(EventType.Create, Data);
var namer = Data.GameObjects.ByName("DEVICE_NAMER").EventHandlerFor(EventType.Draw, Data);
var gameload = Data.Scripts.ByName("scr_rhythmgame_song_load");
var gamename = Data.Scripts.ByName("scr_rhythmgame_draw");
var debugtitle = Data.GameObjects.ByName("obj_title_placeholder").EventHandlerFor(EventType.Create, Data);
var debugroom = Data.GameObjects.ByName("obj_title_placeholder").EventHandlerFor(EventType.Step, Data);
ScriptMessage("Alright, you're gonna need your song's filename, bpm, and length.");
string songname = ScriptInputDialog("File Name","What's the song's filename?","songname.ogg","Cancel","Submit",false,false);
string songbpm = ScriptInputDialog("BPM","What's the BPM as an integer? (No decimals!)","bpm = 100","Cancel","Submit",false,false);
string songlength = ScriptInputDialog("Length","What's the song's lenth in seconds? Up to 3 decimal places.","track_length = 69.420","Cancel","Submit",false,false);
importGroup.QueueFindReplace(gamename.Code,"Tenna boss",songname);
importGroup.QueueFindReplace(gameload.Code,"tenna_battle_guitar.ogg","");
importGroup.QueueFindReplace(gameload.Code,"tenna_battle.ogg",songname);
importGroup.QueueFindReplace(gameload.Code,"bpm = 148",songbpm);
importGroup.QueueFindReplace(gameload.Code,"track_length = 165.405",songlength);
importGroup.QueueFindReplace(init,"debug = 0","debug = 1");
importGroup.QueueFindReplace(debugtitle,"Quick Load","Go to Rhythm Editor");
importGroup.QueueFindReplace(debugroom,"scr_load()","room_goto(room_rhythmgame_editor)");
}

importGroup.Import();

if (doLoad == true)
{
ScriptMessage("Loaded! Save data.win and don't forget to delete the .txts from your save folder.");
}

if (doLoad == false)
{
ScriptMessage("All set! Save data.win, put your song in the mus folder,\nthen open Chapter 3 to access the editor.");
}

void QueueGMLFile(string path)
{
    importGroup.QueueReplace(Path.GetFileNameWithoutExtension(path), File.ReadAllText(path));
}
