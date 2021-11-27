using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopQuizBubbleManager : MonoBehaviour
{
    public float score = 100f;
    public float modifier = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score -= Time.deltaTime * modifier;

        if (score <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Pop ()
    {
        Destroy(this.gameObject);

        // raise popped event
        GameEvents.PopQuizBubblePopped(score);
    }
}
