using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace C18_Ex05
{
    public partial class GameSettingsD : Form
    {
        private const bool v_IsEnabled = true;
        private static GameBoardD s_GameBoard;

        public GameSettingsD()
        {
            InitializeComponent();
            m_ButtonStart.Click += new EventHandler(start_Click);
            m_CheckBoxPlayer2.Click += new EventHandler(checkBox_Click);
        }

        private void start_Click(object sender, EventArgs e) // When the Player presses the start button the game begins
        {
            m_TextBoxPlayer1.Text = m_TextBoxPlayer1.Text == "" ? "player1" : m_TextBoxPlayer1.Text;
            m_TextBoxPlayer2.Text = m_TextBoxPlayer2.Text == "" ? "player2" : m_TextBoxPlayer2.Text;
           
            this.Hide();
            GameManager.InitalizeGame(m_TextBoxPlayer1.Text, m_TextBoxPlayer2.Text, !m_CheckBoxPlayer2.Checked, (int)m_NumericUpDownRows.Value, (int)m_NumericUpDownCols.Value);
            s_GameBoard = new GameBoardD();
            s_GameBoard.ShowDialog();
            this.Close();
        }

        private void checkBox_Click(object sender, EventArgs e) //Handle the click checkBox event
        {
            if(m_CheckBoxPlayer2.Checked)
            {
                m_TextBoxPlayer2.Enabled = v_IsEnabled;
                m_TextBoxPlayer2.Text = "";              
            }
            else
            {
                m_TextBoxPlayer2.Enabled = !v_IsEnabled;
                m_TextBoxPlayer2.Text = string.Format("[{0}]",GameManager.ePlayerType.Computer.ToString());
            }         
        }
    }
}
