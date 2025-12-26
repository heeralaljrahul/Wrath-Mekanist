#region

using Dalamud.Interface.Components;
using Dalamud.Interface.Utility.Raii;
using ECommons;
using ECommons.DalamudServices;
using ECommons.ExcelServices;
using ECommons.ImGuiMethods;
using Lumina.Excel.Sheets;
using System;
using System.Linq;
using Mekanist.Combos.PvE;
using Mekanist.Extensions;
using Mekanist.Services;
using Mekanist.Services.IPC;
using Mekanist.Services.IPC_Subscriber;
using Mekanist.API.Enum;

#endregion

namespace Mekanist.Window.Tabs;

internal class AutoRotationTab : ConfigWindow
{
    private static uint _selectedNpc = 0;
    internal static new void Draw()
    {
        ImGui.TextWrapped($"This is where you can configure the parameters in which Auto-Rotation will operate. " +
                          $"Features marked with an 'Auto-Mode' checkbox are able to be used with Auto-Rotation.");
        ImGui.Separator();

        var cfg = Service.Configuration.RotationConfig;
        bool changed = false;

        if (P.UIHelper.ShowIPCControlledIndicatorIfNeeded())
            changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                "Enable Auto-Rotation", ref cfg.Enabled);
        else
            changed |= ImGui.Checkbox($"Enable Auto-Rotation", ref cfg.Enabled);
        if (P.IPC.GetAutoRotationState())
        {
            var inCombatOnly = (bool)P.IPC.GetAutoRotationConfigState(
                Enum.Parse<AutoRotationConfigOption>("InCombatOnly"))!;
            ImGuiExtensions.Prefix(!inCombatOnly);
            changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                "Only in Combat", ref cfg.InCombatOnly, "InCombatOnly");

