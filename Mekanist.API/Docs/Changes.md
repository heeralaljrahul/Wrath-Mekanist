### `0.1.2` <sup>(2025-12-20)</sup>

Moved `WrathCombo.API.IPC.RawMethods` to
`WrathCombo.API.WrathIPCWrapper.RawMethods`.\
Fixed publishing script to include downloading Dalamud.

### `0.1.1` <sup>(2025-12-20)</sup>

Marked `Utility` `WrathCombo.API.IPC.RawMethods` as obsolete,
to be made internal in `1.1.0` (Wrapper methods are in place for these).

### `0.1.0` <sup>(2025-12-20)</sup>

Added Raw IPC Subscriber Methods for all IPC endpoints.\
Stubbed Wrapper methods for IPC Methods.\
Added Exceptions to categorize all encounterable Exceptions.\
Designed, but didn't fully implement, wrapper method documentation.

### `0.0.9` <sup>(2025-12-19)</sup>

Finalize the initial Enums and layout for the package.\
Finished publishing script work, and moved the package to be under puni.sh.\
Fully adopt this package in place of the same data that was in WrathCombo
(in [WrathCombo#948](https://github.com/PunishXIV/WrathCombo/pull/948)).

### `0.0.1` <sup>(2025-12-19)</sup>

Initial Release.\
Includes:

- All Enums from WrathCombo
  (from `WrathCombo.Services.IPC` and `WrathCombo.AutoRotation`)
- A new extension to give the value type for `AutoRotationConfigOption` values.