using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuListScript : MonoBehaviour
{
    [SerializeField] private GameObject listButtonPrefab;
    [SerializeField] private RectTransform buttonAreaTransform;
    [SerializeField] private int maxSize = 360;
    
    public void SetListItem(MenuContentStruct[] list)
    {
        foreach (var item in list)
        {
            CreateListButton(item);
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(buttonAreaTransform);
        (this.transform as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Math.Min(maxSize, list.Length*40));
    }

    private void CreateListButton(MenuContentStruct item)
    {
        var button = Instantiate(listButtonPrefab, buttonAreaTransform);
        var buttonScript = button.GetComponent<ListButtonScript>();
        buttonScript.init(item);
    }

    public void openMenu(int posX)
    {
        transform.position.Set(posX, 0, 0);
        this.openMenu();
    }

    public void openMenu()
    {
        
    }
}
