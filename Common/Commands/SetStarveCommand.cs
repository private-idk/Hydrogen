using System;
using Terraria.ModLoader;

namespace Hydrogen.Common.Commands;

public class SetStaveCommand : ModCommand
{
    public override string Command => "st";

    public override CommandType Type => CommandType.Chat;

    public override void Action(CommandCaller caller, string input, string[] args)
    {
        HydrogenPlayer.Starve = Int32.Parse(args[0]);
    }
}