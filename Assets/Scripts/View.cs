using System.Data;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class View : MonoBehaviour
{
    Controller controller;

    [SerializeField] GameObject squareprefab;
    [SerializeField] Transform gridParent;
    

    private void Awake()
    {
        controller = new Controller(this);
    }

    public void CreateGrid(ref Board board, int rows, int cols)
    {
        for(int i=0; i < rows; i++)
        {
            for(int j=0; j < cols; j++)
            {
                GameObject newSquare = Instantiate(squareprefab, gridParent);
                int2 coor = board.GetSquare(i, j).coor;
                newSquare.GetComponentInChildren<TextMeshProUGUI>().text = $"{coor.x},{coor.y}";
            }

        }

    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
