using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class Gameplay : MonoBehaviour
{
    class Level
    {
        public float bpm;
        public int[,] circles;
    }

    public Transform FCircle1, FCircle2, FCircle3, FCircle4;
    public Transform BCyl1, BCyl2, BCyl3, BCyl4;
    public ParticleSystem ps1, ps2, ps3, ps4;
    public ParticleSystem psg1, psg2, psg3, psg4;
    public TextMeshPro textH, textJ, textK,textL,textScore,textMult;
    public float bpm =120f;

    private int lastIter = 0;
    private float counter;
    private bool showBinds = false;
    private float endPos;
    private float minYtop;
    private float minYbot;
    private float perfectYtop;
    private float perfectYbot;
    private int score = 0;
    private int perfInd;
    private int multiplier = 1;
    private float multProgress = 0;
    string lvl = "" +
        "1000" +
        "0100" +
        "0010" +
        "0001" +
                "";
    private List<GameObject> circs = new List<GameObject>();
    private Level level = new Level();
    private int[] perf = new int[4];

    void MakeLevel(Level level)
    {
        level.bpm = bpm;
        level.circles = new int[lvl.Length / 4, 4];
        for (int i = 0; i < lvl.Length; i += 4)
        {
            for (int k = 0; k < 4; k++)
            {
                level.circles[i / 4, k] = int.Parse(""+lvl[i + k]);
            }
        }
        counter = 0f;
    }
    void SpawnCircles(Level level)
    {
        if (counter < 60f/level.bpm)
        {
            counter += Time.deltaTime;
            return;
        }
        for (int k = 0; k < 4; k++)
        {
            if (level.circles[lastIter, k] == 1)
            {
                switch (k) {
                    case 0:
                        circs.Add(Instantiate(FCircle1.gameObject));
                        break;
                    case 1:
                        circs.Add(Instantiate(FCircle2.gameObject));
                        break;
                    case 2:
                        circs.Add(Instantiate(FCircle3.gameObject));
                        break;
                    case 3:
                        circs.Add(Instantiate(FCircle4.gameObject));
                        break;
                }
            }
        }

        counter = 0;
        lastIter += 1;

        if(lastIter == lvl.Length/4)
        {
            lastIter = 0;
        }
    }

    void MoveCircles()
    {
        for ( int i=0;i<circs.Count;i++)
        {
            circs[i].transform.position = new Vector3(circs[i].transform.position.x, circs[i].transform.position.y + level.bpm/-64f*Time.deltaTime);
            if (circs[i].transform.position.y < endPos)
            {
                Destroy(circs[i]);
                circs.Remove(circs[i]);
                i = -1;
            }
        }
    }
    void Click()
    {
        #region f1
        if (Input.GetKey(KeyCode.H))
        {
            BCyl1.gameObject.GetComponent<SpriteRenderer>().color = new Color(0,1f,0);
            for (int i = 0; i < circs.Count; i++)
            {
                if (circs[i].transform.position.x == FCircle1.position.x)
                {
                    if (circs[i].transform.position.y < minYtop && circs[i].transform.position.y > minYbot)
                    {
                        if (circs[i].transform.position.y < perfectYtop && circs[i].transform.position.y > perfectYbot)
                        {
                            ps1.Play();
                            perfInd = 2;
                        }
                        else
                        {
                            psg1.Play();
                            perfInd = 1;
                        }
                        Destroy(circs[i]);
                        circs.Remove(circs[i]);
                        i = -1;
                    }
                    else
                    {
                        
                    }
                }
            }
            AddScore(perfInd);
        }
        else
        {
            BCyl1.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0.5f, 0);
        }
        #endregion f1
        #region f2
        if (Input.GetKey(KeyCode.J))
        {
            BCyl2.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0, 0);
            for (int i = 0; i < circs.Count; i++)
            {
                if (circs[i].transform.position.x == FCircle2.position.x)
                {
                    if (circs[i].transform.position.y < minYtop && circs[i].transform.position.y > minYbot)
                    {
                        if (circs[i].transform.position.y < perfectYtop && circs[i].transform.position.y > perfectYbot)
                        {
                            ps2.Play();
                            perfInd = 2;
                        }
                        else
                        {
                            psg2.Play();
                           perfInd = 1;
                        }
                        Destroy(circs[i]);
                        circs.Remove(circs[i]);
                        i = -1;
                    }
                    else
                    {

                    }
                }
            }

        }
        else
        {
            BCyl2.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0, 0);
        }
        #endregion f2
        #region f3
        if (Input.GetKey(KeyCode.K))
        {
            BCyl3.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0);
            for (int i = 0; i < circs.Count; i++)
            {
                if (circs[i].transform.position.x == FCircle3.position.x)
                {
                    if (circs[i].transform.position.y < minYtop && circs[i].transform.position.y > minYbot)
                    {
                        if (circs[i].transform.position.y < perfectYtop && circs[i].transform.position.y > perfectYbot)
                        {
                            ps3.Play();
                            perfInd = 2;
                        }
                        else
                        {
                            psg3.Play();
                            perfInd = 1;
                        }
                        Destroy(circs[i]);
                        circs.Remove(circs[i]);
                        i = -1;
                    }
                    
                }
            }
        }
        else
        {
            BCyl3.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0);
        }
        #endregion f3
        #region f4
        if (Input.GetKey(KeyCode.L))
        {
            BCyl4.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 1f);
            for (int i = 0; i < circs.Count; i++)
            {
                if (circs[i].transform.position.x == FCircle4.position.x)
                {
                    if (circs[i].transform.position.y < minYtop && circs[i].transform.position.y > minYbot)
                    {
                        if (circs[i].transform.position.y < perfectYtop && circs[i].transform.position.y > perfectYbot)
                        {
                            ps4.Play();
                            perfInd = 2;
                        }
                        else
                        {
                            psg4.Play();
                            perfInd = 1;
                        }
                        Destroy(circs[i]);
                        circs.Remove(circs[i]);
                        i = -1;
                    }
                    
                }
            }
        }
        else
        {
            BCyl4.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0.6f);
        }
        #endregion f4
        AddScore(perfInd);
        perfInd = 0;
    }

    void Start()
    {
        endPos = -5.29f;
        minYtop = -3.87f;
        minYbot = -4.20f;
        perfectYtop = -3.92f;
        perfectYbot = -4.08f;
        MakeLevel(level);
        showBinds = true;
        score = 0;
    }
    public void AddScore(int perf)
    {
        score += (perf==-1?0:perf) * 25;
        multProgress += 1.5f * (perf==-1?perf*0:perf);
        if (multProgress >= 25f)
        {
            textMult.gameObject.GetComponentInParent<SpriteRenderer>().color = Color.cyan;
            multiplier = 2;
        }
        if (multProgress >= 90f) { multiplier = 3; textMult.GetComponentInParent<SpriteRenderer>().color = Color.yellow; }
        if (multProgress >= 120f) { multiplier = 4; textMult.gameObject.GetComponentInParent<SpriteRenderer>().color = Color.green; }
        if (multProgress >= 150f) { multiplier = 5; textMult.gameObject.GetComponentInParent<SpriteRenderer>().color = Color.magenta; }
        if (multProgress < 25f) { multiplier = 1; textMult.gameObject.GetComponentInParent<SpriteRenderer>().color = Color.white; }
        textScore.text = String.Format("{0:000000}", score);
        textMult.text = multiplier.ToString();
    }

    void Update()
    {
        if (showBinds)
        {
            textH.alpha -= Time.deltaTime/1.5f;
            textJ.alpha -= Time.deltaTime/1.5f;
            textK.alpha -= Time.deltaTime/1.5f;
            textL.alpha -= Time.deltaTime/1.5f;
            if (textH.alpha == 0f) showBinds = false;
        }
        SpawnCircles(level);
        MoveCircles();
        Click();
    }
}
