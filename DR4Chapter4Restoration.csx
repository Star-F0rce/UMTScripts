// Chapter 4 Restoration Script
// Based on TouchControlsEnabler by GitMuslim, Some fixes by NC-devC

using System;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using UndertaleModLib.Util;

EnsureDataLoaded();

if (Data.GeneralInfo.DisplayName.Content != "DELTARUNE Chapter 4")
{
    ScriptError("This isn't Chapter 4.");
    return;
}

bool doRose = ScriptQuestion("Restore rose animation?");
bool doFurry = ScriptQuestion("Restore \"furry degenerate\"?");
// Insert rose anim
if (doRose == true)
{
string dataPath = Path.Combine(Path.GetDirectoryName(ScriptPath), "rose");

Dictionary<string, UndertaleEmbeddedTexture> textures = new Dictionary<string, UndertaleEmbeddedTexture>();

UndertaleEmbeddedTexture roseTexturePage = new UndertaleEmbeddedTexture();
roseTexturePage.TextureData.Image = GMImage.FromPng(File.ReadAllBytes(Path.Combine(dataPath, "rose.png")));
Data.EmbeddedTextures.Add(roseTexturePage);
textures.Add(Path.GetFileName(Path.Combine(dataPath, "rose.png")), roseTexturePage);

UndertaleTexturePageItem AddNewTexturePageItem(ushort sourceX, ushort sourceY, ushort sourceWidth, ushort sourceHeight)
{
    ushort targetX = 0;
    ushort targetY = 0;
    ushort targetWidth = sourceWidth;
    ushort targetHeight = sourceHeight;
    ushort boundingWidth = sourceWidth;
    ushort boundingHeight = sourceHeight;
    var texturePage = textures["rose.png"];

    UndertaleTexturePageItem tpItem = new() 
    { 
        SourceX = sourceX, 
        SourceY = sourceY, 
        SourceWidth = sourceWidth, 
        SourceHeight = sourceHeight, 
        TargetX = targetX, 
        TargetY = targetY, 
        TargetWidth = targetWidth, 
        TargetHeight = targetHeight, 
        BoundingWidth = boundingWidth, 
        BoundingHeight = boundingHeight, 
        TexturePage = texturePage,
        Name = new UndertaleString($"PageItem {Data.TexturePageItems.Count}")
    };
    Data.TexturePageItems.Add(tpItem);
    return tpItem;
}

UndertaleTexturePageItem pg_rosea = AddNewTexturePageItem(0, 0, 8, 8);
UndertaleTexturePageItem pg_roseb = AddNewTexturePageItem(8, 0, 8, 8);
UndertaleTexturePageItem pg_rosec = AddNewTexturePageItem(16, 0, 8, 8);
UndertaleTexturePageItem pg_rosed = AddNewTexturePageItem(24, 0, 8, 8);
UndertaleTexturePageItem pg_rosee = AddNewTexturePageItem(32, 0, 8, 8);
UndertaleTexturePageItem pg_rosef = AddNewTexturePageItem(40, 0, 8, 8);
UndertaleTexturePageItem pg_roseg = AddNewTexturePageItem(48, 0, 8, 8);
UndertaleTexturePageItem pg_roseh = AddNewTexturePageItem(56, 0, 8, 8);
UndertaleTexturePageItem pg_rosei = AddNewTexturePageItem(0, 8, 8, 8);
UndertaleTexturePageItem pg_rosej = AddNewTexturePageItem(8, 8, 8, 8);
UndertaleTexturePageItem pg_rosek = AddNewTexturePageItem(16, 8, 8, 8);
UndertaleTexturePageItem pg_rosel = AddNewTexturePageItem(24, 8, 8, 8);
UndertaleTexturePageItem pg_rosem = AddNewTexturePageItem(32, 8, 8, 8);
UndertaleTexturePageItem pg_rosen = AddNewTexturePageItem(40, 8, 8, 8);
UndertaleTexturePageItem pg_roseo = AddNewTexturePageItem(48, 8, 8, 8);
UndertaleTexturePageItem pg_rosep = AddNewTexturePageItem(56, 8, 8, 8);
UndertaleTexturePageItem pg_roseq = AddNewTexturePageItem(0, 16, 8, 8);
UndertaleTexturePageItem pg_roser = AddNewTexturePageItem(8, 16, 8, 8);
UndertaleTexturePageItem pg_roses = AddNewTexturePageItem(16, 16, 8, 8);
UndertaleTexturePageItem pg_roset = AddNewTexturePageItem(24, 16, 8, 8);
UndertaleTexturePageItem pg_roseu = AddNewTexturePageItem(32, 16, 8, 8);
UndertaleTexturePageItem pg_rosev = AddNewTexturePageItem(40, 16, 8, 8);
UndertaleTexturePageItem pg_rosew = AddNewTexturePageItem(48, 16, 8, 8);

void AddNewUndertaleSprite(string spriteName, ushort width, ushort height, UndertaleTexturePageItem[] spriteTextures)
{
    var name = Data.Strings.MakeString(spriteName);
    ushort marginLeft = 0;
    int marginRight = width - 1;
    ushort marginTop = 0;
    int marginBottom = height - 1;

    var sItem = new UndertaleSprite { Name = name, Width = width, Height = height, MarginLeft = marginLeft, MarginRight = marginRight, MarginTop = marginTop, MarginBottom = marginBottom, IsSpecialType = true, SVersion = 3, GMS2PlaybackSpeed = 1.0f, GMS2PlaybackSpeedType = AnimSpeedType.FramesPerGameFrame};
    foreach (var spriteTexture in spriteTextures) 
    {
        sItem.Textures.Add(new UndertaleSprite.TextureEntry() { Texture = spriteTexture });
    }
    Data.Sprites.Add(sItem);
}

AddNewUndertaleSprite("spr_rose2", 8, 8, new UndertaleTexturePageItem[] {pg_rosea, pg_roseb, pg_rosec, pg_rosed, pg_rosee, pg_rosef, pg_roseg, pg_roseh, pg_rosei, pg_rosej, pg_rosek, pg_rosel, pg_rosem, pg_rosen, pg_roseo, pg_rosep, pg_roseq, pg_roser, pg_roses, pg_roset, pg_roseu, pg_rosev, pg_rosew});
}
UndertaleModLib.Compiler.CodeImportGroup importGroup = new(Data);
var weird = Data.GameObjects.ByName("obj_ch4_PDC14A_noelle").EventHandlerFor(EventType.Create, Data);
var offset = Data.GameObjects.ByName("obj_ch4_PDC14A_noelle").EventHandlerFor(EventType.Step, Data);
var furry = Data.GameObjects.ByName("obj_npc_room_animated").EventHandlerFor(EventType.Other,EventSubtypeOther.User0, Data);

if (doRose == true)
{
importGroup.QueueFindReplace(weird,"spr_rose","spr_rose2");
importGroup.QueueFindReplace(weird,"[1000, 100, 50, 200, 1000]","[200, 60, 60, 60, 60, 60, 100, 100, 100, 660, 100, 100, 100, 100, 100, 60, 100, 100, 100, 60, 60, 60, 200]");
importGroup.QueueFindReplace(offset,"            setxy(camerax() + 146, cameray() + 50);","            setxy(camerax() + 201, cameray() + 113);");
}
if (doFurry == true)
{
importGroup.QueueFindReplace(furry,"furry freak","furry degenerate");
}

importGroup.Import();

ScriptMessage("Chapter 4 Restored!");