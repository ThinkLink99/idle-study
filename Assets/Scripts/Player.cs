using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI allowanceText;
    public GameObject UIUtencilPrefab;
    public Transform UIUtencilList;

    public int allowance = 0;
    public List<BoughtUtencil> utencils;

    public bool utencilsChanged = false;

    public void Start()
    {
        GameEvents.OnHomeworkCompleted += GameManager_OnHomeworkCompleted;    
    }
    public void Update()
    {
        allowanceText.text = allowance.ToString("C");

        if (utencilsChanged)
        {
            Dispose();
            Build();
            utencilsChanged = false;
        }
    }

    private void GameManager_OnHomeworkCompleted()
    {
        GiveAllowance();
    }

    void GiveAllowance()
    {
        allowance += 5;
        allowanceText.text = $"${allowance}";
    }
    public bool HasUtencil (Utencil utencil)
    {
        if (utencils.Count == 0) return false;
        if (utencils.Any(u => u.details == utencil))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Build()
    {
        foreach (BoughtUtencil utencil in utencils)
        {
            if (utencil.details.utencilName == "Base") continue;

            GameObject obj = Instantiate(UIUtencilPrefab);
            
            obj.GetComponent<RectTransform>().SetParent(UIUtencilList, false);
            //obj.GetComponent<Image>().
            obj.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = $"({utencil.qty})";
        }
    }
    public void Dispose()
    {
        if (UIUtencilList.childCount == 0) return;
        for (int i = UIUtencilList.childCount - 1; i >= 0; i--)
        {
            var o = UIUtencilList.GetChild(i).gameObject;
            Destroy(o);
        }
    }
    public int ClickAmount
    {
        get
        {
            return utencils.Where(u => !u.details.hasAutoClicker).Select(u => u.details.buff.modifier * u.qty).Sum();
        }
    }
}
