# 2DGame

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
### How to Play
### Pause Menu

## Sounds

## Levels

## Level 1
    The first level is designed to introduce the ability for the player to use the hammer to knock the log over.
## Level 2
    The second level is designed to introduce the ability for the player to use the lever as well as the different kinds of turret the player needs to move past. 
## Level 3
## Level 4
## Level 5
## Level 6
## Level 7
## Level 8
## Level 9
## Final Level

## Bugs/Problems

## Future Works
