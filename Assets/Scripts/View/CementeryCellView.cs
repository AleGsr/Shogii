using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CementeryCellView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countText;

    View view;
    Button buttonComponent;

    PieceType pieceType;

    private void Awake()
    {
        buttonComponent = GetComponent<Button>();
    }

    public void SetCementeryView(View view, PieceType pieceType)
    {
        this.view = view;
        this.pieceType = pieceType;

    }


    public void EnableButton(bool enable = true)
    {
        buttonComponent.enabled = enable;
    }

    public void Start()
    {
        countText.text = "0";
    }

    private void OnEnable()
    {
        buttonComponent.onClick.AddListener(SelectCemetaryCell);
    }

    private void OnDisable()
    {
        buttonComponent.onClick.RemoveListener(SelectCemetaryCell);
    }

    public void UpdateCountText(int count)
    {
        countText.text = count.ToString();
    }

    private void SelectCemetaryCell()
    {
        view?.SelectCementeryPiece(pieceType);
    }

}
