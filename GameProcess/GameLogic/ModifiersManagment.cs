using Gwynbleidd.Entities;

namespace Gwynbleidd.GameProcess.GameLogic;

public static class ModifiersManagment
{
    public static List<IModifier> ActiveModifiers {  get; private set; } = [];

    public static void Add(IModifier modifier)
        => ActiveModifiers.Add(modifier);

    public static void Actualize()
    {
        foreach (var modifier in ActiveModifiers)
        {
            if (modifier.RemainingTurns == 0)
                ActiveModifiers.Remove(modifier);
            else
                modifier.Update();
        }
    }

    public static void Apply(Character target)
    {
        foreach (var modifier in ActiveModifiers)
        {
            if (modifier.Target!.Equals(target))
                modifier.Apply();
        }
    }
}
