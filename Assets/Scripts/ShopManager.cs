using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    private UtencilsManager utencilsManager;
    private Player player;
    public GameObject shop;
    public Transform utencilList;
    public GameObject shopUtencilPrefab;
    public TextMeshProUGUI allowanceText;

    public List<Utencil> utencils;

    public void Start()
    {
        player = gameObject.GetComponent<Player>();
        utencilsManager = gameObject.GetComponent<UtencilsManager>();

        CloseShop();
    }

    public void OpenShop()
    {
        if (GameManager.shopOpen) return;
        if (GameManager.utencilsOpen) utencilsManager.Close();

        GameManager.shopOpen = true;
        BuildShop();

        shop.SetActive(true);
    }
    public void CloseShop()
    {
        GameManager.shopOpen = false;
        shop.SetActive(false);

        DisposeShop();
    }

    public void BuildShop ()
    {
        allowanceText.text = player.allowance.ToString("C");

        foreach (Utencil utencil in utencils)
        {
            if (player.HasUtencil(utencil) && !utencil.stackable) continue;

            GameObject obj = Instantiate(shopUtencilPrefab);
            obj.GetComponent<RectTransform>().SetParent(utencilList, false);

            obj.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = utencil.utencilName;
            obj.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = utencil.utencilDescription;
            obj.transform.GetChild(2).GetComponent<TMPro.TextMeshProUGUI>().text = utencil.cost.ToString("C");
            Utencil u = utencil;
            if (player.allowance - u.cost < 0)
            {
                obj.GetComponent<Button>().enabled = false;
            }
            obj.GetComponent<Button>().onClick.AddListener(() => Buy(u));
        }
    }
    public void DisposeShop ()
    {
        if (utencilList.childCount == 0) return;

        for (int i = utencilList.childCount - 1; i >= 0; i--)
        {
            var o = utencilList.GetChild(i).gameObject;
            Destroy(o);
        }
    }

    public void Buy (Utencil utencil)
    {
        if (player.allowance - utencil.cost < 0) return;
        if (player.HasUtencil(utencil) && !utencil.stackable) return;

        player.allowance -= utencil.cost;
        if (player.HasUtencil(utencil))
        {
            player.utencils.Where(u => u.details == utencil).FirstOrDefault().qty++;
        }
        else
        {
            player.utencils.Add(new BoughtUtencil(utencil, 1));

        }
        player.utencilsChanged = true;

        DisposeShop();
        BuildShop();
    }
}
