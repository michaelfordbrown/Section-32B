using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    public class PieceClass
    {

        // Commands changing facing direction (LEFT or RIGHT)
        public enum enTurningDirection { L, R }

        // Possible compass directions (NORTH, EAST, SOUTH or WEST) 
        public enum enCompass { NORTH = 0, EAST = 1, SOUTH = 2, WEST = 3 };
        static public string[] strCompassArray = new string[] { "N", "E", "S", "W" };
        int intMaxCompPoints = strCompassArray.Length;

        // Collection of piece location attributes
        public struct PieceLocation
        {
            public int intLocationX;
            public int intLocationY;

            public int indexFacingDirection;
            public string strFacingDirection;
        }

        // Piece location on the board
        private PieceLocation plLocation;

        public int getX()
        {
            return plLocation.intLocationX;
        }
        public int getY()
        {
            return plLocation.intLocationY;
        }
        public string getFDS()
        {
            return plLocation.strFacingDirection;
        }
        public int getFDI()
        {
            return plLocation.indexFacingDirection;
        }
        public void setX(int X)
        {
            plLocation.intLocationX = X;
        }
        public void setY(int Y)
        {
            plLocation.intLocationY = Y;
        }
        public void setFDI(int FDI)
        {
            plLocation.indexFacingDirection= FDI;
        }
        public void setFDS(string FDS)
        {
            plLocation.strFacingDirection = FDS;
        }

        public PieceClass()
        {
            // Start direction with piece facing North
            plLocation.indexFacingDirection = (int)enCompass.NORTH;
            plLocation.strFacingDirection = strCompassArray[plLocation.indexFacingDirection];

        }

        // 
        public void ChangeDirection(enTurningDirection enTurnDirect)
        {

            switch (enTurnDirect)
            {
                case enTurningDirection.L:
                    this.plLocation.indexFacingDirection = (this.plLocation.indexFacingDirection - 1 + intMaxCompPoints) % this.intMaxCompPoints;
                    this.plLocation.strFacingDirection = strCompassArray[this.plLocation.indexFacingDirection];
                    break;

                case enTurningDirection.R:
                    this.plLocation.indexFacingDirection = (this.plLocation.indexFacingDirection + 1 + this.intMaxCompPoints) % this.intMaxCompPoints;
                    this.plLocation.strFacingDirection = strCompassArray[this.plLocation.indexFacingDirection];
                    break;

                default:
                    break;
            }

        }
       

        public string Output()
        {
            return (this.plLocation.intLocationX + " " + this.plLocation.intLocationY + " " + this.plLocation.strFacingDirection);
        }

    }
}
