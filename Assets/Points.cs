using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PointSystem : MonoBehaviour
{
    private int[] perf = new int[4];
    public GameObject circle;
    public TextMeshPro scoreText, multText;
    private int score,multiplier;
    private int multProgress = 0;
    private int multLives = 3;
    private int hitNotes = 0;
    private float bpm = 120f;
    private float cooldown = -1f;
    void Start()
    {
        //score = 0;
        //multiplier = 1;
    }
//    void updateCooldown()
//    {
//        if (cooldown < 60f / bpm && cooldown != -1f)
//        {
//            cooldown += Time.deltaTime;
//            if (cooldown >= 60f / bpm)
//            {
//                cooldown = -1f;
//            }
//        }
//    }
//    void updateScore()
//    {
//        foreach (var num in perf)
//        {
//            print("num:" + num);
//            if (num == 1)
//            {
//                score += 25 * multiplier;
//                multProgress += 8;
//                hitNotes++;
//            }
//            if (num == 2)
//            {
//                multProgress += 14;
//                score += 55 * multiplier;
//                hitNotes++;
//            }
//            if (num == -1)
//            {
//                if(cooldown == -1f)
//                {
//                    multLives -= 1;
//                    if (multLives == 0)
//                    {
//                        multProgress = 0;
//                        multLives = 3;
//                    }
//                    cooldown = 0f;
//                }
//            }
//        }
//    }
//    void updateObjs()
//    {
//        scoreText.text = String.Format("{0:000000}", score);
//        multText.text = multiplier.ToString();
//    }

//    void Update()
//    {
//        perf = FindObjectOfType<Gameplay>().returnPerf();
//        updateScore();
//        updateObjs();
//        updateCooldown();
//        FindObjectOfType<Gameplay>().resetPerf();
//        print(score);
//    }
}
