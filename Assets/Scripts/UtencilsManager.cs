using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UtencilsManager : MonoBehaviour
{
    private ShopManager shopManager;
    private Player player;
    public GameObject utencils;
    public Transform utencilList;
    public GameObject shopUtencilPrefab;

    public void Start()
    {
        player = gameObject.GetComponent<Player>();
        shopManager = gameObject.GetComponent<ShopManager>();

        Close();
    }

    public void Open()
    {
        if (GameEvents.utencilsOpen) return;
        if (GameEvents.shopOpen) shopManager.CloseShop();

        GameEvents.utencilsOpen = true;
        Build();

        utencils.SetActive(true);
    }
    public void Close()
    {
        GameEvents.utencilsOpen = false;
        utencils.SetActive(false);

        Dispose();
    }

    public void Build ()
    {
        foreach (BoughtUtencil utencil in player.utencils)
        {
            if (utencil.details.utencilName == "Base") continue;

            GameObject obj = Instantiate(shopUtencilPrefab);
            obj.GetComponent<RectTransform>().SetParent(utencilList, false);

            obj.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = utencil.details.utencilName;
            obj.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = utencil.details.utencilDescription;
        }
    }
    public void Dispose ()
    {
        if (utencilList.childCount == 0) return;
        for (int i = utencilList.childCount - 1; i >= 0; i--)
        {
            var o = utencilList.GetChild(i).gameObject;
            Destroy(o);
        }
    }
}
