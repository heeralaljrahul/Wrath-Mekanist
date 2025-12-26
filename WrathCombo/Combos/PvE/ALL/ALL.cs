using ECommons.ExcelServices;
using ECommons.GameHelpers;
using System.Collections.Generic;
using System.Linq;
using WrathCombo.Core;
using WrathCombo.CustomComboNS;
using WrathCombo.Extensions;
namespace WrathCombo.Combos.PvE;

internal partial class All
{
    /// Used to block user input.
    public const uint SavageBlade = 11;

    public static class Buffs
    {
        public const ushort
            Raised = 148,
            Transcendent = 2648;
    }

    public static class Enums
    {
        /// <summary>
        ///     Whether abilities should be restricted to Bosses or not.
        /// </summary>
        internal enum BossAvoidance
        {
            Off = 1,
            On = 2,
        }

        /// <summary>
        ///     Whether abilities should be restricted to while in a party or not.
        /// </summary>
        internal enum PartyRequirement
        {
            No,
            Yes,
        }
    }

    public static class Debuffs
    {
        public const ushort
            Stun = 2,
            Weakness = 43,
            BrinkOfDeath = 44;
    }


    //Ranged Physical Features
    internal class ALL_Ranged_Mitigation : CustomCombo
    {
        protected internal override Preset Preset => Preset.ALL_Ranged_Mitigation;

        protected override uint Invoke(uint actionID) =>
            actionID is MCH.Tactician &&
            HasStatusEffect(MCH.Buffs.Tactician, anyOwner: true) &&
            IsOffCooldown(actionID)
                ? SavageBlade
                : actionID;
    }

    internal class ALL_Ranged_Interrupt : CustomCombo
    {
        protected internal override Preset Preset => Preset.ALL_Ranged_Interrupt;

        protected override uint Invoke(uint actionID) =>
            actionID is RoleActions.PhysRanged.FootGraze && CanInterruptEnemy() && ActionReady(RoleActions.PhysRanged.HeadGraze)
                ? RoleActions.PhysRanged.HeadGraze
                : actionID;
    }
}
