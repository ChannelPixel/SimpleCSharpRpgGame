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

            lbl_HitPoints.DataBindings.Add("Text", _player, "CurrentHitPoints");
            lbl_Gold.DataBindings.Add("Text", _player, "Gold");
            lbl_Experience.DataBindings.Add("Text", _player, "ExperiencePoints");
            lbl_Level.DataBindings.Add("Text", _player, "Level");

            dgv_Inventory.RowHeadersVisible = false;
            dgv_Inventory.AutoGenerateColumns = false;

            dgv_Inventory.DataSource = _player.Inventory;

            dgv_Inventory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                Width = 197,
                DataPropertyName = "Description"
            });

            dgv_Inventory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Quantity",
                DataPropertyName = "Quantity"
            });

            dgv_Quests.RowHeadersVisible = false;
            dgv_Quests.AutoGenerateColumns = false;

            dgv_Quests.DataSource = _player.Quests;

            dgv_Quests.Columns.Add(new DataGridViewTextBoxColumn 
            {
                HeaderText = "Name",
                Width = 197,
                DataPropertyName = "Name"
            });

            dgv_Quests.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Done?",
                DataPropertyName = "IsCompleted"
            });

            cbo_Weapons.DataSource = _player.Weapons;
            cbo_Weapons.DisplayMember = "Name";
            cbo_Weapons.ValueMember = "Id";

            if(_player.CurrentWeapon != null)
            {
                cbo_Weapons.SelectedItem = _player.CurrentWeapon;
            }

            cbo_Weapons.SelectedIndexChanged += cbo_Weapons_SelectedIndexChanged;

            cbo_Potions.DataSource = _player.Potions;
            cbo_Potions.DisplayMember = "Name";
            cbo_Potions.ValueMember = "Id";

            _player.PropertyChanged += PlayerOnPropertyChanged;

            _player.OnMessage += DisplayMessage;

            _player.MoveTo(_player.CurrentLocation);
        }

        private void ScrollToBottomOfMessages()
        {
            rtb_Messages.SelectionStart = rtb_Messages.Text.Length;
            rtb_Messages.ScrollToCaret();
        }



        private void btn_North_Click(object sender, EventArgs e)
        {
            _player.MoveNorth();
        }
        private void btn_East_Click(object sender, EventArgs e)
        {
            _player.MoveEast();
        }
        private void btn_South_Click(object sender, EventArgs e)
        {
            _player.MoveSouth();
        }
        private void btn_West_Click(object sender, EventArgs e)
        {
            _player.MoveWest();
        }

        private void btn_UseWeapon_Click(object sender, EventArgs e)
        {
            Weapon currentWeapon = (Weapon)cbo_Weapons.SelectedItem;

            _player.UseWeapon(currentWeapon);

        }

        private void btn_UsePotion_Click(object sender, EventArgs e)
        {
            HealingPotion potion = (HealingPotion)cbo_Potions.SelectedItem;

            _player.UsePotion(potion);
        }

        private void btn_Trade_Click(object sender, EventArgs e)
        {
            TradingScreen tradingScreen = new TradingScreen(_player);
            tradingScreen.StartPosition = FormStartPosition.CenterParent;
            tradingScreen.ShowDialog(this);
        }

        private void SimpleRpgFormGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(PLAYER_DATA_FILE_NAME, _player.ToXMLString());
        }

        private void cbo_Weapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            _player.CurrentWeapon = (Weapon)cbo_Weapons.SelectedItem;
        }

        private void PlayerOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "CurrentLocation")
            {
                // Show/hide available movement buttons
                btn_North.Visible = (_player.CurrentLocation.LocationToNorth != null);
                btn_East.Visible = (_player.CurrentLocation.LocationToEast != null);
                btn_South.Visible = (_player.CurrentLocation.LocationToSouth != null);
                btn_West.Visible = (_player.CurrentLocation.LocationToWest != null);
                btn_Trade.Visible = (_player.CurrentLocation.VendorWorkingHere != null);
                // Display current location name and description
                rtb_Location.Text = _player.CurrentLocation.Name + Environment.NewLine;
                rtb_Location.Text += _player.CurrentLocation.Description + Environment.NewLine;
                if (_player.CurrentLocation.MonsterLivingHere == null)
                {
                    cbo_Weapons.Visible = false;
                    cbo_Potions.Visible = false;
                    btn_UseWeapon.Visible = false;
                    btn_UsePotion.Visible = false;
                }
                else
                {
                    cbo_Weapons.Visible = _player.Weapons.Any();
                    cbo_Potions.Visible = _player.Potions.Any();
                    btn_UseWeapon.Visible = _player.Weapons.Any();
                    btn_UsePotion.Visible = _player.Potions.Any();
                }
            }

            if (propertyChangedEventArgs.PropertyName == "Weapons")
            {
                cbo_Weapons.DataSource = _player.Weapons;

                if(!_player.Weapons.Any())
                {
                    cbo_Weapons.Visible = false;
                    btn_UseWeapon.Visible = false;
                }
            }

            if (propertyChangedEventArgs.PropertyName == "Potions")
            {
                cbo_Potions.DataSource = _player.Potions;

                if (!_player.Potions.Any())
                {
                    cbo_Potions.Visible = false;
                    btn_UsePotion.Visible = false;
                }
            }
        }

        private void DisplayMessage(object sender, MessageEventArgs messageEventArgs)
        {
            rtb_Messages.Text +=
                messageEventArgs.Message + Environment.NewLine;

            if(messageEventArgs.AddExtraNewLine)
            {
                rtb_Messages.Text += Environment.NewLine;
            }

            rtb_Messages.SelectionStart = rtb_Messages.Text.Length;
            rtb_Messages.ScrollToCaret();
        }
    }
}
