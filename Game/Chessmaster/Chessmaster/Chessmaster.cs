using System;
using System.IO;
using System.Text;
using System.Security;
using System.Threading;
using System.Speech.Synthesis;
using System.Collections.Generic;

// 
// kato stigne pe6ka kraino, trqbva zadyljitelno da se smeni (vij dali e izpylneno)
// ne kazva posledniq hod
// nqma an pasan
// nqma dvete rokadi (te sa samo za playerToMove !)
// lipsvat nqkolko game moda
// lipsva meniu za na4alen izbor
// lipsva help s pozvoleni hodove i klavi6i za igra v reazli4nite game modove
// lo6o ::: pyrvo kazva hoda ot moveLista i 4ak togava printira teksta
// napravi masata da se vyrti s komanda za vseki pootdelno i da se pazi zanapred
// castle : "White has castled kingside (0-0) and Black has castled queenside (0-0-0)."
// 

public class Chessmaster
{
    #region Variables

    #region Read Move

    public static string gotMove = "";

    public static Queue<char> readMove = new Queue<char>();
    public static string specialFigures = "NBRQK";
    public static string allColumns = "abcdefgh";

    public enum Castles { noCastle, castleKingsideFreeMove, castleKingsideCheckMove, castleKingsideDrawMove, castleKingsideCheckmateMove, castleQueensideFreeMove, castleQueensideCheckMove, castleQueensideDrawMove, castleQueensideCheckmateMove };
    public static string someCastleMove = "O-O";
    public static string castleKingsideFreeMove = "O-O";
    public static string castleKingsideCheckMove = "O-O+";
    public static string castleKingsideDrawMove = "O-O=";
    public static string castleKingsideCheckmateMove = "O-O#";
    public static string castleQueensideFreeMove = "O-O-O";
    public static string castleQueensideCheckMove = "O-O-O+";
    public static string castleQueensideDrawMove = "O-O-O=";
    public static string castleQueensideCheckmateMove = "O-O-O#";
    public static Castles castle = Castles.noCastle;
    public static bool castleKingside = false;
    public static bool castleQueenside = false;

    public static List<List<List<int>>> savePositions = new List<List<List<int>>>();

    public static bool takes;

    public static States give;

    public static List<List<bool>> castlePossibility = new List<List<bool>>();

    #endregion

    #region Figure's Units

    public const int whiteDecimals = 10;
    public const int blackDecimals = 30;
    public const int kingUnits = 6;
    public const int queenUnits = 5;
    public const int rookUnits = 4;
    public const int bishopUnits = 3;
    public const int nightUnits = 2;
    public const int pawnUnits = 1;

    #endregion

    #region Battlefield

    public static int[,] battlefield = new int[8, 8];
    public static List<List<List<int>>> figures = new List<List<List<int>>>();
    public enum States { Free, Check, Draw, Checkmate };
    public static List<List<string>> lastMoves = new List<List<string>>();

    #endregion

    #region Players

    public static int playWith = 0;
    public static int oppositePlayWith = 1;

    public static int playerToMove = 0;
    public static int oppositePlayer = 1;

    public static States realState = States.Free;

    public static int currentMove = 0;

    #endregion

    #region Console Colors

    public static ConsoleColor colorOfOuterFrameBackground = ConsoleColor.DarkGray;
    public static ConsoleColor colorOfOuterFrameForeground = ConsoleColor.White;
    public static ConsoleColor colorOfInternalFrame = ConsoleColor.Black;
    public static ConsoleColor colorOfWhiteFields = ConsoleColor.DarkGray;
    public static ConsoleColor colorOfBlackFields = ConsoleColor.Black;
    public static ConsoleColor colorOfWhiteFigures = ConsoleColor.White;
    public static ConsoleColor colorOfBlackFigures = ConsoleColor.Red;
    public static ConsoleColor colorOfMovesBackground = ConsoleColor.Black;
    public static ConsoleColor colorOfMovesForeground = ConsoleColor.White;

    #endregion

    #region Move this variables to the other or created new groups

    public static bool exchange = false;
    public static int exchangeWith;

    public static bool oppositeCheck;
    public static bool oppositeAvoid;

    public static List<List<int>> lookOnlyThisPositions = new List<List<int>>();
    public static int oppositeFigureIndex;

    public static bool willBeUnderCheck;

    public static int king;
    public static int kingRow;
    public static int kingColumn;
    public static int oppositeKing;
    public static int oppositeKingRow;
    public static int oppositeKingColumn;
    public static int theRow;
    public static int rowChange;
    public static int theColumn;
    public static int columnChange;
    public static int figureRow;
    public static int figureColumn;

    public static int theField;

    //public static int figureMovement;
    public static int rowMovement;
    public static int columnMovement;

    public static int order;

    public static bool makeNextCheck;

    public static bool canJump;

    public static List<string> moveList = new List<string>();

    #endregion

    public static StringBuilder sentence = new StringBuilder();
    public static bool sayLastMove = false;

    public enum GameModes { PlayerVsPlayer, PlayerVsComputer, ComputerVsComputer, CheckMoveList };
    public static GameModes gameMode;

    public static DateTime startTime;

    #endregion

    public static void Main()
    {
        startTime = DateTime.Now;
        Play();
        Console.WriteLine("\n{0}", DateTime.Now - startTime);
    }

    public static void Play()
    {
        //gameMode = ChooseGameMode();
        //gameMode = GameModes.PlayerVsPlayer;
        gameMode = GameModes.CheckMoveList;
        switch (gameMode)
        {
            case GameModes.PlayerVsPlayer: { PlayerVsPlayer(); break; }
            case GameModes.PlayerVsComputer: { PlayerVsComputer(); break; }
            case GameModes.ComputerVsComputer: { ComputerVsComputer(); break; }
            case GameModes.CheckMoveList: { CheckMoveList(); break; }
            default: break;
        }        
    }

    #region Game Modes

    public static GameModes ChooseGameMode()
    {

        return GameModes.PlayerVsPlayer;
    }

    public static void PlayerVsPlayer()
    {
        playWith = 0;
        StartingPosition();
        while ((realState != States.Draw) && (realState != States.Checkmate))
        {
            NextMove();
            ChangePlayerToMove();
        }

        FullPrint();
    }

    public static void PlayerVsComputer()
    {

    }

    public static void ComputerVsComputer()
    {

    }

    public static void CheckMoveList()
    {
        if (!FillMoveList())
            return;

        playWith = 0;   //ChooseFigures(); v ob6tiq slu4ai pri izbora !!!
        StartingPosition();
        while ((realState != States.Draw) && (realState != States.Checkmate))
        {
            NextMove(moveList[currentMove]); //NextMove(); v ob6tiq slu4ai pri izbora !!!
            ChangePlayerToMove();
        }

        FullPrint();
    }

    #endregion

    #region Initial

    public static void ChooseFigures()
    {
        string choise;

        do
        {
            Console.Clear();
            Console.Write("Choose 'White' or 'Black' to play: ");
            choise = Console.ReadLine();
            if (choise == "White")
            {
                playWith = 0;
                oppositePlayWith = 1;
                break;
            }
            else if (choise == "Black")
            {
                playWith = 1;
                oppositePlayWith = 0;
                break;
            }
        } while (true);
    }

