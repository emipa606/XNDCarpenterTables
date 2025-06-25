using UnityEngine;
using Verse;

namespace CarpenterTable;

public class CarpenterTablesSettings : ModSettings
{
    private static bool deconstructInadequateProducts = true;

    public static bool RestrictFurnitureConstruction;

    public void DoWindowContents(Rect wrect)
    {
        var options = new Listing_Standard();
        var defaultColor = GUI.color;
        options.Begin(wrect);
        GUI.color = defaultColor;
        Text.Font = GameFont.Small;
        Text.Anchor = TextAnchor.UpperLeft;

        // Automatic deconstruction of low-quality furniture
        options.Gap();
        options.CheckboxLabeled("CarpenterTables.DeconstructInadequateProducts".Translate(),
            ref deconstructInadequateProducts, "CarpenterTables.DeconstructInadequateProducts_ToolTip".Translate());

        // Restrict furniture construction
        options.Gap();
        options.CheckboxLabeled("CarpenterTables.RestrictFurnitureConstruction".Translate(),
            ref RestrictFurnitureConstruction, "CarpenterTables.RestrictFurnitureConstruction_ToolTip".Translate());
        if (CarpenterTables.CurrentVersion != null)
        {
            options.Gap();
            GUI.contentColor = Color.gray;
            options.Label("CarpenterTables.ModVersion".Translate(CarpenterTables.CurrentVersion));
            GUI.contentColor = Color.white;
        }

        // Finish
        options.End();
        Mod.GetSettings<CarpenterTablesSettings>().Write();
    }

    public override void ExposeData()
    {
        Scribe_Values.Look(ref deconstructInadequateProducts, "deconstructInadequateProducts", true);
        Scribe_Values.Look(ref RestrictFurnitureConstruction, "restrictFurnitureConstruction");
    }
}