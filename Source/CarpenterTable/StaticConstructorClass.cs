﻿using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace CarpenterTable;

[StaticConstructorOnStartup]
public static class StaticConstructorClass
{
    public const string GeneratedRecipeDefPrefix = "CarpenterTableMake";

    static StaticConstructorClass()
    {
        var recipes = new List<RecipeDef>();

        // Go through each minifiable building's def that is buildable by the player, requires materials, doesn't already have a recipeMaker
        foreach (var buildingDef in DefDatabase<ThingDef>.AllDefs.Where(d =>
                     d.IsBuildingArtificial && d.Minifiable && d.BuildableByPlayer &&
                     (d.MadeFromStuff || !d.costList.NullOrEmpty()) && d.recipeMaker == null))
        {
            var error = false;

            // Create the new Recipe Def
            var newRecipe = new RecipeDef
            {
                defName = $"{GeneratedRecipeDefPrefix}_{buildingDef.defName}",
                modContentPack = CT_RecipeDefOf.BaseCarpentersTableRecipe.modContentPack,
                label =
                    $"[{buildingDef.designationCategory.label.ToUpper()}] - {"RecipeMake".Translate(buildingDef.label).CapitalizeFirst()}",
                jobString = "RecipeMakeJobString".Translate(buildingDef.label),
                workSpeedStat = StatDefOf.ConstructionSpeed,
                workSkill = SkillDefOf.Construction,
                unfinishedThingDef = CT_ThingDefOf.UnfinishedBuilding,
                recipeUsers = [CT_ThingDefOf.TableCarpenter],
                defaultIngredientFilter = CT_RecipeDefOf.BaseCarpentersTableRecipe.defaultIngredientFilter,
                effectWorking = EffecterDefOf.ConstructMetal,
                soundWorking = SoundDefOf.Building_Complete,
                factionPrerequisiteTags = DetermineRecipeFactionPrerequisiteTags(buildingDef.minTechLevelToBuild,
                    buildingDef.maxTechLevelToBuild)
            };

            // Add construction skill requirement if there is any
            if (buildingDef.constructionSkillPrerequisite > 0)
            {
                var constructionRequirement = new SkillRequirement
                    { skill = SkillDefOf.Construction, minLevel = buildingDef.constructionSkillPrerequisite };
                newRecipe.skillRequirements = [constructionRequirement];
            }

            // Add ingredient count for building's stuff if applicable
            if (buildingDef.MadeFromStuff)
            {
                var stuffIngredientCount = new IngredientCount();
                stuffIngredientCount.SetBaseCount(buildingDef.costStuffCount);
                stuffIngredientCount.filter.SetAllowAllWhoCanMake(buildingDef);
                newRecipe.ingredients.Add(stuffIngredientCount);
                newRecipe.fixedIngredientFilter.SetAllowAllWhoCanMake(buildingDef);
                newRecipe.productHasIngredientStuff = true;
            }

            // Add ingredient counts for other required materials if applicable
            if (!buildingDef.costList.NullOrEmpty())
            {
                foreach (var normalMaterialCost in buildingDef.costList)
                {
                    if (normalMaterialCost?.thingDef == null)
                    {
                        error = true;
                        continue;
                    }

                    var materialIngredientCount = new IngredientCount();
                    materialIngredientCount.SetBaseCount(normalMaterialCost.count *
                                                         normalMaterialCost.thingDef.VolumePerUnit);
                    materialIngredientCount.filter.SetAllow(normalMaterialCost.thingDef, true);
                    newRecipe.ingredients.Add(materialIngredientCount);
                }

                if (error)
                {
                    Log.Message(
                        $"[XND] Carpenter Tables: Some of the materials {buildingDef.defName} is built from does not exist. Possible error in {buildingDef.modContentPack.Name}");
                    continue;
                }
            }

            // Add building as the recipe def's product
            newRecipe.products.Add(new ThingDefCountClass(buildingDef, 1));

            // Add the new recipe def to the list of recipes
            recipes.Add(newRecipe);
        }

        // Sort the list of recipes alphabetically and add to the database
        recipes.Sort((d1, d2) => string.Compare(d1.label, d2.label, StringComparison.Ordinal));
        DefDatabase<RecipeDef>.Add(recipes);
    }

    private static List<string> DetermineRecipeFactionPrerequisiteTags(TechLevel minTechLevel,
        TechLevel maxTechLevel)
    {
        // If requirements are undefined, return null
        if (minTechLevel == TechLevel.Undefined && maxTechLevel == TechLevel.Undefined)
        {
            return null;
        }

        var resultList = new List<string>();

        // Go through all the playable factions which have recipePrerequisiteTags, compare their tech levels to the specified min and max and if appropriate, add the faction's tags to the list
        foreach (var faction in DefDatabase<FactionDef>.AllDefs.Where(f =>
                     f.isPlayer && !f.recipePrerequisiteTags.NullOrEmpty()))
        {
            if (faction.techLevel < minTechLevel || faction.techLevel > maxTechLevel)
            {
                continue;
            }

            foreach (var tag in faction.recipePrerequisiteTags)
            {
                if (!resultList.Contains(tag))
                {
                    resultList.Add(tag);
                }
            }
        }

        return resultList;
    }
}