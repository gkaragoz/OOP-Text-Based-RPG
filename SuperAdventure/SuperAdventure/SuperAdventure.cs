using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Engine;

namespace SuperAdventure
{
    public partial class SuperAdventure : Form
    {
        private Player _player;
        private Monster _currentMonster;

        public SuperAdventure()
        {
            InitializeComponent();

            _player = new Player(10, 10, 20, 0, 1);
            MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            _player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_RUSTY_SWORD), 1));

            lblHitPoints.Text = _player.CurrentHitPoints.ToString();
            lblGold.Text = _player.Gold.ToString();
            lblExperience.Text = _player.ExperiencePoints.ToString();
            lblLevel.Text = _player.Level.ToString();
        }

        private void btnUseWeapon_Click(object sender, EventArgs e)
        {

        }

        private void btnUsePotion_Click(object sender, EventArgs e)
        {

        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToNorth);
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToEast);
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToSouth);
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToWest);
        }

        private void MoveTo(Location newLocation)
        {
            ////////////////////////////////////////////////////////
            ///////////WE WILL SEPERATE THEM TO METHODS/////////////
            ////////////////////////////////////////////////////////

            //Does the location have any required items
            if (newLocation.ItemRequiredToEnter != null)
            {
                //See if the player has the required item in their inventory
                bool playerHasRequiredItem = false;

                foreach (InventoryItem item in _player.Inventory)
                {
                    if (item.Details.ID == newLocation.ItemRequiredToEnter.ID)
                    {
                        //We found the required item
                        playerHasRequiredItem = true;
                        break; //Exit out of the foreach loop
                    }
                }

                if (!playerHasRequiredItem)
                {
                    //We didn't find the required item in their inventory, so display a message and stop trying to move
                    rtbMessages.Text += "You must have a " + newLocation.ItemRequiredToEnter.Name + " to enter this location." + Environment.NewLine;
                    return;
                }
            }

            //Update the player's current location
            _player.CurrentLocation = newLocation;

            //Show/hide available movement buttons
            btnNorth.Visible = (newLocation.LocationToNorth != null);
            btnEast.Visible = (newLocation.LocationToEast != null);
            btnSouth.Visible = (newLocation.LocationToSouth != null);
            btnWest.Visible = (newLocation.LocationToWest != null);

            //Display current location name and description
            rtbLocation.Text = newLocation.Name + Environment.NewLine;
            rtbLocation.Text += newLocation.Description + Environment.NewLine;

            //Completely heal the player
            _player.CurrentHitPoints = _player.MaximumHitPoints;

            //Update hit points in UI
            lblHitPoints.Text = _player.CurrentHitPoints.ToString();

            //Does the location have a quest?
            if (newLocation.QuestAvailableHere != null)
            {
                //See if the player already has the quest, and if they've completed it
                bool playerAlreadyHasQuest = false;
                bool playerAlreadyCompletedQuest = false;

                foreach (PlayerQuest playerQuest in _player.Quests)
                {
                    if (playerQuest.Details.ID == newLocation.QuestAvailableHere.ID)
                    {
                        playerAlreadyHasQuest = true;

                        if (playerQuest.IsCompleted)
                        {
                            playerAlreadyCompletedQuest = true;
                        }
                    }
                }

                //See if the player already has the quest
                if (playerAlreadyHasQuest)
                {
                    //If the player has not completed the quest yet
                    if (!playerAlreadyCompletedQuest)
                    {
                        //See if the player has all the items needed to complete the quest
                        bool playerHasAllItemsToCompleteQuest = true;

                        foreach (QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                        {
                            bool foundItemInPlayersInventory = false;

                            //Check each item in the player's inventory, to see if they have it, and enough of it
                            foreach (InventoryItem item in _player.Inventory)
                            {
                                //The player has this item in their inventory
                                if (item.Details.ID == qci.Details.ID)
                                {
                                    foundItemInPlayersInventory = true;

                                    if (item.Quantity < qci.Quantity)
                                    {
                                        //The player does not have enough of this item to complete the quest
                                        playerHasAllItemsToCompleteQuest = false;

                                        //There is no reason to continue checking for the other quest completion items
                                        break;
                                    }

                                    //We found the item, so don't check the rest of the player's inventory
                                    break;
                                }
                            }
                        }

                        //The player has all items required to complete the quest
                        if (playerHasAllItemsToCompleteQuest)
                        {
                            //Display message
                            rtbMessages.Text += Environment.NewLine;
                            rtbMessages.Text += "You complete the " + newLocation.QuestAvailableHere.Name + " quest." + Environment.NewLine;

                            //Remove quest items from inventory
                            foreach (QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                            {
                                foreach (InventoryItem item in _player.Inventory)
                                {
                                    if (item.Details.ID == qci.Details.ID)
                                    {
                                        //Subtract the quantity from the player's inventory that was needed to complete the quest.
                                        item.Quantity -= qci.Quantity;
                                        break;
                                    }
                                }
                            }

                            //Give the quest rewards
                            rtbMessages.Text += "You receive: " + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardExperiencePoints.ToString() +
                                " experience points" + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardGold.ToString() +
                                " gold" + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardItem.Name + Environment.NewLine;
                            rtbMessages.Text += Environment.NewLine;

                            _player.ExperiencePoints += newLocation.QuestAvailableHere.RewardExperiencePoints;
                            _player.Gold += newLocation.QuestAvailableHere.RewardGold;

                            //Add the reward item to the player's inventory
                            bool addedItemToPlayerInventory = false;

                            foreach (InventoryItem item in _player.Inventory)
                            {
                                if (item.Details.ID == newLocation.QuestAvailableHere.RewardItem.ID)
                                {
                                    //They have the item in their inventory, so increase the quantity by one
                                    item.Quantity++;

                                    addedItemToPlayerInventory = true;

                                    break;
                                }
                            }

                            //They didn't have the item, so add it to their inventory, with a quantity of 1
                            if (!addedItemToPlayerInventory)
                            {
                                _player.Inventory.Add(new InventoryItem(newLocation.QuestAvailableHere.RewardItem, 1));
                            }

                            //Mark the quest as completed
                            //Find the quest in the player's quest list
                            foreach (PlayerQuest pq in _player.Quests)
                            {
                                if (pq.Details.ID == newLocation.QuestAvailableHere.ID)
                                {
                                    //Mark it as completed
                                    pq.IsCompleted = true;

                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    //The player does not already have the quest

                    //Display the messages
                    rtbMessages.Text += "You receive the " + newLocation.QuestAvailableHere.Name + " quest." + Environment.NewLine;
                    rtbMessages.Text += newLocation.QuestAvailableHere.Description + Environment.NewLine;
                    rtbMessages.Text += "To complete it, return with:" + Environment.NewLine;

                    foreach (QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                    {
                        if (qci.Quantity == 1)
                        {
                            rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.Name + Environment.NewLine;
                        }
                        else
                        {
                            rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.NamePlural + Environment.NewLine;
                        }
                    }
                    rtbMessages.Text += Environment.NewLine;

                    //Add the quest to the player's quest list
                    _player.Quests.Add(new PlayerQuest(newLocation.QuestAvailableHere));
                }
            }
            //Does the location have a monster?
            if (newLocation.MonsterLivingHere != null)
            {
                rtbMessages.Text += "You see a " + newLocation.MonsterLivingHere.Name + Environment.NewLine;

                //Make a new monster, using the values from the standard monster in the World.Monster list
                Monster standardMonster = World.MonsterByID(newLocation.MonsterLivingHere.ID);

                _currentMonster = new Monster(standardMonster.ID, standardMonster.Name,
                    standardMonster.MaximumDamage, standardMonster.RewardExperiencePoints,
                        standardMonster.RewardGold, standardMonster.CurrentHitPoints,
                            standardMonster.MaximumHitPoints);

                foreach (LootItem lootItem in standardMonster.LootTable)
                {
                    _currentMonster.LootTable.Add(lootItem);
                }

                cboWeapons.Visible = true;
                cboPotions.Visible = true;
                btnUseWeapon.Visible = true;
                btnUsePotion.Visible = true;
            }
            else
            {
                _currentMonster = null;

                cboWeapons.Visible = false;
                cboPotions.Visible = false;
                btnUseWeapon.Visible = false;
                btnUsePotion.Visible = false;
            }

            //Refresh player's inventory list
            dgvInventory.RowHeadersVisible = false;

            dgvInventory.ColumnCount = 2;
            dgvInventory.Columns[0].Name = "Name";
            dgvInventory.Columns[0].Width = 197;
            dgvInventory.Columns[1].Name = "Quantity";

            dgvInventory.Rows.Clear();

            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Quantity > 0)
                {
                    dgvInventory.Rows.Add(new[] 
                    {
                        inventoryItem.Details.Name,
                        inventoryItem.Quantity.ToString()
                    });
                }
            }

            //Refresh player's quest list
            dgvQuests.RowHeadersVisible = false;

            dgvQuests.ColumnCount = 2;
            dgvQuests.Columns[0].Name = "Name";
            dgvQuests.Columns[0].Width = 197;
            dgvQuests.Columns[1].Name = "Done?";

            dgvQuests.Rows.Clear();

            foreach (PlayerQuest playerQuest in _player.Quests)
            {
                dgvQuests.Rows.Add(new[]
                {
                    playerQuest.Details.Name,
                    playerQuest.IsCompleted.ToString()
                });
            }

            // Refresh player's weapons combobox
            List<Weapon> weapons = new List<Weapon>();

            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Details is Weapon)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        weapons.Add((Weapon)inventoryItem.Details);
                    }
                }
            }

            if (weapons.Count == 0)
            {
                // The player doesn't have any weapons, so hide the weapon combobox and the "Use" button
                cboWeapons.Visible = false;
                btnUseWeapon.Visible = false;
            }
            else
            {
                cboWeapons.DataSource = weapons;
                cboWeapons.DisplayMember = "Name";
                cboWeapons.ValueMember = "ID";
                
                cboWeapons.SelectedIndex = 0;
            }

            // Refresh player's potions combobox
            List<HealingPotion> healingPotions = new List<HealingPotion>();

            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Details is HealingPotion)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        healingPotions.Add((HealingPotion)inventoryItem.Details);
                    }
                }
            }

            if (healingPotions.Count == 0)
            {
                // The player doesn't have any potions, so hide the potion combobox and the "Use" button
                cboPotions.Visible = false;
                btnUsePotion.Visible = false;
            }
            else
            {
                cboPotions.DataSource = healingPotions;
                cboPotions.DisplayMember = "Name";
                cboPotions.ValueMember = "ID";
                
                cboPotions.SelectedIndex = 0;
            }
        }
    }
}