    public static void StartingPosition()
    {
        #region Console

        Console.WindowWidth = 153;
        Console.BufferWidth = 153;
        Console.WindowHeight = 32;
        Console.BufferHeight = 32;
        Console.SetCursorPosition(0, 0);
        Console.BackgroundColor = colorOfMovesBackground;
        Console.ForegroundColor = colorOfMovesForeground;
        Console.Clear();

        #endregion

        #region Table

        battlefield[0, 0] = battlefield[0, 7] = whiteDecimals + rookUnits;
        battlefield[0, 1] = battlefield[0, 6] = whiteDecimals + nightUnits;
        battlefield[0, 2] = battlefield[0, 5] = whiteDecimals + bishopUnits;
        battlefield[0, 3] = whiteDecimals + queenUnits;
        battlefield[0, 4] = whiteDecimals + kingUnits;

        for (int column = 0; column <= 7; column++)
            battlefield[1, column] = whiteDecimals + pawnUnits;

        for (int row = 2; row <= 5; row++)
            for (int column = 0; column <= 7; column++)
                battlefield[row, column] = 0;

        for (int column = 0; column <= 7; column++)
            battlefield[6, column] = blackDecimals + pawnUnits;

        battlefield[7, 0] = battlefield[7, 7] = blackDecimals + rookUnits;
        battlefield[7, 1] = battlefield[7, 6] = blackDecimals + nightUnits;
        battlefield[7, 2] = battlefield[7, 5] = blackDecimals + bishopUnits;
        battlefield[7, 3] = blackDecimals + queenUnits;
        battlefield[7, 4] = blackDecimals + kingUnits;

        #endregion

        #region Figures

        #region White

        figures.Add(new List<List<int>>(0));

        figures[0].Add(new List<int>(0));
        figures[0].Add(new List<int>(1));
        figures[0].Add(new List<int>(2));

        figures[0][0].Add(whiteDecimals + kingUnits);
        figures[0][0].Add(whiteDecimals + queenUnits);
        figures[0][0].Add(whiteDecimals + rookUnits);
        figures[0][0].Add(whiteDecimals + rookUnits);
        figures[0][0].Add(whiteDecimals + bishopUnits);
        figures[0][0].Add(whiteDecimals + bishopUnits);
        figures[0][0].Add(whiteDecimals + nightUnits);
        figures[0][0].Add(whiteDecimals + nightUnits);
        for (int whitePawn = 0; whitePawn <= 7; whitePawn++)
            figures[0][0].Add(whiteDecimals + pawnUnits);

        for (int rowOfWhiteSpecialFigure = 0; rowOfWhiteSpecialFigure <= 7; rowOfWhiteSpecialFigure++)
            figures[0][1].Add(0);
        for (int rowOfWhitePawn = 0; rowOfWhitePawn <= 7; rowOfWhitePawn++)
            figures[0][1].Add(1);

        figures[0][2].Add(4);
        figures[0][2].Add(3);
        figures[0][2].Add(0);
        figures[0][2].Add(7);
        figures[0][2].Add(2);
        figures[0][2].Add(5);
        figures[0][2].Add(1);
        figures[0][2].Add(6);
        for (int columnOfWhitePawn = 0; columnOfWhitePawn <= 7; columnOfWhitePawn++)
            figures[0][2].Add(columnOfWhitePawn);

        #endregion

        #region Black

        figures.Add(new List<List<int>>(1));

        figures[1].Add(new List<int>(0));
        figures[1].Add(new List<int>(1));
        figures[1].Add(new List<int>(2));

        figures[1][0].Add(blackDecimals + kingUnits);
        figures[1][0].Add(blackDecimals + queenUnits);
        figures[1][0].Add(blackDecimals + rookUnits);
        figures[1][0].Add(blackDecimals + rookUnits);
        figures[1][0].Add(blackDecimals + bishopUnits);
        figures[1][0].Add(blackDecimals + bishopUnits);
        figures[1][0].Add(blackDecimals + nightUnits);
        figures[1][0].Add(blackDecimals + nightUnits);
        for (int blackPawn = 0; blackPawn <= 7; blackPawn++)
            figures[1][0].Add(blackDecimals + pawnUnits);

        for (int rowOfBlackSpecialFigure = 0; rowOfBlackSpecialFigure <= 7; rowOfBlackSpecialFigure++)
            figures[1][1].Add(7);
        for (int rowOfBlackPawn = 0; rowOfBlackPawn <= 7; rowOfBlackPawn++)
            figures[1][1].Add(6);

        figures[1][2].Add(4);
        figures[1][2].Add(3);
        figures[1][2].Add(0);
        figures[1][2].Add(7);
        figures[1][2].Add(2);
        figures[1][2].Add(5);
        figures[1][2].Add(1);
        figures[1][2].Add(6);
        for (int columnOfBlackPawn = 0; columnOfBlackPawn <= 7; columnOfBlackPawn++)
            figures[1][2].Add(columnOfBlackPawn);

        #endregion

        #endregion

        #region Moves

        #region Last moves

        lastMoves.Add(new List<string>(0));
        lastMoves.Add(new List<string>(1));

        #endregion

        #region Save positions

        savePositions.Add(new List<List<int>>(0));
        savePositions.Add(new List<List<int>>(1));

        savePositions[0].Add(new List<int>(0));
        savePositions[0].Add(new List<int>(1));

        savePositions[1].Add(new List<int>(0));
        savePositions[1].Add(new List<int>(1));

        savePositions[0][0].Add(0);
        savePositions[0][0].Add(0);
        savePositions[0][0].Add(0);
        savePositions[0][0].Add(0);

        savePositions[0][1].Add(0);
        savePositions[0][1].Add(0);
        savePositions[0][1].Add(0);
        savePositions[0][1].Add(0);

        savePositions[1][0].Add(0);
        savePositions[1][0].Add(0);
        savePositions[1][0].Add(0);
        savePositions[1][0].Add(0);

        savePositions[1][1].Add(0);
        savePositions[1][1].Add(0);
        savePositions[1][1].Add(0);
        savePositions[1][1].Add(0);

        #endregion

        #region Look only this positions

        lookOnlyThisPositions.Add(new List<int>(0));
        lookOnlyThisPositions.Add(new List<int>(1));
        lookOnlyThisPositions.Add(new List<int>(2));

        #endregion

        #region Castle

        castlePossibility.Add(new List<bool>(0));
        castlePossibility.Add(new List<bool>(1));

        castlePossibility[0].Add(true);
        castlePossibility[0].Add(true);
        castlePossibility[0].Add(true);

        castlePossibility[1].Add(true);
        castlePossibility[1].Add(true);
        castlePossibility[1].Add(true);

        #endregion

        #endregion
    }

    public static bool FillMoveList()
    {
        try
        {
            using (StreamReader reader = new StreamReader("text.txt", Encoding.GetEncoding("windows-1251")))
            {
                string line;

                do
                {
                    line = reader.ReadLine();
                    if (line == null)
                        break;

                    moveList.Add(line);
                } while (true);
            }

            if (moveList.Count < 1)
            {
                Console.WriteLine("The movelist file is empty!");
                return false;
            }

            return true;
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("The path is null!");
            return false;
        }
        catch (ArgumentException)
        {
            Console.WriteLine("The path is a zero-length string, contains only white space, or contains one or more invalid characters as defined by InvalidPathChars!");
            return false;
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters!");
            return false;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file specified in path was not found!");
            return false;
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("The specified path is invalid (for example, it is on an unmapped drive)!");
            return false;
        }
        catch (IOException)
        {
            Console.WriteLine("An I/O error occurred while opening the file!");
            return false;
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("The path specified a file that is read-only.\n"
                            + "-or-\n"
                            + "This operation is not supported on the current platform.\n"
                            + "-or-\n"
                            + "path specified a directory.\n"
                            + "-or- \n"
                            + "The caller does not have the required permission!");
            return false;
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("The path is in an invalid format!");
            return false;
        }
        catch (SecurityException)
        {
            Console.WriteLine("The caller does not have the required permission!");
            return false;
        }
        catch
        {
            Console.WriteLine("Fatal Error!");
            return false;
        }
    }

    #endregion

    #region Print

    public static void FullPrint()
    {
        Console.Clear();
        if (playWith == 0)
            PrintWhiteBattlefield();
        else
            PrintBlackBattlefield();

        PrintLastMoves();
    }

