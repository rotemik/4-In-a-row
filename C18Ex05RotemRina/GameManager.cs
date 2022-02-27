using System;
using System.Drawing;

namespace C18_Ex05
{
    public abstract class GameManager
    {
        public static Player Player1 { get; private set; }
        public static Player Player2 { get; private set; }
        public static BoardManager Board { get; private set; }
        public static Player CurrentPlayer { get; private set; }
        private static bool s_IsTheFirstGame = true;

        public enum eBoardRange
        {
            BoardRangeStart = 4,
            BoardRangeEnd = 8,
        };

        public enum ePlayerType
        {
            Human = 1,
            Computer = 2,
        };

        public enum ePlayerNumber
        {
            Empty = 0,
            Player1 = 1,
            Player2 = 2,
        };

        public enum eEndGameStatus
        {
            Winning,
            Tie,
            AnotherTurn,
        };

        public static void InitalizeGame(string i_Player1Name, string i_Player2Name, bool i_IsComputer, int i_Rows, int i_Cols) // Initialize the game from start or restart
        {
            Board = new BoardManager(i_Rows, i_Cols);
            if (s_IsTheFirstGame)
            {
                Player1 = new Player(i_Player1Name, ePlayerType.Human, ePlayerNumber.Player1);
                ePlayerType i_OpponentType = i_IsComputer ? ePlayerType.Computer : ePlayerType.Human;
                Player2 = new Player(i_Player2Name, i_OpponentType, ePlayerNumber.Player2);
            }
            CurrentPlayer = Player1;
            s_IsTheFirstGame = false;
        }
        public static eEndGameStatus PlayTurn(int i_ChipCol, Action<Point> i_UpdateAction) // Make one turn for the player
        {
            Point i_ChipPosition = CurrentPlayer.GetChipPosition(i_ChipCol, Board);
            i_UpdateAction.Invoke(i_ChipPosition);
            eEndGameStatus i_Status = checkGameStatus();
            if (!GameManager.CurrentPlayer.IsHuman())
            {
                i_Status = PlayTurn(i_ChipCol , i_UpdateAction);
            }
            return i_Status;
        }

        private static eEndGameStatus checkGameStatus() // Check the status game to know how to continue
        {
            eEndGameStatus eGameStatus;

            if (IsWon())
            {
                eGameStatus = eEndGameStatus.Winning;
            }
            else if (IsTie())
            {
                eGameStatus = eEndGameStatus.Tie;
            }
            else
            {
                switchCurrentPlayer();
                eGameStatus = eEndGameStatus.AnotherTurn;
            }
            return eGameStatus;
        }

        public static bool IsWon() //Check if the current player won
        {
            bool i_IsWon = Board.ThereIsAQuartet();

            if (i_IsWon)
            {
                CurrentPlayer.Points++;

            }
            return i_IsWon;
        }

        public static bool IsTie() //Check if the matrix full, then is a tie
        {
            return Board.IsBoardFull();
        }

        public static bool IsColumnAvailable(int i_ChipCol) // Check if more chips can be inserted  
        {

            return Board.IsColumnAvailable(i_ChipCol);
        }

        private static void switchCurrentPlayer() //Switch between the players
        {
            if (CurrentPlayer.PlayerNumber == GameManager.ePlayerNumber.Player1)
            {
                CurrentPlayer = Player2;
            }
            else
            {
                CurrentPlayer = Player1;
            }
        }

        public static void RestartGame() //Restart game if the player wanted to play another game
        {
            InitalizeGame(Player1.PlayerName, Player2.PlayerName, !Player2.IsHuman(), Board.BoardMatrix.GetLength(0), Board.BoardMatrix.GetLength(1));
        }
    }
}
