using System.Linq;
using System.Reflection;
using HarmonyLib;
using Verse;
using Verse.AI;

namespace CarpenterTable;

[StaticConstructorOnStartup]
public static class HarmonyPatches
{
    static HarmonyPatches()
    {
        var h = new Harmony("XeoNovaDan.CarpenterTable");

        // Harmony.DEBUG = true;

        // Automatic patches
        h.PatchAll();

        // Manual patches
        // Patch the initAction for Toils_Recipe.FinishRecipeAndStartStoringProduct
        var nestedTypes = typeof(Toils_Recipe).GetNestedTypes(BindingFlags.NonPublic | BindingFlags.Instance);
        var first = nestedTypes.FirstOrDefault(t => t.Name.Contains("FinishRecipeAndStartStoringProduct"));
        if (first == null)
        {
            return;
        }

        var methods = first.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        var method = methods.MaxBy(mi => mi.GetMethodBody()?.GetILAsByteArray().Length ?? -1);
        h.Patch(method,
            transpiler: new HarmonyMethod(
                typeof(Patch_Toils_Recipe.ManualPatch_FinishRecipeAndStartStoringProduct_InitAction),
                "Transpiler"));
    }
}