    public static void PrintWhiteBattlefield()
    {
        Console.SetCursorPosition(0, 0);
        Console.BackgroundColor = colorOfOuterFrameBackground;
        Console.ForegroundColor = colorOfOuterFrameForeground;
        Console.WriteLine(new string(' ', 48));
        Console.WriteLine(new string(' ', 4) + "  a  " + "  b  " + "  c  " + "  d  " + "  e  " + "  f  " + "  g  " + "  h  " + new string(' ', 4));
        Console.WriteLine(new string(' ', 48));
        Console.Write(new string(' ', 3));
        Console.BackgroundColor = colorOfInternalFrame;
        Console.Write(new string(' ', 42));
        Console.BackgroundColor = colorOfOuterFrameBackground;
        Console.WriteLine(new string(' ', 3));

        for (int i = 7; i >= 0; i--)
        {
            for (int k = 1; k <= 3; k++)
            {
                Console.BackgroundColor = colorOfOuterFrameBackground;
                Console.ForegroundColor = colorOfOuterFrameForeground;
                Console.Write("{0}{1}{2}", new string(' ', 1), k == 2 ? (i + 1).ToString() : " ", new string(' ', 1));
                Console.BackgroundColor = colorOfInternalFrame;
                Console.Write(new string(' ', 1));
                for (int j = 0; j <= 7; j++)
                {
                    if ((i + j) % 2 == 0)
                        Console.BackgroundColor = colorOfBlackFields;
                    else
                        Console.BackgroundColor = colorOfWhiteFields;

                    if ((k == 2) && (battlefield[i, j] != 0))
                        Console.Write("  {0}  ", Figure(battlefield[i, j]));
                    else
                        Console.Write(new string(' ', 5));
                }

                Console.BackgroundColor = colorOfInternalFrame;
                Console.Write(new string(' ', 1));
                Console.BackgroundColor = colorOfOuterFrameBackground;
                Console.ForegroundColor = colorOfOuterFrameForeground;
                Console.WriteLine("{0}{1}{2}", new string(' ', 1), k == 2 ? (i + 1).ToString() : " ", new string(' ', 1));
            }
        }

        Console.Write(new string(' ', 3));
        Console.BackgroundColor = colorOfInternalFrame;
        Console.Write(new string(' ', 42));
        Console.BackgroundColor = colorOfOuterFrameBackground;
        Console.WriteLine(new string(' ', 3));
        Console.WriteLine(new string(' ', 48));
        Console.WriteLine(new string(' ', 4) + "  a  " + "  b  " + "  c  " + "  d  " + "  e  " + "  f  " + "  g  " + "  h  " + new string(' ', 4));
        Console.Write(new string(' ', 48));
    }

    public static void PrintBlackBattlefield()
    {
        Console.SetCursorPosition(0, 0);
        Console.BackgroundColor = colorOfOuterFrameBackground;
        Console.ForegroundColor = colorOfOuterFrameForeground;
        Console.WriteLine(new string(' ', 48));
        Console.WriteLine(new string(' ', 4) + "  h  " + "  g  " + "  f  " + "  e  " + "  d  " + "  c  " + "  b  " + "  a  " + new string(' ', 4));
        Console.WriteLine(new string(' ', 48));
        Console.Write(new string(' ', 3));
        Console.BackgroundColor = colorOfInternalFrame;
        Console.Write(new string(' ', 42));
        Console.BackgroundColor = colorOfOuterFrameBackground;
        Console.WriteLine(new string(' ', 3));

        for (int i = 0; i <= 7; i++)
        {
            for (int k = 1; k <= 3; k++)
            {
                Console.BackgroundColor = colorOfOuterFrameBackground;
                Console.ForegroundColor = colorOfOuterFrameForeground;
                Console.Write("{0}{1}{2}", new string(' ', 1), k == 2 ? (i + 1).ToString() : " ", new string(' ', 1));
                Console.BackgroundColor = colorOfInternalFrame;
                Console.Write(new string(' ', 1));
                for (int j = 7; 0 <= j; j--)
                {
                    if ((i + j) % 2 == 0)
                        Console.BackgroundColor = colorOfBlackFields;
                    else
                        Console.BackgroundColor = colorOfWhiteFields;

                    if ((k == 2) && (battlefield[i, j] != 0))
                        Console.Write("  {0}  ", Figure(battlefield[i, j]));
                    else
                        Console.Write(new string(' ', 5));
                }

                Console.BackgroundColor = colorOfInternalFrame;
                Console.Write(new string(' ', 1));
                Console.BackgroundColor = colorOfOuterFrameBackground;
                Console.ForegroundColor = colorOfOuterFrameForeground;
                Console.WriteLine("{0}{1}{2}", new string(' ', 1), k == 2 ? (i + 1).ToString() : " ", new string(' ', 1));
            }
        }

        Console.Write(new string(' ', 3));
        Console.BackgroundColor = colorOfInternalFrame;
        Console.Write(new string(' ', 42));
        Console.BackgroundColor = colorOfOuterFrameBackground;
        Console.WriteLine(new string(' ', 3));
        Console.WriteLine(new string(' ', 48));
        Console.WriteLine(new string(' ', 4) + "  h  " + "  g  " + "  f  " + "  e  " + "  d  " + "  c  " + "  b  " + "  a  " + new string(' ', 4));
        Console.Write(new string(' ', 48));
    }

    public static char Figure(int field)
    {
        if ((figures[0][0][0] - kingUnits < field) && (field <= figures[0][0][0]))
            Console.ForegroundColor = colorOfWhiteFigures;
        else
            Console.ForegroundColor = colorOfBlackFigures;

        switch (field % 10)
        {
            case 1: return 'p';
            case 2: return 'N';
            case 3: return 'B';
            case 4: return 'R';
            case 5: return 'Q';
            case 6: return 'K';
            default: return ' ';
        }
    }

    public static void PrintLastMoves()
    {
        int nextWhiteToMove = 0;

        Console.BackgroundColor = colorOfMovesBackground;
        Console.ForegroundColor = colorOfMovesForeground;
        if (0 < lastMoves[0].Count)
        {
            for (int i = 0; i < lastMoves[0].Count; i++)
            {
                nextWhiteToMove = i + 1;
                Console.SetCursorPosition(49 + (i / 30) * 26, 1 + (i % 30));
                if (i < 90)
                    Console.Write("{0,2}. ", (i + 1));
                else
                    Console.Write("{0,3}. ", (i + 1));

                Console.Write("{0, -11}", lastMoves[0][i]);
                if (i < lastMoves[1].Count)
                    Console.Write("{0}", lastMoves[1][i]);
            }

            if (lastMoves[0].Count == lastMoves[1].Count)
            {
                Console.SetCursorPosition(49 + (nextWhiteToMove / 30) * 26, 1 + (nextWhiteToMove % 30));
                if (nextWhiteToMove < 90)
                    Console.Write("{0,2}. ", nextWhiteToMove + 1);
                else
                    Console.Write("{0,3}. ", nextWhiteToMove + 1);
            }
        }
        else
        {
            Console.SetCursorPosition(49, 1);
            Console.Write("{0,2}. ", (1));
        }
    }

    #endregion

    #region Player's Move

    public static void NextMove(string giveMove)
    {
        do
        {
            if (sayLastMove)
                SayMove();

            FullPrint();
            // Thread.Sleep(100);
            gotMove = giveMove;
            if (ReadMove() && IsLegalMove())
            {
                sayLastMove = true;
                MakeSentence();
                currentMove++;
                lastMoves[playerToMove].Add(gotMove);
                realState = give;
                break;
            }
        } while (true);
    }

    #region Talking

    public static void MakeSentence()
    {
        sentence.Clear();
        if (playerToMove == 0)
            sentence.Append("White ");
        else
            sentence.Append("Black ");

        switch (savePositions[playerToMove][0][0] % 10)
        {
            case kingUnits: { sentence.Append("king on "); break; }
            case queenUnits: { sentence.Append("queen on "); break; }
            case rookUnits: { sentence.Append("rook on "); break; }
            case bishopUnits: { sentence.Append("bishop on "); break; }
            case nightUnits: { sentence.Append("night on "); break; }
            case pawnUnits: { sentence.Append("pawn on "); break; }
            default: break;
        }

        sentence.Append((char)(savePositions[playerToMove][0][2] + 97));
        sentence.Append(" " + (savePositions[playerToMove][0][1] + 1));
        if (takes)
            sentence.Append(" takes");
        else
            sentence.Append(" moves to");

        sentence.Append(" " + (char)(savePositions[playerToMove][1][2] + 97));
        sentence.Append(" " + (savePositions[playerToMove][1][1] + 1));
        if (exchange)
        {
            sentence.Append(" exchange with ");
            switch (savePositions[playerToMove][0][0] % 10)
            {
                case kingUnits: { sentence.Append("king"); break; }
                case queenUnits: { sentence.Append("queen"); break; }
                case rookUnits: { sentence.Append("rook"); break; }
                case bishopUnits: { sentence.Append("bishop"); break; }
                case nightUnits: { sentence.Append("night"); break; }
                case pawnUnits: { sentence.Append("pawn"); break; }
                default: break;
            }
        }

        switch (give)
        {
            case States.Free: { sentence.Append("."); break; }
            case States.Check: { sentence.Append(" - Check!"); break; }
            case States.Draw: { sentence.Append(" - Draw!"); break; }
            case States.Checkmate: { sentence.Append(" - Checkmate!"); break; }
            default: break;
        }
    }

