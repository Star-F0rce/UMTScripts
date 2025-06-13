using System;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using UndertaleModLib.Util;
EnsureDataLoaded();
UndertaleModLib.Compiler.CodeImportGroup importGroup = new(Data);

if (Data.GeneralInfo.DisplayName.Content != "DELTARUNE Chapter 4")
{
    ScriptError("This isn't Chapter 4.");
    return;
}

bool mark = ScriptQuestion("This will reset the charts, are you sure you want to run this?");
if (mark == false)
{
    ScriptError("You weren't sure.");
    return;
}

string dataPath = Path.Combine(Path.GetDirectoryName(ScriptPath), "chart");

QueueGMLFile(Path.Combine(dataPath, "C4_chart.gml"));
QueueGMLFile(Path.Combine(dataPath, "C4_songload.gml"));
QueueGMLFile(Path.Combine(dataPath, "C4_songdraw.gml"));
importGroup.QueueReplace("gml_GlobalScript_scr_rhythmgame_notechart","C4_chart.gml");
importGroup.QueueReplace("gml_GlobalScript_scr_rhythmgame_draw","C4_songdraw.gml");
importGroup.QueueReplace("gml_GlobalScript_scr_rhythmgame_song_load","C4_songload.gml");

importGroup.Import(false);

ScriptMessage("Done! Note that this doesn't entirely fix Raise Up Your Bat.\nRestore the vanilla data.win to do that.");

void QueueGMLFile(string path)
{
    importGroup.QueueReplace(Path.GetFileNameWithoutExtension(path), File.ReadAllText(path));
}