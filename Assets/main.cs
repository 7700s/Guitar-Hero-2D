using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class NewBehaviourScript : MonoBehaviour
{
    class Level
    {
        public float speed;
        public int[,] circles;
    }
    public TextMeshPro text;
    private float counter;
    private float spaces = 0.4f;
    public Transform FCircle1, FCircle2, FCircle3, FCircle4;
    private float endPos;
    private int lastIter = 0;
    private float minYtop;
    private float minYbot;
    private float perfectYtop;
    private float perfectYbot;
    string lvl = "" +
                "1001" +
                "0000" +
                "1001" +
                "0000" +
                "0011" +
                "0011" +
                "0011" +
                "1101" +
                "";
    private List<GameObject> circs = new List<GameObject>();
    Level level = new Level();

    void MakeLevel(Level level)
    {
        float speed = -3.5f;
        level.speed = speed;
        level.circles = new int[lvl.Length / 4, 4];
        for (int i = 0; i < lvl.Length; i += 4)
        {
            for (int k = 0; k < 4; k++)
            {
                level.circles[i / 4, k] = int.Parse(""+lvl[i + k]);
            }
        }
        counter = level.speed / spaces * -1f;
    }
    void SpawnCircles(Level level)
    {
        if (counter < spaces*level.speed/-3.5f)
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
            circs[i].transform.position = new Vector3(circs[i].transform.position.x, circs[i].transform.position.y + level.speed*Time.deltaTime);
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
            foreach (var item in circs)
            {
                if (item.transform.position.x == FCircle1.position.x)
                {
                    if (item.transform.position.y < minYtop && item.transform.position.y > minYbot)
                    {
                        if (item.transform.position.y < perfectYtop && item.transform.position.y > perfectYbot)
                        {
                            print("1: perfect");
                        }
                        else
                        {
                            print("1: good");
                        }
                    }
                }
            }
        }
        #endregion f1
        #region f2
        if (Input.GetKey(KeyCode.J))
        {
            foreach (var item in circs)
            {
                if (item.transform.position.x == FCircle2.position.x)
                {
                    if (item.transform.position.y < minYtop && item.transform.position.y > minYbot)
                    {
                        if (item.transform.position.y < perfectYtop && item.transform.position.y > perfectYbot)
                        {
                            print("2: perfect");
                        }
                        else
                        {
                            print("2: good");
                        }
                    }
                }
            }
            #endregion f2
        #region f3
            if (Input.GetKey(KeyCode.K))
            {
                foreach (var item in circs)
                {
                    if (item.transform.position.x == FCircle3.position.x)
                    {
                        if (item.transform.position.y < minYtop && item.transform.position.y > minYbot)
                        {
                            if (item.transform.position.y < perfectYtop && item.transform.position.y > perfectYbot)
                            {
                                print("3: perfect");
                            }
                            else
                            {
                                print("3: good");
                            }
                        }
                    }
                }
            }
            #endregion f3
        #region f4
            if (Input.GetKey(KeyCode.K))
            {
                foreach (var item in circs)
                {
                    if (item.transform.position.x == FCircle4.position.x)
                    {
                        if (item.transform.position.y < minYtop && item.transform.position.y > minYbot)
                        {
                            if (item.transform.position.y < perfectYtop && item.transform.position.y > perfectYbot)
                            {
                                print("4: perfect");
                            }
                            else
                            {
                                print("4: good");
                            }
                        }
                    }
                }
            }
        }
       #endregion f4
    }

    void Start()
    {
        endPos = -5.29f;
        minYtop = -3.9f;
        minYbot = -4.61f;
        perfectYtop = -4.14f;
        perfectYbot = -4.34f;
        MakeLevel(level);
    }
    void Update()
    {
        SpawnCircles(level);
        MoveCircles();
        Click();
        
    }
}
