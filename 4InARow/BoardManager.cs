using System;
using System.Collections.Generic;
using System.Text;

namespace C18_Ex05
{
    public class BoardManager
    {
        // $G$ DSN-999 (-3) This array should be readonly.
        private int[,] m_BoardMatrix;
        private int m_NumOfEmptyCells;
        public BoardManager(int i_Height, int i_Width)
        { 
            m_BoardMatrix = new int[i_Height, i_Width]; // create new matrix
            m_NumOfEmptyCells = i_Height * i_Width; // update the amount of cells
        }

        public int InsertChip(int i_ColIndex, int i_Chip)
        {
            int i_EmptyRowIndex = findFirstEmptyRow(i_ColIndex);
            BoardMatrix[i_EmptyRowIndex, i_ColIndex] = i_Chip; // update the cell with the new chip
            m_NumOfEmptyCells--;
            return i_EmptyRowIndex;
        }

        private int findFirstEmptyRow(int i_ColIndex)
        {
            int i_RowIndex = BoardMatrix.GetLength(0) - 1;
            for (; i_RowIndex >= 0; i_RowIndex--)
            {
                if (BoardMatrix[i_RowIndex, i_ColIndex] == (int)GameManager.ePlayerNumber.Empty)
                {
                    break;
                }
            }
            return i_RowIndex;
        }

        public bool IsColumnAvailable(int i_ColIndex)
        {
            bool i_IsColumnAvailable = false;
            for (int i_RowIndex = 0; i_RowIndex < BoardMatrix.GetLength(0); i_RowIndex++)
            {
                if (BoardMatrix[i_RowIndex, i_ColIndex] == (int)GameManager.ePlayerNumber.Empty)
                {
                    i_IsColumnAvailable = true;
                    break;
                }
            }
            return i_IsColumnAvailable;
        }

        public bool IsBoardFull()
        {
            bool i_IsBoardFull;
            if (m_NumOfEmptyCells == 0)
            {
                i_IsBoardFull = true;
            }
            else
            {
                i_IsBoardFull = false;
            }
            return i_IsBoardFull;
        }

        public bool ThereIsAQuartet()
        {
            bool i_ThereIsAQuartet;
            // if one of the checks found a quartet
            if (checkVerticalQuartet() || checkHorizontalQuartet() || checkDiagonalQuartet())
            {
                i_ThereIsAQuartet = true;
            }
            else
            {
                i_ThereIsAQuartet = false;
            }
            return i_ThereIsAQuartet;
        }

        private bool checkVerticalQuartet()
        {
            bool i_ThereIsQuartet = false;
            int i_Chip;
            for (int i_RowIndex = BoardMatrix.GetLength(0) - 4; i_RowIndex >= 0; i_RowIndex--)
            {
                for (int i_ColIndex = 0; i_ColIndex < BoardMatrix.GetLength(1); i_ColIndex++)
                {
                    i_Chip = BoardMatrix[i_RowIndex, i_ColIndex];
                    if (i_Chip != (int)GameManager.ePlayerNumber.Empty)
                    {
                        if ((i_Chip == BoardMatrix[i_RowIndex + 1, i_ColIndex]) && (i_Chip == BoardMatrix[i_RowIndex + 2, i_ColIndex]) && (i_Chip == BoardMatrix[i_RowIndex + 3, i_ColIndex]))
                        {
                            i_ThereIsQuartet = true;
                            break;
                        }
                    }
                }
            }
            return i_ThereIsQuartet;
        }

        private bool checkHorizontalQuartet()
        {
            bool i_ThereIsQuartet = false;
            int i_Chip;
            for (int i_RowIndex = BoardMatrix.GetLength(0) - 1; i_RowIndex >= 0; i_RowIndex--)
            {
                for (int i_ColIndex = 0; i_ColIndex < BoardMatrix.GetLength(1) - 3; i_ColIndex++)
                {
                    i_Chip = BoardMatrix[i_RowIndex, i_ColIndex];
                    if (i_Chip != (int)GameManager.ePlayerNumber.Empty)
                    {
                        if ((i_Chip == BoardMatrix[i_RowIndex, i_ColIndex + 1]) && (i_Chip == BoardMatrix[i_RowIndex, i_ColIndex + 2]) && (i_Chip == BoardMatrix[i_RowIndex, i_ColIndex + 3]))
                        {
                            i_ThereIsQuartet = true;
                            break;
                        }
                    }
                }
            }
            return i_ThereIsQuartet;
        }

        private bool checkDiagonalQuartet()
        {
            bool i_ThereIsQuartet = false;
            int i_Chip;
            for (int i_ColIndex = 0; i_ColIndex < BoardMatrix.GetLength(1) - 3; i_ColIndex++)
            {
                // check right and down diagonal
                for (int i_RowIndex = 0; i_RowIndex < BoardMatrix.GetLength(0) - 3; i_RowIndex++)
                {
                    i_Chip = BoardMatrix[i_RowIndex, i_ColIndex];
                    if (i_Chip != (int)GameManager.ePlayerNumber.Empty)
                    {
                        if ((i_Chip == BoardMatrix[i_RowIndex + 1, i_ColIndex + 1]) && (i_Chip == BoardMatrix[i_RowIndex + 2, i_ColIndex + 2]) && (i_Chip == BoardMatrix[i_RowIndex + 3, i_ColIndex + 3]))
                        {
                            i_ThereIsQuartet = true;
                            break;
                        }
                    }
                }
                if(!i_ThereIsQuartet)
                {
                    // check right and up diagonal
                    for (int i_RowIndex = 3; i_RowIndex < BoardMatrix.GetLength(0); i_RowIndex++)
                    {
                        i_Chip = BoardMatrix[i_RowIndex, i_ColIndex];
                        if (i_Chip != (int)GameManager.ePlayerNumber.Empty)
                        {
                            if ((i_Chip == BoardMatrix[i_RowIndex - 1, i_ColIndex + 1]) && (i_Chip == BoardMatrix[i_RowIndex - 2, i_ColIndex + 2]) && (i_Chip == BoardMatrix[i_RowIndex - 3, i_ColIndex + 3]))
                            {
                                i_ThereIsQuartet = true;
                                break;
                            }
                        }
                    }
                }              
            }
            return i_ThereIsQuartet;
        }

        public int[,] BoardMatrix
        {
            get { return m_BoardMatrix; }
        }
    }
}
