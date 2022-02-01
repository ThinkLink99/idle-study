using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUtencil", menuName = "Custom/New Utencil")]
public class Utencil : ScriptableObject
{
    public string utencilName;
    public string utencilDescription;

    public ClickBuff buff;
    public AutoClicker autoClicker;

    public int cost;
    public bool stackable;

    public bool hasAutoClicker = false;
}

public class Base : Utencil
{
    public new string utencilName = "Base";
}