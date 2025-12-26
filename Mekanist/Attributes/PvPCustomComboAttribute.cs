using System;

namespace Mekanist.Attributes;

/// <summary> Attribute designating secret combos. </summary>
[AttributeUsage(AttributeTargets.Field)]
internal class PvPCustomComboAttribute : Attribute
{
}