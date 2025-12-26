#region

using ECommons.ExcelServices;
using WrathCombo.Attributes;
using WrathCombo.Combos.PvE;
using WrathCombo.Combos.PvP;
using static WrathCombo.Attributes.PossiblyRetargetedAttribute;

// ReSharper disable EmptyRegion
// ReSharper disable InconsistentNaming
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo

#endregion

namespace WrathCombo.Combos;

/// <summary> Combo presets. </summary>
public enum Preset
{
    #region PvE Combos

    #region MACHINIST

    #region Simple Mode

    [AutoAction(false, false)]
    [ReplaceSkill(MCH.SplitShot, MCH.HeatedSplitShot)]
    [ConflictingCombos(MCH_ST_AdvancedMode)]
    [CustomComboInfo("Simple Mode - Single Target", "Replaces Split Shot with a full one-button single target rotation.\nThis is the ideal option for newcomers to the job.", Job.MCH)]
    [SimpleCombo]
    MCH_ST_SimpleMode = 8001,

    [AutoAction(true, false)]
    [ReplaceSkill(MCH.SpreadShot, MCH.Scattergun)]
    [ConflictingCombos(MCH_AoE_AdvancedMode)]
    [CustomComboInfo("Simple Mode - AoE", "Replaces Spreadshot with a full one-button AoE rotation.\nThis is the ideal option for newcomers to the job.\nWill lock out input to keep Flamethrower going by replacing Spreadshot with Savage Blade.", Job.MCH)]
    [SimpleCombo]
    MCH_AoE_SimpleMode = 8200,

    #endregion

    #region Advanced ST

    [AutoAction(false, false)]
    [ReplaceSkill(MCH.SplitShot, MCH.HeatedSplitShot)]
    [ConflictingCombos(MCH_ST_SimpleMode)]
    [CustomComboInfo("Advanced Mode - Single Target", "Replaces Split Shot with a full one-button single target rotation.\nThese features are ideal if you want to customize the rotation.", Job.MCH)]
    [AdvancedCombo]
    MCH_ST_AdvancedMode = 8100,

    [ParentCombo(MCH_ST_AdvancedMode)]
    [CustomComboInfo("Balance Opener (Level 90/100)", "Adds the Balance opener at lvl 90/100.", Job.MCH)]
    MCH_ST_Adv_Opener = 8101,

    #region BS

    [ParentCombo(MCH_ST_AdvancedMode)]
    [CustomComboInfo("Barrel Stabilizer Option", "Adds Barrel Stabilizer to the rotation.", Job.MCH)]
    MCH_ST_Adv_Stabilizer = 8110,

    [ParentCombo(MCH_ST_AdvancedMode)]
    [CustomComboInfo("Full Metal Field Option", "Adds Full Metal Field to the rotation.", Job.MCH)]
    MCH_ST_Adv_Stabilizer_FullMetalField = 8111,

    #endregion

    [ParentCombo(MCH_ST_AdvancedMode)]
    [CustomComboInfo("Wildfire Option", "Adds Wildfire to the rotation.", Job.MCH)]
    MCH_ST_Adv_WildFire = 8108,

    #region Hypercharge

    [ParentCombo(MCH_ST_AdvancedMode)]
    [CustomComboInfo("Hypercharge Option", "Adds Hypercharge to the rotation.", Job.MCH)]
    MCH_ST_Adv_Hypercharge = 8105,

    [ParentCombo(MCH_ST_AdvancedMode)]
    [CustomComboInfo("Heat Blast / Blazing Shot Option", "Adds Heat Blast or Blazing Shot to the rotation", Job.MCH)]
    MCH_ST_Adv_Heatblast = 8106,

    #endregion

    [ParentCombo(MCH_ST_AdvancedMode)]
    [CustomComboInfo("Gauss Round / Ricochet \nDouble Check / Checkmate option", "Adds Gauss Round and Ricochet or Double Check and Checkmate to the rotation. Will prevent overcapping.", Job.MCH)]
    MCH_ST_Adv_GaussRicochet = 8104,

    [ParentCombo(MCH_ST_AdvancedMode)]
    [CustomComboInfo("Reassemble Option", "Adds Reassemble to the rotation.\nWill be used priority based.\nOrder from highest to lowest priority :\nExcavator - Chainsaw - Air Anchor - Drill - Clean Shot", Job.MCH)]
    MCH_ST_Adv_Reassemble = 8103,

    #region Tools