    public static void SayMove()
    {
        sayLastMove = false;
        using (SpeechSynthesizer say = new SpeechSynthesizer())
        {
            say.Rate = -4;
            say.SetOutputToDefaultAudioDevice();
            say.Speak(sentence.ToString());
        }
    }

    #endregion

    public static void NextMove()
    {
        do
        {
            if (sayLastMove)
                SayMove();

            FullPrint();
            gotMove = Console.ReadLine();
            if (ReadMove() && IsLegalMove())
            {
                sayLastMove = true;
                MakeSentence();
                currentMove++;
                lastMoves[playerToMove].Add(gotMove);
                realState = give;
                break;
            }
        } while (true);
    }

    public static bool ReadMove()
    {
        #region Castle

        if (gotMove.IndexOf(someCastleMove) != -1)
        {
            takes = false;
            exchange = false;
            if (gotMove == castleKingsideFreeMove)
            {
                give = States.Free;
                castle = Castles.castleKingsideFreeMove;
                return castleKingside = true;
            }
            else if (gotMove == castleKingsideCheckMove)
            {
                give = States.Check;
                castle = Castles.castleKingsideCheckMove;
                return castleKingside = true;
            }
            else if (gotMove == castleKingsideDrawMove)
            {
                give = States.Draw;
                castle = Castles.castleKingsideDrawMove;
                return castleKingside = true;
            }
            else if (gotMove == castleKingsideCheckmateMove)
            {
                give = States.Checkmate;
                castle = Castles.castleKingsideCheckmateMove;
                return castleKingside = true;
            }
            else if (gotMove == castleQueensideFreeMove)
            {
                give = States.Free;
                castle = Castles.castleQueensideFreeMove;
                return castleQueenside = true;
            }
            else if (gotMove == castleQueensideCheckMove)
            {
                give = States.Check;
                castle = Castles.castleQueensideCheckMove;
                return castleQueenside = true;
            }
            else if (gotMove == castleQueensideDrawMove)
            {
                give = States.Draw;
                castle = Castles.castleQueensideDrawMove;
                return castleQueenside = true;
            }
            else if (gotMove == castleQueensideCheckmateMove)
            {
                give = States.Checkmate;
                castle = Castles.castleQueensideCheckmateMove;
                return castleQueenside = true;
            }
        }

        #endregion

        if (gotMove.Length < 5)
            return false;

        readMove.Clear();
        for (int i = 0; i < gotMove.Length; i++)
            readMove.Enqueue(gotMove[i]);

        savePositions[playerToMove][0][0] = specialFigures.IndexOf(readMove.Peek());
        if (savePositions[playerToMove][0][0] != -1)
        {
            if (playerToMove == 0)
                savePositions[playerToMove][0][0] += whiteDecimals + nightUnits;
            else
                savePositions[playerToMove][0][0] += blackDecimals + nightUnits;

            readMove.Dequeue();
            if (readMove.Count < 5)
                return false;
        }
        else
        {
            if (playerToMove == 0)
                savePositions[playerToMove][0][0] = whiteDecimals + pawnUnits;
            else
                savePositions[playerToMove][0][0] = blackDecimals + pawnUnits;
        }

        savePositions[playerToMove][0][2] = allColumns.IndexOf(readMove.Peek());
        if (savePositions[playerToMove][0][2] == -1)
            return false;

        readMove.Dequeue();
        savePositions[playerToMove][0][1] = (int)readMove.Peek() - 49;
        if ((savePositions[playerToMove][0][1] < 0) || (7 < savePositions[playerToMove][0][1]))
            return false;

        readMove.Dequeue();
        if (readMove.Peek() == '-')
            takes = false;
        else if ((readMove.Peek() == 'x') || (readMove.Peek() == ':'))
            takes = true;
        else
            return false;

        readMove.Dequeue();
        savePositions[playerToMove][1][2] = allColumns.IndexOf(readMove.Peek());
        if (savePositions[playerToMove][1][2] == -1)
            return false;

        readMove.Dequeue();
        savePositions[playerToMove][1][1] = (int)readMove.Peek() - 49;
        if ((savePositions[playerToMove][1][1] < 0) || (7 < savePositions[playerToMove][1][1]))
            return false;

        savePositions[playerToMove][1][0] = battlefield[savePositions[playerToMove][1][1], savePositions[playerToMove][1][2]];
        exchange = false;
        readMove.Dequeue();
        if (readMove.Count == 0)
        {
            give = States.Free;
            return true;
        }
        else if (readMove.Count == 1)
        {
            if (readMove.Peek() == '#')
                give = States.Checkmate;
            else if (readMove.Peek() == '+')
                give = States.Check;
            else if (readMove.Peek() == '=')
                give = States.Draw;
            else
                return false;

            return true;
        }
        else if ((readMove.Count == 2) || (readMove.Count == 3))
        {
            if (readMove.Peek() != '=')
                return false;

            readMove.Dequeue();
            exchangeWith = specialFigures.IndexOf(readMove.Peek());
            if (exchangeWith == -1)
                return false;

            exchange = true;
            exchangeWith += figures[playerToMove][0][0] - kingUnits + nightUnits;
            if (readMove.Count == 1)
                return true;

            readMove.Dequeue();
            if (readMove.Peek() == '#')
                give = States.Checkmate;
            else if (readMove.Peek() == '+')
                give = States.Check;
            else if (readMove.Peek() == '=')
                give = States.Draw;
            else
                return false;

            return true;
        }
        else
            return false;
    }

