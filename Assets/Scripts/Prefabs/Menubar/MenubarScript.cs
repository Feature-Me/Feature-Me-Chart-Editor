using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MenubarScript : MonoBehaviour
{
    [SerializeField] private MenuListStruct[] menuListItem;
    [SerializeField] private GameObject menuButtonPrefab;
    [SerializeField] private GameObject menuListPrefab;
    [SerializeField] private RectTransform buttonContainerTransform;
    [SerializeField] private RectTransform listContainerTransform;

    void Start()
    {
        foreach (var menu in menuListItem)
        {
            CreateList(menu);
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(buttonContainerTransform);
    }

    private void CreateList(MenuListStruct menu)
    {
        var button = Instantiate(menuButtonPrefab, buttonContainerTransform);
        var list = Instantiate(menuListPrefab, listContainerTransform);
        var buttonScript = button.GetComponent<MenuButtonScript>();
        var listScript = list.GetComponent<MenuListScript>();
        buttonScript.SetLabel(menu.name);
        buttonScript.list = list;
        listScript.SetListItem(menu.items);

    }
}
