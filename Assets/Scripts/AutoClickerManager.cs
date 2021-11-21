using System.Collections.Generic;
using UnityEngine;

public class AutoClickerManager : MonoBehaviour
{
    public List<Utencil> clickers;
    private void Start()
    {
        GameEvents.OnUtencilPickup += GameManager_OnUtencilPickup;
    }

    private void GameManager_OnUtencilPickup(Utencil obj)
    {
        clickers.Add(obj);
    }

    public void Update()
    {
        foreach (var clicker in clickers)
        {
            if (clicker.hasAutoClicker)
                clicker.autoClicker.Click(clicker.buff.modifier);
        }
    }
}