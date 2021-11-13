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
    public int allowance = 0;
    public List<Utencil> utencils;

    public void Start()
    {
        GameManager.OnHomeworkCompleted += GameManager_OnHomeworkCompleted;    
    }
    public void Update()
    {

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

    public int ClickAmount
    {
        get
        {
            return utencils.Select(u => u.buff.modifier).Sum();
        }
    }
}