    public static bool IsLegalMove()
    {
        //if (castle)
        //{
        //    if (Castle())
        //        return false;
        //}

        if (((savePositions[playerToMove][0][1] == savePositions[playerToMove][1][1]) && (savePositions[playerToMove][0][2] == savePositions[playerToMove][1][2]))
            || (battlefield[savePositions[playerToMove][0][1], savePositions[playerToMove][0][2]] != savePositions[playerToMove][0][0])
                || (!takes && (battlefield[savePositions[playerToMove][1][1], savePositions[playerToMove][1][2]] != 0)))
            return false;

        if (takes
            && ((battlefield[savePositions[playerToMove][1][1], savePositions[playerToMove][1][2]] <= figures[oppositePlayer][0][0] - kingUnits)
                || (figures[oppositePlayer][0][0] <= battlefield[savePositions[playerToMove][1][1], savePositions[playerToMove][1][2]])))
            return false;

        canJump = true;
        switch (savePositions[playerToMove][0][0] % 10)
        {
            case kingUnits: { canJump = JumpOfKing(playerToMove, savePositions[playerToMove][0][1], savePositions[playerToMove][0][2], savePositions[playerToMove][1][1], savePositions[playerToMove][1][2]); break; }
            case queenUnits: { canJump = JumpOfQueen(savePositions[playerToMove][0][1], savePositions[playerToMove][0][2], savePositions[playerToMove][1][1], savePositions[playerToMove][1][2]); break; }
            case rookUnits: { canJump = JumpOfRook(savePositions[playerToMove][0][1], savePositions[playerToMove][0][2], savePositions[playerToMove][1][1], savePositions[playerToMove][1][2]); break; }
            case bishopUnits: { canJump = JumpOfBishop(savePositions[playerToMove][0][1], savePositions[playerToMove][0][2], savePositions[playerToMove][1][1], savePositions[playerToMove][1][2]); break; }
            case nightUnits: { canJump = JumpOfNight(savePositions[playerToMove][0][1], savePositions[playerToMove][0][2], savePositions[playerToMove][1][1], savePositions[playerToMove][1][2]); break; }
            case pawnUnits: { canJump = JumpOfPawn(playerToMove, savePositions[playerToMove][0][1], savePositions[playerToMove][0][2], savePositions[playerToMove][1][1], savePositions[playerToMove][1][2], takes, exchange); break; }
            default: break;
        }

        if (!canJump)
            return false;

        savePositions[playerToMove][0][3] = ReturnIndexOfFigure(playerToMove);
        figures[playerToMove][1][savePositions[playerToMove][0][3]] = savePositions[playerToMove][1][1];
        figures[playerToMove][2][savePositions[playerToMove][0][3]] = savePositions[playerToMove][1][2];
        if (takes)
        {
            savePositions[playerToMove][1][3] = ReturnIndexOfFigure(oppositePlayer);
            RemoveFigureAtPosition(oppositePlayer, savePositions[playerToMove][1][3]);
        }

        if (exchange)
        {
            figures[playerToMove][0][savePositions[playerToMove][0][3]] = exchangeWith;
            MakeMove(0, savePositions[playerToMove][0][1], savePositions[playerToMove][0][2], exchangeWith, savePositions[playerToMove][1][1], savePositions[playerToMove][1][2]);
        }
        else
            MakeMove(0, savePositions[playerToMove][0][1], savePositions[playerToMove][0][2], savePositions[playerToMove][0][0], savePositions[playerToMove][1][1], savePositions[playerToMove][1][2]);

        makeNextCheck = true;
        oppositeCheck = Checks(oppositePlayer);
        if (Checks(playerToMove)
            || (((give == States.Free) || (give == States.Draw)) && oppositeCheck)
                || (((give == States.Check) || (give == States.Checkmate)) && !oppositeCheck))
            makeNextCheck = false;

        if (makeNextCheck)
        {
            oppositeAvoid = OppositeAvoid();
            if ((((give == States.Draw) || (give == States.Checkmate)) && oppositeAvoid)
                || ((give == States.Free) && !oppositeAvoid)
                    || ((give == States.Check) && !oppositeAvoid))
                makeNextCheck = false;
        }

        if (!makeNextCheck)
        {
            figures[playerToMove][0][savePositions[playerToMove][0][3]] = savePositions[playerToMove][0][0];
            figures[playerToMove][1][savePositions[playerToMove][0][3]] = savePositions[playerToMove][0][1];
            figures[playerToMove][2][savePositions[playerToMove][0][3]] = savePositions[playerToMove][0][2];
            MakeMove(savePositions[playerToMove][0][0], savePositions[playerToMove][0][1], savePositions[playerToMove][0][2], savePositions[playerToMove][1][0], savePositions[playerToMove][1][1], savePositions[playerToMove][1][2]);
            if (takes)
                AddFigureAtPosition(oppositePlayer, savePositions[playerToMove][1][3], savePositions[playerToMove][1][0], savePositions[playerToMove][1][1], savePositions[playerToMove][1][2]);
        }

        return makeNextCheck;
    }

    #region Jumps

    public static bool JumpOfKing(int player, int fromRow, int fromColumn, int toRow, int toColumn)
    {
        if ((-1 <= toRow - fromRow) && (toRow - fromRow <= 1) && (-1 <= toColumn - fromColumn) && (toColumn - fromColumn <= 1)
                && ((toRow - figures[1 - player][1][0] < -1) || (1 < toRow - figures[1 - player][1][0]) || (toColumn - figures[1 - player][2][0] < -1) || (1 < toColumn - figures[1 - player][2][0])))
            return true;
        else
            return false;
    }

    public static bool JumpOfQueen(int fromRow, int fromColumn, int toRow, int toColumn)
    {
        return (JumpOfRook(fromRow, fromColumn, toRow, toColumn) || JumpOfBishop(fromRow, fromColumn, toRow, toColumn));
    }

    public static bool JumpOfRook(int fromRow, int fromColumn, int toRow, int toColumn)
    {
        if (toRow == fromRow)
        {
            if (toColumn < fromColumn)
            {
                for (int j = toColumn + 1; j < fromColumn; j++)
                    if (battlefield[toRow, j] != 0)
                        return false;
            }
            else
                for (int j = fromColumn + 1; j < toColumn; j++)
                    if (battlefield[toRow, j] != 0)
                        return false;
        }
        else if (toColumn == fromColumn)
        {
            if (toRow < fromRow)
            {
                for (int i = toRow + 1; i < fromRow; i++)
                    if (battlefield[i, toColumn] != 0)
                        return false;
            }
            else
                for (int i = fromRow + 1; i < toRow; i++)
                    if (battlefield[i, toColumn] != 0)
                        return false;
        }

        return true;
    }

    public static bool JumpOfBishop(int fromRow, int fromColumn, int toRow, int toColumn)
    {
        if ((toRow == fromRow) || (toColumn == fromColumn))
            return false;

        if ((int)Math.Abs(toRow - fromRow) != (int)Math.Abs(toColumn - fromColumn))
            return false;

        columnChange = 1;
        if (toRow < fromRow)
        {
            if (toColumn > fromColumn)
                columnChange = -1;

            for (int i = toRow + 1; i < fromRow; i++)
                if (battlefield[i, toColumn + (i - toRow) * columnChange] != 0)
                    return false;
        }
        else
        {
            if (toColumn < fromColumn)
                columnChange = -1;

            for (int i = fromRow + 1; i < toRow; i++)
                if (battlefield[i, fromColumn + (i - fromRow) * columnChange] != 0)
                    return false;
        }

        return true;
    }

    public static bool JumpOfNight(int fromRow, int fromColumn, int toRow, int toColumn)
    {
        if (((toRow == fromRow - 2) && (toColumn == fromColumn - 1))
                || ((toRow == fromRow - 2) && (toColumn == fromColumn + 1))
                || ((toRow == fromRow - 1) && (toColumn == fromColumn - 2))
                || ((toRow == fromRow - 1) && (toColumn == fromColumn + 2))
                || ((toRow == fromRow + 1) && (toColumn == fromColumn - 2))
                || ((toRow == fromRow + 1) && (toColumn == fromColumn + 2))
                || ((toRow == fromRow + 2) && (toColumn == fromColumn - 1))
                || ((toRow == fromRow + 2) && (toColumn == fromColumn + 1)))
            return true;
        else
            return false;
    }

    public static bool JumpOfPawn(int player, int fromR, int fromColumn, int toRow, int toColumn, bool taking = false, bool exchanging = false)
    {
        if ((toRow == fromR) || (toColumn - fromColumn < -1) || (1 < toColumn - fromColumn) || (toRow - fromR < -2) || (2 < toRow - fromR))
            return false;

        if (taking && (toColumn == fromColumn))
            return false;

        if (!taking && (toColumn != fromColumn))
            return false;

        if (taking && ((toRow - fromR == 2) || (toRow - fromR == -2)))
            return false;

        if (player == 0)
        {
            if (toRow < fromR)
                return false;

            if ((toRow - fromR == 2) && (toColumn != fromColumn))
                return false;

            if ((fromR != 1) && (toRow - fromR == 2))
                return false;

            if (taking && (toRow - fromR == 2))
                return false;

            if ((toRow - fromR == 2) && (battlefield[fromR + 1, fromColumn] != 0))
                return false;

            if (exchanging && toRow < 7)
                return false;
        }
        else
        {
            if (toRow > fromR)
                return false;

            if ((fromR - toRow == 2) && (toColumn != fromColumn))
                return false;

            if ((fromR != 6) && (fromR - toRow == 2))
                return false;

            if (taking && (fromR - toRow == 2))
                return false;

            if ((fromR - toRow == 2) && (battlefield[fromR - 1, fromColumn] != 0))
                return false;

            if (exchanging && 0 < toRow)
                return false;
        }

        return true;
    }

    #endregion

    public static int ReturnIndexOfFigure(int player)
    {
        if (player == playerToMove)
            order = 0;
        else
            order = 1;

        for (int i = 0; i < figures[player][0].Count; i++)
            if ((figures[player][1][i] == savePositions[playerToMove][order][1]) && (figures[player][2][i] == savePositions[playerToMove][order][2]))
                return i;

        return -1;
    }