    [ParentCombo(MCH_ST_AdvancedMode)]
    [CustomComboInfo("Tools", "Adds Hotshot, Drill, Air Anchor, Chainsaw and Excavator to the rotation.", Job.MCH)]
    MCH_ST_Adv_Tools = 8119,

    #endregion

    #region Queen

    [ParentCombo(MCH_ST_AdvancedMode)]
    [CustomComboInfo("Rook Autoturret/Automaton Queen Option", "Adds Rook Autoturret or Automaton Queen to the rotation.", Job.MCH)]
    MCH_ST_Adv_TurretQueen = 8107,

    [ParentCombo(MCH_ST_AdvancedMode)]
    [CustomComboInfo("Rook / Queen Overdrive Option", "Adds Rook or Queen Overdrive to the rotation.", Job.MCH)]
    MCH_ST_Adv_QueenOverdrive = 8115,

    #endregion

    [ParentCombo(MCH_ST_AdvancedMode)]
    [CustomComboInfo("Head Graze Option", "Uses Head Graze to interrupt during the rotation, where applicable.", Job.MCH)]
    MCH_ST_Adv_Interrupt = 8113,

    [ParentCombo(MCH_ST_AdvancedMode)]
    [CustomComboInfo("Second Wind Option", "Use Second Wind when below the set HP percentage.", Job.MCH)]
    MCH_ST_Adv_SecondWind = 8114,

    #region Raidwides

    [ParentCombo(MCH_ST_AdvancedMode)]
    [CustomComboInfo("Dismantle Raidwide Option", "Adds Dismantle when Raidwide is detected casting.", Job.MCH)]
    MCH_ST_Dismantle = 8195,

    [ParentCombo(MCH_ST_AdvancedMode)]
    [CustomComboInfo("Tactician Raidwide Option", "Adds Tactician when Raidwide is detected casting.", Job.MCH)]
    MCH_ST_Adv_Tactician = 8118,

    #endregion

    #endregion

    #region Advanced AoE

    [AutoAction(true, false)]
    [ReplaceSkill(MCH.SpreadShot, MCH.Scattergun)]
    [ConflictingCombos(MCH_AoE_SimpleMode)]
    [CustomComboInfo("Advanced Mode - AoE", "Replaces Spreadshot with a full one-button AoE rotation.\nThese features are ideal if you want to customize the rotation.\nWill lock out input to keep Flamethrower going by replacing Spreadshot with Savage Blade.", Job.MCH)]
    [AdvancedCombo]
    MCH_AoE_AdvancedMode = 8300,

    [ParentCombo(MCH_AoE_AdvancedMode)]
    [CustomComboInfo("Flamethrower Option", "Adds Flamethrower to the rotation.\n Changes to Savage blade when in use to prevent cancelling.", Job.MCH)]
    MCH_AoE_Adv_FlameThrower = 8305,

    #region BS

    [ParentCombo(MCH_AoE_AdvancedMode)]
    [CustomComboInfo("Barrel Stabilizer Option", "Adds Barrel Stabilizer to the rotation.", Job.MCH)]
    MCH_AoE_Adv_Stabilizer = 8307,

    [ParentCombo(MCH_AoE_AdvancedMode)]
    [CustomComboInfo("Full Metal Field Option", "Adds Full Metal Field to the rotation.", Job.MCH)]
    MCH_AoE_Adv_Stabilizer_FullMetalField = 8308,

    #endregion

    [ParentCombo(MCH_AoE_AdvancedMode)]
    [CustomComboInfo("Gauss Round / Ricochet \nDouble Check / Checkmate option", "Adds Gauss Round and Ricochet or Double Check and Checkmate to the rotation.", Job.MCH)]
    MCH_AoE_Adv_GaussRicochet = 8302,

    [ParentCombo(MCH_AoE_AdvancedMode)]
    [CustomComboInfo("Hypercharge Option", "Adds Hypercharge to the rotation.", Job.MCH)]
    MCH_AoE_Adv_Hypercharge = 8303,

    #region Queen

    [ParentCombo(MCH_AoE_AdvancedMode)]
    [CustomComboInfo("Rook Autoturret/Automaton Queen Option", "Adds Rook Autoturret or Automaton Queen to the rotation.", Job.MCH)]
    MCH_AoE_Adv_Queen = 8304,

    [ParentCombo(MCH_AoE_AdvancedMode)]
    [CustomComboInfo("Rook / Queen Overdrive Option", "Adds Rook or Queen Overdrive to the rotation.", Job.MCH)]
    MCH_AoE_Adv_QueenOverdrive = 8314,

