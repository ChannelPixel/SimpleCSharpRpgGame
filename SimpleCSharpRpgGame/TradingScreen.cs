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
    public partial class TradingScreen : Form
    {
        private Player _currentPlayer { get; set; }

        public TradingScreen(Player player)
        {
            _currentPlayer = player;

            InitializeComponent();

            DataGridViewCellStyle rightAlignedCellStyle = new DataGridViewCellStyle();
            rightAlignedCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv_MyItems.RowHeadersVisible = false;
            dgv_MyItems.AutoGenerateColumns = false;

            dgv_MyItems.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "ItemID",
                    Visible = false
                }
            );

            dgv_MyItems.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Name",
                    Width = 100,
                    DataPropertyName = "Description",
                }
            );

            dgv_MyItems.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Qty",
                    Width = 30,
                    DataPropertyName = "Quantity",
                    DefaultCellStyle = rightAlignedCellStyle
                }
            );

            dgv_MyItems.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Price",
                    Width = 35,
                    DataPropertyName = "Quantity",
                    DefaultCellStyle = rightAlignedCellStyle
                }
            );

            dgv_MyItems.Columns.Add(
                new DataGridViewButtonColumn()
                {
                    Text = "Sell 1",
                    Width = 50,
                    DataPropertyName = "ItemID",
                    UseColumnTextForButtonValue = true
                }
            );

            dgv_MyItems.DataSource = _currentPlayer.Inventory;
            dgv_MyItems.CellClick += dgv_MyItems_CellClick;


            dgv_VendorItems.RowHeadersVisible = false;
            dgv_VendorItems.AutoGenerateColumns = false;


            dgv_VendorItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ItemID",
                Visible = false
            });

            dgv_VendorItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                Width = 100,
                DataPropertyName = "Description"
            });

            dgv_VendorItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Price",
                Width = 35,
                DefaultCellStyle = rightAlignedCellStyle,
                DataPropertyName = "Price"
            });

            dgv_VendorItems.Columns.Add(new DataGridViewButtonColumn
            {
                Text = "Buy 1",
                UseColumnTextForButtonValue = true,
                Width = 50,
                DataPropertyName = "ItemID"
            });

            // Bind the vendor's inventory to the datagridview
            dgv_VendorItems.DataSource = _currentPlayer.CurrentLocation.VendorWorkingHere.Inventory;

            // When the user clicks on a row, call this function
            dgv_VendorItems.CellClick += dgv_VendorItems_CellClick;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool buyClick = false;
        private void dgv_VendorItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(!buyClick)
            {
                buyClick = true;
                if (e.ColumnIndex == 3)
                {
                    var itemID = dgv_VendorItems.Rows[e.RowIndex].Cells[0].Value;

                    Item itemBeingBought = World.ItemByID(Convert.ToInt32(itemID));

                    if (_currentPlayer.Gold >= itemBeingBought.Price)
                    {

                        _currentPlayer.AddItemToInventory(itemBeingBought);

                        _currentPlayer.Gold -= itemBeingBought.Price;
                    }
                    else
                    {
                        MessageBox.Show("You don't have enough gold to buy the " + itemBeingBought.Name);
                    }
                }

                
            }
            else
            {
                buyClick = false;
            }
        }


        private bool sellClick = false;
        private void dgv_MyItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(!sellClick)
            {
                sellClick = true;

                if (e.ColumnIndex == 4)
                {
                    var itemID = dgv_MyItems.Rows[e.RowIndex].Cells[0].Value;

                    Item itemBeingSold = World.ItemByID(Convert.ToInt32(itemID));

                    if (itemBeingSold.Price == World.UNSELLABLE_ITEM_PRICE)
                    {
                        MessageBox.Show("You cannot sell the " + itemBeingSold.Name);
                    }
                    else
                    {

                        _currentPlayer.RemoveItemFromInventory(itemBeingSold);

                        _currentPlayer.Gold += itemBeingSold.Price;
                    }
                }

                
            }
            else
            {
                sellClick = false;
            }
        }
    }
}
