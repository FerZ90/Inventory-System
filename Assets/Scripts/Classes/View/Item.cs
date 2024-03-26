using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI nameTxt;
    [SerializeField] private TextMeshProUGUI amountTxt;

    private ItemModel _itemModel;
    private IItemListener _listener;

    public UnityEvent OnItemClickEvent;

    public void Setup(ItemModel itemModel/*, IItemListener listener*/)
    {
        _itemModel = itemModel;
        //_listener = listener;
        nameTxt.text = itemModel.name;
        amountTxt.text = itemModel.amount.ToString();
    }

    public void OnItemClick()
    {
        //_listener.OnItemClick(this);
        OnItemClickEvent?.Invoke();
    }

    private void OnDestroy()
    {
        OnItemClickEvent.RemoveAllListeners();
    }
}
