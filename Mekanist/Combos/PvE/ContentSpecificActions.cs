namespace Mekanist.Combos.PvE;

/// <summary>
/// Stub class for content-specific (Variant/Criterion dungeon) actions.
/// Functionality removed as not applicable to Machinist-only plugin.
/// </summary>
internal static class ContentSpecificActions
{
    /// <summary>
    /// Attempts to get a content-specific action. Always returns false.
    /// </summary>
    public static bool TryGet(out uint action)
    {
        action = 0;
        return false;
    }
}
