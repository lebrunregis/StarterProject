# Fake Stop Motion

Create a Stop Motion effect without affecting animations.  

## WebGL demo
See it in action [here](https://radivarig.github.io/FakeStopMotion_Demo/)!

## How it works
Stores local position/rotation and resets it until the next time interval.  
Separately snaps target rotation to even 360 divisions.  

## Keeps animations intact
Since it only uses transform storing it does not require or change animations or Animator.  
It lets animator update the transforms then resets them to stored values.  

## Resillient to game fps changes
It does not count frames and instead waits for `framesPerSecond` interval to pass.  

## Exclude nested transforms
Nested objects can be ignored by attaching `FakeStopMotionIgnore.cs` component.  
Useful for objects that accumulate position offset and start floating away, like particle emmiters.  

## Reset/Pause timer
Call `ResetTimer` to update transforms in the current frame.  
Call `PauseTimer/UnpauseTimer` to pause/resume.  

## Compatible with UPixelator snapping
This asset was made for [UPixelator](https://assetstore.unity.com/packages/slug/243562)
 to remove pixel creeping and get the animated sprite feel.  
It is compatible with `UPixelatorSnappable.cs` which snaps objects to pixel grid to remove flickering.  

## Please note
Immediate effects like weapon trails will look as rendered ahead of the stored transforms.  

## Render Pipelines
This asset is not RP specific, but the demo scene supports Built-in and URP.  

## Other assets
Used in the demo scene:
  - If you're interested in these assets it's better to download them directly from the package manager
  - `Unity Technologies > 3d Game Kit` character with modified scripts

## Contact
If you have any questions or feedback, please contact me at reslav.hollos@gmail.com.  
You can also join the [Discord server](https://discord.gg/uFEDDpS8ad)!  
