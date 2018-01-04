using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    public class BoardGameClass : BoardClass
    {
        public PieceClass pieceOne = new PieceClass();

        public void MoveForwardX()
        {
            switch (pieceOne.getFDS())
            {
                // Facing North or South
                case "N":
                case "S":
                    {
                        break;
                    }
                // Facing East
                case "E":
                    {
                        if (pieceOne.getX() < cintBoardMax)
                            pieceOne.setX(pieceOne.getX()+1);
                        break;
                    }
                // Facing West
                case "W":
                    {
                        if (pieceOne.getX() > cintBoardMin)
                            pieceOne.setX(pieceOne.getX() - 1);
                        break;
                    }
                // Other
                default:
                    break;
            }
        }
        public void MoveForwardY()
        {
            switch (pieceOne.getFDS())
            {
                // Facing East or West
                case "E":
                case "W":
                    {

                        break;
                    }
                // Facing North
                case "N":
                    {
                        if (pieceOne.getY() < cintBoardMax)
                            pieceOne.setY(pieceOne.getY() + 1);
                        break;
                    }
                // Facing South
                case "S":
                    {
                        if (pieceOne.getY() > cintBoardMin)
                            pieceOne.setY(pieceOne.getY() - 1);
                        break;
                    }
                // Other
                default:
                    break;
            }
        }

        public void Move(char chrMove)
        {
            switch (chrMove)
            {
                // Turn piece left by 90 degrees
                case 'L':
                    {
                        pieceOne.ChangeDirection(PieceClass.enTurningDirection.L);
                        break;
                    }
                // Turn piece right by 90 degrees
                case 'R':
                    {
                        pieceOne.ChangeDirection(PieceClass.enTurningDirection.R);
                        break;
                    }
                // Move piece forward by one space
                case 'M':
                    {
                        this.MoveForwardX();
                        this.MoveForwardY();
                        break;
                    }
                // Reset location attributes
                case 'E':
                    {
                        pieceOne.setX(cintBoardMin);
                        pieceOne.setY(cintBoardMin);
                        pieceOne.setFDI((int)PieceClass.enCompass.NORTH);
                        pieceOne.setFDS(PieceClass.strCompassArray[pieceOne.getFDI()]);
                        break;
                    }
                // Other
                default:
                    break;
            }
        }

        // Go through set of commands and move/rotate piece
        public void ProcessCommands(string strCommands)
        {
            int i = 0;
            while (i < strCommands.Length)
            {
                this.Move(strCommands[i]);
                i++;
            }
        }
        public BoardGameClass()
        {
            this.ProcessCommands("E");
        }


    }
}
