# GettingUpTool
Tool for viewing, exporting and replacing textures in the game Marc Ecko's Getting Up

<div>
  <strong>Basic usage of the tool</strong><br>
  Tool should automatically find your game folder<br>
  On left-hand side you get a tree-view of the games folder structure<br>
  Here you can find all the textures for graffiti etc.<br>
  Click in the tree to navigate, find the textures<br>
  Click on a texture to view it in the tool, then you can export it to DDS file<br>
  Edit the DDS file in your editor of choice
</div><br>

<div>
  The games textures are stored in files with the extension ST<br>
  They are essentially DDS but with a different header<br>
  I have not bothered to figure out the entire header (struct PixelData)
</div><br>

<p>Each graffiti piece has 3 textures with it, they are for what parts are shown when it's sprayed a little bit, little bit more, and complete piece.</p>
<br>

<p>The classes in <strong>Textures/</strong> folder are un-used, but may be useful to anyone wanting to continue work on this tool.
Feel free to fork it.</p>

Source is scarcely commented.
