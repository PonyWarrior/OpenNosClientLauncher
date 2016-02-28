using System;
using System.Drawing;
using System.Windows.Forms;

namespace OpenNosClientLauncher
{
    public partial class GameStartStatusForm : Form
    {
        public GameStartStatusForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        #region formverschiebung
        private Point mouseposition;
        void MovementFORMMDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mouseposition = new Point(-e.X, -e.Y);
        }
        void MovementFORMMMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseposition.X, mouseposition.Y);
                Location = mousePos;
            }
        }

        void MovementtbMDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mouseposition = new Point(-e.X, -e.Y);
        }
        void MovementtbMMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseposition.X - textBox_log.Left, mouseposition.Y - textBox_log.Top);
                Location = mousePos;
            }
        }

        #endregion


    }
}
