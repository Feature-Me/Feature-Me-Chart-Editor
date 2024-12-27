using TMPro;
using UnityEngine;

public class MenuButtonScript : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI text;
    public GameObject list;
    public MenubarScript parentMenuBar;
    
    public void SetLabel(string t)
    {
        text.text = t;
    }

    public void OnClick()
    {
        var listScript = list.GetComponent<MenuListScript>();

        if (parentMenuBar.IsActive && parentMenuBar.ActiveList == listScript) listScript.closeMenu();
        else list.GetComponent<MenuListScript>().openMenu(this.transform.position.x);
    }

    public void SetMenuActive()
    {
        parentMenuBar.IsActive = true;
    }
    
}