    #endregion

    [ParentCombo(MCH_AoE_AdvancedMode)]
    [CustomComboInfo("Reassemble Option", "Adds Reassemble to the rotation.", Job.MCH)]
    MCH_AoE_Adv_Reassemble = 8301,

    #region Tools

    [ParentCombo(MCH_AoE_AdvancedMode)]
    [CustomComboInfo("Tools", "Adds Bioblaster, Air Anchor, Chainsaw and Excavator to the rotation.", Job.MCH)]
    MCH_AoE_Adv_Tools = 8315,

    #endregion

    [ParentCombo(MCH_AoE_AdvancedMode)]
    [CustomComboInfo("Head Graze Option", "Uses Head Graze to interrupt during the rotation, where applicable.", Job.MCH)]
    MCH_AoE_Adv_Interrupt = 8311,

    [ParentCombo(MCH_AoE_AdvancedMode)]
    [CustomComboInfo("Second Wind Option", "Use Second Wind when below the set HP percentage.", Job.MCH)]
    MCH_AoE_Adv_SecondWind = 8399,

    #endregion

    #region Basic combo

    [ReplaceSkill(MCH.CleanShot, MCH.HeatedCleanShot)]
    [CustomComboInfo("Basic Combo", "Replace Clean Shot with its combo chain.", Job.MCH)]
    [BasicCombo]
    MCH_ST_BasicCombo = 8117,

    #endregion

    [ReplaceSkill(MCH.Dismantle)]
    [ConflictingCombos(MCH_DismantleTactician)]
    [CustomComboInfo("Double Dismantle Protection", "Prevents the use of Dismantle when target already has the effect by replacing it with Savage Blade.", Job.MCH)]
    MCH_DismantleProtection = 8042,

    [ReplaceSkill(MCH.Dismantle)]
    [ConflictingCombos(MCH_DismantleProtection)]
    [CustomComboInfo("Dismantle - Tactician", "Swap dismantle with tactician when dismantle is on cooldown.", Job.MCH)]
    MCH_DismantleTactician = 8058,

    #region Heatblast

    [ReplaceSkill(MCH.Heatblast, MCH.BlazingShot)]
    [CustomComboInfo("Single Button Heat Blast Feature", "Turns Heat Blast or Blazing Shot into Hypercharge \nwhen u have 50 or more heat or when u got Hypercharged buff.", Job.MCH)]
    MCH_Heatblast = 8006,

    [ParentCombo(MCH_Heatblast)]
    [CustomComboInfo("Barrel Option", "Adds Barrel Stabilizer to the feature when off cooldown.", Job.MCH)]
    MCH_Heatblast_AutoBarrel = 8052,

    [ParentCombo(MCH_Heatblast)]
    [CustomComboInfo("Wildfire Option", "Adds Wildfire to the feature when off cooldown and overheated.", Job.MCH)]
    MCH_Heatblast_Wildfire = 8015,

    [ParentCombo(MCH_Heatblast)]
    [CustomComboInfo("Gauss Round / Ricochet \nDouble Check / Checkmate Option", "Switches between Heat Blast and either Gauss Round and Ricochet or Double Check and Checkmate, depending on cooldown timers.", Job.MCH)]
    MCH_Heatblast_GaussRound = 8016,

    #endregion

    #region AutoCrossbow

    [ReplaceSkill(MCH.AutoCrossbow)]
    [CustomComboInfo("Single Button Auto Crossbow Feature", "Turns Auto Crossbow into Hypercharge when at or above 50 heat.", Job.MCH)]
    MCH_AutoCrossbow = 8018,

    [ParentCombo(MCH_AutoCrossbow)]
    [CustomComboInfo("Barrel Option", "Adds Barrel Stabilizer to the feature when below 50 Heat Gauge.", Job.MCH)]
    MCH_AutoCrossbow_AutoBarrel = 8019,

    [ParentCombo(MCH_AutoCrossbow)]
    [CustomComboInfo("Gauss Round / Ricochet\n Double Check / Checkmate Option", "Switches between Auto Crossbow and either Gauss Round and Ricochet or Double Check and Checkmate, depending on cooldown timers.", Job.MCH)]
    MCH_AutoCrossbow_GaussRound = 8020,

    #endregion

    [ReplaceSkill(MCH.RookAutoturret, MCH.AutomatonQueen)]
    [CustomComboInfo("Overdrive Feature", "Replace Rook Autoturret and Automaton Queen with Overdrive while active.", Job.MCH)]
    MCH_Overdrive = 8002,

