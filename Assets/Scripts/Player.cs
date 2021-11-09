using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text allowanceText;
    public int allowance = 0;

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
}
