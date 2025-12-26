using Dalamud.Interface;
using Dalamud.Interface.Colors;
using Dalamud.Interface.Utility;
using ECommons.DalamudServices;
using ECommons.ImGuiMethods;
using ImGuiNET;
using System.Diagnostics;
using System.Numerics;

namespace WrathCombo.Window.Tabs;

internal static class AboutTab
{
    internal static void Draw(string pluginName)
    {
        using var child = ImGuiEx.ImRaii.Child("###AboutTabChild");
        if (!child) return;

        ImGuiEx.CenterCursor(pluginName.Length * 25f);
        ImGuiEx.TextWrapped(ImGuiColors.DalamudViolet, pluginName);

        var version = Svc.PluginInterface.Manifest.AssemblyVersion;
        ImGuiEx.CenterCursorFor(version.ToString().Length * 11f);
        ImGuiEx.Text(ImGuiColors.DalamudGrey, $"v{version}");

        ImGuiEx.Spacing(2);
        ImGuiEx.LineCentered("###AboutTabDivider", () => ImGuiEx.SeparatorEx(2));
        ImGuiEx.Spacing(2);

        // Credits
        ImGuiEx.CenterCursor(200f);
        ImGui.TextWrapped("Created by Bunz");

        ImGuiEx.Spacing(1);
        ImGuiEx.CenterCursor(300f);
        ImGuiEx.TextWrapped(ImGuiColors.DalamudGrey3, "(based on Wrath Combo by Puni.sh)");

        ImGuiEx.Spacing(2);

        // Disclaimer
        ImGuiEx.CenterCursor(400f);
        ImGuiEx.TextWrapped(ImGuiColors.DalamudYellow,
            "Please support the official Wrath Combo plugin!");

        ImGuiEx.Spacing(1);
        ImGuiEx.CenterCursor(350f);
        ImGuiEx.TextWrapped(ImGuiColors.DalamudGrey,
            "This is an educational fork to learn plugin development.");

        ImGuiEx.Spacing(3);
        ImGuiEx.LineCentered("###AboutTabDivider2", () => ImGuiEx.SeparatorEx(1));
        ImGuiEx.Spacing(2);

        // Mekanist-themed description
        ImGuiEx.CenterCursor(400f);
        ImGui.TextWrapped("Mekanist - A specialized combo plugin for the MCH job");

        ImGuiEx.Spacing(1);
        ImGuiEx.CenterCursor(420f);
        ImGuiEx.TextWrapped(ImGuiColors.DalamudGrey,
            "Condenses combos and abilities for a streamlined Mekanist gameplay experience.");

        ImGuiEx.Spacing(3);

        // Links section
        ImGuiEx.LineCentered("###AboutTabLinks", () =>
        {
            if (ImGuiEx.IconButton(FontAwesomeIcon.Globe, "Repository"))
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/PunishXIV/WrathCombo",
                    UseShellExecute = true
                });
            if (ImGui.IsItemHovered())
                ImGui.SetTooltip("Original Wrath Combo Repository");

            ImGui.SameLine();
            ImGuiEx.Spacing(20f, false);

            if (ImGuiEx.IconButton(FontAwesomeIcon.ExternalLinkAlt, "Discord"))
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://discord.gg/Zzrcc8kmvy",
                    UseShellExecute = true
                });
            if (ImGui.IsItemHovered())
                ImGui.SetTooltip("Puni.sh Discord Community");
        });

        ImGuiEx.Spacing(2);

        // Footer
        ImGuiEx.CenterCursor(250f);
        ImGuiEx.TextWrapped(ImGuiColors.DalamudGrey3,
            "Thank you to the Wrath Combo team for the original plugin!");
    }
}
