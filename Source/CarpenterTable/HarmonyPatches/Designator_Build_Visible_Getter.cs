using HarmonyLib;
using RimWorld;
using Verse;

namespace CarpenterTable;

[HarmonyPatch(typeof(Designator_Build), nameof(Designator_Build.Visible), MethodType.Getter)]
public static class Designator_Build_Visible_Getter
{
    public static void Postfix(Designator_Build __instance, ref bool __result)
    {
        // If the 'restrict furniture construction' setting is enabled, god mode is not enabled and the PlacingDef is furniture, hide the designator
        if (CarpenterTablesSettings.restrictFurnitureConstruction && !DebugSettings.godMode &&
            __instance.PlacingDef.IsFurniture())
        {
            __result = false;
        }
    }
}