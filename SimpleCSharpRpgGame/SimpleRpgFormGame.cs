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
    }
}
