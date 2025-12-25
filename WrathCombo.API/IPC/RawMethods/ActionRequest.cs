#region

using Dalamud.Plugin.Ipc;
using FFXIVClientStructs.FFXIV.Client.Game;

// ReSharper disable RedundantSuppressNullableWarningExpression
// ReSharper disable StaticMemberInitializerReferesToMemberBelow

#endregion

namespace WrathCombo.API;

public static partial class WrathIPCWrapper
{
    public partial class RawMethod
    {
        /// <remarks>
        ///     Use
        ///     <see cref="Dalamud.Plugin.Ipc.ICallGateSubscriber{T1,TRet}.InvokeAction(T1)">
        ///         .InvokeAction()
        ///     </see>
        ///     , <see langword="void" /> return
        /// </remarks>
        public static readonly
            ICallGateSubscriber<ActionType, uint, int, object>
            RequestBlacklist =
                Interface!.GetIpcSubscriber<ActionType, uint, int, object>
                    ($"{WC}RequestBlacklist");

        /// <remarks>
        ///     Use
        ///     <see cref="Dalamud.Plugin.Ipc.ICallGateSubscriber{T1,TRet}.InvokeAction(T1)">
        ///         .InvokeAction()
        ///     </see>
        ///     , <see langword="void" /> return
        /// </remarks>
        public static readonly
            ICallGateSubscriber<ActionType, uint, object>
            ResetBlacklist =
                Interface!.GetIpcSubscriber<ActionType, uint, object>
                    ($"{WC}ResetBlacklist");

        /// <remarks>
        ///     Use
        ///     <see cref="Dalamud.Plugin.Ipc.ICallGateSubscriber{T1,TRet}.InvokeAction(T1)">
        ///         .InvokeAction()
        ///     </see>
        ///     , <see langword="void" /> return
        /// </remarks>
        public static readonly
            ICallGateSubscriber<object>
            ResetAllBlacklists =
                Interface!.GetIpcSubscriber<object>
                    ($"{WC}ResetAllBlacklist");

        public static readonly
            ICallGateSubscriber<ActionType, uint, float>
            GetArtificialCooldown =
                Interface!.GetIpcSubscriber<ActionType, uint, float>
                    ($"{WC}GetArtificialCooldown");

        /// <remarks>
        ///     Use
        ///     <see cref="Dalamud.Plugin.Ipc.ICallGateSubscriber{T1,TRet}.InvokeAction(T1)">
        ///         .InvokeAction()
        ///     </see>
        ///     , <see langword="void" /> return
        /// </remarks>
        public static readonly
            ICallGateSubscriber<ActionType, uint, int, bool?, object>
            RequestActionUse =
                Interface!.GetIpcSubscriber<ActionType, uint, int, bool?, object>
                    ($"{WC}RequestActionUse");

        /// <remarks>
        ///     Use
        ///     <see cref="Dalamud.Plugin.Ipc.ICallGateSubscriber{T1,TRet}.InvokeAction(T1)">
        ///         .InvokeAction()
        ///     </see>
        ///     , <see langword="void" /> return
        /// </remarks>
        public static readonly
            ICallGateSubscriber<ActionType, uint, object>
            ResetRequest =
                Interface!.GetIpcSubscriber<ActionType, uint, object>
                    ($"{WC}ResetRequest");

        /// <remarks>
        ///     Use
        ///     <see cref="Dalamud.Plugin.Ipc.ICallGateSubscriber{T1,TRet}.InvokeAction(T1)">
        ///         .InvokeAction()
        ///     </see>
        ///     , <see langword="void" /> return
        /// </remarks>
        public static readonly
            ICallGateSubscriber<object>
            ResetAllRequests =
                Interface!.GetIpcSubscriber<object>
                    ($"{WC}ResetAllRequests");
    }
}