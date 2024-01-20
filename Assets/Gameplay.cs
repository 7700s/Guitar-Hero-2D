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
    public TextMeshPro textH, textJ, textK,textL;
    public int bpm;

    private int lastIter = 0;
    private float counter;
    private bool showBinds = false;
    private float endPos;
    private float minYtop;
    private float minYbot;
    private float perfectYtop;
    private float perfectYbot;
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
                            perf[0] = 2;
                        }
                        else
                        {
                            psg1.Play();
                            perf[0] = 1;
                        }
                        Destroy(circs[i]);
                        circs.Remove(circs[i]);
                        i = -1;
                    }
                    else
                    {
                        perf[0] = -1;
                    }
                }
            }
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
                            perf[1] = 2;
                        }
                        else
                        {
                            psg2.Play();
                            perf[1] = 1;
                        }
                        Destroy(circs[i]);
                        circs.Remove(circs[i]);
                        i = -1;
                    }
                    else
                    {
                        perf[1] = -1;
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
                            perf[2] = 2;
                        }
                        else
                        {
                            psg3.Play();
                            perf[2] = 1;
                        }
                        Destroy(circs[i]);
                        circs.Remove(circs[i]);
                        i = -1;
                    }
                    perf[2] = -1;
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
                            perf[3] = 2;
                        }
                        else
                        {
                            psg4.Play();
                            perf[3] = 1;
                        }
                        Destroy(circs[i]);
                        circs.Remove(circs[i]);
                        i = -1;
                    }
                    perf[3] = -1;
                }
            }
        }
        else
        {
            BCyl4.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0.6f);
        }
        #endregion f4
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
    }

    public int[] returnPerf()
    {
        return perf;
    }
    public void resetPerf()
    {
        perf[0] = 0;
        perf[1] = 0;
        perf[2] = 0;
        perf[3] = 0;
    }

    void Update()
    {
        if (showBinds)
        {
            textH.alpha -= Time.deltaTime/2;
            textJ.alpha -= Time.deltaTime/2;
            textK.alpha -= Time.deltaTime/2;
            textL.alpha -= Time.deltaTime/2;
            if (textH.alpha == 0f) showBinds = false;
        }
        SpawnCircles(level);
        MoveCircles();
        Click();
    }
}
