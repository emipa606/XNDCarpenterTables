﻿namespace CarpenterTable
{
    public static class Patch_Dialog_BillConfig
    {
        // [HarmonyPatch(typeof(Dialog_BillConfig))]
        // [HarmonyPatch(nameof(Dialog_BillConfig.DoWindowContents))]
        // public static class Patch_DoWindowContents
        // {

        // public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        // {
        // var instructionList = instructions.ToList();
        // var done = false;

        // for (var i = 0; i < instructionList.Count; i++)
        // {
        // CodeInstruction instruction = instructionList[i];

        // // Look for 'listing_Standard.EndSection(listing_Standard2)'
        // if (!done && instruction.opcode == OpCodes.Callvirt && (MethodInfo)instruction.operand == AccessTools.Method(typeof(Listing_Standard), nameof(Listing_Standard.EndSection)))
        // {
        // yield return instruction;
        // yield return new CodeInstruction(OpCodes.Ldarg_0); // this
        // yield return new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(Dialog_BillConfig), "bill")); // this.bill
        // yield return new CodeInstruction(OpCodes.Ldloc_S, 8); // listing_Standard2
        // instruction = new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Patch_DoWindowContents), nameof(TranspilerHelper_QualitySlider))); // TranspilerHelper_QualitySlider(this.bill, listing_Standard2)
        // done = true;
        // }

        // yield return instruction;
        // }
        // }

        // public static void TranspilerHelper_QualitySlider(Bill_Production bill, Listing_Standard listing)
        // {
        // // If set to auto-deconstruct inadequate quality products, bill's repeat mode isn't 'do until x', bill's recipe was generated by the static constructor class and the product has quality...
        // if (CarpenterTablesSettings.deconstructInadequateProducts && bill.repeatMode != BillRepeatModeDefOf.TargetCount && bill.recipe.defName.Contains(StaticConstructorClass.GeneratedRecipeDefPrefix) &&
        // bill.recipe.ProducedThingDef.HasComp(typeof(CompQuality)))
        // {
        // // Add a quality slider
        // Widgets.QualityRange(listing.GetRect(28), 1098906561, ref bill.qualityRange);
        // }
        // }

        // }
    }
}