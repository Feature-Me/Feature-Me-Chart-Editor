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
    [SerializeField] private GameObject background;
    private bool isActive = false;
    private MenuListScript activeList;

    public bool IsActive
    {
        get { return isActive; }
        set
        {
            toggleBg(value);
            isActive = value; }
    }
    public MenuListScript ActiveList
    {
        get {return activeList;}
        set
        {
            if (activeList != value)
            {
                if(activeList != null) activeList.closeMenu();
                activeList = value;
            }
            else return;
        }
    }

    void Start()
    {
        foreach (var menu in menuListItem)
        {
            CreateList(menu);
        }

        (background.transform as RectTransform)?.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width);
        (background.transform as RectTransform)?.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height);

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
        buttonScript.parentMenuBar = this;
        listScript.SetListItem(menu.items);
        listScript.parentMenuBar = this;
    }

    public void hideMenu()
    {
        this.IsActive = false;
        this.activeList.closeMenu();
    }

    public void toggleBg(bool value)
    {
        if(value) background.SetActive(true);
        else background.SetActive(false);
    }
}
