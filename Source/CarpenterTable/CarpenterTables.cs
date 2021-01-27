using UnityEngine;
using Verse;

namespace CarpenterTable
{

    public class CarpenterTables : Mod
    {
        public CarpenterTablesSettings settings;

        public CarpenterTables(ModContentPack content) : base(content)
        {
            GetSettings<CarpenterTablesSettings>();
        }

        public override string SettingsCategory()
        {
            return "CarpenterTables.SettingsCategory".Translate();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            GetSettings<CarpenterTablesSettings>().DoWindowContents(inRect);
        }

    }

}
