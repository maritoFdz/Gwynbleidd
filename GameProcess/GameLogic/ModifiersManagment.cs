using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gwynbleidd.GameProcess.GameLogic;

public static class ModifiersManagment
{
    public static List<IModifier>? ActiveModifiers {  get; private set; }
}
