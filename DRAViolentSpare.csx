// Defeating enemies with violence will spare them instead

EnsureDataLoaded();

ScriptMessage("This will make it so regular enemies defeated\nviolently will be spared instead.");

UndertaleModLib.Compiler.CodeImportGroup importGroup = new(Data);

if (Data.GeneralInfo.DisplayName.Content == "DELTARUNE Chapter 1")
{
var defeat = Data.Scripts.ByName("scr_defeatrun");
var ponman = Data.GameObjects.ByName("obj_ponman_enemy").EventHandlerFor(EventType.Draw, Data);

importGroup.QueueFindReplace(defeat.Code,@"
    defeatanim = instance_create(x, y, obj_defeatanim);
    defeatanim.sprite_index = sprite_index;
    defeatanim.sprite_index = hurtsprite;
    defeatanim.image_index = 0;
    defeatanim.image_xscale = image_xscale;
    defeatanim.image_yscale = image_yscale;
    instance_destroy();", @"
    global.flag[51 + myself] = 2;
    event_user(10);
    scr_monsterdefeat();
");

importGroup.QueueFindReplace(ponman,@"
            hspeed = 12;
            turnt -= 8;
            vspeed = -4;", @"
    global.flag[51 + myself] = 2;
    event_user(10);
    scr_monsterdefeat();
");
}
if (Data.GeneralInfo.DisplayName.Content == "DELTARUNE Chapter 2")
{
var hurt = Data.Scripts.ByName("scr_enemy_drawhurt_generic");

importGroup.QueueFindReplace(hurt.Code,"scr_defeatrun()","scr_spare(myself)");
}

if (Data.GeneralInfo.DisplayName.Content == "DELTARUNE Chapter 3" || Data.GeneralInfo.DisplayName.Content == "DELTARUNE Chapter 4")
{
var hurt = Data.Scripts.ByName("scr_enemy_hurt");

importGroup.QueueFindReplace(hurt.Code,"scr_defeatrun()","scr_spare(myself)");
}

importGroup.Import();

ScriptMessage("Violence lowered!");