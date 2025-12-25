#region

using Dalamud.Plugin;

#endregion

namespace WrathCombo.API;

public static partial class WrathIPCWrapper
{
    private static IDalamudPluginInterface? Interface;

    public static void InitWrapper(IDalamudPluginInterface pluginInterface)
    {
        Interface = pluginInterface;
    }
}