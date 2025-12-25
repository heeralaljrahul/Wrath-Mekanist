#region

using Dalamud.Plugin.Ipc;
using WrathCombo.API.Enum;

// ReSharper disable RedundantSuppressNullableWarningExpression
// ReSharper disable StaticMemberInitializerReferesToMemberBelow

#endregion

namespace WrathCombo.API;

public static partial class WrathIPCWrapper
{
    public partial class RawMethod
    {
        public static readonly
            ICallGateSubscriber<object, object>
            GetAutoRotationConfigState =
                Interface!.GetIpcSubscriber<object, object>
                    ($"{WC}GetAutoRotationConfigState");

        public static readonly
            ICallGateSubscriber<Guid, object, object, SetResult>
            SetAutoRotationConfigState =
                Interface!.GetIpcSubscriber<Guid, object, object, SetResult>
                    ($"{WC}SetAutoRotationConfigState");
    }
}