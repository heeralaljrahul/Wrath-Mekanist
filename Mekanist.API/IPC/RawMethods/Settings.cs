#region

using Dalamud.Plugin.Ipc;
using Mekanist.API.Enum;

// ReSharper disable RedundantSuppressNullableWarningExpression
// ReSharper disable StaticMemberInitializerReferesToMemberBelow

#endregion

namespace Mekanist.API;

public static partial class WrathIPCWrapper
{
    public partial class RawMethod
    {
        /// <summary>
        ///     Meant to throw to test that IPC calls to Wrath Combo are truly working.
        /// </summary>
        /// <remarks>
        ///     Use
        ///     <see cref="Dalamud.Plugin.Ipc.ICallGateSubscriber{T1,TRet}.InvokeAction(T1)">
        ///         .InvokeAction()
        ///     </see>
        ///     , <see langword="void" /> return
        /// </remarks>
        public static readonly
            ICallGateSubscriber<object>
            Test =
                Interface!.GetIpcSubscriber<object>
                    ($"{WC}Test");

        public static readonly
            ICallGateSubscriber<bool>
            IPCReady =
                Interface!.GetIpcSubscriber<bool>
                    ($"{WC}IPCReady");

        public static readonly
            ICallGateSubscriber<string, string, Guid?>
            RegisterForLease =
                Interface!.GetIpcSubscriber<string, string, Guid?>
                    ($"{WC}RegisterForLease");

        public static readonly
            ICallGateSubscriber<string, string, string?, Guid?>
            RegisterForLeaseWithCallback =
                Interface!.GetIpcSubscriber<string, string, string?, Guid?>
                    ($"{WC}RegisterForLeaseWithCallback");

        public static readonly
            ICallGateSubscriber<bool>
            GetAutoRotationState =
                Interface!.GetIpcSubscriber<bool>
                    ($"{WC}GetAutoRotationState");

        public static readonly
            ICallGateSubscriber<Guid, bool, SetResult>
            SetAutoRotationState =
                Interface!.GetIpcSubscriber<Guid, bool, SetResult>
                    ($"{WC}SetAutoRotationState");

        public static readonly
            ICallGateSubscriber<bool>
            IsCurrentJobAutoRotationReady =
                Interface!.GetIpcSubscriber<bool>
                    ($"{WC}IsCurrentJobAutoRotationReady");

        public static readonly
            ICallGateSubscriber<Guid, SetResult>
            SetCurrentJobAutoRotationReady =
                Interface!.GetIpcSubscriber<Guid, SetResult>
                    ($"{WC}SetCurrentJobAutoRotationReady");

        /// <remarks>
        ///     Use
        ///     <see cref="Dalamud.Plugin.Ipc.ICallGateSubscriber{T1,TRet}.InvokeAction(T1)">
        ///         .InvokeAction()
        ///     </see>
        ///     , <see langword="void" /> return
        /// </remarks>
        public static readonly
            ICallGateSubscriber<Guid, object>
            ReleaseControl =
                Interface!.GetIpcSubscriber<Guid, object>
                    ($"{WC}ReleaseControl");

        public static readonly
            ICallGateSubscriber<
                Dictionary<ComboTargetTypeKeys, ComboSimplicityLevelKeys?>>
            IsCurrentJobConfiguredOn =
                Interface!
                    .GetIpcSubscriber<
                            Dictionary<ComboTargetTypeKeys, ComboSimplicityLevelKeys
                                ?>>
                        ($"{WC}IsCurrentJobConfiguredOn");

        public static readonly
            ICallGateSubscriber<
                Dictionary<ComboTargetTypeKeys, ComboSimplicityLevelKeys?>>
            IsCurrentJobAutoModeOn =
                Interface!
                    .GetIpcSubscriber<
                            Dictionary<ComboTargetTypeKeys, ComboSimplicityLevelKeys
                                ?>>
                        ($"{WC}IsCurrentJobAutoModeOn");

        public static readonly
            ICallGateSubscriber<uint, List<string>?>
            GetComboNamesForJob =
                Interface!.GetIpcSubscriber<uint, List<string>?>
                    ($"{WC}GetComboNamesForJob");

        public static readonly
            ICallGateSubscriber<uint, Dictionary<string, List<string>>?>
            GetComboOptionNamesForJob =
                Interface!.GetIpcSubscriber<uint, Dictionary<string, List<string>>?>
                    ($"{WC}GetComboOptionNamesForJob");

        public static readonly
            ICallGateSubscriber<string, Dictionary<ComboStateKeys, bool>?>
            GetComboState =
                Interface!
                    .GetIpcSubscriber<string, Dictionary<ComboStateKeys, bool>?>
                        ($"{WC}GetComboState");

        public static readonly
            ICallGateSubscriber<Guid, string, bool, bool, SetResult>
            SetComboState =
                Interface!.GetIpcSubscriber<Guid, string, bool, bool, SetResult>
                    ($"{WC}SetComboState");

        public static readonly
            ICallGateSubscriber<uint, bool>
            GetComboOptionState =
                Interface!.GetIpcSubscriber<uint, bool>
                    ($"{WC}GetComboOptionState");

        public static readonly
            ICallGateSubscriber<Guid, string, bool, SetResult>
            SetComboOptionState =
                Interface!.GetIpcSubscriber<Guid, string, bool, SetResult>
                    ($"{WC}SetComboOptionState");
    }
}