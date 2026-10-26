.github/copilot-instructions.md
# GitHub Copilot Instructions for [XND] Carpenter Tables (Continued)

Welcome to the GitHub Copilot instructions for the [XND] Carpenter Tables (Continued) mod for RimWorld! This mod adds carpenter's tables to the game, allowing constructors to produce minifiable buildings like turrets and beds. Below are the instructions to help you navigate the mod's codebase, coding patterns, and integration with Harmony patching.

## Mod Overview and Purpose

[XND] Carpenter Tables (Continued) is an update to the XeoNovaDans mod that introduces carpenter's tables to the RimWorld game. These tables enable players to produce minifiable buildings, such as turrets and beds, without having to use blueprints. The mod enhances the construction process by providing better quality control, tool cabinet benefits, and reduced clicking when producing multiple pieces of furniture.

## Key Features and Systems

- **Carpenter's Tables**: Players can build and use carpenter's tables to produce minifiable buildings.
- **Quality Control**: Players can manage who can create specific furniture, leading to better quality control.
- **Tool Cabinet Integration**: Carpenter tables benefit from tool cabinets, improving construction speed.
- **Reduced Clicking**: Players can produce multiple pieces of furniture with fewer clicks compared to traditional blueprint placement.
- **Compatibility**: The mod should work seamlessly with ongoing savegames and other mods, such as MinifyEverything and Zetrith's Multiplayer.

## Coding Patterns and Conventions

### C# Files
The mod's C# files are organized into various classes and methods to handle different aspects of the mod, such as settings, recipe availability, and Harmony patches.

- **CarpenterTables.cs**: Contains the main class for the mod, including methods for handling settings and ensuring generated recipes.
- **HarmonyPatches**: These files include postfix patches for modifying the behavior of existing methods in RimWorld, such as recipe availability and work amounts.

### XML Files
XML files are used to define game elements, such as recipes, buildings, items, and work givers. These files are located in the `Defs` directory.

- **Recipes_Production.xml**: Defines the recipes available for production at carpenter's tables.
- **Buildings_Production.xml**: Defines the buildings that can be produced at carpenter's tables.
- **Items_Unfinished.xml**: Defines unfinished items used in the production process.
- **WorkGivers.xml**: Defines work givers associated with carpenter's tables.

## XML Integration

The mod integrates with RimWorld's XML system to define new game elements. The `Defs` directory contains various XML files that describe recipes, buildings, items, and work givers. When you modify these files, ensure that you follow the XML schema provided by RimWorld to maintain compatibility and avoid errors.

### Example: Defining a New Recipe

To define a new recipe in `Recipes_Production.xml`, you can use the following template:

xml
<RecipeDef>
  <defName>Recipe_CarpenterTable_Build</defName>
  <label>Build Furniture at Carpenter Table</label>
  <description>Allows constructors to produce furniture at carpenter tables.</description>
  <researchPrerequisites>
    <li>Research_Production</li>
  </researchPrerequisites>
  <workAmount>50</workAmount>
  <skillRequirements>
    <li>Construction 3</li>
  </skillRequirements>
  <ingredients>
    <li>Wood 2</li>
  </ingredients>
  <products>
    <li>Building_Furniture 1</li>
  </products>
</RecipeDef>


Ensure that you include all required fields and attributes to avoid errors when loading the mod.

## Harmony Patching

The mod uses the Harmony Patch Library to modify the behavior of existing methods in RimWorld. Harmony patches are applied in the `HarmonyPatches` directory.

### Example: Postfix Patch

To create a postfix patch, you can use the following template:

csharp
using HarmonyLib;
using RimWorld;
using Verse;

namespace XNDCarpenterTables.HarmonyPatches
{
    [HarmonyPatch(typeof(RecipeDef), nameof(RecipeDef.WorkAmountForStuff))]
    public static class RecipeDef_WorkAmountForStuff
    {
        [HarmonyPostfix]
        public static void Postfix(RecipeDef __instance, ThingDef stuff, ref float __result)
        {
            // Custom logic for modifying work amount
            if (__instance.defName == "Recipe_CarpenterTable_Build")
            {
                __result *= 0.8f; // Reduce work amount by 20%
            }
        }
    }
}


In this example, the `Postfix` method modifies the work amount for a specific recipe. Ensure that you follow the Harmony patching conventions and test your patches thoroughly to avoid unintended side effects.

## Suggestions for Copilot

To get the most out of GitHub Copilot while working on this mod, consider the following suggestions:

1. **Use XML Templates**: When modifying XML files, use the provided templates to ensure that you include all required fields and attributes.
2. **Explore Existing Code**: Review existing C# and XML files to understand the coding patterns and conventions used in the mod.
3. **Test Patches**: Always test your Harmony patches thoroughly to ensure that they work as expected and do not introduce bugs.
4. **Follow Coding Standards**: Adhere to the coding standards and conventions used in the mod to maintain consistency and readability.
5. **Seek Documentation**: If you encounter any issues or have questions, refer to the RimWorld documentation or seek help from the RimWorld community.

By following these instructions and suggestions, you can effectively use GitHub Copilot to enhance your development workflow for the [XND] Carpenter Tables (Continued) mod. Happy coding!

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

