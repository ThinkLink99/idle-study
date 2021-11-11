using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickerFloatingTextManager : MonoBehaviour
{
    public Transform parent;
    public GameObject clickAmountText;
    private TextMeshProUGUI tmText;
    public float clickAmountTextY = 0;
    public float moveSpeed = 32f;

    // Start is called before the first frame update
    void Start()
    {
        tmText = clickAmountText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!clickAmountText.activeInHierarchy) return;
        clickAmountTextY += Time.deltaTime * moveSpeed;
        clickAmountText.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, clickAmountTextY);
        tmText.alpha = 255 - clickAmountTextY;

        if (clickAmountTextY >= 250) clickAmountText.SetActive(false);
    }

    public void SetActive()
    {
        var obj = Instantiate(clickAmountText);

        obj.transform.parent = parent;
        obj.SetActive(true);
        clickAmountTextY = 0;
    }
}
