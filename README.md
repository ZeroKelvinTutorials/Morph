# Morph
Line Renderer Morph from https://youtu.be/v1Q08dG1Me4

To make it work:

Set up a GameObject with the MorphLines script on it.

Populate this script's LineRenderer list in the editor and set its morph time.

Press numbers on your keyboard to go towards the LineRenderer in that index.

Things that could make this tool better:

Not rely on having to have both lines be of same size prior to morphin. Ideally it would start adapting its size to target size.

Have it work between Lists of Line Renderers, right now it only works in a 1:1 Line Renderer scenario.
