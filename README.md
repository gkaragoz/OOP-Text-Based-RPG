#### OOP-Text-Based-RPG
I just create this repository because I just want to make practice of my OOP (Object-Oriented-Programming) skills. With that project, I'm going to make a native super simple RPG Text Based game using C# on Windows Form Application.

#### What are the classes/objects in our game? 
For our game, we want to do these things:

- The player goes to locations.
- The player may need to have certain items to enter a location.
- The location might have a quest available.
- To complete a quest, the player must collect certain items and turn them in.
- The player can collect items by going to a location and fighting monsters there.
- The player fights monsters with weapons.
- The player can use a healing potion while fighting.
- The player receives loot items after defeating a monster.
- After turning in the quest, the player receives reward items.

So, the nouns (classes/objects) in this game will be Player, Location, Item, Quest, Monster,
Weapon and Healing Potion. We'll need a few others, but we can start with these.

#### Version 1.0 released.

#### What's next?
This is a very simple RPG, and there is a lot you can do to expand it.

Here are a few ideas:
-	Save the player's current game to disk, and re-load it later
-	As the player gains experience, increase their level
	-	Increase MaximumHitPoints with each new level
	-	Add a minimum level requirement for some items
	-	Add a minimum level requirement for some locations
-	Add randomization to battles
	-	Determine if the player hits the monster
	-	Determine if the monster hits the player
-	Add player attributes (strength, dexterity, etc.)
	-	Use attributes in battle: who attacks first, amount of damage, etc.
-	Add armor and jewelry
	-	Makes it more difficult for the monster to hit the player
	-	Has special benefits: increased chance to hit, increased damage, etc.
-	Add crafting skills the player can acquire
-	Add crafting recipes the player use
	-	Require the appropriate skill
	-	Requires components (inventory items)
-	Make some quests repeatable
-	Make quest chains (player must complete Quest A before they can receive Quest B)
-	Add magic scrolls
-	Add spells
	-	Level requirements for the spells
	-	Spells require components to cast (maybe?)
-	Add more potions
	-	More powerful healing potions
	-	Potions to improve player's to hit chances, or damage
-	Add poisons to use in battle
-	Add pets
	-	Help the player in battle by attacking opponents
	-	Help the player in battle by healing the player
-	Add stores/vendors
	-	Player can sell useless items and buy new equipment, scrolls, potions, poisons,
and crafting/spell components

There are also more programming techniques you can learn to make the program a little
cleaner.
-	LINQ, when searching lists
-	Events/delegates, to handle communication between the logic project and the UI
project – which will let you move more logic code out of the UI project
-	BindingList, so you don't have to repeatedly repopulate the DataGridViews and ComboBox
in the UI

#### What will the game look like?
![alt tag](https://s30.postimg.org/um0v4fkn5/Game_screenshot.png)
