using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New ItemData", menuName = "ItemData", order = 51)]
public class ItemData : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _lable;
    [SerializeField] private GameObject _template;

    public Sprite Icon => _icon;
    public string Lable => _lable;
    public GameObject Template => _template;
}
