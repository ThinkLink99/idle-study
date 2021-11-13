using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickerFloatingTextManager : MonoBehaviour
{
    private GameObject text;
    private TextMeshProUGUI tmText;
    public float clickAmountTextY = 0;
    public float moveSpeed = 64f;

    // Start is called before the first frame update
    void Start()
    {
        text = this.gameObject;
        tmText = text.GetComponent<TextMeshProUGUI>();

        SetActive();
    }

    // Update is called once per frame
    void Update()
    {
        if (!text.activeInHierarchy) return;
        clickAmountTextY += Time.deltaTime * moveSpeed;
        //text.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, clickAmountTextY);

        if (clickAmountTextY >= 250)
        {
            text.SetActive(false);
            Destroy(text);
        }
    }

    public void SetActive()
    {
        text.SetActive(true);
        clickAmountTextY = 0;
    }
}
