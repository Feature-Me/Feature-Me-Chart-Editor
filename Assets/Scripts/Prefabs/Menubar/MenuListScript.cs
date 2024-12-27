using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuListScript : MonoBehaviour
{
    [SerializeField] private GameObject listButtonPrefab;
    [SerializeField] private RectTransform buttonAreaTransform;
    [SerializeField] private int maxSize = 360;
    [SerializeField] private CanvasGroup canvasGroup;
    public MenubarScript parentMenuBar;
    private bool active;
    private bool isPointerOver;

    
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
        buttonScript.init(item,closeMenu);
    }

    public void openMenu(float posX)
    {
        transform.position.Set(posX, 0, 0);
        this.openMenu();
    }

    public async void openMenu()
    {
        gameObject.SetActive(true);
        parentMenuBar.ActiveList = this;
        parentMenuBar.IsActive = true;
        this.active = true;
        float defaultY = transform.position.y;
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        this.transform.DOMoveY(defaultY+40,0f);
        //transform.position.Set(transform.position.x, defaultY+40, 0);
        this.transform.DOMoveY(defaultY,0.3f).SetEase(Ease.OutQuart);
        canvasGroup.DOFade(1,0.3f).SetEase(Ease.OutQuart);
        await UniTask.Delay(300);
        canvasGroup.interactable = true;
    }

    public async void closeMenu()
    {
        parentMenuBar.IsActive = false;
        this.active = false;
        //parentMenuBar.ActiveList = null;
        float defaultY = transform.position.y;
        canvasGroup.alpha = 1;
        canvasGroup.interactable = false;
        this.transform.DOMoveY(defaultY+40,0.3f).SetEase(Ease.OutQuart);
//        this.transform.DOMoveY(defaultY,0.3f).SetEase(Ease.OutQuart);
        canvasGroup.DOFade(0,0.3f).SetEase(Ease.OutQuart);
        await UniTask.Delay(300);
        this.transform.DOMoveY(defaultY, 0f);
        this.gameObject.SetActive(false);
    }

    public void OnHoverEnter()
    {
        this.isPointerOver = true;
    }

    public void OnHoverExit()
    {
        this.isPointerOver = false;
    }

    public void onPointerDown()
    {
        //if(!this.isPointerOver) this.closeMenu();
        
    }
    
}
