using UnityEngine;

[System.Serializable]
public class AutoClicker
{
    public float currentTime = 0;
    public float duration = 5;

    public void Click (int amount)
    {
        currentTime += Time.deltaTime;
        if (currentTime >= duration)
        {
            currentTime = 0;
            // raise Game Click Event
            GameEvents.Click(amount);
        }
    }
}
