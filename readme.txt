Assignment 1 - Graphics and Interaction - COMP30019

The Implementation of terrain is done using the diamond square algorithm,
a terrain object is created inside unity and the script is associated with it.
The Script imports the implmentation of the diamond square algorithm, it uses
the height map of the terrain to map the Unity terrain to various random generated
heights. The diamond square is applied by initlizing the heights to 0, then 
performing the diamond and square steps incrementing or decrementing the random
heights. Thus averaging out the overall differences.

The Camera was implemented by creating a camera controller and associating the main
camera to it. Thus moving the controller results in the player's movements.