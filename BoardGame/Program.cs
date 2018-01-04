using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            BoardGameClass gameOne = new BoardGameClass();

            PieceClass objBoardPiece = new PieceClass();
            string strCommandSet = "E";

            while (strCommandSet != "Q")
            {
                Console.WriteLine("Enter Move: (M)ove forward, turn (L)eft, turn (R)ight , r(E)set and (Q)uit.");
                strCommandSet = Console.ReadLine();

                gameOne.ProcessCommands(strCommandSet);
                Console.WriteLine(gameOne.pieceOne.Output());

                //objBoardPiece.ProcessCommands(strCommandSet);
                //Console.WriteLine(objBoardPiece.Output());
            }
        }
    }
}


