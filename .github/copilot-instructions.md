# Copilot Instructions for [XND] Carpenter Tables (Continued)

## Mod Overview and Purpose

### Name: [XND] Carpenter Tables (Continued)

This mod introduces a new workbench, the Carpenter's Table, to the RimWorld game. It allows constructors to produce 'minifiable' buildings like turrets and beds at a dedicated workstation. This addition provides players with better control over furniture production, optimizes quality through workbench dynamics, and reduces the micromanagement associated with construction tasks.

## Key Features and Systems

- **Carpenter's Table Workbench**: A new furniture creation station, improving control over production.
- **Minimal Integration with Other Mods**: Automatically recognizes appropriate buildable/minifiable objects from other mods, requiring no extra patching.
- **Quality Control**: Manage which colonists are responsible for producing specific furniture, ensuring better results.
- **Tool Cabinet Compatibility**: Benefits from adjacent tool cabinets to increase production speed.
- **Multilingual Support**: Available in Chinese and Japanese.

## Coding Patterns and Conventions

- **Namespaces and Static Classes**: As seen in files like `Designator_Build_Visible_Getter.cs`, `CarpenterTableUtility.cs`, and other helper files, static classes are utilized to encapsulate related methods.
- **Patch Management**: Harmony patches are managed centrally within `HarmonyPatches.cs` to keep modifications modular and unobtrusive.
- **Modular Design**: The project is broken down into specific files for different aspects of the mod functionality, such as settings (`CarpenterTablesSettings.cs`), utility functions (`CarpenterTableUtility.cs`), and recipe definitions (`CT_RecipeDefOf.cs`).

## XML Integration

The mod utilizes XML definitions to manage new item properties and integration with the game. Make sure to respect existing XML structures when adding or changing assets, particularly when working with furniture definitions and the associated bills.

## Harmony Patching

- **Files**: `HarmonyPatches.cs`
- Employed for modifying game behaviors without altering the core source code, ensuring compatibility and minimizing conflicts with other mods.
- Patches are applied to methods responsible for building visibility, recipe availability, work amounts, and recipe execution workflows.

## Suggestions for Copilot

To effectively use GitHub Copilot in this project:

- **Code Completion**: Utilize Copilot for generating boilerplate code when adding new static utility classes or extending existing ones.
- **Method Suggestions**: Leverage Copilot's ability to suggest method bodies within existing classes like `CarpenterTableUtility` and `UnfinishedBuilding`.
- **XML Handling**: Allow Copilot to assist with crafting correctly structured XML for new item definitions or mod settings adjustments.
- **Harmony Patches**: Seek Copilot's recommendations on crafting Harmony patch methods to ensure correct method signatures and integration points.

## Additional Development Tips

- **Testing for Compatibility**: Regularly test the mod with diverse mod loadouts to ensure compatibility.
- **Logging**: Implement comprehensive logging to track errors and bugs, aiding in quick fixes and improvements.
- **Community Engagement**: Encourage players to report issues with logs and setup details, and participate in mod compatibility testing across platforms.

Remember to refer to the Harmony documentation and the RimWorld modding community resources for any complex issues or advanced features you wish to integrate.

---

For issues and discussions, please refer to the mod's GitHub repository and follow the current protocols for bug reporting and feature requests.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.
