Out of Focus [![Status](https://rawgit.com/bryan/bryan.github.io/master/images/inactive.svg)](#)
=======
**Lead Programmers:** Matthew Pohlmann, Brian Chen <br/>
**Programmers:** Bryan Chong, Jeffrey Chau <br/>
**Lead Artist:** Josh DiGiovanni <br/>
**Designers:** Omar Khulusi, David Zhang <br/>
**Documentation / Floater:** Bryan Chong <br/>

This is the Game Design Document for **Out of Focus** built for the 2014 Global Game Jam. This documentation describes our vision of the game.

> We don’t see things as they are, we see them as we are. (Anaïs Nin)

Drawing from quantum physics, Out of Focus explores the concept of how we, humans, perceive the working world. Objects can only function when being perceived, rather than existing through the laws of normative physics. Each human being possess an individual understanding of the world that consists of only their immediate surroundings; anything else bears no significance to the individual.

-------

Terminology and Symbols
-------
(*) represents tentative and/or subject-to-change implementation(s) <br />
(-) represents suggested idea but not implementated

Overview
-------
**Out of Focus** is a top-down 2D puzzle adventure game with limited field of vision in which only objects that are within the player's field of view are active (i.e. if you don't look at a door that is closing, it won't continue to close until you look at it again). To get around this limitation, the player has the ability to place a "camcorder" that provides a live view of a distant location, meaning that the object that the camera can see acts as if it is being viewed by the player.

Premise / Setting
-------
"I've always been called narrow sighted... and narrow minded. <br />
In my world, things only exist if if I know about it. <br />
As a result, the people around me have left, leaving me alone. <br />
So I stay here in my house. <br />
Creating puzzles for myself. <br />
Hoping that one day, I can see as the world sees..."




Platform
-------
Designed for the Unity Web Player using the Unity3D game engine; however, because of the nature of Unity, it should be easy to port to other platforms (including PC/Mac and mobile).

Core Gameplay
-------
#### Objective
Get to the exit. Don't die or you restart the level.

#### **What the Player Can Do**
+ W,A,S,D movement (8-directional)
+ Field of vision points in the direction of the mouse
+ Space bar to pick up "camcorder"
+ 'F' key to put down "camcorder"
+ Player can die (player falls down pit)
+ Player can restart the level at will
+ (-) Player can close eyes
+ (-) Player can turn on/off lights in some rooms to increase/decrease range of vision
+ (-) Player can look at mirrors to reflect his field of vision around corners/back at himself, etc.

### What the Player Cannot Do
+ Player (i.e. the person actually playing the game) cannot see the whole level at once (camera/screen is smaller than the level)
+ (-) Player cannot move through the "camcorder" he/she places - it is impassable terrain

#### The Vision Mechanic
The player's vision is represented as a cone in the direction of the mouse. Objects within the field of vision (FOV) are active (affected by mechanisms and player interaction), and vice versa.

Level Design Implementation
-------
#### In-Game Objects
![Player](https://github.com/Valakor/GameJam2014/blob/master/Assets/Sprites/sm_player.png?raw=true) Player: The player is '1' arbitrary unit squared <br/>
![Windows](https://github.com/Valakor/GameJam2014/blob/master/Assets/Sprites/sm_window.png?raw=true) (-) Windows: You can look through but you can't pass it <br/>
![Camcorder](https://github.com/Valakor/GameJam2014/blob/master/Assets/Sprites/sm_cam.png?raw=true) Camcorder: Provides same cone of vision from afar <br/>
![Moving platform](https://github.com/Valakor/GameJam2014/blob/master/Assets/Sprites/sm_platform.png?raw=true) Moving platform <br/>
![Doors](https://github.com/Valakor/GameJam2014/blob/master/Assets/Sprites/sm_door.png?raw=true) Doors <br/>
![Buttons](https://github.com/Valakor/GameJam2014/blob/master/Assets/Sprites/sm_button.png?raw=true) Buttons <br/>
![Walls](https://github.com/Valakor/GameJam2014/blob/master/Assets/Sprites/sm_wall.png?raw=true) Walls <br/>
![Pitfall](https://github.com/Valakor/GameJam2014/blob/master/Assets/Sprites/sm_pitfall.png?raw=true) Pitfall <br/>
(-) Light Switches


Artistic Direction 
-------
+ Cute character
+ Pastel color scheme - low stress environment
+ Skewed perspective (strict top-down gameplay) - see Pokémon for inspiration
