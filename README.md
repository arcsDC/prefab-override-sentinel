# prefab-override-sentinel

A Unity editor window that scans scenes for prefab instances, categorizes every override, and lets you selectively revert or promote changes back to the source prefab.

## Stack

Primary language: **C#**

## Project structure

- `Editor/PrefabOverrideSentinel.cs` — Central editor window for auditing, filtering, reverting, and promoting prefab overrides across the active scene.
- `PackageManifest/package.json` — unity package manifest
- `Editor/OverrideCategorizer.cs` — classifies overrides by property type
- `Editor/OverrideMerger.cs` — revert and promote operations
- `Editor/SceneOverrideScanner.cs` — finds all prefab instances in scene
- `Editor/OverrideInspector.cs` — adds sentinel shortcut to prefab inspector
- `Editor/ProjectValidator.cs` — validates prefab hierarchy for orphaned or broken references
- `Editor/SentinelConfig.cs` — persistent editor settings

## Usage

Review the source files and install any dependencies referenced by the project before running it.
