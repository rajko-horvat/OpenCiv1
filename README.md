## About this repository
<p>This is a rewrite of Civilization 1 Game designed by Sid Meier and Bruce Shelley in year 1991.</p>
<p>The game logic is <b>Based on original DOS CIV I version 475.05</b> disassembly.</p>
<p>The game is still very popular and easy to play. But the obsoletness of DOS or Windows 16-bit platform 
and the bugs that have never been fixed are hindering the popularity of the game.<p>
<p>The news, discussions about this project and releases are published regularly on <a href="https://forums.civfanatics.com/threads/rewrite-of-civilization-1-source-code-openciv1-project.682623/" target="_blank">Civilization Fanatics Forum page</a></p>

## Copyright considerations
<p><b>The available code is not a full working copy of the game.</b> <b>To run Open Civilization 1 you are legally required to own your own copy of the Civilization game.</b> 
This is the reason that game files are not included (sounds, images and text) as they are copyrighted.</p>

<p>The part of the game assembly code is emulated with Virtual CPU, and the rest of the code has been rewritten from scratch 
until all of the code is replaced with new copyright free code. The other resources (like graphics, music and text) 
will also be completely replaced with copyright free resources before publishing the complete game.</p>

## Current status
<p><b>The game is in working state</b>, but you have to legally own the Original game (the .txt, .pic and .pal files have to be present).
The <b>Debug mode</b> can be toggled by pressing Alt + D Key.</p>

## Running the code
If you want to compile the code, it is assumed that:
<ul>
<li>You are using Visual Studio 2022.</li>
<li>You have .NET Framework 4.8 installed.</li>
<li>For debugging you have installed DOS CIV I game at 'c:\Dos\Civ1\', or at '~/Dos/Civ1/' if you are using Mono on Linux.
It's where it's home directory resides (Images, palettes, text and save games are loaded/saved there, for now).</li>
</ul>

## Help needed
<p>All contributions are welcome.</p>
For this stage of code rewrite, the programmings skills needed are:
<ul>
<li>Moderate knowledge of assembly language,</li>
<li>Knowledge of C# language.</li>
<li>For details see: https://github.com/rajko-horvat/OpenCiv1/wiki/Introduction-to-code-translating</li>
</ul>

## Project milestones
<p>The goal is to completely rewrite the code (first stage), fix the bugs and port the code to a modern platform (second stage).</p>
<b>Milestones for a first stage are:</b>
<ul>
<li>Reaching the initial playability of the game (passed),</li>
<li>Rewrite of the game code, functionalities and features (in progress...),</li>
<li>Archive the game code.</li>
</ul><br>
<b>Planned milestones for a second stage are:</b>
<ul>
<li>Fixing the bugs and introduction of new features 
(Multiple languages besides basic English, Multiplayer capabilities...),</li>
<li>Porting to HTML5 platform,</li>
<li>Redesigning graphics and music.</li>
</ul>

## Screenshots of the Open Civilization 1 game
<p align="center">
<img src="Screenshots/Screenshot1.png" alt="Screenshot 1" /><br/>
<img src="Screenshots/Screenshot2.png" alt="Screenshot 2" /><br/>
<img src="Screenshots/Screenshot3.png" alt="Screenshot 3" /><br/>
<img src="Screenshots/Screenshot4.png" alt="Screenshot 4" /><br/>
<img src="Screenshots/Screenshot5.png" alt="Screenshot 5" /><br/>
<img src="Screenshots/Screenshot6.png" alt="Screenshot 6" /><br/>
<img src="Screenshots/Screenshot7.png" alt="Screenshot 7" /><br/>
<img src="Screenshots/Screenshot8.png" alt="Screenshot 8" /><br/>
<img src="Screenshots/Screenshot9.png" alt="Screenshot 9" /><br/>
<img src="Screenshots/Screenshot10.png" alt="Screenshot 10" /><br/>
<img src="Screenshots/Screenshot11.png" alt="Screenshot 11" /><br/>
<img src="Screenshots/Screenshot12.png" alt="Screenshot 12" /><br/>
<img src="Screenshots/Screenshot13.png" alt="Screenshot 13" /><br/>
<img src="Screenshots/Screenshot14.png" alt="Screenshot 14" /><br/>
</p>