using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ListButtonScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Button button;

    public void init(MenuContentStruct item,UnityAction close)
    {
        text.text = item.name;
        //button.onClick = item.onClick;
        //button.onClick.AddListener(()=>Debug.Log("aaa"));
        if (item.onClick != null) button.onClick.AddListener(item.onClick.Invoke);
        button.onClick.AddListener(close);
        
    }
}
