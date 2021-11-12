using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUtencil", menuName = "Custom/New Utencil")]
public class Utencil : ScriptableObject
{
    public string utencilName;
    public string utencilDescription;

    public ClickBuff buff;
}
