using Unity.Mathematics;
using UnityEngine;

public class Controller
{
    View view;
    Board board;

    const int ROWS = 9;
    const int COLS = 9;

    Team currentTurn = Team.White;
    Piece selectedPiece = null;

    public Controller(View view)
    {
        this.view = view;
        board = new Board(ROWS, COLS);
        view.CreateGrid(ref board, ROWS, COLS);
        SetBoard();
        //view.RemovePiece(new int2(0, 1)); //Borra piezas
        //view.RemovePiece(new int2(0, 2));
        //Debug.Log(board.GetSquare(0, 0).piece);

    }

    void SetBoard()
    {
        //BlackTeam
        CreatePiece(new int2(0,0), PieceType.Spear, Team.Black);
        CreatePiece(new int2(0,1), PieceType.Horse, Team.Black);
        CreatePiece(new int2(0,2), PieceType.Silver, Team.Black);
        CreatePiece(new int2(0,3), PieceType.Gold, Team.Black);
        CreatePiece(new int2(0,4), PieceType.King, Team.Black);
        CreatePiece(new int2(0,5), PieceType.Gold, Team.Black);
        CreatePiece(new int2(0,6), PieceType.Silver, Team.Black);
        CreatePiece(new int2(0,7), PieceType.Horse, Team.Black);
        CreatePiece(new int2(0,8), PieceType.Spear, Team.Black);

        CreatePiece(new int2(1,1), PieceType.Tower, Team.Black);
        CreatePiece(new int2(1,7), PieceType.Bishop, Team.Black);

        CreatePiece(new int2(2,0), PieceType.Pawn, Team.Black);
        CreatePiece(new int2(2,1), PieceType.Pawn, Team.Black);
        CreatePiece(new int2(2,2), PieceType.Pawn, Team.Black);
        CreatePiece(new int2(2,3), PieceType.Pawn, Team.Black);
        CreatePiece(new int2(2,4), PieceType.Pawn, Team.Black);
        CreatePiece(new int2(2,5), PieceType.Pawn, Team.Black);
        CreatePiece(new int2(2,6), PieceType.Pawn, Team.Black);
        CreatePiece(new int2(2,7), PieceType.Pawn, Team.Black);
        CreatePiece(new int2(2,8), PieceType.Pawn, Team.Black);


        //WhiteTeam

        CreatePiece(new int2(6, 0), PieceType.Pawn, Team.White);
        CreatePiece(new int2(6, 1), PieceType.Pawn, Team.White);
        CreatePiece(new int2(6, 2), PieceType.Pawn, Team.White);
        CreatePiece(new int2(6, 3), PieceType.Pawn, Team.White);
        CreatePiece(new int2(6, 4), PieceType.Pawn, Team.White);
        CreatePiece(new int2(6, 5), PieceType.Pawn, Team.White);
        CreatePiece(new int2(6, 6), PieceType.Pawn, Team.White);
        CreatePiece(new int2(6, 7), PieceType.Pawn, Team.White);
        CreatePiece(new int2(6, 8), PieceType.Pawn, Team.White);

        CreatePiece(new int2(7, 1), PieceType.Bishop, Team.White);
        CreatePiece(new int2(7, 7), PieceType.Tower, Team.White);

        CreatePiece(new int2(8, 0), PieceType.Spear, Team.White);
        CreatePiece(new int2(8, 1), PieceType.Horse, Team.White);
        CreatePiece(new int2(8, 2), PieceType.Silver, Team.White);
        CreatePiece(new int2(8, 3), PieceType.Gold, Team.White);
        CreatePiece(new int2(8, 4), PieceType.King, Team.White);
        CreatePiece(new int2(8, 5), PieceType.Gold, Team.White);
        CreatePiece(new int2(8, 6), PieceType.Silver, Team.White);
        CreatePiece(new int2(8, 7), PieceType.Horse, Team.White);
        CreatePiece(new int2(8, 8), PieceType.Spear, Team.White);
    }

    public void SelectSquare(int2 gridPos)
    {
        ref Square selectedSquare = ref board.GetSquare(gridPos.x, gridPos.y);
        if(selectedPiece != null)
        {
            if (selectedSquare.piece == null) MoveSelectedPiece(selectedSquare);
            else if (selectedSquare.piece.team == currentTurn) selectedPiece = selectedSquare.piece;
            else
            {
                EatPiece(selectedSquare.coor);
                MoveSelectedPiece(selectedSquare);
            }
        }
        else
        {
            if (selectedSquare.piece == null) return;
            if (selectedSquare.piece.team != currentTurn) return;
            selectedPiece = selectedSquare.piece;
        }
    }

    void EatPiece(int2 coor)
    {

    }

    private void MoveSelectedPiece(Square selectedSquare)
    {
        RemovePiece(selectedPiece.coor);
        AddPiece(ref selectedPiece, selectedSquare.coor);
        selectedPiece = null;
    }

    void CreatePiece(int2 coor, PieceType type, Team team)
    {
        Piece piece = type switch
        {
            PieceType.Pawn => new Pawn(coor, team),
            PieceType.Spear => new Spear(coor, team),
            PieceType.Horse => new Horse(coor, team),
            PieceType.Silver => new Silver(coor, team),
            PieceType.Gold => new Gold(coor, team),
            PieceType.Tower => new Tower(coor, team),
            PieceType.Bishop => new Bishop(coor, team),
            PieceType.King => new King(coor, team),
            _ => null
        };
        board.GetSquare(coor.x, coor.y).piece = piece;
        view.AddPiece(ref piece, coor);

    }

    void RemovePiece(int2 coor)
    {
        board.GetSquare(coor.x,coor.y).piece = null;
        view.RemovePiece(coor);
    }

    void AddPiece(ref Piece piece, int2 coor)
    {
        board.GetSquare(coor.x, coor.y).piece = piece;
        piece.coor = coor;
        view.AddPiece(ref piece, coor);
    }

    ~Controller(){}
    
}
