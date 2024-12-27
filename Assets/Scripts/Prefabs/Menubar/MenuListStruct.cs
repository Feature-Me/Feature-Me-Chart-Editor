using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public struct MenuContentStruct
{
    public string name;
    //[Serializable] public class clickEvent : UnityEvent {}
    //[FormerlySerializedAs("onClick")]
    [SerializeField]
    private Button.ButtonClickedEvent onclick;
    public Button.ButtonClickedEvent onClick
    {
        get { return onclick; }
        set { onclick = value; }
    }
    
}

[Serializable]
public struct MenuListStruct
{
    public string name;
    public MenuContentStruct[] items;
}
