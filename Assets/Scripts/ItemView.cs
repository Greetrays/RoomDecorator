using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private Button _selectionButton;

    private ItemData _itemData;

    public event UnityAction<ItemData> ItemSelected;
    public event UnityAction<ItemView> ItemDisabled;

    private void OnEnable()
    {
        _selectionButton.onClick.AddListener(OnClickSelectionButton);
    }

    private void OnDisable()
    {
        ItemDisabled?.Invoke(this);
        _selectionButton.onClick.RemoveListener(OnClickSelectionButton);
    }

    private void OnClickSelectionButton()
    {
        ItemSelected?.Invoke(_itemData);
    }

    public void FillData(ItemData item)
    {
        _icon.sprite = item.Icon;
        _lable.text = item.Lable;
        _itemData = item;
    }
}
