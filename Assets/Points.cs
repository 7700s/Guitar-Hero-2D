using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointSystem : MonoBehaviour
{
    private int[] perf = new int[4];
    public GameObject circle;
    public TextMeshPro scoreText, multText;
    private int score;
    void Start()
    {
        score = 0;
    }
    void updateScore()
    {

    }
    void updateMult()
    {

    }

    void Update()
    {
        perf = FindObjectOfType<Gameplay>().returnPerf();
    }
}
