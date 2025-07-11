using Gwynbleidd.Entities;

namespace Gwynbleidd.GameProcess.GameLogic;

public static class ModifiersManagment
{
    public static List<IModifier> ActiveModifiers {  get; private set; } = [];

    public static void Add(IModifier modifier)
        => ActiveModifiers.Add(modifier);

    public static void OnTurnEnd()
    {
        for (int i = ActiveModifiers.Count - 1; i >= 0; i--)
        {
            var modifier = ActiveModifiers[i];
            modifier.Target!.ModifyVelocity(0); // Resets character stats
            modifier.Target.ModifyCooldown(0);

            if (modifier.RemainingTurns == 0)
                ActiveModifiers.RemoveAt(i);
            else
                modifier.Update();
        }
    }

    public static void Apply()
    {
        foreach (var modifier in ActiveModifiers)
            modifier.Apply();
    }
}
