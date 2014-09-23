GameAI_hw2
==========

pursue, evade, arrive, wander,  path follow


How each is used:
    Pursue is implemented through the Green Cube.  The script FollowPlayerScript contains the behaviour for pursue.
    Arrive is implemented though the Green Cube.   The script FollowPlayerScript contains the behaviour for arrive.
    Evade is implemented through the Red Cube.  The script EvadePlayerScript contains the behaviour for evade.
    Wander is implemented through the Red Cube.  The script EvadePlayerScript contains the behaviour for wander.
    Path Follow is implemented through the Purple Cube.  The script pathFollowScript contains the behaviour for path following.

General Summary:
    The player controls the cyan cube.
    The Green Cube pursues the player.
    When the Green Cube gets within range of the player the arrive behaviour is initiated and it decelerates.
    The Red Cube wanders, picking a random point and travelling to it until a new random point appears (shown by red spheres).
    When the Red Cube is in range of the player, the evade behaviour is initiated and the Red Cube accelerates away from the player.
    The Purple Cube follows a rectangular path around the playing field.

The story is as follows:
    Andy (of Toy Story) was getting older and his parents bought him a Rubicks Cube for Christmas.  This Rubicks Cube was soon cast aside by the greedy boy, and it broke into little pieces.  
    The individual cubes each had their own motivations and behaved differently.  The leader was the Cyan Cube and he/she was intent upon gathering the others.  Green Cube was a follower and pursued Cyan wherever it went.
    The Red cube on the other hand wanted independence and walked freely, except when Cyan got too close for comfort.  Then Red would run away from Cyan as fast as it could.
    Purple could not be swayed from the path it walked, as it went in circles around the others who scampered around aimlessly.
    
Scripts:

    playerMovementScript:
        controls the movement of the character. WASD and Xbox controller support.
        
    FollowPlayerScript:
        Changes GUI Text depending upon if the Green Cube is pursuing or arriving.
        Does a distance check to see if Green is pursuing or arriving.
        Sets the speed/acceleration of Green according to whether it is pursuing or arriving.
        Rotates Green so that it is looking at the player.
        
    EvadePlayerScript:
        Changes GUI Text depending upon if the Red Cube is wandering or evading.
        Does a distance check to see if Red is wandering or evading.
        If Red is close the player it triggers the evade behaviour.
        Evading means accelerating away from the player.
        If Red is not within the proximity of the player it wanders.
        Wandering means picking a point every X seconds and travelling towards that point.
        It creates a visual cue (red sphere) to show player where it is wandering to.
        Rotates Red so that it is facing the direction which it is moving towards.
        
    pathFollowScript:
        Gets next point along the rectangle.
        Moves toward the next point.
  
Notes:
    You can tell which direction that players are facing based upon their eyes, which look forward.
    Use WASD to move the player character.
    The circle around the player signifies the arrive distance as well as the maximum distance for evade to take effect.
    This circle will become visible for when the pursuer is within the vicinity.