## About
<p>OpenCiv1 project is an open source rewrite of <a href="https://en.wikipedia.org/wiki/Civilization_(video_game)">Civilization game</a> designed by Sid Meier and Bruce Shelley in year 1991.</p>
<ul>
<li>The OpenCiv1 uses .NET 8 and Avalonia UI framework and is OS independent. It is currently compatible with desktops: Windows, Linux and MacOSX.</li>
<p align="center">
<img src="src/Resources/Screenshots/Windows.png" alt="Windows OS" width="260" />
<img src="src/Resources/Screenshots/Linux.png" alt="Linux OS" width="260" />
<img src="src/Resources/Screenshots/MacOSX.png" alt="MacOSX OS" width="260" /></p>
<li>The game logic is <b>Based on original DOS Civilization game version 475.05</b> disassembly.</li>
<li>The game is still very popular and easy to play. But the obsoletness of DOS or Windows 16-bit platform and the bugs that have never been fixed are hindering the popularity of the game.</li>
<li>The news, discussions about this project and release news are published regularly on <a href="https://forums.civfanatics.com/threads/rewrite-of-civilization-1-source-code-openciv1-project.682623/" target="_blank">Civilization Fanatics Forum page</a></li>
</ul>

## Copyright considerations
<p><b>The available code is not a full working copy of the game.</b> <b>To run OpenCiv1 you are legally required to own your own copy of the DOS Civilization game.</b> 
<b>This is the reason that not a single file from the original game is included in this GitHub repository as they are copyrighted.</b></p>

<p>The part of the game assembly code is emulated with Virtual CPU, and the rest of the code has been rewritten from scratch until all of the code is replaced with new copyright free code. The other resources (like graphics, music and text) will also be completely replaced with copyright free resources before publishing the complete game.</p>

## Dependencies
<ul>
<li>.NET 8</li>
<li>Visual C++ 2015-2019 redistributable (on some Windows machines)</li>
</ul>

## How to run the release version of OpenCiv1
<p>The files from the Release should be copied directly into installed and working DOS Civilization game directory. The game can be run by running the OpenCiv1 executable.</p>

## How to compile the code (.NET 8 SDK required)
If you want to Debug (or Compile) the code with Visual Studio 2022 Community Edition, it is assumed that:
<ul>
<li>For debugging purposes you have installed DOS Civilization game at 'c:\Dos\Civ1\', or at '~/Dos/Civ1/' if you are using Linux (uppercase files!).
It is where its home directory resides (Images, palettes, text and save games are loaded/saved there, for now).</li>
</ul>
You can also compile with CLI method:
<ul>
<li>git clone https://github.com/rajko-horvat/OpenCiv1 (To clone a specific branch use: git clone -b [branch] https://github.com/rajko-horvat/OpenCiv1)</li>
<li>cd OpenCiv1</li>
<li>dotnet build -c Release</li>
</ul>

## Current status
<p><b>The game is in working state</b>, but you have to legally own the Original game (the .txt, .pic and .pal files have to be present).<br/><br/>
Additional keyboard shortcuts:
<ul>
<li>Alt + D - Enable / Disable the <b>Debug mode (Shift-56)</b></li>
<li>Alt + P - Pause / Resume game</li>
<li>Alt + 1 - Show / Hide Screen 1</li>
<li>Alt + 2 - Show / Hide Screen 2</li>
<li>Alt + 3 - Show / Hide Screen 3</li>
</ul></p>

## How to Contribute (Help needed)
<p>Anyone can contribute to this repository in accordance with these <a href="https://github.com/rajko-horvat/OpenCiv1/.github/CONTRIBUTING.md">Contributing rules</a></p>
Currently, you can contribute to this repository in one of the following ways:
<ul>
<li>By testing the game functionality and submitting Issues,</li>
<li>By translating the part(s) of the code from pseudo assembly language to native C# language (for details see <a href="https://github.com/rajko-horvat/OpenCiv1/wiki/Introduction-to-code-translating">Introduction to code translating</a>),</li>
<li>By designing parts of a 'Default' Visual and Audio theme (which must preserve original Game appearance and feel as much as possible, SVG and MIDI/SoundFonts would be the best),</li>
<li>By designing parts of a 'Custom' Visual and Audio theme(s) (SVG and MIDI/SoundFonts would be the best).</li>
</ul>

## Project milestones
<p>The goal is to completely rewrite the code (first stage), fix the bugs and port the code to a modern platform (second stage).</p>

### Milestones for a first stage
<ul>
<li>Reaching the initial playability of the game (passed),</li>
<li>Rewrite of the game code, functionalities and features (in progress...),</li>
<li>Archive the game code.</li>
</ul>

### Planned milestones for a second stage
<b>What will change in the new version:</b>
<ul>
<li>Porting to HTML5 platform (Web interface, online gaming),</li>
<li>Graphics (the new graphics will be as close as possible to the spirit of the original version),</li>
<li>Music/Sounds (the new music/sounds will be as close as possible to the spirit of the original version),</li>
<li>Some text where appropriate,</li>
<li>Design (Map zoom functionality, some small updates, also some dialogs will be slightly different),</li>
<li>Multilanguage capability,</li>
<li>Multiplayer capability,</li>
<li>Cheat capability,</li>
<li>Plugin capability (can override rules, graphics and music/sounds).</li>
</ul>
<b>What will stay the same:</b>
<ul>
<li>Original game rules and logic (except for established bugs),</li>
<li>Overall look and feel of the original game.</li>
</ul>

## Current screenshots of the OpenCiv1 game
<p align="center">
<img src="src/Resources/Screenshots/Screenshot1.png" alt="Screenshot 1" width="400" />
<img src="src/Resources/Screenshots/Screenshot2.png" alt="Screenshot 2" width="400" />
<img src="src/Resources/Screenshots/Screenshot3.png" alt="Screenshot 3" width="400" />
<img src="src/Resources/Screenshots/Screenshot4.png" alt="Screenshot 4" width="400" />
<img src="src/Resources/Screenshots/Screenshot5.png" alt="Screenshot 5" width="400" />
<img src="src/Resources/Screenshots/Screenshot6.png" alt="Screenshot 6" width="400" />
<img src="src/Resources/Screenshots/Screenshot7.png" alt="Screenshot 7" width="400" />
<img src="src/Resources/Screenshots/Screenshot8.png" alt="Screenshot 8" width="400" />
<img src="src/Resources/Screenshots/Screenshot9.png" alt="Screenshot 9" width="400" />
<img src="src/Resources/Screenshots/Screenshot10.png" alt="Screenshot 10" width="400" />
<img src="src/Resources/Screenshots/Screenshot11.png" alt="Screenshot 11" width="400" />
<img src="src/Resources/Screenshots/Screenshot12.png" alt="Screenshot 12" width="400" />
<img src="src/Resources/Screenshots/Screenshot13.png" alt="Screenshot 13" width="400" />
<img src="src/Resources/Screenshots/Screenshot14.png" alt="Screenshot 14" width="400" />
</p>