# The Run of The MADMAN

## Items

There are three items the player can equip; a hammer, rock, or fist.

## Player

The player has several animations PlayerIdle, PlayerWalk, PlayerClimb, PlayerDeath, PlayerHammer, PlayerThrow, and PlayerPullLever. The animation Controller called Player is used to make the transitions from each animations in conjuction with the PlayerCharacterController Script. The PlayerPullLever, PlayerHammer, PlayerThrow, PlayerDeath animations have animation events so the event of the action is tied to the length of the animation. This was to make a visual indication of the player actions corresponding to the action. 

The variables that are adjusted are the throwforce, and forcejump which determine the force the rock is thrown and the height of the player's jump respectively. 

## Interatable Objects

### Log

The Log is uses to go over chasms or over spikes. The player uses an item in order to knock the log over. The hammer is used to accomplish this. 

### Climbing Wall

A wall with a yellowish color is used to climb on. The are used in conjunction with spike so the player need to just to then climb onto the wall to increase the difficulty. The fists need to be equipped in order to use the climbing wall. 

### Lever

    A lever the player can pull to de-activate a turret. This is used for the player to us timing and tactics to de-activate the turret and move in the time the turret is de-activated. The player needs to equip fists in order to use the lever. 

## Enemies

### Enemy

The enemy has several animations; EnemyChase, EnemyHit, EnemyIdle, EnemyPatrol, EnemyThrow, and EnemyDeath. The animation Controller called Enemy is used to make the transitions from each animations in conjunction with the EnemyController. The EnemyThrow, EnemyDeath, EnemyHit animations have animation events so the event of the action is tied to the length of the animation. Also unlike the Player's animation controller has a state machine to determine which state the Enemy is in. This is to have a AI since the Player is not controlling the enemies.  

There are two types of Enemies; Shuriken and Chase. The Shuriken enemies, when in sight of the player, throw shurikens. The Chase Enemies, when is sight of the player, the enemy changes to chasing animation and move fast at the player. 

The variables used to vary the Enemies are; Patrol Speed, Chase Speed, Does Chase, Throw Interval, Turn Around Interval, Heath, Distance, Speed Of Shuriken. 

1. Patrol Speed: This is the speed of the enemy when it is move between the two patrol points.
2. Chase Speed: This is the speed of the enemy when the enemy is chasing the player.
3. Does Chase: A Boolean that determines whether the enemy chases or throws the shuriken at the player. 
4. Throw Interval: The interval between each of the shuriken throws.
5. Turn Around Interval: The interval for the enemy to turn around when the enemy reaches the patrol points.  
6. Health: The health of the enemy. The health determines how many rock the player need to throw at the enemy before the enemy dies. The hammer kills the enemy is one hit.
7: Distance: This is the distance the player has to be away for the enemy to see the player.
8: Speed of Shuriken: The speed of the shuriken when thrown.

### Turrets
There are two type of turrets; Tiny turret, Big Turret. The difference is the Tiny Turrets cannot should through the foreground and have tiny cannon balls. The Big Turrets cannon balls are bigger and can move through the foreground.

The variables used to vary the turrets are; Rate of Fire, Speed Turn, Projectile Hit Ground, Speed of Projectile, Accuracy.

1. Rate of Fire: The firing rat of the turret
2. Speed Turn: The speed the turret barrel turns to face player.
3. Projectile Hit Ground: Determines whether the cannon balls of the turret hit the foreground.
4. Speed of Projectile: The speed of the cannon ball of the turret.
5. Accuracy: The accuracy of the turret when aiming at the player.

## Projectiles

### Turret Cannon Ball
The cannon ball's speed is determined by a variable on the turret. The bullets can either go through the ground or hit the ground. This was to differentiate the Big and Small Turrets as well as provide variance in the challenges the player faces. The Big Turret has bigger cannon balls and the tiny turrets have smaller cannon balls. This also increases the difficulty since the bigger cannon balls have more area to hit the player. The speed of the cannon ball is determined by the cannon.

### Shuriken
The shurikens speed is determined by the enemy. The shuriken with move at the player. If the shuriken hits the player the player dies.

### Rock
The rock is effected by gravity. The player has to angle the throw so the rock can move toward the enemy. The rock does 1 damage / removes one health from the enemy. 

## Menus

### Main Menu
The main menu has to splash screen an a option to see the how to play screen as well as an option to quit the game.
### How to Play
The how to play screen just shows a screen for playing the game. Then there are button to go back to title screen, play game or quit game.
### Pause Menu
The pause menu can be accessed by pressing escape. The pause menu allows the player to display the how to play screen. Also, resuming the game and quitting the game.
### Complete Level Menu
The complete level menu shows whe the player reaches the last checkpoint of the level. 

## Sounds

## Levels

## Level 1

The first level is designed to introduce the ability for the player to use the hammer to knock the log over.

## Level 2

The second level is designed to introduce the ability for the player to use the lever as well as the different kinds of turret the player needs to move past. 

## Level 3

This level combines the different turrets along the lever. There are spikes and log obstacles to increase the difficulty as well.

## Level 4

This level is a further extension to the previous level with more turrets and and spikes.

## Level 5
## Level 6
## Level 7

This level is a introduces the two different enemies. There is the first obstacle a turret which the player already knows. Then introduces one shuriken enemy. Then the next obstacle is a chasing enemy. Then the player is meet with more turrets. Then another enemy. Then a log obstacle. Then reaching the fourth checkpoint the player has an option to choose two different paths. The paths that is lower should be harder and is a shortcut with a secret path at the end. The upper is easier but has more obstacles. The idea is to give player choice to the game and experiment with more complex layouts. 

## Level 8

This level tries to encompass majority of the obstacles in an interesting layout. There are three branching paths one is the semi secret root in the beginning right before the second checkpoint. The player can choose to go past the shuriken enemy. At the fourth checkpoint there is another branch. The lower root is harder which has more enemies. The upper root has spikes with turrets and climbing wall. The player has pull the lever to continue or if the player want to make thing harder they can opt not to pull the lever.

## Level 9

This level is a speed level where the object is to have the player move past the obstacles with high speed. There are a lot of turrets to give the player a sense of fear when going through the level.

## Final Level

## Bugs/Problems
* The climbing sometimes does not work properly. 
* The enemies animations as well as timing of death is off when you kill the enemy with a rock. 
* The animations for the player when throwing does not have feet movement.

## Future Works
* Fixing the movement of the enemy so the player cannot push the enemy as well as fix the timing of the animations.
* Make a better and easier climbing wall so the player does not have an glitches. Also have climbing wall change the players speed. 

