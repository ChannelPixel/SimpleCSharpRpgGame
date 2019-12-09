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

namespace SimpleCSharpRpgGame
{
    public partial class SimpleRpgFormGame : Form
    {
        private Player _player;
        private Monster _currentMonster;

        public SimpleRpgFormGame()
        {
            InitializeComponent();

            Location location = new Location(1, "Home", "This is your house");

            _player = new Player(10, 10, 20 , 0, 1);

            lbl_HitPoints.Text = _player.CurrentHitPoints.ToString();
            lbl_Gold.Text = _player.Gold.ToString();
            lbl_Experience.Text = _player.ExperiencePoints.ToString();
            lbl_Level.Text = _player.Level.ToString();
        }

        private void MoveTo(Location newLocation)
        {
            if(newLocation.ItemRequiredToEnter != null)
            {
                bool playerHasRequiredItem = false;

                foreach(InventoryItem ii in _player.Inventory)
                {
                    if(ii.Details.ID == newLocation.ItemRequiredToEnter.ID)
                    {
                        playerHasRequiredItem = true;
                        break;
                    }
                }

                if(!playerHasRequiredItem)
                {
                    rtb_Messages.Text += "You must have a " +
                        newLocation.ItemRequiredToEnter.Name +
                        " to enter this location" + Environment.NewLine;
                    return;
                }

                _player.CurrentLocation = newLocation;

                btn_North.Visible = (newLocation.LocationToNorth != null);
                btn_East.Visible = (newLocation.LocationToEast != null);
                btn_South.Visible = (newLocation.LocationToSouth != null);
                btn_West.Visible = (newLocation.LocationToWest != null);

                rtb_Location.Text = newLocation.Name + Environment.NewLine;
                rtb_Location.Text += newLocation.Description + Environment.NewLine;

                _player.CurrentHitPoints = _player.MaximumHitPoints;

                lbl_HitPoints.Text = _player.CurrentHitPoints.ToString();

                if(newLocation.QuestAvailableHere != null)
                {
                    bool playerAlreadyHasQuest = false;
                    bool playerAlreadyCompletedQuest = false;

                    foreach(PlayerQuest playerQuest in _player.Quests)
                    {
                        playerAlreadyHasQuest = true;

                        if(playerQuest.IsCompleted)
                        {
                            playerAlreadyCompletedQuest = true;
                        }
                    }

                    if(playerAlreadyHasQuest)
                    {
                        if(!playerAlreadyCompletedQuest)
                        {
                            bool playerHasAllItemsToCompleteQuest = true;

                            foreach(QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                            {
                                bool foundItemInPlayersInventory = false;

                                foreach(InventoryItem ii in _player.Inventory)
                                {
                                    if(ii.Details.ID == qci.Details.ID)
                                    {
                                        foundItemInPlayersInventory = true;

                                        if(ii.Quantity < qci.Quantity)
                                        {
                                            playerHasAllItemsToCompleteQuest = false;

                                            break;
                                        }

                                        break;
                                    }

                                    if(!foundItemInPlayersInventory)
                                    {
                                        playerHasAllItemsToCompleteQuest = false;

                                        break;
                                    }
                                }
                            }

                            if(playerHasAllItemsToCompleteQuest)
                            {
                                rtb_Messages.Text += Environment.NewLine;
                                rtb_Messages.Text += "You complete the " +
                                    newLocation.QuestAvailableHere.Name +
                                    " quest." + Environment.NewLine;

                                foreach(QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                                {
                                    foreach(InventoryItem ii in _player.Inventory)
                                    {
                                        if(ii.Details.ID == qci.Details.ID)
                                        {
                                            ii.Quantity -= qci.Quantity;
                                            break;
                                        }
                                    }
                                }

                                rtb_Messages.Text += "You receive: " + Environment.NewLine;
                                rtb_Messages.Text +=
                                    newLocation.QuestAvailableHere.RewardExperiencePoints.ToString() + " experience points" + Environment.NewLine;
                                rtb_Messages.Text +=
                                    newLocation.QuestAvailableHere.RewardGold.ToString() + " gold" + Environment.NewLine;
                                rtb_Messages.Text +=
                                    newLocation.QuestAvailableHere.RewardItem.Name.ToString() + Environment.NewLine;

                                _player.ExperiencePoints += newLocation.QuestAvailableHere.RewardExperiencePoints;
                                _player.Gold += newLocation.QuestAvailableHere.RewardGold;

                                bool addedItemToPlayerInventory = false;

                                foreach(InventoryItem ii in _player.Inventory)
                                {
                                    if(ii.Details.ID == newLocation.QuestAvailableHere.RewardItem.ID)
                                    {
                                        ii.Quantity++;

                                        addedItemToPlayerInventory = true;

                                        break;
                                    }
                                }

                                if(!addedItemToPlayerInventory)
                                {
                                    _player.Inventory.Add(new InventoryItem(newLocation.QuestAvailableHere.RewardItem, 1));
                                }

                                foreach(PlayerQuest pq in _player.Quests)
                                {
                                    if (pq.Details.ID == newLocation.QuestAvailableHere.ID)
                                    {
                                        pq.IsCompleted = true;

                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        rtb_Messages.Text += "You receive the " +
                            newLocation.QuestAvailableHere.Name +
                            " quest." + Environment.NewLine;
                        rtb_Messages.Text += newLocation.QuestAvailableHere.Description +
                            Environment.NewLine;
                        rtb_Messages.Text += "To complete it, return with:" +
                            Environment.NewLine;

                        foreach(QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                        {
                            if(qci.Quantity == 1)
                            {
                                rtb_Messages.Text += qci.Quantity.ToString() + " " +
                                    qci.Details.Name + Environment.NewLine;
                            }
                            else
                            {
                                rtb_Messages.Text += qci.Quantity.ToString() + " " +
                                    qci.Details.NamePlural + Environment.NewLine;
                            }
                        }
                        rtb_Messages.Text += Environment.NewLine;

                        _player.Quests.Add(new PlayerQuest(newLocation.QuestAvailableHere));

                    }
                }

                if(newLocation.MonsterLivingHere != null)
                {
                    rtb_Messages.Text += "You see a "
                        + newLocation.MonsterLivingHere.Name + Environment.NewLine;

                    Monster standardMonster = World.MonsterByID(
                        newLocation.MonsterLivingHere.ID);

                    _currentMonster = new Monster(standardMonster.ID, standardMonster.Name, standardMonster.MaximumDamage,
                        standardMonster.RewardExperiencePoints, standardMonster.RewardGold, standardMonster.CurrentHitPoints,
                        standardMonster.MaximumHitPoints);

                    foreach(LootItem lootItem in standardMonster.LootTable)
                    {
                        _currentMonster.LootTable.Add(lootItem);
                    }

                    cbo_Weapons.Visible = true;
                    cbo_Potions.Visible = true;
                    btn_UseWeapon.Visible = true;
                    btn_UseWeapon.Visible = true;
                }
                else
                {
                    _currentMonster = null;
                    cbo_Weapons.Visible = false;
                    cbo_Potions.Visible = false;
                    btn_UseWeapon.Visible = false;
                    btn_UseWeapon.Visible = false;
                }

                dgv_Inventory.RowHeadersVisible = false;
                dgv_Inventory.ColumnCount = 2;
                dgv_Inventory.Columns[0].Name = "Name";
                dgv_Inventory.Columns[0].Width = 197;
                dgv_Inventory.Columns[1].Name = "Quantity";
                dgv_Inventory.Rows.Clear();
                foreach(InventoryItem inventoryItem in _player.Inventory)
                {
                    if(inventoryItem.Quantity > 0)
                    {
                        dgv_Inventory.Rows.Add(new[] { inventoryItem.Details.Name,
                            inventoryItem.Quantity.ToString()});
                    }
                }

                dgv_Quests.RowHeadersVisible = false;
                dgv_Quests.ColumnCount = 2;
                dgv_Quests.Columns[0].Name = "Name";
                dgv_Quests.Columns[0].Width = 197;
                dgv_Quests.Columns[1].Name = "Done?";
                dgv_Quests.Rows.Clear();
                foreach(PlayerQuest playerQuest in _player.Quests)
                {
                    dgv_Quests.Rows.Add(new[] { playerQuest.Details.Name,
                        playerQuest.IsCompleted.ToString()});
                }

                List<Weapon> weapons = new List<Weapon>();
                foreach(InventoryItem inventoryItem in _player.Inventory)
                {
                    if(inventoryItem.Details is Weapon)
                    {
                        if(inventoryItem.Quantity > 0)
                        {
                            weapons.Add((Weapon)inventoryItem.Details);
                        }
                    }
                }

                if(weapons.Count == 0)
                {
                    cbo_Weapons.Visible = false;
                    btn_UsePotion.Visible = false;
                }
                else
                {
                    cbo_Weapons.DataSource = weapons;
                    cbo_Weapons.DisplayMember = "Name";
                    cbo_Weapons.ValueMember = "ID";

                    cbo_Weapons.SelectedIndex = 0;
                }

                List<HealingPotion> healingPotions = new List<HealingPotion>();

                foreach(InventoryItem inventoryItem in _player.Inventory)
                {
                    if(inventoryItem.Details is HealingPotion)
                    {
                        if(inventoryItem.Quantity > 0)
                        {
                            healingPotions.Add((HealingPotion)inventoryItem.Details);
                        }
                    }
                }

                if(healingPotions.Count == 0)
                {
                    cbo_Potions.Visible = false;
                    btn_UsePotion.Visible = false;
                }
                else
                {
                    cbo_Potions.DataSource = healingPotions;
                    cbo_Potions.DisplayMember = "Name";
                    cbo_Potions.ValueMember = "ID";
                    cbo_Potions.SelectedIndex = 0;
                }
            }

        }

        private void btn_North_Click(object sender, EventArgs e)
        {

        }

        private void btn_West_Click(object sender, EventArgs e)
        {

        }

        private void btn_East_Click(object sender, EventArgs e)
        {

        }

        private void btn_South_Click(object sender, EventArgs e)
        {

        }

        private void btn_UseWeapon_Click(object sender, EventArgs e)
        {

        }

        private void btn_UsePotion_Click(object sender, EventArgs e)
        {

        }
    }
}
