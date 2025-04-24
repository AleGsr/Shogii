using UnityEngine;
using Unity.Mathematics;

public struct Board
{

    Square[,] grid;

    public Board(int rows, int cols)
    {
        grid = new Square[rows, cols];
        for (int i =0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                grid[i, j] = new Square(i,j);
            }
        }
        //Debug.Log(grid[3, 0].GetCoor);
    }

    public ref Square GetSquare(int row, int col) => ref grid[row, col];

}

public struct Square
{
    public int2 coor;
    public int2 GetCoor=> coor;

    public Square(int x, int y) 
    { 
        coor = new int2(x, y);
    }

}