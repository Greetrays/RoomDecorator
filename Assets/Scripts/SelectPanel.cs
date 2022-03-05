using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPanel : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _objectPlacer;
    [SerializeField] private List<ItemData> _items;
    [SerializeField] private ItemView _itemTemplate;

    private void Start()
    {
        foreach (var item in _items)
        {
            AddItem(item);
        }
    }

    private void AddItem(ItemData item)
    {
        ItemView itemView = Instantiate(_itemTemplate, _container);
        itemView.FillData(item);
        itemView.ItemSelected += OnItemSelected;
        itemView.ItemDisabled += OnItemDisabled;
    }

    private void OnItemSelected(ItemData item)
    {

    }

    private void OnItemDisabled(ItemView itemView)
    {
        itemView.ItemSelected -= OnItemSelected;
        itemView.ItemDisabled -= OnItemDisabled;
    }
}
