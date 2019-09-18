# 03_Arcade_Snake_Game
Classic arcade snake game

Unzip Builds.rar and click on .exe file to paly the game

GAMEPLAY
  Get a maximum score by eating the pizza/food/apple in the given time frame.
  
CONTROLS
   The SNAKE i.e the player can be controlled with the virtual JOYSTICK or using the keyboard keys WASD or ARROW keys.



This Game contains:
a) MAIN MENU
    - START - on click goes to the game.
    - EXIT    - on click exits from the game.
    - CREDITS - on click goes to the credits of the game.
    
b) PAUSE MENU
    - It can be accessed by clicking the ESCAPE button on the pause button on the UI.
      
    - START - on click RESUMEs the game.
    - HOME - on click goes to the MAIN MENU screen.
    - EXIT - on click exits from the game.
    
c) GAME OVER
    - When the time runs out 'TIME OUT' screen flashes and goes to the game over screen.
      
    - Shows the 'SCORE' of the game.
      
    - HOME - on click goes to the MAIN MENU screen.
    - EXIT - on click exits from the game.
    
    
    
CONDITIONS
    
* SNAKE MOVEMENT SPEED can be controlled by changing the 'move speed' attached to the 'SnakeController.cs' script on the SnakeHead1 game object.

* PIZZA(food/apple) SPAWN INTERVAL can be changed by changing 'spaenDelay' attached to the 'SpawnPizza.cs' script attached to the 'PizzaSpawner' game object.

    The spawned food is destroyer over time using 'DestroyOverTime.cs'. Therefore when changing the spawn interval also adjust the time in 'DestroyOverTime.cs'

* Snake bounces back like a MIRROR on hitting the walls.

* Path where the snake moves turn GREEN.



* Game UI shows TIME REMAINING, SCORE, and PAUSE BUTTON.
* Game has background music and play sound on eating food.



INSTRUCTIONS

* EXE file can be found in the 'Build' folder. Use a resolution of 800*600 in windowed mode for the best experience.
* Play game in 5:4 aspect ratio.
