using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Player player;
    public GameObject shop;
    public Transform utencilList;
    public GameObject shopUtencilPrefab;

    public List<Utencil> utencils;

    public void Start()
    {
        CloseShop();
    }

    public void OpenShop()
    {
        BuildShop();

        shop.SetActive(true);
    }
    public void CloseShop()
    {
        shop.SetActive(false);

        DisposeShop();
    }

    public void BuildShop ()
    {
        foreach (Utencil utencil in utencils)
        {
            GameObject obj = Instantiate(shopUtencilPrefab);
            obj.transform.parent = utencilList;

            obj.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = utencil.utencilName;
            obj.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = utencil.utencilDescription;
        }
    }
    public void DisposeShop ()
    {
        for (int i = utencilList.childCount; i >= 0; i--)
        {
            Destroy(utencilList.GetChild(i));
        }
    }
}