    [ReplaceSkill(MCH.HotShot)]
    [CustomComboInfo("Big Hitter Feature", "Replace Hot Shot, Drill, Air Anchor, Chainsaw and Excavator depending on which is on cooldown.", Job.MCH)]
    MCH_BigHitter = 8004,

    [ReplaceSkill(MCH.GaussRound, MCH.Ricochet, MCH.CheckMate, MCH.DoubleCheck)]
    [CustomComboInfo("Gauss Round / Ricochet \nDouble Check / Checkmate Feature", "Replace Gauss Round and Ricochet or Double Check and Checkmate with one or the other depending on which has more charges.", Job.MCH)]
    MCH_GaussRoundRicochet = 8003,

    // Last value ST = 8119
    // Last value AoE = 8315
    // Last value Misc = 8058

    #endregion

    #endregion

    #region PvP Combos

    #region MACHINIST

    [PvPCustomCombo]
    [ReplaceSkill(MCHPvP.BlastCharge)]
    [CustomComboInfo("Burst Mode", "Turns Blast Charge into an all-in-one damage button.", Job.MCH)]
    MCHPvP_BurstMode = 118000,

    [PvPCustomCombo]
    [ParentCombo(MCHPvP_BurstMode)]
    [CustomComboInfo("Air Anchor Option", "Adds Air Anchor to Burst Mode.", Job.MCH)]
    MCHPvP_BurstMode_AirAnchor = 118001,

    [PvPCustomCombo]
    [ParentCombo(MCHPvP_BurstMode)]
    [CustomComboInfo("Analysis Option", "Adds Analysis to Burst Mode.", Job.MCH)]
    MCHPvP_BurstMode_Analysis = 118002,

    [PvPCustomCombo]
    [ParentCombo(MCHPvP_BurstMode_Analysis)]
    [CustomComboInfo("Alternate Analysis Option", "Uses Analysis with Air Anchor instead of Chain Saw.", Job.MCH)]
    MCHPvP_BurstMode_AltAnalysis = 118003,

    [PvPCustomCombo]
    [ParentCombo(MCHPvP_BurstMode)]
    [CustomComboInfo("Drill Option", "Adds Drill to Burst Mode.", Job.MCH)]
    MCHPvP_BurstMode_Drill = 118004,

    [PvPCustomCombo]
    [ParentCombo(MCHPvP_BurstMode_Drill)]
    [CustomComboInfo("Alternate Drill Option", "Saves Drill for use after Wildfire.", Job.MCH)]
    MCHPvP_BurstMode_AltDrill = 118005,

    [PvPCustomCombo]
    [ParentCombo(MCHPvP_BurstMode)]
    [CustomComboInfo("Bio Blaster Option", "Adds Bio Blaster to Burst Mode.", Job.MCH)]
    MCHPvP_BurstMode_BioBlaster = 118006,

    [PvPCustomCombo]
    [ParentCombo(MCHPvP_BurstMode)]
    [CustomComboInfo("Chain Saw Option", "Adds Chain Saw to Burst Mode.", Job.MCH)]
    MCHPvP_BurstMode_ChainSaw = 118007,

    [PvPCustomCombo]
    [ParentCombo(MCHPvP_BurstMode)]
    [CustomComboInfo("Full Metal Field Option", "Adds Full Metal Field to Burst Mode.", Job.MCH)]
    MCHPvP_BurstMode_FullMetalField = 118008,

    [PvPCustomCombo]
    [ParentCombo(MCHPvP_BurstMode)]
    [CustomComboInfo("Wildfire Option", "Adds Wildfire to Burst Mode.", Job.MCH)]
    MCHPvP_BurstMode_Wildfire = 118009,

    [PvPCustomCombo]
    [ParentCombo(MCHPvP_BurstMode)]
    [CustomComboInfo("Marksmans Spite Option",
        "Adds Marksmans Spite to Burst Mode when the target is below specified HP.", Job.MCH)]
    MCHPvP_BurstMode_MarksmanSpite = 118011,

    [PvPCustomCombo]
    [ParentCombo(MCHPvP_BurstMode)]
    [CustomComboInfo("Role Action Eagle Eye Shot Option", "Automatically Adds Eagle Eye Shot to Burst Mode when target is guarded or under selected health percentage \n WILL ONLY WORK IN LARGE SCALE PVP",
       Job.MCH)]
    MCHPvP_Eagle = 118012,

    // Last value = 118012

    #endregion

    #endregion
}
