using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_game.Properties;

namespace Tic_Tac_Toe_game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        struct stGameInfo
        {
            public short counter;
            public string winner;
            public bool GameEnd;
        };

        stGameInfo GameInfo;
        


        bool Check_Win_Case(PictureBox img1, PictureBox img2, PictureBox img3)
        {
            if ((img1.Tag.ToString() != "?") && (img1.Tag.ToString() == img1.Tag.ToString()) && (img2.Tag.ToString() == img1.Tag.ToString())
                && (img3.Tag.ToString() == img1.Tag.ToString()))
            {              
                img1.BackColor = Color.Lime;
                img2.BackColor = Color.Lime;
                img3.BackColor = Color.Lime;
                GameInfo.winner = img1.Tag.ToString() == "x" ? "Player1" : "Player2";
                lblWinnerStatus.Text = GameInfo.winner;
                GameInfo.GameEnd = true;

                return true;

            }
            return false;
        }
        void RestImg(PictureBox img)
        {
            img.Image = Resources.ImageInfo1;
            img.Tag = "?";
            img.BackColor = Color.Transparent;
        }
        void RestartGame()
        {
            img1.Enabled = true;
            img2.Enabled = true;
            img3.Enabled = true;
            img4.Enabled = true;
            img5.Enabled = true;
            img6.Enabled = true;
            img7.Enabled = true;
            img8.Enabled = true;
            img9.Enabled = true;

            GameInfo.GameEnd = false;
            GameInfo.counter = 0;
            GameInfo.winner = "on progrees";
            lblPlayer.Text = "Player1";
            lblPlayer.Tag = "0";

            lblWinnerStatus.Text = "on progrees";
            RestImg(img1);
            RestImg(img2);
            RestImg(img3);
            RestImg(img4);
            RestImg(img5);
            RestImg(img6);
            RestImg(img7);
            RestImg(img8);
            RestImg(img9);

        }
        void Game_Over()
        {

            img1.Enabled = false;
            img2.Enabled = false;
            img3.Enabled = false;
            img4.Enabled = false;
            img5.Enabled = false;
            img6.Enabled = false;
            img7.Enabled = false;
            img8.Enabled = false;
            img9.Enabled = false;
            lblPlayer.Text = "Game over";
        }
        void ChangeTurn(PictureBox img)
        {
            // if the player click a unvalidate button 
            if (img.Tag.ToString() != "?")
            {
                MessageBox.Show("this case already taken!", "wrong choice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lblPlayer.Tag.ToString() == "0")
            {
                img.Image = Resources.ImageX;
                lblPlayer.Text = "Player2";
                lblPlayer.Tag = "1";
                img.Tag = "x";
            }
            else
            {
                img.Image = Resources.ImageO2;
                lblPlayer.Text = "Player1";
                lblPlayer.Tag = "0";
                img.Tag = "o";
            }
            GameInfo.counter++;
        }

        bool Game_Winner_Logic()
        {
            //row cases
            if (Check_Win_Case(img1, img2, img3))
            {
                Game_Over();
                return true;

            }

            if (Check_Win_Case(img4, img5, img6))
            {
                Game_Over();
                return true;
            }

            if (Check_Win_Case(img7, img8, img9))
            {
                Game_Over();
                return true;
            }

            // column cases
            if (Check_Win_Case(img1, img4, img7))
            {
                Game_Over();
                return true;
            }
            if (Check_Win_Case(img2, img5, img8))
            {
                Game_Over();
                return true;
            }
            if (Check_Win_Case(img3, img6, img9))
            {
                Game_Over();
                return true;
            }

            //last cases(dianogle)
            if (Check_Win_Case(img1, img5, img9))
            {
                Game_Over();
                return true;

            }
            if (Check_Win_Case(img3, img5, img7))
            {
                Game_Over();
                return true;
            }

            return false;
        }

        bool IsWin(){
            // if the game finished 
            if (GameInfo.GameEnd) {
               
                return false;

            }

            Game_Winner_Logic();

            //counting start from 0 , amd the max counter case = 9
            if (GameInfo.counter == 9 && !Game_Winner_Logic())
            {
                MessageBox.Show("its a draw!", "game over", MessageBoxButtons.OK);
                lblWinnerStatus.Text = "Draw";
                lblPlayer.Text = "Game over";
                Game_Over();
                return false;

            }

            if (GameInfo.GameEnd)
            {
                MessageBox.Show($"{GameInfo.winner} is the winner!", "game over", MessageBoxButtons.OK);
            }
            return true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.White;
            Pen pen = new Pen(White);
            pen.Width = 10;

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(pen, 500, 150, 500, 600);
            e.Graphics.DrawLine(pen, 650, 150, 650, 600);

            e.Graphics.DrawLine(pen, 800, 300, 350, 300);
            e.Graphics.DrawLine(pen, 800, 450, 350, 450);

        }


        private void img_Click(object sender, EventArgs e)
        {
            ChangeTurn((PictureBox)sender);
            IsWin();
        }

        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            RestartGame();

        }       

       
    }
}