    #endregion

    public static void MakeMove(int fromFigure, int fromRow, int fromColumn, int toFigure, int toRow, int toColumn)
    {
        battlefield[fromRow, fromColumn] = fromFigure;
        battlefield[toRow, toColumn] = toFigure;
    }

    public static bool Checks(int player)
    {
        oppositeKing = figures[1 - player][0][0];
        kingRow = figures[player][1][0];
        kingColumn = figures[player][2][0];

        #region Queen and Rook

        for (theRow = kingRow - 1; (0 <= theRow) && (theRow <= 7); theRow--)
            if (battlefield[theRow, kingColumn] != 0)
            {
                if ((oppositeKing - battlefield[theRow, kingColumn] == kingUnits - queenUnits)
                        || (oppositeKing - battlefield[theRow, kingColumn] == kingUnits - rookUnits))
                    return true;

                break;
            }

        for (theRow = kingRow + 1; (0 <= theRow) && (theRow <= 7); theRow++)
            if (battlefield[theRow, kingColumn] != 0)
            {
                if ((oppositeKing - battlefield[theRow, kingColumn] == kingUnits - queenUnits)
                        || (oppositeKing - battlefield[theRow, kingColumn] == kingUnits - rookUnits))
                    return true;

                break;
            }

        for (theColumn = kingColumn - 1; (0 <= theColumn) && (theColumn <= 7); theColumn--)
            if (battlefield[kingRow, theColumn] != 0)
            {
                if ((oppositeKing - battlefield[kingRow, theColumn] == kingUnits - queenUnits)
                        || (oppositeKing - battlefield[kingRow, theColumn] == kingUnits - rookUnits))
                    return true;

                break;
            }

        for (theColumn = kingColumn + 1; (0 <= theColumn) && (theColumn <= 7); theColumn++)
            if (battlefield[kingRow, theColumn] != 0)
            {
                if ((oppositeKing - battlefield[kingRow, theColumn] == kingUnits - queenUnits)
                        || (oppositeKing - battlefield[kingRow, theColumn] == kingUnits - rookUnits))
                    return true;

                break;
            }

        #endregion

        #region Queen and Bishop

        theColumn = kingColumn;
        columnChange = -1;
        for (theRow = kingRow - 1; 0 <= theRow; theRow--)
        {
            theColumn += columnChange;
            if (theColumn < 0)
                break;

            if (battlefield[theRow, theColumn] != 0)
            {
                if ((oppositeKing - battlefield[theRow, theColumn] == kingUnits - queenUnits)
                    || (oppositeKing - battlefield[theRow, theColumn] == kingUnits - bishopUnits))
                    return true;

                break;
            }
        }

        theColumn = kingColumn;
        columnChange = 1;
        for (theRow = kingRow - 1; 0 <= theRow; theRow--)
        {
            theColumn += columnChange;
            if (7 < theColumn)
                break;

            if (battlefield[theRow, theColumn] != 0)
            {
                if ((oppositeKing - battlefield[theRow, theColumn] == kingUnits - queenUnits)
                    || (oppositeKing - battlefield[theRow, theColumn] == kingUnits - bishopUnits))
                    return true;

                break;
            }
        }

        theColumn = kingColumn;
        columnChange = -1;
        for (theRow = kingRow + 1; theRow <= 7; theRow++)
        {
            theColumn += columnChange;
            if (theColumn < 0)
                break;

            if (battlefield[theRow, theColumn] != 0)
            {
                if ((oppositeKing - battlefield[theRow, theColumn] == kingUnits - queenUnits)
                    || (oppositeKing - battlefield[theRow, theColumn] == kingUnits - bishopUnits))
                    return true;

                break;
            }
        }

        theColumn = kingColumn;
        columnChange = 1;
        for (theRow = kingRow + 1; theRow <= 7; theRow++)
        {
            theColumn += columnChange;
            if (7 < theColumn)
                break;

            if (battlefield[theRow, theColumn] != 0)
            {
                if ((oppositeKing - battlefield[theRow, theColumn] == kingUnits - queenUnits)
                    || (oppositeKing - battlefield[theRow, theColumn] == kingUnits - bishopUnits))
                    return true;

                break;
            }
        }

        #endregion

        #region Night

        if ((0 <= kingRow - 2) && (0 <= kingColumn - 1) && (oppositeKing - battlefield[kingRow - 2, kingColumn - 1] == kingUnits - nightUnits))
            return true;

        if ((0 <= kingRow - 1) && (0 <= kingColumn - 2) && (oppositeKing - battlefield[kingRow - 1, kingColumn - 2] == kingUnits - nightUnits))
            return true;

        if ((kingRow + 1 <= 7) && (0 <= kingColumn - 2) && (oppositeKing - battlefield[kingRow + 1, kingColumn - 2] == kingUnits - nightUnits))
            return true;

        if ((kingRow + 2 <= 7) && (0 <= kingColumn - 1) && (oppositeKing - battlefield[kingRow + 2, kingColumn - 1] == kingUnits - nightUnits))
            return true;

        if ((kingRow + 2 <= 7) && (kingColumn + 1 <= 7) && (oppositeKing - battlefield[kingRow + 2, kingColumn + 1] == kingUnits - nightUnits))
            return true;

        if ((kingRow + 1 <= 7) && (kingColumn + 2 <= 7) && (oppositeKing - battlefield[kingRow + 1, kingColumn + 2] == kingUnits - nightUnits))
            return true;

        if ((0 <= kingRow - 1) && (kingColumn + 2 <= 7) && (oppositeKing - battlefield[kingRow - 1, kingColumn + 2] == kingUnits - nightUnits))
            return true;

        if ((0 <= kingRow - 2) && (0 <= kingColumn + 1) && (oppositeKing - battlefield[kingRow - 2, kingColumn + 1] == kingUnits - nightUnits))
            return true;

        #endregion

        #region Pawn

        if (battlefield[kingRow, kingColumn] == whiteDecimals + kingUnits)
        {
            if ((kingRow + 1 <= 7) && (0 <= kingColumn - 1) && (oppositeKing - battlefield[kingRow + 1, kingColumn - 1] == kingUnits - pawnUnits))
                return true;

            if ((kingRow + 1 <= 7) && (kingColumn + 1 <= 7) && (oppositeKing - battlefield[kingRow + 1, kingColumn + 1] == kingUnits - pawnUnits))
                return true;
        }
        else
        {
            if ((0 <= kingRow - 1) && (0 <= kingColumn - 1) && (oppositeKing - battlefield[kingRow - 1, kingColumn - 1] == kingUnits - pawnUnits))
                return true;

            if ((0 <= kingRow - 1) && (kingColumn + 1 <= 7) && (oppositeKing - battlefield[kingRow - 1, kingColumn + 1] == kingUnits - pawnUnits))
                return true;
        }

        #endregion

        return false;
    }

    #region Opposite's Chance

    public static bool OppositeAvoid()
    {
        for (oppositeFigureIndex = 0; oppositeFigureIndex < figures[oppositePlayer][0].Count; oppositeFigureIndex++)
        {
            ClearAllFieldsForLooking();
            if (IsThereLegalMoveThisFigure())
                return true;
        }

        return false;
    }

    #region Looking array

    public static void ClearAllFieldsForLooking()
    {
        lookOnlyThisPositions[0].Clear();
        lookOnlyThisPositions[1].Clear();
        lookOnlyThisPositions[2].Clear();
    }

    public static void AddFieldForLooking(int figure, int row, int column)
    {
        lookOnlyThisPositions[0].Add(figure);
        lookOnlyThisPositions[1].Add(row);
        lookOnlyThisPositions[2].Add(column);
    }

    #endregion

    #region Is there Legal move this Figure

