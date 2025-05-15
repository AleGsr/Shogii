using System.Data;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class View : MonoBehaviour
{
    Controller controller;

    [SerializeField] GameObject squareprefab;

    [Header("View Objects")]
    [SerializeField] Transform gridParent;
    [SerializeField] CementeryView whiteCementery;
    [SerializeField] CementeryView blackCementery;

    SquareView[,] gridView; 


    private void Awake()
    {
        controller = new Controller(this);
    }

    private void Start()
    {
        whiteCementery.SetCementeryView(this);
        blackCementery.SetCementeryView(this);
    }

    public void EnableTeamCemetary(Team team)
    {
        if(team == Team.White)
        {
            whiteCementery.EnableCementaryView();
            blackCementery.EnableCementaryView(false);
        }
        else
        {
            whiteCementery.EnableCementaryView(false);
            blackCementery.EnableCementaryView();
        }
    }

    public void CreateGrid(ref Board board, int rows, int cols)
    {
        gridView = new SquareView[rows, cols];
        for(int i=0; i < rows; i++)
        {
            for(int j=0; j < cols; j++)
            {
                gridView[i,j] = Instantiate(squareprefab, gridParent).GetComponent<SquareView>();
                int2 coor = board.GetSquare(i, j).coor;
                gridView[i, j].SetSquare(coor.x, coor.y, this);
            }

        }

    }


    public void AddPiece(ref Piece piece, int2 coor)
    {
        gridView[coor.x, coor.y].AddPiece(ref piece);
    }

    public void RemovePiece(int2 coor)
    {
        gridView[coor.x, coor.y].RemovrePiece();
    }

    public void SelectSquare(int2 gridPos)
    {
        //Debug.Log("Presionao");
        //Debug.Log(gridPos);
        controller.SelectSquare(gridPos);
    }

    public void SelectCementeryPiece(PieceType pieceType)
    {
        controller.SelectCemetarySquare(pieceType);

    }


    public void UpdateCementery(Team team, PieceType pieceType, int count)
    {
        if(team == Team.White) whiteCementery.UpdateCellView(pieceType, count);
        else blackCementery.UpdateCellView(pieceType, count);
    }

}
