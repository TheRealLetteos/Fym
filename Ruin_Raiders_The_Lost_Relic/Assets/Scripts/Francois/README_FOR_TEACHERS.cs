/* 
 * 
 * I know, using a script as a readme!! When you are too lazy to open notepad++
 * -François
 * 
 * =================GENERAL===============
     * 
     * The level editor is a WYSIWYG (what you see is what you get). Right now, only one tileset is present (and some tiles are wrong, we'll get to that later, as we 
     * wish to implement more than one tileset).
     * 
     * Click on a tile, then click where to place it. Tiles overwrite what is already there.
     * 
     * 
     *
 * 
 * =================COMMAND PATTERN========
 * 
     * Our first required patterns *cough*.
     * 
     * Use 'A' to undo and 'S' to redo. Adding a new action eliminates any potential futures "redo", if any. We are first used ctrl+z and ctrl+y but
     * this conflicted with Unity's systems (and led to many lost changes!!) * 
     * 
     * We at first allowed "painting" tiles by clicking and dragging the mouse,
     * but it created problems with our command pattern. We'd have to "batch" commands to they can be undone as follows:
     * 
     *  CLICK DOWN - start recording actions
     *  **paint tiles** all recorded in the "CommandBatch"
     *  CLICK UP - stop recording actions, and add them to the stack
     *  
     *  This creates other problems we will not elaborate on here. We might still implement this version (CommandBatches instead of Commands) in future version.
     *  
 *  
 *  
 *  
 *  ==============SAVING=====================
 *  
     *  Enter a path where Unity is allowed to modify files (NOT c:\). End your query with the level's name, i.e. C:\mydocuments\unity\level1.
     *  
     *  Using the .dat extension is not mandatory.
     *  
     *  Click save
     *  Please note the system will overwrite the file if it already exists.
     *  
     *  You can load the file with the "load" button with the same procedure.
     *  
 *  
 *  
 *  
 *  ================TILES AND SPRITES==========
 *  
     *  Currently, all tiles are added to the same tile palette. We use three palettes for our game:
     *  
     *  1) Background 
     *  2) Ground
     *  3) Foreground (some of them animated)
     *   
     *  These palettes are rendered in order. None of them move.
     *  
     *  In addition, sprites help populate the game. Sprites are used for players, enemies, collectibles, rocks, pressure plates, doors, etc.) 
     *  
     *  We are still working on the physics and dynamics of how levels are made. In the final version of our products, players will be able to add
     *  elements belonging to the three palettes (starting with background, then ground, then foreground such as decoration) and then add corresponding sprites,
     *  such as the player.
     *  
     *  Right now, player's locations, door and other dynamic elements need to be added manually after the level is saved using Unity's editor.
     *  
     *  
     *  
 *  
 *  =============OTHER NOTES============
 *  
     *  We currently save our files using a Binary Encoder. If times allows, we will move to a .json system, which will allow a better way to save and edit the level.
     *  
     *  
     *  
 *  
 *  ===============EXPORTING==========
 *  
     *  A level can easily be saved and then sent to another person so he can work on it.
 */