    public static bool IsThereLegalMoveThisFigure()
    {
        SaveOppositePositionsWithoutRealTakes(0, figures[oppositePlayer][0][oppositeFigureIndex], figures[oppositePlayer][1][oppositeFigureIndex], figures[oppositePlayer][2][oppositeFigureIndex]);

        king = figures[playerToMove][0][0];
        oppositeKing = figures[oppositePlayer][0][0];
        oppositeKingRow = figures[oppositePlayer][1][0];    //
        oppositeKingColumn = figures[oppositePlayer][2][0]; //

        figureRow = savePositions[oppositePlayer][0][1];
        figureColumn = savePositions[oppositePlayer][0][2];

        switch (figures[oppositePlayer][0][oppositeFigureIndex] % 10)
        {
            case kingUnits: return IsThereLegalMoveThisKing();
            case queenUnits: return IsThereLegalMoveThisQueen();
            case rookUnits: return IsThereLegalMoveThisRook();
            case bishopUnits: return IsThereLegalMoveThisBishop();
            case nightUnits: return IsThereLegalMoveThisNight();
            case pawnUnits: return IsThereLegalMoveThisPawn();
            default: return false;
        }
    }

    public static void SaveOppositePositionsWithoutRealTakes(int fromOrTo, int figure, int row, int column)
    {
        savePositions[oppositePlayer][fromOrTo][0] = figure;
        savePositions[oppositePlayer][fromOrTo][1] = row;
        savePositions[oppositePlayer][fromOrTo][2] = column;
    }

    public static bool IsThereLegalMoveThisKing()
    {
        KingMovement();
        for (int field = 0; field < lookOnlyThisPositions[0].Count; field++)
        {
            SaveOppositePositionsWithoutRealTakes(1, lookOnlyThisPositions[0][field], lookOnlyThisPositions[1][field], lookOnlyThisPositions[2][field]);
            figures[oppositePlayer][1][0] = savePositions[oppositePlayer][1][1];
            figures[oppositePlayer][2][0] = savePositions[oppositePlayer][1][2];
            MakeMove(0, savePositions[oppositePlayer][0][1], savePositions[oppositePlayer][0][2], savePositions[oppositePlayer][0][0], savePositions[oppositePlayer][1][1], savePositions[oppositePlayer][1][2]);
            willBeUnderCheck = Checks(oppositePlayer);
            figures[oppositePlayer][1][0] = savePositions[oppositePlayer][0][1];
            figures[oppositePlayer][2][0] = savePositions[oppositePlayer][0][2];
            MakeMove(savePositions[oppositePlayer][0][0], savePositions[oppositePlayer][0][1], savePositions[oppositePlayer][0][2], savePositions[oppositePlayer][1][0], savePositions[oppositePlayer][1][1], savePositions[oppositePlayer][1][2]);
            if (!willBeUnderCheck)
                return true;
        }

        return false;
    }

    public static bool IsThereLegalMoveThisQueen()
    {
        QeenMovement();
        for (int field = 0; field < lookOnlyThisPositions[0].Count; field++)
        {
            SaveOppositePositionsWithoutRealTakes(1, lookOnlyThisPositions[0][field], lookOnlyThisPositions[1][field], lookOnlyThisPositions[2][field]);
            MakeMove(0, savePositions[oppositePlayer][0][1], savePositions[oppositePlayer][0][2], savePositions[oppositePlayer][0][0], savePositions[oppositePlayer][1][1], savePositions[oppositePlayer][1][2]);
            willBeUnderCheck = Checks(oppositePlayer);
            MakeMove(savePositions[oppositePlayer][0][0], savePositions[oppositePlayer][0][1], savePositions[oppositePlayer][0][2], savePositions[oppositePlayer][1][0], savePositions[oppositePlayer][1][1], savePositions[oppositePlayer][1][2]);
            if (!willBeUnderCheck)
                return true;
        }

        return false;
    }

    public static bool IsThereLegalMoveThisRook()
    {
        RookMovement();
        for (int field = 0; field < lookOnlyThisPositions[0].Count; field++)
        {
            SaveOppositePositionsWithoutRealTakes(1, lookOnlyThisPositions[0][field], lookOnlyThisPositions[1][field], lookOnlyThisPositions[2][field]);
            MakeMove(0, savePositions[oppositePlayer][0][1], savePositions[oppositePlayer][0][2], savePositions[oppositePlayer][0][0], savePositions[oppositePlayer][1][1], savePositions[oppositePlayer][1][2]);
            willBeUnderCheck = Checks(oppositePlayer);
            MakeMove(savePositions[oppositePlayer][0][0], savePositions[oppositePlayer][0][1], savePositions[oppositePlayer][0][2], savePositions[oppositePlayer][1][0], savePositions[oppositePlayer][1][1], savePositions[oppositePlayer][1][2]);
            if (!willBeUnderCheck)
                return true;
        }

        return false;
    }

    public static bool IsThereLegalMoveThisBishop()
    {
        BishopMovement();
        for (int field = 0; field < lookOnlyThisPositions[0].Count; field++)
        {
            SaveOppositePositionsWithoutRealTakes(1, lookOnlyThisPositions[0][field], lookOnlyThisPositions[1][field], lookOnlyThisPositions[2][field]);
            MakeMove(0, savePositions[oppositePlayer][0][1], savePositions[oppositePlayer][0][2], savePositions[oppositePlayer][0][0], savePositions[oppositePlayer][1][1], savePositions[oppositePlayer][1][2]);
            willBeUnderCheck = Checks(oppositePlayer);
            MakeMove(savePositions[oppositePlayer][0][0], savePositions[oppositePlayer][0][1], savePositions[oppositePlayer][0][2], savePositions[oppositePlayer][1][0], savePositions[oppositePlayer][1][1], savePositions[oppositePlayer][1][2]);
            if (!willBeUnderCheck)
                return true;
        }

        return false;
    }

    public static bool IsThereLegalMoveThisNight()
    {
        NightMovement();
        for (int field = 0; field < lookOnlyThisPositions[0].Count; field++)
        {
            SaveOppositePositionsWithoutRealTakes(1, lookOnlyThisPositions[0][field], lookOnlyThisPositions[1][field], lookOnlyThisPositions[2][field]);
            MakeMove(0, savePositions[oppositePlayer][0][1], savePositions[oppositePlayer][0][2], savePositions[oppositePlayer][0][0], savePositions[oppositePlayer][1][1], savePositions[oppositePlayer][1][2]);
            willBeUnderCheck = Checks(oppositePlayer);
            MakeMove(savePositions[oppositePlayer][0][0], savePositions[oppositePlayer][0][1], savePositions[oppositePlayer][0][2], savePositions[oppositePlayer][1][0], savePositions[oppositePlayer][1][1], savePositions[oppositePlayer][1][2]);
            if (!willBeUnderCheck)
                return true;
        }

        return false;
    }

    public static bool IsThereLegalMoveThisPawn()
    {
        PawnMovement();
        for (int field = 0; field < lookOnlyThisPositions[0].Count; field++)
        {
            SaveOppositePositionsWithoutRealTakes(1, lookOnlyThisPositions[0][field], lookOnlyThisPositions[1][field], lookOnlyThisPositions[2][field]);
            //if (JumpOfPawn(oppositePlayer, savePositions[oppositePlayer][0][1], savePositions[oppositePlayer][0][2], savePositions[oppositePlayer][1][1], savePositions[oppositePlayer][1][2], taking: (savePositions[oppositePlayer][1][0] != 0))) // ili e staroto, no mai4e gre6no 'taking: (savePositions[oppositePlayer][0][0] != 0'
            //{
            MakeMove(0, savePositions[oppositePlayer][0][1], savePositions[oppositePlayer][0][2], savePositions[oppositePlayer][0][0], savePositions[oppositePlayer][1][1], savePositions[oppositePlayer][1][2]);
            willBeUnderCheck = Checks(oppositePlayer);
            MakeMove(savePositions[oppositePlayer][0][0], savePositions[oppositePlayer][0][1], savePositions[oppositePlayer][0][2], savePositions[oppositePlayer][1][0], savePositions[oppositePlayer][1][1], savePositions[oppositePlayer][1][2]);
            if (!willBeUnderCheck)
                return true;
            //}
        }

        return false;
    }

    #endregion

    #region Movements

