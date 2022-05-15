# Smash Captains
Smash Captains is a biplane-themed race game filled with inspirations ranging from classic console games like Steve Cartwright's [Barnstorming](https://en.wikipedia.org/wiki/Barnstorming_(video_game)) on the Atari 2600 and [Looping](https://en.wikipedia.org/wiki/Looping_(video_game)) on the ColecoVision to modern casual mobile games like Crossy Road. I landed on the design for Smash Captains after binging [Summoning Salt](https://www.youtube.com/c/SummoningSalt)'s speedrun videos and reading about the strange story behind [Todd Rogers](https://en.wikipedia.org/wiki/Todd_Rogers_(gamer))'s alleged Barnstorming highsore. I wanted to make a game that was designed for speedrunning, had a retro influenced style, but felt firmly modern in some ways. I had been tinkering with voxel art visuals for a while and was eager to make something using Magicavoxel and in 3D. The result of all of this was Smash Captains, a colorful voxel art speedrun game.

## Gameplay
Press the screen or hold space to give your wobbly plane thrust as you race to the finish line. Avoid obstacles and grab power-ups along the way.

![Smash Captains gameplay](https://github.com/mklewandowski/smash-captains/blob/main/Assets/Images/smash-captains-gameplay.gif?raw=true)

## Voxel Art

Smash Captains contains 40 playable biplanes and additional in-game voxel art.

![Smash Captains planes](https://github.com/mklewandowski/smash-captains/blob/main/Assets/Images/smash-captains-planes.gif?raw=true)

Voxel art is created using Magicavoxel. To add new voxel art to the project, do the following:
- create asset model in Magicavoxel
- export model as a .obj file (multiple files are exported, only the .obj file is needed)
- import the .obj model file into Unity
- change the material on the mesh renderer to `voxelMaterial.mat`
- drop the model into a scene (scale and rotation might need to be adjusted)

## Supported Platforms
Smash Captains is designed for use on multiple platforms including:
- iOS
- Android
- Web
- Mac and PC standalone builds

## Running Locally
Use the following steps to run locally:
1. Clone this repo
2. Open repo folder using Unity 2021.3.0f.1
3. Install Text Mesh Pro

## Development Tools
- Created using Unity 2021.3.0f.1
- Code edited using Visual Studio Code
- Voxel art made using [Magicavoxel](https://www.voxelmade.com/magicavoxel/)
- Sounds created using [Bfxr](https://www.bfxr.net/)
- Audio edited using [Audacity](https://www.audacityteam.org/)
- 2D images created and edited using [Paint.NET](https://www.getpaint.net/)
