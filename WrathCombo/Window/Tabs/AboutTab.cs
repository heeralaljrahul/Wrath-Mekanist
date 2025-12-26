using Dalamud.Interface;
using Dalamud.Interface.Colors;
using Dalamud.Interface.Utility;
using ECommons.DalamudServices;
using ECommons.ImGuiMethods;
using System.Diagnostics;

namespace WrathCombo.Window.Tabs;

internal static class AboutTab
{
    internal static void Draw(string pluginName)
    {
        ImGuiEx.ImGuiLineCentered("AboutTitle", () =>
        {
            ImGuiEx.Text(ImGuiColors.DalamudViolet, pluginName);
        });

        var version = Svc.PluginInterface.Manifest.AssemblyVersion;
        ImGuiEx.ImGuiLineCentered("AboutVersion", () =>
        {
            ImGuiEx.Text(ImGuiColors.DalamudGrey, $"v{version}");
        });

        ImGuiHelpers.ScaledDummy(10f);

        ImGui.Separator();

        ImGuiHelpers.ScaledDummy(10f);

        // Credits
        ImGuiEx.ImGuiLineCentered("AboutCredits", () =>
        {
            ImGui.TextWrapped("Created by Bunz");
        });

        ImGuiHelpers.ScaledDummy(5f);

        ImGuiEx.ImGuiLineCentered("AboutBasedOn", () =>
        {
            ImGuiEx.TextWrapped(ImGuiColors.DalamudGrey3, "(based on Wrath Combo by Puni.sh)");
        });

        ImGuiHelpers.ScaledDummy(10f);

        // Disclaimer
        ImGuiEx.ImGuiLineCentered("AboutDisclaimer", () =>
        {
            ImGuiEx.TextWrapped(ImGuiColors.DalamudYellow,
                "Please support the official Wrath Combo plugin!");
        });

        ImGuiHelpers.ScaledDummy(5f);

        ImGuiEx.ImGuiLineCentered("AboutEducational", () =>
        {
            ImGuiEx.TextWrapped(ImGuiColors.DalamudGrey,
                "This is an educational fork to learn plugin development.");
        });

        ImGuiHelpers.ScaledDummy(15f);

        ImGui.Separator();

        ImGuiHelpers.ScaledDummy(10f);

        // Mekanist description
        ImGuiEx.ImGuiLineCentered("AboutDescription1", () =>
        {
            ImGui.TextWrapped("Mekanist - A specialized combo plugin for the MCH job");
        });

        ImGuiHelpers.ScaledDummy(5f);

        ImGuiEx.ImGuiLineCentered("AboutDescription2", () =>
        {
            ImGuiEx.TextWrapped(ImGuiColors.DalamudGrey,
                "Condenses combos and abilities for a streamlined Mekanist gameplay experience.");
        });

        ImGuiHelpers.ScaledDummy(15f);

        // Links section
        ImGuiEx.ImGuiLineCentered("AboutLinks", () =>
        {
            if (ImGui.Button("Original Repository"))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/PunishXIV/WrathCombo",
                    UseShellExecute = true
                });
            }

            ImGui.SameLine();

            if (ImGui.Button("Puni.sh Discord"))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://discord.gg/Zzrcc8kmvy",
                    UseShellExecute = true
                });
            }
        });

        ImGuiHelpers.ScaledDummy(10f);

        // Footer
        ImGuiEx.ImGuiLineCentered("AboutFooter", () =>
        {
            ImGuiEx.TextWrapped(ImGuiColors.DalamudGrey3,
                "Thank you to the Wrath Combo team for the original plugin!");
        });
    }
}
