using TMPro;
using UnityEngine;

public class MenuButtonScript : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI text;
    public GameObject list;
    public void SetLabel(string t)
    {
        text.text = t;
    }

    public void OpenList()
    {
        list.GetComponent<MenuListScript>().openMenu();
    }
}
