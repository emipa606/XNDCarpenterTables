using Mlie;
using UnityEngine;
using Verse;

namespace CarpenterTable;

public class CarpenterTables : Mod
{
    public static string CurrentVersion;

    public CarpenterTables(ModContentPack content)
        : base(content)
    {
        GetSettings<CarpenterTablesSettings>();
        CurrentVersion =
            VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
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