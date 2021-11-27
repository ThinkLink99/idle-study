using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopQuizManager : MonoBehaviour
{
    public Color popQuizProgressColor = Color.red;
    public Slider popQuizProgress;
    public Image popQuizProgressFill;


    public GameObject popQuizBubblePrefab;
    public Transform popQuizBubbleParent;

    public float popUpChance = 0.5f;
    public float popUpTime = 5;
    private float currentTime = 0;
    private bool popQuizFinishedThisAssignment = false;


    // Start is called before the first frame update
    void Start()
    {
        popQuizProgressFill.color = popQuizProgressColor;
        GameEvents.OnPopQuizBubblePopped += GameEvents_OnPopQuizBubblePopped;
        GameEvents.OnHomeworkCompleted += GameEvents_OnHomeworkCompleted;
        GameEvents.OnHomeworkFailed += GameEvents_OnHomeworkFailed;
    }

    private void GameEvents_OnHomeworkFailed()
    {
        popQuizProgress.value = 0;
        popQuizFinishedThisAssignment = false;
    }

    private void GameEvents_OnHomeworkCompleted(float time)
    {
        popQuizProgress.value = 0;
        popQuizFinishedThisAssignment = false;
    }

    private void GameEvents_OnPopQuizBubblePopped(float score)
    {
        if (!popQuizProgress.gameObject.activeInHierarchy)
        {
            popQuizProgress.gameObject.SetActive(true);
        }
        popQuizProgress.value = score;
    }

    // Update is called once per frame
    void Update()
    {
        if (popQuizFinishedThisAssignment) return;

        currentTime += Time.deltaTime;
        if (currentTime >= popUpTime)
        {
            currentTime = 0;
            float rand = Random.Range(0, 1);
            if (rand <= popUpChance)
            {
                popQuizFinishedThisAssignment = true;

                // make bubble
                var obj = Instantiate(popQuizBubblePrefab);
                //obj.transform.parent = popQuizBubbleParent;
                obj.GetComponent<RectTransform>().SetParent(popQuizBubbleParent, false);
                var r = popQuizBubbleParent.GetComponent<RectTransform>();

                obj.GetComponent<RectTransform>().position = new Vector3(Random.Range(r.position.x, r.rect.width), r.position.y); 
            }
        }
    }
}
