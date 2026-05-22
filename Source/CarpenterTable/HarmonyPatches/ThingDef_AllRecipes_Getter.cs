using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using Verse;

namespace CarpenterTable;

[HarmonyPatch(typeof(ThingDef), nameof(ThingDef.AllRecipes), MethodType.Getter)]
public static class ThingDef_AllRecipes_Getter
{
    private static readonly FieldInfo AllRecipesCachedField = AccessTools.Field(typeof(ThingDef), "allRecipesCached");

    public static void Prefix(ThingDef __instance)
    {
        if (!IsCarpenterTable(__instance))
        {
            return;
        }

        if (StaticConstructorClass.EnsureGeneratedRecipes())
        {
            AllRecipesCachedField?.SetValue(__instance, null);
        }
    }

    public static void Postfix(ThingDef __instance, List<RecipeDef> __result)
    {
        if (!IsCarpenterTable(__instance))
        {
            return;
        }

        if (__result.NullOrEmpty())
        {
            AllRecipesCachedField?.SetValue(__instance, null);
        }
    }

    private static bool IsCarpenterTable(ThingDef def)
    {
        if (def == null)
        {
            return false;
        }

        if (CT_ThingDefOf.TableCarpenter != null)
        {
            return def == CT_ThingDefOf.TableCarpenter;
        }

        return def.defName == "TableCarpenter";
    }
}