    public static void KingMovement()
    {
        kingRow = figures[playerToMove][1][0];
        kingColumn = figures[playerToMove][2][0];
        for (rowChange = -1; rowChange <= 1; rowChange++)
            for (columnChange = -1; columnChange <= 1; columnChange++)
                if (!((rowChange == 0) && (columnChange == 0)))
                {
                    rowMovement = figureRow + rowChange;
                    columnMovement = figureColumn + columnChange;
                    if ((0 <= rowMovement) && (rowMovement <= 7) && (0 <= columnMovement) && (columnMovement <= 7))
                    {
                        theField = battlefield[rowMovement, columnMovement];
                        if (((theField <= oppositeKing - kingUnits) || (oppositeKing < theField))
                                && (theField != king)
                                    && ((rowMovement - kingRow < -1) || (1 < rowMovement - kingRow) || (columnMovement - kingColumn < -1) || (1 < columnMovement - kingColumn)))
                            AddFieldForLooking(theField, rowMovement, columnMovement);
                    }
                }
    }

    public static void QeenMovement()
    {
        RookMovement();
        BishopMovement();
    }

    public static void RookMovement()
    {
        rowMovement = figureRow;
        for (columnMovement = figureColumn - 1; 0 <= columnMovement; columnMovement--)
        {
            theField = battlefield[rowMovement, columnMovement];
            if (((theField <= oppositeKing - kingUnits) || (oppositeKing < theField))
                    && (theField != king))
                AddFieldForLooking(theField, rowMovement, columnMovement);
            else
                break;
        }

        for (columnMovement = figureColumn + 1; columnMovement <= 7; columnMovement++)
        {
            theField = battlefield[rowMovement, columnMovement];
            if (((theField <= oppositeKing - kingUnits) || (oppositeKing < theField))
                    && (theField != king))
                AddFieldForLooking(theField, rowMovement, columnMovement);
            else
                break;
        }

        columnMovement = figureColumn;
        for (rowMovement = figureRow - 1; 0 <= rowMovement; rowMovement--)
        {
            theField = battlefield[rowMovement, columnMovement];
            if (((theField <= oppositeKing - kingUnits) || (oppositeKing < theField))
                    && (theField != king))
                AddFieldForLooking(theField, rowMovement, columnMovement);
            else
                break;
        }

        for (rowMovement = figureRow + 1; rowMovement <= 7; rowMovement++)
        {
            theField = battlefield[rowMovement, columnMovement];
            if (((theField <= oppositeKing - kingUnits) || (oppositeKing < theField))
                    && (theField != king))
                AddFieldForLooking(theField, rowMovement, columnMovement);
            else
                break;
        }
    }

    public static void BishopMovement()
    {
        BishopMovementAdding(-1, -1);
        BishopMovementAdding(-1, 1);
        BishopMovementAdding(1, -1);
        BishopMovementAdding(1, 1);
    }

    public static void BishopMovementAdding(int rChange, int cChange)
    {
        columnMovement = figureColumn;
        for (rowMovement = figureRow + rChange; (0 <= rowMovement) && (rowMovement <= 7); rowMovement += rChange)
        {
            columnMovement += cChange;
            if ((0 <= columnMovement) && (columnMovement <= 7))
            {
                theField = battlefield[rowMovement, columnMovement];
                if (((theField <= oppositeKing - kingUnits) || (oppositeKing < theField))
                        && (theField != king))
                    AddFieldForLooking(theField, rowMovement, columnMovement);
            }
            else
                break;
        }
    }

    public static void NightMovement()
    {
        NightMovementAdding(figureRow - 2, figureColumn - 1);
        NightMovementAdding(figureRow - 2, figureColumn + 1);
        NightMovementAdding(figureRow - 1, figureColumn - 2);
        NightMovementAdding(figureRow - 1, figureColumn + 2);
        NightMovementAdding(figureRow + 1, figureColumn - 2);
        NightMovementAdding(figureRow + 1, figureColumn + 2);
        NightMovementAdding(figureRow + 2, figureColumn - 1);
        NightMovementAdding(figureRow + 2, figureColumn + 1);

        //for (rowChange = -2; rowChange <= 2; rowChange++)
        //{
        //    rowMovement = figureRow + rowChange;
        //    if ((0 <= rowMovement) && (rowMovement <= 7))
        //        for (columnChange = -2; columnChange <= 2; columnChange++)
        //        {
        //            columnMovement = figureColumn + columnChange;
        //            theField = battlefield[rowMovement, columnMovement];
        //            if ((0 <= columnMovement) && (columnMovement <= 7)
        //                && (rowChange * rowChange + columnChange * columnChange == 5)
        //                    && ((theField <= oppositeKing - kingUnits) || (oppositeKing < theField))
        //                        && (theField != king))
        //                AddFieldForLooking(theField, rowMovement, columnMovement);
        //        }
        //}
    }

    public static void NightMovementAdding(int rMovement, int cMovement)
    {
        if ((0 <= rMovement) && (rMovement <= 7) && (0 <= cMovement) && (cMovement <= 7))
        {
            theField = battlefield[rMovement, cMovement];
            if (((theField <= oppositeKing - kingUnits) || (oppositeKing < theField))
                    && (theField != king))
                AddFieldForLooking(theField, rMovement, cMovement);
        }
    }

    public static void PawnMovement()
    {
        if (oppositePlayer == 1)
            rowChange = -1;
        else
            rowChange = 1;

        rowMovement = figureRow + rowChange;
        if ((0 <= rowMovement) && (rowMovement <= 7))
        {
            columnMovement = figureColumn - 1;
            for (columnChange = 0; columnChange <= 2; columnChange++)
            {
                columnMovement += columnChange;
                if ((0 <= columnMovement) && (columnMovement <= 7))
                {
                    theField = battlefield[rowMovement, columnMovement];
                    if (columnMovement == figureColumn)
                    {
                        if (theField == 0)
                        {
                            AddFieldForLooking(theField, rowMovement, columnMovement);
                            rowMovement += rowChange;
                            if ((0 <= rowMovement) && (rowMovement <= 7))
                            {
                                theField = battlefield[rowMovement, columnMovement];
                                if (theField == 0)
                                    AddFieldForLooking(theField, rowMovement, columnMovement);
                            }

                            rowMovement -= rowChange;
                        }
                    }
                    else
                    {
                        if (((oppositeKing - kingUnits < theField) && (theField < oppositeKing)))
                            AddFieldForLooking(theField, rowMovement, columnMovement);
                    }
                }
            }
        }
    }

    #endregion

    #endregion

    #region Players' Figures

    public static void MoveFigure(int player, int figure, int row, int column)
    {
        for (int i = 0; i < figures[player][0].Count; i++)
            if ((figures[player][0][i] == figure) && (figures[player][1][i] == row) && (figures[player][2][i] == column))
            {
                figures[player][1][i] = row;
                figures[player][2][i] = column;
                break;
            }
    }

    public static void RemoveFigure(int player, int figure, int row, int column)
    {
        for (int i = 0; i < figures[player][0].Count; i++)
            if ((figures[player][0][i] == figure) && (figures[player][1][i] == row) && (figures[player][2][i] == column))
            {
                RemoveFigureAtPosition(player, i);
                break;
            }
    }

    public static void RemoveFigureAtPosition(int player, int index)
    {
        figures[player][0].RemoveAt(index);
        figures[player][1].RemoveAt(index);
        figures[player][2].RemoveAt(index);
    }

    public static void AddFigure(int player, int figure, int row, int column)
    {
        int firstOfExchangeKind = figures[player][0].Count;

        for (int i = 0; i < figures[player][0].Count; i++)
            if (figures[player][0][i] <= figure)
            {
                firstOfExchangeKind = i;
                break;
            }

        AddFigureAtPosition(player, firstOfExchangeKind, figure, row, column);
    }

    public static void AddFigureAtPosition(int player, int index, int figure, int row, int column)
    {
        figures[player][0].Insert(index, figure);
        figures[player][1].Insert(index, row);
        figures[player][2].Insert(index, column);
    }

    #endregion

    public static void ChangePlayerToMove()
    {
        oppositePlayer = playerToMove;
        playerToMove = 1 - playerToMove;
    }
}