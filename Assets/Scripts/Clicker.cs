using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    public Player player;
    
    public void Start()
    {

    }
    private void Update()
    {
        
    }

    public void Click ()
    {
        GameEvents.Click(player.ClickAmount);
    }
}
