// Changes the Dice Brace to the Easy Ring

EnsureDataLoaded();

ScriptMessage("Replaces the Dice Brace with the Easy Ring");

UndertaleModLib.Compiler.CodeImportGroup importGroup = new(Data);
if (Data.GeneralInfo.DisplayName.Content != "DELTARUNE Chapter 1")
{
var armor = Data.Scripts.ByName("scr_armorinfo");
var damage = Data.Scripts.ByName("scr_damage");
var damageall = Data.Scripts.ByName("scr_damage_all");
var damageallo = Data.Scripts.ByName("scr_damage_all_overworld");
// Import code
// Replaces the Dice Brace
importGroup.QueueFindReplace(armor.Code,@"
        case 2:
            armornametemp = scr_84_get_lang_string(""scr_armorinfo_slash_scr_armorinfo_gml_46_0"");
            armordesctemp = scr_84_get_lang_string(""scr_armorinfo_slash_scr_armorinfo_gml_47_0"");
            amessage2temp = scr_84_get_lang_string(""scr_armorinfo_slash_scr_armorinfo_gml_48_0"");
            amessage3temp = scr_84_get_lang_string(""scr_armorinfo_slash_scr_armorinfo_gml_49_0"");
            armorattemp = 0;
            armordftemp = 2;
            armormagtemp = 0;
            armorboltstemp = 0;
            armorgrazeamttemp = 0;
            armorgrazesizetemp = 0;
            armorchar1temp = 1;
            armorchar2temp = 1;
            armorchar3temp = 1;
            armorabilitytemp = "" "";
            armorabilityicontemp = 0;
            armoricontemp = 4;
            value = 150;
            break;", @"
        case 2:
            armornametemp = scr_84_get_lang_string(""scr_armorinfo_slash_scr_armorinfo_gml_46_0"");
            armordesctemp = scr_84_get_lang_string(""scr_armorinfo_slash_scr_armorinfo_gml_47_0"");
            amessage2temp = scr_84_get_lang_string(""scr_armorinfo_slash_scr_armorinfo_gml_48_0"");
            amessage3temp = scr_84_get_lang_string(""scr_armorinfo_slash_scr_armorinfo_gml_49_0"");
            armorattemp = 3;
            armordftemp = 6;
            armormagtemp = 3;
            armorboltstemp = 0;
            armorgrazeamttemp = 0;
            armorgrazesizetemp = 20;
            armorchar1temp = 1;
            armorchar2temp = 1;
            armorchar3temp = 1;
            armorabilitytemp = scr_84_get_lang_string(""scr_armorinfo_slash_scr_armorinfo_gml_79_0"");
            armorabilityicontemp = 7;
            armoricontemp = 4;
            value = 150;
            break;
");
importGroup.QueueFindReplace(damage.Code,"        global.inv = global.invc * 40;",@"
        if (global.chararmor1[1] == 2 || global.chararmor2[1] == 2 || global.chararmor1[2] == 2 || global.chararmor2[2] == 2 || global.chararmor1[3] == 2 || global.chararmor2[3] == 2)
            global.inv = global.invc * 60;
        else
            global.inv = global.invc * 40;
");

importGroup.QueueFindReplace(damageall.Code,"        global.inv = global.invc * 40;",@"
        if (global.chararmor1[1] == 2 || global.chararmor2[1] == 2 || global.chararmor1[2] == 2 || global.chararmor2[2] == 2 || global.chararmor1[3] == 2 || global.chararmor2[3] == 2)
            global.inv = global.invc * 60;
        else
            global.inv = global.invc * 40;
");

importGroup.QueueFindReplace(damageallo.Code,"        global.inv = global.invc * 40;",@"
        if (global.chararmor1[1] == 2 || global.chararmor2[1] == 2 || global.chararmor1[2] == 2 || global.chararmor2[2] == 2 || global.chararmor1[3] == 2 || global.chararmor2[3] == 2)
            global.inv = global.invc * 60;
        else
            global.inv = global.invc * 40;
");
}

if (Data.GeneralInfo.DisplayName.Content == "DELTARUNE Chapter 2" || Data.GeneralInfo.DisplayName.Content == "DELTARUNE Chapter 3" || Data.GeneralInfo.DisplayName.Content == "DELTARUNE Chapter 4")
{
var armor = Data.Scripts.ByName("scr_armorinfo");
var damage = Data.Scripts.ByName("scr_damage");
var damagep = Data.Scripts.ByName("scr_damage_proportional");
var damageall = Data.Scripts.ByName("scr_damage_all");
var damageallo = Data.Scripts.ByName("scr_damage_all_overworld");
var save = Data.GameObjects.ByName("obj_savepoint").EventHandlerFor(EventType.Other, EventSubtypeOther.User0, Data);
// Import code
// Replaces the Dice Brace
importGroup.QueueFindReplace(armor.Code,@"
        case 2:
            armornametemp = stringsetloc(""Dice Brace"", ""scr_armorinfo_slash_scr_armorinfo_gml_49_0"");
            armordesctemp = stringsetloc(""A bracelet made out of various#symbol-inscribed cubes."", ""scr_armorinfo_slash_scr_armorinfo_gml_50_0"");
            amessage2temp = stringsetloc(""... okay."", ""scr_armorinfo_slash_scr_armorinfo_gml_51_0"");
            amessage3temp = stringsetloc(""It says \""Friendship!\"""", ""scr_armorinfo_slash_scr_armorinfo_gml_52_0"");
            amessage4temp = stringsetloc(""Hey, y-you jumbled it..."", ""scr_armorinfo_slash_scr_armorinfo_gml_54_0"");
            armorattemp = 0;
            armordftemp = 2;
            armormagtemp = 0;
            armorboltstemp = 0;
            armorgrazeamttemp = 0;
            armorgrazesizetemp = 0;
            armorchar1temp = 1;
            armorchar2temp = 1;
            armorchar3temp = 1;
            armorabilitytemp = stringsetloc("" "", ""scr_armorinfo_slash_scr_armorinfo_gml_64_0"");
            armorabilityicontemp = 0;
            armoricontemp = 4;
            value = 150;
            break;", @"
        case 2:
            armornametemp = stringsetloc(""Easy Ring"", ""scr_armorinfo_slash_scr_armorinfo_gml_49_0"");
            armordesctemp = stringsetloc(""A ring that makes life just a#little easier."", ""scr_armorinfo_slash_scr_armorinfo_gml_50_0"");
            amessage2temp = stringsetloc(""... I guess."", ""scr_armorinfo_slash_scr_armorinfo_gml_51_0"");
            amessage3temp = stringsetloc(""It says \""Friendship!\"""", ""scr_armorinfo_slash_scr_armorinfo_gml_52_0"");
            amessage4temp = stringsetloc(""Another ring?"", ""scr_armorinfo_slash_scr_armorinfo_gml_54_0"");
            armorattemp = 1 + (global.chapter * 2);
            armordftemp = 4 + (global.chapter * 2);
            armormagtemp = 1 + (global.chapter * 2);
            armorboltstemp = 0;
            armorgrazeamttemp = 0;
            armorgrazesizetemp = 0;
            armorchar1temp = 1;
            armorchar2temp = 1;
            armorchar3temp = 1;
            armorchar4temp = 0;
            armorabilitytemp = stringsetloc(""GrazeArea"", ""scr_armorinfo_slash_scr_armorinfo_gml_91_0"");
            armorabilityicontemp = 7;
            armoricontemp = 4;
            value = 5;
            break;
");
// 1.5x Inv Frames for wearing the ring
importGroup.QueueFindReplace(damage.Code,"        global.inv = global.invc * 40;",@"
        if (scr_armorcheck_equipped_party(2) == 1)
            global.inv = global.invc * 60;
        else
            global.inv = global.invc * 40;
");

importGroup.QueueFindReplace(damagep.Code,"        global.inv = global.invc * 40;",@"
        if (scr_armorcheck_equipped_party(2) == 1)
            global.inv = global.invc * 60;
        else
            global.inv = global.invc * 40;
");

importGroup.QueueFindReplace(damageall.Code,"        global.inv = global.invc * 40;",@"
        if (scr_armorcheck_equipped_party(2) == 1)
            global.inv = global.invc * 60;
        else
            global.inv = global.invc * 40;
");

importGroup.QueueFindReplace(damageallo.Code,"        global.inv = global.invc * 40;",@"
        if (scr_armorcheck_equipped_party(2) == 1)
            global.inv = global.invc * 60;
        else
            global.inv = global.invc * 40;
");
// Save Points now give you the easy ring if you don't have it.
importGroup.QueueAppend(save, @"
if (scr_armorcheck_equipped_party(2) == 0 && scr_armorcheck_inventory(2) == 0)
    scr_armorget(2)
");
}
// Chapter 2 Specific edits --------------
// Mansion Teacups do less damage
if (Data.GeneralInfo.DisplayName.Content == "DELTARUNE Chapter 2")
{
var teacup = Data.GameObjects.ByName("obj_teacup_bullet").EventHandlerFor(EventType.Create, Data);
importGroup.QueueAppend(teacup, @"
if (scr_armorcheck_equipped_party(2) == 1 && room == room_dw_mansion_b_west_2f)
    damage = 4;
");
}
//Chapter 3 Specific edits ---------------
if (Data.GeneralInfo.DisplayName.Content == "DELTARUNE Chapter 3")
{
var knight = Data.GameObjects.ByName("obj_knight_enemy").EventHandlerFor(EventType.Step, EventSubtypeStep.Step, Data);
var mantlea = Data.GameObjects.ByName("obj_shadow_mantle_cloud_bullet").EventHandlerFor(EventType.Create, Data);
var mantleb = Data.GameObjects.ByName("obj_shadow_mantle_groundfire").EventHandlerFor(EventType.Create, Data);
var mantlec = Data.GameObjects.ByName("obj_shadow_mantle_fire").EventHandlerFor(EventType.Create, Data);
var mantled = Data.GameObjects.ByName("obj_shadow_mantle_dash_hitbox").EventHandlerFor(EventType.Create, Data);
var mantlee = Data.GameObjects.ByName("obj_shadow_mantle_groundfire2").EventHandlerFor(EventType.Create, Data);
var mantlez = Data.GameObjects.ByName("obj_shadow_mantle_enemy").EventHandlerFor(EventType.Create, Data);
//Knight attacks give more invincibility
importGroup.QueueFindReplace(knight,"                global.invc = 0.4;",@"
                if (scr_armorcheck_equipped_party(2) == 1)
                    global.invc = 1;
                else
                    global.invc = 0.4;
");
//Shadow Mantle attacks do less damage
importGroup.QueueAppend(mantlea,@"if (scr_armorcheck_equipped_party(2) == 1)
    damage = 1;");
importGroup.QueueAppend(mantleb,@"if (scr_armorcheck_equipped_party(2) == 1)
    damage = 1;");
importGroup.QueueAppend(mantlec,@"if (scr_armorcheck_equipped_party(2) == 1)
    damage = 1;");
importGroup.QueueAppend(mantled,@"if (scr_armorcheck_equipped_party(2) == 1)
    damage = 1;");
importGroup.QueueAppend(mantlee,@"if (scr_armorcheck_equipped_party(2) == 1)
    damage = 1;");
importGroup.QueueAppend(mantlez,@"if (scr_armorcheck_equipped_party(2) == 1)
    damage = 1;");
}

importGroup.Import();

ScriptMessage("Easy Ring installed!");