Features:

- Movement System: 
    1. Rolling - instead of usual sideways movement your character rolls (it's a circle) by applying torque. When you are changing directions, the rolling is being stopped and reversed to keep everything smooth;
    ![rolling](.../Gifs/Features/rolling.gif)
    2. Jumping works by checking whether at least 1 of 2 legs is on the ground and then applying relative up impulse force after pressing the spacebar;
    ![jumping](.../Gifs/Features/jumping.gif)
    3. Sticking - when the bottom of the main character is less than 1 meter to the ground, a force in that direction is being applied to make the main character 
- Enemy System:
    1. Mosqitoes - they passively fly in a circle for a few seconds before moving in the direction of the player while making circles mimicing flying;
    ![mosqitoe](.../Gifs/Features/mosqitoe.gif)
    2. Catching - when the player touches a mosqitoe while they are in flight (player), the mosqitoe is being disabled and the score inscreased;
    ![catching](.../Gifs/Features/catching.gif)
    3. Losing - when the mosqitoe touches a player when they are grounded, they lose the game;
    ![losing](.../Gifs/Features/losing.gif)
    4. Spawning - enemy manager spawns increasing waves of mosqitoes every time the player catches all the mosqitoes, with a pause before the spawning;
    ![spawning](.../Gifs/Features/spawning.gif)