using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CementeryView : MonoBehaviour
{

    [SerializeField] CementeryCellView pawnView;
    [SerializeField] CementeryCellView spearView;
    [SerializeField] CementeryCellView horseView;
    [SerializeField] CementeryCellView silverView;
    [SerializeField] CementeryCellView goldView;
    [SerializeField] CementeryCellView towerView;
    [SerializeField] CementeryCellView bishopView;

    
    public void SetCementeryView(View view)
    {
        pawnView.SetCementeryView (view, PieceType.Pawn);
        spearView.SetCementeryView (view, PieceType.Spear);
        horseView.SetCementeryView (view, PieceType.Horse);
        silverView.SetCementeryView (view, PieceType.Silver);
        goldView.SetCementeryView (view, PieceType.Gold);
        towerView.SetCementeryView (view, PieceType.Tower);
        bishopView.SetCementeryView (view, PieceType.Bishop);
    }

    public void EnableCementaryView(bool enable = true)
    {
        pawnView.EnableButton(enabled);
        spearView.EnableButton(enabled);
        horseView.EnableButton(enabled);
        silverView.EnableButton(enabled);
        goldView.EnableButton(enabled);
        towerView.EnableButton(enabled);
        bishopView.EnableButton(enabled);
    }

    public void UpdateCellView(PieceType pieceType, int count)
    {
        switch (pieceType)
        {
            case PieceType.Pawn:
                pawnView.UpdateCountText(count); 
                break;
            case PieceType.Spear:
                spearView.UpdateCountText(count);
                break;
            case PieceType.Horse:
                horseView.UpdateCountText(count);
                break;
            case PieceType.Silver:
                silverView.UpdateCountText(count);
                break;
            case PieceType.Gold:
                goldView.UpdateCountText(count);
                break;
            case PieceType.Tower:
                towerView.UpdateCountText(count);
                break;
            case PieceType.Bishop:
                bishopView.UpdateCountText(count);
                break;
        }
    }


}
