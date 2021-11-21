using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public static class GameEvents 
{
    public static event Action OnHomeworkCompleted;
    public static event Action OnHomeworkFailed;
    public static event Action<int> OnClick;
    public static event Action<Utencil> OnUtencilPickup;

    public static bool shopOpen = false;
    public static bool utencilsOpen = false;

    public static void HomeworkComplete()
    {
        OnHomeworkCompleted?.Invoke();
    }
    public static void HomeworkFailed()
    {
        OnHomeworkFailed?.Invoke();
    }
    public static void Click(int amount)
    {
        OnClick?.Invoke(amount);
    }
    public static void UtencilPickup(Utencil utencil)
    {
        OnUtencilPickup?.Invoke(utencil);
    }
}
