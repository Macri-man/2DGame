# The Run of The MADMAN

## Items

There are three items the player can equip; a hammer, rock, or fist. The Rock is used to attack the enemies and stop shurikens from hitting the player. The hammer can be used to kill an enemy. The fist can be used to pull a lever or climb a climbing wall.

## Player

The player has several animations: PlayerIdle, PlayerWalk, PlayerClimb, PlayerDeath, PlayerHammer, PlayerThrow, and PlayerPullLever. The animation Controller called Player is used to make the transitions between animations in conjuction with the PlayerCharacterController Script. The PlayerPullLever, PlayerHammer, PlayerThrow, PlayerDeath animations have animation events so the event of the action is tied to the length of the animation. This was to make a visual indication of the player actions corresponding to the action. 

The variables that are adjusted are the throwforce, and forcejump which determine the force the rock is thrown and the height of the player's jump respectively. 

## Interactable Objects

### Log

The Log is uses to go over chasms or over spikes. The player uses an item in order to knock the log over. The hammer is used to accomplish this. 

### Climbing Wall

Any wall with a yellowish color can be climbed. These walls are used in conjunction with spikes so the player need to jump to and then climb the wall to increase the difficulty. The fists need to be equipped in order to use the climbing walls. 

### Lever

A lever the player can pull to de-activate a turret. This is used for the player to use timing and tactics to de-activate the turret and move during the time that the turret is de-activated. The player needs to equip fists in order to use the lever. The lever has to be paired with one Turret. The lever has a variable called interval that changes the time the turret is disabled.

## Enemies

### Enemy

The enemy has several animations: EnemyChase, EnemyHit, EnemyIdle, EnemyPatrol, EnemyThrow, and EnemyDeath. The animation Controller called Enemy is used to make the transitions between animations in conjunction with the EnemyController. The EnemyThrow, EnemyDeath, EnemyHit animations have animation events so the event of the action is tied to the length of the animation. Also unlike the Player's animation controller has a state machine to determine which state the Enemy is in. This is to have a AI since the Player is not controlling the enemies.  

There are two types of Enemies: Shuriken and Chase. The Shuriken enemies, when in sight of the player, throw shurikens. For the Chase Enemies, when is sight of the player, the enemy changes to chasing animation and charges toward the player. 

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
There are two type of turrets; Tiny turret, Big Turret. The difference is the Tiny Turrets cannot shoot through the foreground and have tiny cannon balls. The Big Turrets cannon balls are bigger and their shots can move through the foreground.

The variables used to vary the turrets are; Rate of Fire, Speed Turn, Projectile Hit Ground, Speed of Projectile, Accuracy.

1. Rate of Fire: The firing rates of the turret
2. Speed Turn: The speed the turret barrel turns to face player.
3. Projectile Hit Ground: Determines whether the cannon balls of the turret hit the foreground.
4. Speed of Projectile: The speed of the cannon ball of the turret.
5. Accuracy: The accuracy of the turret when aiming at the player.

## Projectiles

### Turret Cannon Ball
The cannon ball's speed is determined by a variable on the turret. The bullets can either go through the ground or hit the ground. This was to differentiate the Big and Small Turrets as well as provide variance in the challenges the player faces. The Big Turret has bigger cannon balls and the tiny turrets have smaller cannon balls. This also increases the difficulty since the bigger cannon balls have more area to hit the player. The speed of the cannon ball is determined by the cannon.

### Shuriken
The shurikens speed is determined by the enemy. The shurikens are not affected by gravity as they move toward the player. If a shuriken hits the player the player dies.

### Rock
The rock is affected by gravity. The player has to angle the throw so the rock can move toward the enemy. The rock does 1 damage / removes one health from the enemy. 

## How to Play
The how to play screen just shows a screen for playing the game with illustration to show what the buttons are doing. Then there are buttons to go back to the title screen, play game or quit game. There is also a button in the pause menu during play that gives access to the how to play screen.

## Sounds
There isn't any moving sound but there are sound for each action the player makes as well as the action of each of the turrets and enemies. This is because to many sounds going off at once with the background music and footstep can lead to confusion but sounds to action cause the player to pay attention and use these sounds to help them complete the levels.  

## Levels
The are several aspects in levels. There are spike pits before a climbing wall with enemies that the player can coerce into falling or moving into the spikes. The player can sneak up on enemies by waiting for them to move so the player can hit them from behind. There are several different configurations of turrets that can shoot through the foreground and turrets that cannot shoot through the foreground. There are also enemies paired with turrets. This variance is to give the player a challenge and think about overcoming the obstacles by using previous encounters with similar obstacles. 

## Level 1

The first level is designed to introduce the ability for the player to use the hammer to knock the log over.

## Level 2

The second level is designed to introduce the ability for the player to use the lever as well as the different kinds of turret the player needs to move past. 

## Level 3

This level combines the different turrets along the lever. There are spikes and log obstacles to increase the difficulty as well.

## Level 4

This level is a further extension to the previous level with more turrets and and spikes.

## Level 5
This level is more fast-paced with the player at an increased speed to allow the player a more intense experience with the obstacles being more turrets. Also, the climbing wall in introduced in the beginning where the player has to select the fist before climbing. 

## Level 6
This level is a continuation of level 5 with more climbing and more turret obstacles. 

## Level 7

This level introduces the two different enemies. There is a first obstacle that the player is already familiar with, the turrets. The next obstacle is one shuriken-throwing enemy. After the shuriken enemy there is a chasing enemy. This is to gradually introduce new opponents to the player. When the player reaches the fourth checkpoint, they have an option to choose two different paths. The path that is lower should be harder and there is a shortcut with a secret path at the end to get to the finish. The upper path is easier but has more obstacles. The idea is to give player choice to the game and experiment with more complex layouts. 

## Level 8

This level is a continuation of level 8. There are multiple enemies and turrets. The configuration was to provide difficulty but variance in each consecutive challenge. This level tries to encompass the majority of the obstacles in an interesting layout. There are three branching paths: one is the semi-secret route in the beginning right before the second checkpoint. The player can choose to go past the shuriken enemy. At the fourth checkpoint there is another branch. The lower route is harder and has more enemies. The upper route has spikes with turrets and climbing wall. On the lower route the player has an option again to go left or right to complete the level.

## Level 9

This level is a speed level where the objective is to have the player move past the obstacles with high speed. There are a lot of turrets to give the player a sense of fear when going through the level. At the end there are two pull levers to get some sort of challenge for the player to think, not just dodge bullets. There is an enemy right near the checkpoint. The idea is to use rocks or sneak up and use the hammer to kill the enemy before continuing.

## Final Level

The final level is less intense but has majority of the obstacles. There is a shortcut that is hard to get to and encourages the player to explore the environment. Also, there are a couple of Big Turrets that in previous level do not hit the foreground but in this level they do. This is to create a hesitation as well as to make a challenge based on the players observance of the turrets and assumptions. 

## Bugs/Problems
* The climbing sometimes does not work properly. 
* The enemies' animations as well as timing of death is off when you kill the enemy with a rock. 
* The animations for the player when throwing does not have feet movement.
* The enemies not turning around when you push them.
* Enemies sometime get caught on the walls.
* The player can get stuck on the wall and environment, but it is typically easy to break free and resume play.

## Future Works
* Fixing the movement of the enemy so the player cannot push the enemy as well as fix the timing of the animations.
* Make a better and easier climbing wall so the player does not have an glitches. Also have climbing wall change the players speed.
* Add the Story to the game.

