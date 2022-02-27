using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace C18_Ex05
{
    public class Player
    {
        public string PlayerName { get; set; }
        public int Points { get; set; }
        public GameManager.ePlayerNumber PlayerNumber { get; private set; }
        private readonly GameManager.ePlayerType r_PlayerType;
        // $G$ CSS-999 (-3) missing blank lines
        public Player(string i_Name, GameManager.ePlayerType i_PlayerType, GameManager.ePlayerNumber i_PlayerNumber)
        {
            PlayerName = i_Name;
            Points = 0;
            r_PlayerType = i_PlayerType;
            PlayerNumber = i_PlayerNumber;
        }

        public Point GetChipPosition(int i_ChipCol , BoardManager i_Board)
        {
            Point i_ChipPosition;
            if (this.IsHuman())
            {
                // get the point of the inserted chip and update matrix
                i_ChipPosition = new Point(i_Board.InsertChip(i_ChipCol, (int)PlayerNumber), i_ChipCol); 
            }
            else
            {
                // get the point from the computer and insert it to the matrix
                i_ChipCol = getPlaceForChipInputFromComputer(GameManager.Board.BoardMatrix);
                i_ChipPosition = new Point(i_Board.InsertChip(i_ChipCol, (int)PlayerNumber), i_ChipCol);
            }
            return i_ChipPosition;
        }

        private int getPlaceForChipInputFromComputer(int[,] i_BoardMatrix)
        {
            Random i_RandomIndex = new Random();
            int i_ColIndex = i_RandomIndex.Next(1, i_BoardMatrix.GetLength(1) + 1);
            while(i_BoardMatrix[0, i_ColIndex - 1] != (int)GameManager.ePlayerNumber.Empty) // while the position is not empty
            {
                i_ColIndex++;
                if(i_ColIndex > i_BoardMatrix.GetLength(1))
                {
                    i_ColIndex = 1;
                }
            }
            return i_ColIndex - 1;
        }

        public bool IsHuman()
        {
            return r_PlayerType == GameManager.ePlayerType.Human ? true : false;
        }
    }
}
