using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ListButtonScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Button button;

    public void init(MenuContentStruct item)
    {
        text.text = item.name;
        button.onClick = item.onClick;
    }
}