            if (inCombatOnly)
            {
                ImGuiExtensions.Prefix(false);
                changed |= ImGui.Checkbox($"Bypass When Combo Suggests Self-Use Action", ref cfg.BypassBuffs);
                ImGuiComponents.HelpMarker($"Allows self-use actions to be used without being in combat.");

                ImGuiExtensions.Prefix(false);
                changed |= ImGui.Checkbox($"Bypass Only in Combat for Quest Targets", ref cfg.BypassQuest);
                ImGuiComponents.HelpMarker("Disables Auto-Mode outside of combat unless you're within range of a quest target.");

                ImGuiExtensions.Prefix(false);
                changed |= ImGui.Checkbox($"Bypass Only in Combat for FATE Targets", ref cfg.BypassFATE);
                ImGuiComponents.HelpMarker("Disables Auto-Mode outside of combat unless you're synced to a FATE.");

                ImGuiExtensions.Prefix(true);
                ImGuiEx.SetNextItemWidthScaled(100);
                changed |= ImGui.InputInt("Delay to activate Auto-Rotation once combat starts (seconds)", ref cfg.CombatDelay);

                if (cfg.CombatDelay < 0)
                    cfg.CombatDelay = 0;
            }
        }

        changed |= ImGui.Checkbox("Enable Automatically in Instanced Content", ref cfg.EnableInInstance);
        changed |= ImGui.Checkbox("Disable After Leaving Instanced Content", ref cfg.DisableAfterInstance);

        if (ImGui.CollapsingHeader("Damage Settings"))
        {
            ImGuiEx.TextUnderlined($"Targeting Mode");

            P.UIHelper.ShowIPCControlledIndicatorIfNeeded("DPSRotationMode");
            changed |= P.UIHelper.ShowIPCControlledComboIfNeeded(
                "###DPSTargetingMode", true, ref cfg.DPSRotationMode,
                ref cfg.HealerRotationMode, "DPSRotationMode");

            ImGuiComponents.HelpMarker("Manual - Leaves all targeting decisions to you.\n" +
                                       "Highest Max - Prioritises enemies with the highest max HP.\n" +
                                       "Lowest Max - Prioritises enemies with the lowest max HP.\n" +
                                       "Highest Current - Prioritises the enemy with the highest current HP.\n" +
                                       "Lowest Current - Prioritises the enemy with the lowest current HP.\n" +
                                       "Tank Target - Prioritises the same target as the first tank in your group.\n" +
                                       "Nearest - Prioritises the closest target to you.\n" +
                                       "Furthest - Prioritises the furthest target from you.");
            ImGui.Spacing();

            if (cfg.DPSRotationMode is DPSRotationMode.Manual)
            {
                changed |= ImGui.Checkbox("Enforce Best AoE Target Selection", ref cfg.DPSSettings.AoEIgnoreManual);

                ImGuiComponents.HelpMarker("For all other targeting modes, AoE will target based on highest number of targets hit. In manual mode, it will only do this if you tick this box.");
            }

                
            P.UIHelper.ShowIPCControlledIndicatorIfNeeded("DPSAoETargets");
            var input = P.UIHelper.ShowIPCControlledNumberInputIfNeeded(
                "Targets Required for AoE Damage Features", ref cfg.DPSSettings.DPSAoETargets, "DPSAoETargets");
            if (input)
            {
                changed |= input;
                if (cfg.DPSSettings.DPSAoETargets < 0)
                    cfg.DPSSettings.DPSAoETargets = 0;
            }
            ImGuiComponents.HelpMarker($"Disabling this will turn off AoE DPS features. Otherwise will require the amount of targets required to be in range of an AoE feature's attack to use. This applies to all 3 roles, and for any features that deal AoE damage.");

            ImGuiEx.SetNextItemWidthScaled(100);
            changed |= ImGui.SliderFloat("Max Target Distance", ref cfg.DPSSettings.MaxDistance, 1, 30);
            cfg.DPSSettings.MaxDistance =
                Math.Clamp(cfg.DPSSettings.MaxDistance, 1, 30);

            ImGuiComponents.HelpMarker("Max distance all targeting modes (except Manual) will look for a target. Values from 1 to 30 only.");

            P.UIHelper.ShowIPCControlledIndicatorIfNeeded("FATEPriority");
            changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                "Prioritise FATE Targets", ref cfg.DPSSettings.FATEPriority, "FATEPriority");
            P.UIHelper.ShowIPCControlledIndicatorIfNeeded("QuestPriority");
            changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                "Prioritise Quest Targets", ref cfg.DPSSettings.QuestPriority, "QuestPriority");
            changed |= ImGui.Checkbox($"Prioritise Targets Not In Combat", ref cfg.DPSSettings.PreferNonCombat);

            if (cfg.DPSSettings.PreferNonCombat && changed)
                cfg.DPSSettings.OnlyAttackInCombat = false;

            changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                "Only Attack Targets Already In Combat", ref cfg.DPSSettings.OnlyAttackInCombat,
                "OnlyAttackInCombat");

            if (cfg.DPSSettings.OnlyAttackInCombat && changed)
                cfg.DPSSettings.PreferNonCombat = false;

            changed |= ImGui.Checkbox("Always Target Regardless of Action", ref cfg.DPSSettings.AlwaysSelectTarget);

            ImGuiComponents.HelpMarker("Normally, Auto-rotation will only target an enemy if the next action it would fire needs a target. This will change the behaviour so it will always select the target regardless of what the action can target.");

            changed |= ImGui.Checkbox("Un-Target and Stop Actions for Pyretics", ref cfg.DPSSettings.UnTargetAndDisableForPenalty);

            ImGuiComponents.HelpMarker("This will un-set any current target and disable Auto-Rotation actions if there is a current detected Pyretic (or similar, like Acceleration Bomb) mechanic affecting the player, that would harm them if they took any action.");

            var npcs = Service.Configuration.IgnoredNPCs.ToList();
            var selected = npcs.FirstOrNull(x => x.Key == _selectedNpc);
            var prev = selected is null ? "" : $"{Svc.Data.Excel.GetSheet<BNpcName>().GetRow(selected.Value.Value).Singular} (ID: {selected.Value.Key})";
            ImGuiEx.TextUnderlined($"Ignored NPCs");
            using (var combo = ImRaii.Combo("###Ignore", prev))
            {
                if (combo)
                {
                    if (ImGui.Selectable(""))
                    {
                        _selectedNpc = 0;
                    }

                    foreach (var npc in npcs)
                    {
                        var npcData = Svc.Data.Excel
                            .GetSheet<BNpcName>().GetRow(npc.Value);
                        if (ImGui.Selectable($"{npcData.Singular} (ID: {npc.Key})"))
                        {
                            _selectedNpc = npc.Key;
                        }
                    }
                }
            }
            ImGuiComponents.HelpMarker("These NPCs will be ignored by Auto-Rotation.\n" +
                                       "Every instance of this NPC will be excluded from automatic targeting (Manual will still work).\n" +
                                       "To remove an NPC from this list, select it and press the Delete button below.\n" +
                                       "To add an NPC to this list, target the NPC and use the command: /mek ignore");

            if (_selectedNpc > 0)
            {
                if (ImGui.Button("Delete From Ignored"))
                {
                    Service.Configuration.IgnoredNPCs.Remove(_selectedNpc);
                    Service.Configuration.Save();

                    _selectedNpc = 0;
                }
            }

        }

        ImGuiEx.TextUnderlined("Advanced");
        changed |= ImGui.InputInt("Throttle Delay (ms)", ref cfg.Throttler);
        ImGuiComponents.HelpMarker("Auto-Rotation has a built in throttler to only run every so many milliseconds for performance reasons. If you experience issues with frame rate, try increasing this value. Do note this may have a side-effect of introducing clipping if set too high, so experiment with the value.");

        var orbwalker = OrbwalkerIPC.IsEnabled && OrbwalkerIPC.PluginEnabled();
        using (ImRaii.Disabled(!orbwalker))
        {
            P.UIHelper.ShowIPCControlledIndicatorIfNeeded("OrbwalkerIntegration");
            changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                "Enable Orbwalker Integration", ref cfg.OrbwalkerIntegration, "OrbwalkerIntegration");

            ImGuiComponents.HelpMarker($"This will make Auto-Rotation use actions with cast times even whilst moving, as Orbwalker will lock movement during the cast. You may need to enable \"Buffer Initial Cast\" setting in Orbwalker if not already enabled. Requires an Orbwalker plugin to be installed and enabled.");
        }

        if (changed)
            Service.Configuration.Save();

    }
}