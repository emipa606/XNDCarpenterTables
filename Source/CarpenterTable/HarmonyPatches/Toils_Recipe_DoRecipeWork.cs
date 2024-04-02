using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.AI;

namespace CarpenterTable;

[HarmonyPatch(typeof(Toils_Recipe), nameof(Toils_Recipe.DoRecipeWork))]
public static class Toils_Recipe_DoRecipeWork
{
    public static void Postfix(Toil __result)
    {
        // Change the tickAction
        var tickAction = __result.tickAction;
        __result.tickAction = () =>
        {
            // If the thing being worked on is an unfinished building, check for construction failure
            var actor = __result.actor;
            if (actor.CurJob.GetTarget(TargetIndex.B).Thing is UnfinishedBuilding unfinishedBuilding)
            {
                var successChance = actor.GetStatValue(StatDefOf.ConstructSuccessChance);
                var constructionSpeed = actor.GetStatValue(StatDefOf.ConstructionSpeed);
                var workToBuild = unfinishedBuilding.Recipe.WorkAmountForStuff(unfinishedBuilding.Stuff);
                if (Rand.Chance(1 - Mathf.Pow(successChance, constructionSpeed / workToBuild)))
                {
                    actor.jobs.EndCurrentJob(JobCondition.Incompletable);
                    MoteMaker.ThrowText(unfinishedBuilding.DrawPos, unfinishedBuilding.Map,
                        "TextMote_ConstructionFail".Translate(), 6);
                    Messages.Message(
                        "MessageConstructionFailed".Translate(unfinishedBuilding.Label.UncapitalizeFirst(),
                            actor.LabelShort, actor.Named("WORKER")),
                        new TargetInfo(unfinishedBuilding.Position, unfinishedBuilding.Map),
                        MessageTypeDefOf.NegativeEvent);
                    unfinishedBuilding.Destroy(DestroyMode.FailConstruction);
                    return;
                }
            }

            tickAction();
        };
    }
}