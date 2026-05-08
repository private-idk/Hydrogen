using System;
using System.ComponentModel.DataAnnotations;
using Hydrogen.Content.Debuffs;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Hydrogen;

public class HydrogenPlayer : ModPlayer
{
    /// <summary>
    /// Максимальное значение голода у игрока
    /// </summary>
    public const int maxStarve = 100;

    private static int _oldBreath;
    private static bool _isDrowning;    

    private int _starveTimer = 0;

    [Range(0, maxStarve)]
    private static int _starve;    

    /// <summary>
    /// Устанавливается true, если игрок тонет
    /// </summary>
    public static bool isDrowning { get => _isDrowning; }

    /// <summary>
    /// Насколько голоден игрок. 100 - максимально сыт
    /// </summary>
    public static int Starve { get => _starve; }

    public override void SaveData(TagCompound tag)
    {
        tag["Mods.Hydrogen.StarveValue"] = _starve;
    }
    public override void LoadData(TagCompound tag)
    {
        if (!tag.ContainsKey("Mods.Hydrogen.StarveValue"))
            tag.Add("Mods.Hydrogen.StarveValue", 100);

        _starve = (int)tag["Mods.Hydrogen.StarveValue"];
    }
    public override void PreUpdate()
    {
        _oldBreath = Player.breath;
    }
    public override void PostUpdate()
    {
        if (_oldBreath > Player.breath && Player.breath > 0)
        {
            Player.breath -= 3;
            _isDrowning = true;
        }
        else
        {
            _isDrowning = false;
        }

        if (Player.breath == 0)
        {
            Player.AddBuff(BuffID.Confused, 2);
        }

        if (_oldBreath == 0 && Player.breath > 0)
        {
            Player.AddBuff(ModContent.BuffType<DrowConsequencesDebuff>(), 30000);
        }

        if (_starve > 0)
        {
            if (_starveTimer < 10080)
                _starveTimer += 1;
            else
            {
                _starve -= 1;

                _starveTimer = 0;
            }
        }
        else
        {
            if (_starveTimer < 300)
                _starveTimer += 1;
            else
            {
                Player.Hurt(PlayerDeathReason.ByCustomReason(NetworkText.FromKey("Mods.Hydrogen.DeathReasons.ByStarving", Player.name)), Player.statLifeMax / 10, 0);

                _starveTimer = 0;
            }
        }
    }
    public override void OnRespawn()
    {
        _starve = 10;
    }
}
