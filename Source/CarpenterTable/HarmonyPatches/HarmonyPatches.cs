using System.Reflection;
using HarmonyLib;
using Verse;

namespace CarpenterTable;

[StaticConstructorOnStartup]
public static class HarmonyPatches
{
    static HarmonyPatches()
    {
        new Harmony("XeoNovaDan.CarpenterTable").PatchAll(Assembly.GetExecutingAssembly());
    }
}