using Verse;

namespace CarpenterTable
{

    public class UnfinishedBuilding : UnfinishedThing
    {

        public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
        {
            // If the 'construction' of the unfinished building is 'failed', treat it like cancelling the unfinished thing but with construction failure percentages
            if (mode == DestroyMode.FailConstruction)
            {
                foreach (var ingredient in ingredients)
                {
                    var ingredientCountLeft = GenMath.RoundRandom(ingredient.stackCount * 0.5f);
                    if (ingredientCountLeft <= 0)
                    {
                        continue;
                    }

                    ingredient.stackCount = ingredientCountLeft;
                    GenPlace.TryPlaceThing(ingredient, Position, Map, ThingPlaceMode.Near);
                }
                ingredients.Clear();
            }

            base.Destroy(mode);
        }

    }

}
