using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.Tests
{
    [TestFixture]
    public class BoardGameTests
    {

        [Test]
        //The board has a fixed size of 5 squares (assume it is always square).
        public void BoardSizeSetTo5Squares()
        {
            Assert.That(BoardClass.cintBoardSize, Is.EqualTo(5));
            Assert.That(BoardClass.cintBoardMax, Is.EqualTo(4));
            Assert.That(BoardClass.cintBoardMin, Is.EqualTo(0));
        }

        [Test]
        //The piece can move around the board in one of four directions ((N)orth, (E)ast, (S)outh and (W)est).
        public void PieceMovesOneInFourDirections()
        {
            string[] CompassPoints = new string[] { "N", "E", "S", "W" };
            int intMaxComPoints = CompassPoints.Length;

            BoardGameClass BGResult = new BoardGameClass();

            // Rotate piece multiple times to the right
            for (int i = 0; i < 60; i ++)
            {
                Console.WriteLine("Rotation To Right Test {0}, Exp: {1}  Res:{2}", i, CompassPoints[i % intMaxComPoints], BGResult.pieceOne.getFDS());
                Assert.That(BGResult.pieceOne.getFDS(), Is.EqualTo(CompassPoints[i % intMaxComPoints]));
                BGResult.pieceOne.ChangeDirection(PieceClass.enTurningDirection.R);
            }

            // Move piece back to its starting position (0 0 N)
            BGResult.Move('E');
            Assert.That(BGResult.pieceOne.getX(), Is.EqualTo(0));
            Assert.That(BGResult.pieceOne.getY(), Is.EqualTo(0));
            Assert.That(BGResult.pieceOne.getFDS(), Is.EqualTo("N"));
            Console.WriteLine("Move Piece Back To Starting Position");

                // While Facing North move from bottom left to top left
                for (int mi = BoardClass.cintBoardMin; mi < BoardClass.cintBoardMax; mi++)
                {
                    Assert.That(BGResult.pieceOne.getY(), Is.EqualTo(mi));
                    Assert.That(BGResult.pieceOne.getX(), Is.EqualTo(BoardClass.cintBoardMin));
                    BGResult.MoveForwardY();
                    BGResult.MoveForwardX();
                }
                Console.WriteLine(BGResult.pieceOne.Output());
                // Turn piece 90 degrees to face East move from top left to top right
                BGResult.pieceOne.ChangeDirection(PieceClass.enTurningDirection.R);
                for (int mi = BoardClass.cintBoardMin; mi < BoardClass.cintBoardMax; mi++)
                {
                    Assert.That(BGResult.pieceOne.getY(), Is.EqualTo(BoardClass.cintBoardMax));
                    Assert.That(BGResult.pieceOne.getX(), Is.EqualTo(mi));
                    BGResult.MoveForwardY();
                    BGResult.MoveForwardX();
                }
                Console.WriteLine(BGResult.pieceOne.Output());
                // Turn piece 90 degrees to face South move from top right to bottom right
                BGResult.pieceOne.ChangeDirection(PieceClass.enTurningDirection.R);
                for (int mi = 4; mi >= BoardClass.cintBoardMin; mi--)
                {
                    Assert.That(BGResult.pieceOne.getY(), Is.EqualTo(mi));
                    Assert.That(BGResult.pieceOne.getX(), Is.EqualTo(BoardClass.cintBoardMax));
                    BGResult.MoveForwardY();
                    BGResult.MoveForwardX();
                }
                Console.WriteLine(BGResult.pieceOne.Output());
                // Turn piece 90 degrees to face West move from bottom right to bottom left
                BGResult.pieceOne.ChangeDirection(PieceClass.enTurningDirection.R);
                for (int mi = BoardClass.cintBoardMax; mi <= BoardClass.cintBoardMin; mi++)
                {
                    Assert.That(BGResult.pieceOne.getY(), Is.EqualTo(BoardClass.cintBoardMin));
                    Assert.That(BGResult.pieceOne.getX(), Is.EqualTo(mi));
                    BGResult.MoveForwardY();
                    BGResult.MoveForwardX();
                    Console.WriteLine("T4: ", BGResult.pieceOne.Output());
                }
                Console.WriteLine(BGResult.pieceOne.Output());

        }

        [Test]
        public void InitialPieceLocationSetToBottomOfBoardFacingNorth()
        {
            PieceClass Result = new PieceClass();

            Assert.That(Result.getX(), Is.EqualTo(0));
            Assert.That(Result.getY(), Is.EqualTo(0));
            Assert.That(Result.getFDS(), Is.EqualTo("N"));
        }

        [Test]
        public void ShouldDisplayInitialPieceLocation()
        {
            PieceClass TestPiece = new PieceClass();

            var Result = TestPiece.Output();

            Assert.That(Result, Contains.Substring("0 0 N"));
        }

        [Test]
        public void CheckExampleInputs()
        {
            BoardGameClass gameTest = new BoardGameClass();

            string[] strInputArray = new string[] { "MRMLMRM", "RMMMLMM", "MMMMM"};
            string[] strExpectedResults = new string[] { "2 2 E", "3 2 N", "0 4 N" };
            string Result;

            for(int i = 0; i < strInputArray.Length; i++)
            {
                gameTest.ProcessCommands(strInputArray[i]);
                Result = gameTest.pieceOne.Output();
                Console.WriteLine(gameTest.pieceOne.Output());

                Assert.That(Result, Is.EqualTo(strExpectedResults[i]));

                // Move piece back to its starting position (0 0 N)
                gameTest.Move('E');
            }
        }
    }
}
