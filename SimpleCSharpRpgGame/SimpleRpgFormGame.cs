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
using System.IO;

namespace SimpleCSharpRpgGame
{
    public partial class SimpleRpgFormGame : Form
    {
        private Player _player;
        private Monster _currentMonster;
        private const string PLAYER_DATA_FILE_NAME = "PlayerData.xml";

        public SimpleRpgFormGame()
        {
            InitializeComponent();

            if(File.Exists(PLAYER_DATA_FILE_NAME))
            {
                _player = Player.CreatePlayerFromXmlString(
                    File.ReadAllText(PLAYER_DATA_FILE_NAME));
            }
            else
            {
                _player = Player.CreateDefaultPlayer();
            }

            MoveTo(World.LocationByID(_player.CurrentLocation.ID));

            UpdatePlayerStats();
            UpdateInventoryListInUI();
            UpdatePotionListInUI();
            UpdateQuestListInUI();
            UpdateWeaponListInUI();
        }

        private void UpdateInventoryListInUI()
        {
            dgv_Inventory.RowHeadersVisible = false;
            dgv_Inventory.ColumnCount = 2;
            dgv_Inventory.Columns[0].Name = "Name";
            dgv_Inventory.Columns[0].Width = 197;
            dgv_Inventory.Columns[1].Name = "Quantity";
            dgv_Inventory.Rows.Clear();
            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Quantity > 0)
                {
                    dgv_Inventory.Rows.Add(new[] { 
                        inventoryItem.Details.Name,
                        inventoryItem.Quantity.ToString() });
                }
            }
        }

        private void UpdateQuestListInUI()
        {
            dgv_Quests.RowHeadersVisible = false;
            dgv_Quests.ColumnCount = 2;
            dgv_Quests.Columns[0].Name = "Name";
            dgv_Quests.Columns[0].Width = 197;
            dgv_Quests.Columns[1].Name = "Done?";
            dgv_Quests.Rows.Clear();
            foreach (PlayerQuest playerQuest in _player.Quests)
            {
                dgv_Quests.Rows.Add(new[] {
                    playerQuest.Details.Name,
                    playerQuest.IsCompleted.ToString() });
            }
        }

        private void UpdateWeaponListInUI()
        {
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
                cbo_Weapons.Visible = false;
                btn_UseWeapon.Visible = false;
            }
            else
            {
                cbo_Weapons.DataSource = weapons;
                cbo_Weapons.DisplayMember = "Name";
                cbo_Weapons.ValueMember = "ID";
                cbo_Weapons.SelectedIndex = 0;
            }
        }

        private void UpdatePotionListInUI()
        {
            List<HealingPotion> healingPotions = new List<HealingPotion>();
            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Details is HealingPotion)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        healingPotions.Add(
                        (HealingPotion)inventoryItem.Details);
                    }
                }
            }
            if (healingPotions.Count == 0)
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

        private void ScrollToBottomOfMessages()
        {
            rtb_Messages.SelectionStart = rtb_Messages.Text.Length;
            rtb_Messages.ScrollToCaret();
        }

        private void UpdatePlayerStats()
        {
            lbl_HitPoints.Text = _player.CurrentHitPoints.ToString();
            lbl_Gold.Text = _player.Gold.ToString();
            lbl_Experience.Text = _player.ExperiencePoints.ToString();
            lbl_Level.Text = _player.Level.ToString();
        }

        private void MoveTo(Location newLocation)
        {
            if (!_player.HasRequiredItemToEnterThisLocation(newLocation))
            {
                rtb_Messages.Text += "You must have a " +
                newLocation.ItemRequiredToEnter.Name +
                " to enter this location." + Environment.NewLine;
                ScrollToBottomOfMessages();
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
                bool playerAlreadyHasQuest = _player.HasThisQuest(newLocation.QuestAvailableHere);
                bool playerAlreadyCompletedQuest = _player.CompletedThisQuest(newLocation.QuestAvailableHere);

                if (playerAlreadyHasQuest)
                {
                    if(!playerAlreadyCompletedQuest)
                    {
                        bool playerHasAllItemsToCompleteQuest = _player.HasAllQuestCompletionItems(newLocation.QuestAvailableHere);

                        if(playerHasAllItemsToCompleteQuest)
                        {
                            rtb_Messages.Text += Environment.NewLine;
                            rtb_Messages.Text += "You complete the " +
                                newLocation.QuestAvailableHere.Name +
                                " quest." + Environment.NewLine;

                            _player.RemoveQuestCompletionItems(newLocation.QuestAvailableHere);
                            _player.ExperiencePoints += newLocation.QuestAvailableHere.RewardExperiencePoints;
                            _player.Gold += newLocation.QuestAvailableHere.RewardGold;
                            _player.AddItemToInventory(newLocation.QuestAvailableHere.RewardItem);
                            _player.MarkQuestCompleted(newLocation.QuestAvailableHere);

                            rtb_Messages.Text += "You receive: " + Environment.NewLine;
                            rtb_Messages.Text +=
                                newLocation.QuestAvailableHere.RewardExperiencePoints.ToString() + " experience points" + Environment.NewLine;
                            rtb_Messages.Text +=
                                newLocation.QuestAvailableHere.RewardGold.ToString() + " gold" + Environment.NewLine;
                            rtb_Messages.Text +=
                                newLocation.QuestAvailableHere.RewardItem.Name.ToString() + Environment.NewLine;
                            ScrollToBottomOfMessages();
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
                    ScrollToBottomOfMessages();
                    _player.Quests.Add(new PlayerQuest(newLocation.QuestAvailableHere));
                }
            }

            if(newLocation.MonsterLivingHere != null)
            {
                rtb_Messages.Text += "You see a "
                    + newLocation.MonsterLivingHere.Name + Environment.NewLine;
                ScrollToBottomOfMessages();
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

            UpdatePlayerStats();
            UpdateInventoryListInUI();
            UpdateQuestListInUI();
            UpdateWeaponListInUI();
            UpdatePotionListInUI();
        }

        private void btn_North_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToNorth);
        }

        private void btn_West_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToWest);
        }

        private void btn_East_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToEast);
        }

        private void btn_South_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToSouth);
        }

        private void btn_UseWeapon_Click(object sender, EventArgs e)
        {
            Weapon currentWeapon = (Weapon)cbo_Weapons.SelectedItem;

            int damageToMonster = RandomNumberGenerator.NumberBetween(
                currentWeapon.MinimumDamage,
                currentWeapon.MaximumDamage);

            _currentMonster.CurrentHitPoints -= damageToMonster;

            rtb_Messages.Text += "You hit the " +
                _currentMonster.Name + " for " +
                damageToMonster.ToString() + " points." + Environment.NewLine;

            ScrollToBottomOfMessages();

            if (_currentMonster.CurrentHitPoints <= 0)
            {
                rtb_Messages.Text += Environment.NewLine;
                rtb_Messages.Text += "You defeated the " + _currentMonster.Name +
                    Environment.NewLine;

                _player.ExperiencePoints += _currentMonster.RewardExperiencePoints;
                rtb_Messages.Text += "You receive " +
                    _currentMonster.RewardExperiencePoints.ToString() + " experience points" + Environment.NewLine;

                _player.Gold += _currentMonster.RewardGold;
                rtb_Messages.Text += "You receive " +
                    _currentMonster.RewardGold.ToString() + " gold" + Environment.NewLine;

                ScrollToBottomOfMessages();

                List<InventoryItem> lootedItems = new List<InventoryItem>();

                foreach(LootItem lootItem in _currentMonster.LootTable)
                {
                    if(RandomNumberGenerator.NumberBetween(1,100) <= lootItem.DropPercentage)
                    {
                        lootedItems.Add(new InventoryItem(lootItem.Details, 1));
                    }
                }

                if(lootedItems.Count == 0)
                {
                    foreach(LootItem lootItem in _currentMonster.LootTable)
                    {
                        if (lootItem.IsDefaultItem)
                        {
                            lootedItems.Add(new InventoryItem(lootItem.Details, 1));
                        }
                    }
                }

                foreach(InventoryItem inventoryItem in lootedItems)
                {
                    _player.AddItemToInventory(inventoryItem.Details);

                    if (inventoryItem.Quantity == 1)
                    {
                        rtb_Messages.Text += "You loot " +
                        inventoryItem.Quantity.ToString() + " " +
                        inventoryItem.Details.Name + Environment.NewLine;
                        ScrollToBottomOfMessages();
                    }
                    else
                    {
                        rtb_Messages.Text += "You loot " +
                        inventoryItem.Quantity.ToString() + " " +
                        inventoryItem.Details.NamePlural + Environment.NewLine;
                        ScrollToBottomOfMessages();
                    }
                }

                UpdatePlayerStats();

                UpdateInventoryListInUI();
                UpdateWeaponListInUI();
                UpdatePotionListInUI();

                rtb_Messages.Text += Environment.NewLine;

                ScrollToBottomOfMessages();

                MoveTo(_player.CurrentLocation);
            }
            else
            {
                int damageToPlayer = RandomNumberGenerator.NumberBetween(
                    0,
                    _currentMonster.MaximumDamage);

                rtb_Messages.Text += "The " + _currentMonster.Name + " did " +
                    damageToPlayer.ToString() + " points of damage." + Environment.NewLine;

                ScrollToBottomOfMessages();

                _player.CurrentHitPoints -= damageToPlayer;

                lbl_HitPoints.Text = _player.CurrentHitPoints.ToString();

                if(_player.CurrentHitPoints <= 0)
                {
                    rtb_Messages.Text += "The " + _currentMonster.Name + " killed you" +
                        Environment.NewLine;

                    ScrollToBottomOfMessages();

                    MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
                }
            }
        }

        private void btn_UsePotion_Click(object sender, EventArgs e)
        {
            HealingPotion potion = (HealingPotion)cbo_Potions.SelectedItem;

            _player.CurrentHitPoints = (_player.CurrentHitPoints + potion.AmountToHeal);

            if(_player.CurrentHitPoints > _player.MaximumHitPoints)
            {
                _player.CurrentHitPoints = _player.MaximumHitPoints;
            }

            foreach(InventoryItem ii in _player.Inventory)
            {
                if(ii.Details.ID == potion.ID)
                {
                    ii.Quantity--;
                    break;
                }

                rtb_Messages.Text += "You drink a " + potion.Name + Environment.NewLine;

                int damageToPlayer =
                    RandomNumberGenerator.NumberBetween(
                        0,
                        _currentMonster.MaximumDamage);

                rtb_Messages.Text += "The " + _currentMonster.Name + " did " +
                    damageToPlayer.ToString() + " points of damage." + Environment.NewLine;

                _player.CurrentHitPoints -= damageToPlayer;

                ScrollToBottomOfMessages();

                if (_player.CurrentHitPoints <= 0)
                {
                    rtb_Messages.Text += "The " + _currentMonster.Name + " killed you " +
                        Environment.NewLine;

                    ScrollToBottomOfMessages();

                    MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
                }

                lbl_HitPoints.Text = _player.CurrentHitPoints.ToString();

                UpdateInventoryListInUI();
                UpdatePotionListInUI();
            }
        }

        private void SimpleRpgFormGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(PLAYER_DATA_FILE_NAME, _player.ToXMLString());
        }
    }
}
