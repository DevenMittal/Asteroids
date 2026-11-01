# Asteroids

I built an arcade-style space game in C# with MonoGame. It combines ship rotation and thrust, projectiles, asteroid collisions, lives, and a survival-time score.

## Gameplay

https://github.com/user-attachments/assets/ede8e2fb-3b2f-476c-aed6-30f6fb4b6691

This is the original gameplay clip already attached to the repository.

## Controls

| Key | Action |
| --- | --- |
| Up arrow | Thrust |
| Left / Right arrows | Rotate |
| Space | Fire |
| R | Restart after losing |
| Escape | Exit |

## Run locally

This repository uses a legacy **MonoGame Windows / .NET Framework 4.5** project. It references MonoGame’s MSBuild imports and locally installed framework assemblies, rather than a modern DesktopGL NuGet setup.

On a Windows machine with compatible Visual Studio, .NET Framework targeting assemblies, and the legacy MonoGame build/content tools:

1. Open `Asteroids.sln`.
2. Check that MonoGame’s imports and assembly references resolve.
3. Build the included `Content/Content.mgcb` assets with the matching content tools.
4. Run the `Asteroids` project using the solution’s x86 configuration.

The checked-in project does not currently build with the macOS .NET SDK: its legacy `MonoGame.Content.Builder.targets` import is missing. I have not migrated it or rerun the Windows application during this documentation pass. The existing clip shows historical gameplay, not a freshly verified cross-platform release.

## Implementation

The game loop manages asteroid spawning and collisions. `Ship.cs` handles directional movement, `Bullet.cs` handles projectiles, and asteroid classes handle motion and collision behavior.

The source and content files are in `Asteroids/`. This is an early game project, without automated gameplay tests or a packaged release. A cross-platform port would be a separate change from this documentation update.
