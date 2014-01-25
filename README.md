1337 GAME TITLE
=======
**Lead Programmers:** Matthew Pohlmann, Brian Chen <br/>
**Programmers:** Bryan Chong, Jeffrey Chau <br/>
**Lead Artist:** Josh DiGiovanni <br/>
**Lead Designer:** Omar Khulusi, David Zhang <br/>
**Documentation / Floater:** Bryan Chong <br/>

This is the Game Design Document for **[1337 GAME TITLE]** built for the 2014 Global Game Jam. This documentation describes our vision of the game.

> We don’t see things as they are, we see them as we are. (Anaïs Nin)

Drawing from quantum physics, **[1337 GAME TITLE]** explores the concept of how we, humans, perceive the working world. Objects can only function when being perceived, rather than existing through the laws of normative physics. Each human being possess an individual understanding of the world that consists of only their immediate surroundings; anything else bears no significance to the individual.

-------

Terminology and Symbols
-------
(*) represents tentative and/or subject-to-change implementation(s)

Overview
-------
**[1337 GAME TITLE]** is a top-down 2D puzzle adventure game with limited field of vision in which only objects that are within the player's field of view are active (i.e. if you don't look at a door that is closing, it won't continue to close until you look at it again). To get around this limitation, the player has the ability to place a "camcorder" that provides a live view of a distant location, meaning that the object that the camera can see acts as if it is being viewed by the player.

Premise / Setting
-------
**THIS IS WHERE SOMEONE PUTS SOME STORYLINE TO FIT THIS GAME!**


Platform
-------
Designed for PC using the Unity3D game engine; however, because of the nature of Unity, it should be easy to port to other platforms (including web and mobile).

Core Gameplay
-------
####Objective
Get to the exit. Don't die or you restart the level.

####**What the Player Can Do**
+ WASD movement (8-directional)
+ Field of vision points in the direction of the mouse
+ Left click to interact
+ Right click to pick up/put down "camcorder"
+ Player can die (i.e. door closes on player, player falls down pit)
+ Player can restart the level at will
+ (*) Player can close eyes
+ (*) Player can turn on/off lights in some rooms to increase/decrease range of vision
+ (*) Player can look at mirrors to reflect his field of vision around corners/back at himself, etc.

###What the Player Cannot Do
+ Player (i.e. the person actually playing the game) cannot see the whole level at once (camera/screen is smaller than the level)
+ Player cannot move through the "camcorder" he/she places - it is impassable terrain

####The Vision Mechanic
The player's vision is represented as a cone in the direction of the mouse that is (*) about 60 degrees (subject to permanent change or in-game change by a game mechanic). Objects within the field of vision (FOV) are active (affected by mechanisms and player interaction), and vice versa. Objects retain momentum when no longer observed, that is if the player slams a door, the door will retain its speed and momentum upon being observed again and continue to close. 

Level Design Implementation
-------
####In-Game Objects
+ Player: The player is '1' arbitrary unit squared
+ Windows: You can look through but you can't pass it
+ "Camcorder": Provides same cone of vision from afar
+ Moving platform
+ Doors
+ Buttons
+ Walls
+ Pitfall
+ Light Switches

Artistic Direction 
-------
**JOSH NEEDS TO PUT THINGS HERE!**