using Mlie;
using UnityEngine;
using Verse;

namespace CarpenterTable;

public class CarpenterTables : Mod
{
    public static string currentVersion;
    public CarpenterTablesSettings settings;

    public CarpenterTables(ModContentPack content)
        : base(content)
    {
        GetSettings<CarpenterTablesSettings>();
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(
                ModLister.GetActiveModWithIdentifier("Mlie.XNDCarpenterTables"));
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        GetSettings<CarpenterTablesSettings>().DoWindowContents(inRect);
    }

    public override string SettingsCategory()
    {
        return "CarpenterTables.SettingsCategory".Translate();
    }
}