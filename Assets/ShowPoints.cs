using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ShowPoints : MonoBehaviour
{
    public TextMeshPro scoreTitle;
    public TextMeshPro scoreNum;
    public TextMeshPro hitsTitle;
    public TextMeshPro hitNum;
    public TextMeshPro title;
    public Canvas button;

    private int score;
    private int hits;
    private int score2 = 0;
    private int hits2 = 0;
    private float waitTime = 0f;

    private int bFirst = 0;
    private float firstWait;
    void Start()
    {
        score = FindObjectOfType<Gameplay>().returnScore()[0];
        hits  = FindObjectOfType<Gameplay>().returnScore()[1];
    }
    Color visible(TextMeshPro input)
    {
        return new Color(input.color.r, input.color.g, input.color.b, 1f);
    }
    bool set = false;
    void Animation()
    {
        if (waitTime>0.4f && bFirst == 0) {
            bFirst = 1;
        }
        if(waitTime > 1f && bFirst == 2)
        {
            scoreTitle.color = visible(scoreTitle);
            scoreNum.color = visible(scoreNum);
            hitsTitle.color = visible(hitsTitle);
            hitNum.color = visible(hitNum);
            bFirst = 3; 
        }
        if(waitTime > 2f && score2 != score && hits2 != hits && bFirst ==3)
        {
            if (!set)
            {
                firstWait = waitTime;
                set = true;
            }
            if (waitTime - firstWait <= 3f)
            {
                scoreNum.text = ((waitTime-firstWait)/3f*score).ToString("000000");
                hitNum.text = ((waitTime - firstWait) / 3f * hits).ToString("000000");
            }
        }
        if (bFirst == 1)
        {
            title.color = visible(title);
            bFirst = 2;
        }
        if(score==score2 && hits == hits2)
        {
            button.enabled = true;
        }

    }
    // Update is called once per frame
    void Update()
    {
        waitTime += Time.deltaTime;
        Animation();
    }
}
