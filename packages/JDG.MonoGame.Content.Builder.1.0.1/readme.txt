JDG.MonoGame.Content.Builder
JustDattGuy

Installation
----------------
By the time of reading this, you've more than likely installed the Nuget Package. From an installation perspective, this is all you need to do.


Usage
----------------
If you don't have an installed version of MonoGame, the provided Content file won't have the Pipeline tool associated with it yet. To do this, follow these steps:
	1. Right click the Content.mgcb file, and click "Open With..."
	2. Click Add...
	3. Complete the text box entitled "Program" by locating Pipeline.exe in the package you've just downloaded. Packages are typically located at the root folder for the solution, under "Packages"
		i. Pipeline.exe is located in the "JDG.MonoGame.Content.Builder.X.X.X/tools" folder (Where X is the version you're using)
	4. Leave "Arguments" blank, and enter whatever you like in the "Friendly name" box.
	5. Click OK.
	6. Find the newly added program in the list by the friendly name you've just given it, select it and then click "Set as Default".

From here, by double clicking the Content.mgcb file in your solution, it will automatically be opened in the Pipeline tool, ready for you to add your content.

Build your project!
Once built, the content files you've added will also be built and placed in to the Content folder of where your program is built to.

Enjoy!


Issues
----------------
 - Errors can be experienced regarding d3d libraries missing, if this happens, just make sure you have the latest Direct X installed.