using System.Linq;
using FFXIVClientStructs.FFXIV.Client.Game;
using Mekanist.CustomComboNS.Functions;
using Mekanist.Data;
using static Mekanist.Data.ActionWatching;
namespace Mekanist.Extensions;

internal static class UIntExtensions
{
    internal static bool LevelChecked(this uint value) => CustomComboFunctions.LevelChecked(value);

    internal static bool TraitLevelChecked(this uint value) => CustomComboFunctions.TraitLevelChecked(value);

    internal static string ActionName(this uint value) => CustomComboFunctions.GetActionName(value);

    internal static ActionAttackType ActionAttackType(this uint value) => (ActionAttackType)ActionSheet[value].ActionCategory.RowId;
    
    internal static float ActionRange(this uint value) =>
        ActionManager.GetActionRange(value);
    
    internal static bool IsGroundTargeted(this uint value) =>
        ActionSheet.FirstOrDefault(x => x.Value.RowId == value).Value.TargetArea;
    
    internal static bool IsEnemyTargetable(this uint value) =>
        ActionSheet.FirstOrDefault(x => x.Value.RowId == value).Value.CanTargetHostile;
    
    internal static bool IsFriendlyTargetable(this uint value) =>
        ActionSheet.FirstOrDefault(x => x.Value.RowId == value).Value.CanTargetAlly;
}

internal static class UShortExtensions
{
    internal static string StatusName(this ushort value) => StatusCache.GetStatusName(value);
}