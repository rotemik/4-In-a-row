using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace C18_Ex05
{
    // $G$ CSS-999 (-3) Class that inherit from Form - should be named with Form at the beginning.
    public partial class GameBoardD : Form
    {
        private const int k_ButtonWidth = 32;
        private const int k_ButtonHeight = 30;
        private const int k_ButtonNumberHeight = 20;
        private const int k_ButtonSpace = 10;
        private const int k_PositionX = 12;
        private const int k_PositionY = 12;
        private int m_PlayersDetailsPositionY;

        private Button[,] m_ButtonsMatrix;
        private List<Button> m_NumberButtons;
        Label m_Player1NameLabel;
        Label m_Player2NameLabel;

        public GameBoardD()
        {
            InitializeComponent();
            createBoard(GameManager.Board.BoardMatrix);
            addPlayersLabels(GameManager.Player1, GameManager.Player2);
        }

        private void createBoard(int[,] i_Board) // the function creates the visual board game
        {
            m_ButtonsMatrix = new Button[i_Board.GetLength(0), i_Board.GetLength(1)];
            m_NumberButtons = new List<Button>();

            int i_PositionY = k_PositionX;
            int i_PositionX = k_PositionY;
            Size i_NumberColButtonSize = new Size(k_ButtonWidth, k_ButtonNumberHeight);
            Size i_CubeButtonSize = new Size(k_ButtonWidth, k_ButtonHeight);

            // adds the clickble number buttons to the dialog
            for (int i_PrintNumber = 0; i_PrintNumber < i_Board.GetLength(1); i_PrintNumber++)
            {
                int i_ColNumber = i_PrintNumber;
                Button i_NumberButton = createButtonNumberCol((i_PrintNumber + 1).ToString(), i_NumberColButtonSize, new Point(i_PositionX, i_PositionY));
                i_NumberButton.Click += delegate (object sender, EventArgs e) { button_Click(sender, e, i_ColNumber); };
                m_NumberButtons.Add(i_NumberButton);
                i_PositionX += k_ButtonWidth + k_ButtonSpace;
            }

            i_PositionY = k_PositionY + k_ButtonHeight + k_ButtonSpace;

            // adds the matrix buttons to the dialog
            for (int i_RowIndex = 0; i_RowIndex < i_Board.GetLength(0); i_RowIndex++)
            {
                i_PositionX = k_PositionX;
                for (int i_ColumnIndex = 0; i_ColumnIndex < i_Board.GetLength(1); i_ColumnIndex++)
                {
                    m_ButtonsMatrix[i_RowIndex, i_ColumnIndex] = createButtonNumberCol("", i_CubeButtonSize, new Point(i_PositionX, i_PositionY));
                    i_PositionX += k_ButtonWidth + k_ButtonSpace;
                }
                i_PositionY += k_ButtonHeight + k_ButtonSpace;
            }
            m_PlayersDetailsPositionY = i_PositionY + k_ButtonSpace;
        }

        private void button_Click(object sender, EventArgs e, int i_ChipCol)
        {
            GameManager.eEndGameStatus i_GameStatus = GameManager.PlayTurn(i_ChipCol, updateButtonCube);
            handleEndTurn(i_GameStatus, i_ChipCol);
        }

        private void handleEndTurn(GameManager.eEndGameStatus i_GameStatus, int i_ChipCol) //Perform a move according to status
        {            
            if (i_GameStatus == GameManager.eEndGameStatus.AnotherTurn) //continue playing
            {
                if (!GameManager.IsColumnAvailable(i_ChipCol))
                {
                    m_NumberButtons[i_ChipCol].Enabled = false;
                }
            }
            else //Game over, show messageBox 
            {
                DialogResult i_Result;
                if (i_GameStatus == GameManager.eEndGameStatus.Winning)
                {
                    i_Result = MessageBox.Show(string.Format("{0} Won!!! {1}Another Round?", GameManager.CurrentPlayer.PlayerName, Environment.NewLine), "A Win!", MessageBoxButtons.YesNo);
                }
                else
                {
                    i_Result = MessageBox.Show(string.Format("Tie!!!{0}Another Round?", Environment.NewLine), "A Tie!", MessageBoxButtons.YesNo);
                }

                if (i_Result == DialogResult.Yes)
                {
                    restart(GameManager.CurrentPlayer);
                }
                else if (i_Result == DialogResult.No || i_Result == DialogResult.Cancel)
                {
                    this.Close();
                }
            }         
        }

        private void restart(Player i_Player) //Set Game for new game
        {
            cleanBoard();
            if (i_Player != null)
            {
                Label i_LabelToUpdate = i_Player.PlayerNumber == GameManager.ePlayerNumber.Player1 ? m_Player1NameLabel : m_Player2NameLabel;
                i_LabelToUpdate.Text = string.Format("{0} : {1}", i_Player.PlayerName, i_Player.Points);
            }
            GameManager.RestartGame();
        }

        private void cleanBoard() // set the visual board game
        {
            foreach (Button i_ButtonNumber in m_NumberButtons)
            {
                i_ButtonNumber.Enabled = true;
            }

            foreach (Button i_ButtonCube in m_ButtonsMatrix)
            {
                i_ButtonCube.Text = "";
            }
        }

        private void updateButtonCube(Point i_CubePosition) // Print player's sign on the chosen button
        {
            char i_PlayerSign;
            switch (GameManager.CurrentPlayer.PlayerNumber)
            {
                case GameManager.ePlayerNumber.Player1:
                    // $G$ DSN-999 (-3) better use enum here
                    i_PlayerSign = 'X';
                    break;
                case GameManager.ePlayerNumber.Player2:
                    i_PlayerSign = 'O';
                    break;
                default:
                    i_PlayerSign = ' ';
                    break;
            }
            m_ButtonsMatrix[i_CubePosition.X, i_CubePosition.Y].Text = i_PlayerSign.ToString();
        }

        private void addPlayersLabels(Player i_Player1, Player i_Player2) // Create the labels for the players scores
        {
            m_Player1NameLabel = new Label();
            m_Player1NameLabel.Text = string.Format("{0} : {1}", i_Player1.PlayerName, i_Player1.Points);
            m_Player1NameLabel.Location = new Point(k_PositionX, m_PlayersDetailsPositionY);

            m_Player2NameLabel = new Label();
            m_Player2NameLabel.Text = string.Format("{0} : {1}", i_Player2.PlayerName, i_Player2.Points);
            m_Player2NameLabel.Location = new Point(k_PositionX + 100, m_PlayersDetailsPositionY);

            this.Controls.Add(m_Player1NameLabel);
            this.Controls.Add(m_Player2NameLabel);
        }

        private Button createButtonNumberCol(string i_Text, Size i_ButtonSize, Point i_ButtonPosition) // Create number buttons for the game
        {
            Button i_NumberColButton = new Button();
            i_NumberColButton.Text = i_Text;
            i_NumberColButton.Size = i_ButtonSize;
            i_NumberColButton.Location = i_ButtonPosition;
            this.Controls.Add(i_NumberColButton);
            return i_NumberColButton;
        }
    }
}
