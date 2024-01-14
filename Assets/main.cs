using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    struct Level
    {
        public float speed;
        public int[,] circles;
        public int size;
    }
    public Transform FCircle1, FCircle2, FCircle3, FCircle4;
    private float startPos;
    private float endPos;
    private float minYtop;
    private float minYbot;
    private float perfectYtop;
    private float perfectYbot;
    private List<GameObject> circs;
    Level level = new Level();

    void Start()
    {
        startPos = FCircle1.position.y;
        endPos = -5.29f;
        minYtop = -3.9f;
        minYbot = -4.61f;
        perfectYtop = -4.14f;
        perfectYbot = -4.34f;
    }
    
    void MakeLevel(Level level)
    {
        float speed = -3.5f;
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
        level.size = lvl.Length/4;
        level.speed = speed;
        level.circles = new int[lvl.Length / 4, 4];
        for(int i = 0; i < lvl.Length; i += 4)
        {
            for(int k = 0; k < 4; k++)
            {
                level.circles[i / 4, k] = lvl[i + k];
            }
        }
    }
    void MoveCircles(Level level)
    {

        for(int i = 0; i < level.size; i++)
        {
            for(int k = 0; k < 4; k++)
            {
                if (level.circles[i * 4,k]==1)
                {
                    switch (k){
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
        }
    }

    void Click()
    {
        #region f1
        if (Input.GetKey(KeyCode.H))
        {
            foreach (var item in circs)
            {
                if(item.transform.position.x == FCircle1.position.x)
            }
            if(FCircle1.position.y < minYtop && FCircle1.position.y > minYbot)
            {
                if(FCircle1.position.y < perfectYtop && FCircle1.position.y > perfectYbot)
                {
                    print("1 perfect");
                }
                else
                {
                    print("1 good");
                }
                FCircle1.position = FCircle1.position = new Vector3(FCircle1.position.x, startPos);
            }
        }
        #endregion f1
        #region f2
        if (Input.GetKey(KeyCode.J))
        {
            if (FCircle2.position.y < minYtop && FCircle2.position.y > minYbot)
            {
                if (FCircle2.position.y < perfectYtop && FCircle2.position.y > perfectYbot)
                {
                    print("2 perfect");
                }
                else
                {
                    print("2 good");
                }
                FCircle2.position = new Vector3(FCircle2.position.x, startPos);
            }
        }
        #endregion f2
        #region f3
        if (Input.GetKey(KeyCode.K))
        {
            if (FCircle3.position.y < minYtop && FCircle3.position.y > minYbot)
            {
                if (FCircle3.position.y < perfectYtop && FCircle3.position.y > perfectYbot)
                {
                    print("3 perfect");
                }
                else
                {
                    print("3 good");
                }
                FCircle3.position = new Vector3(FCircle3.position.x, startPos);
            }
        }
        #endregion f3
        #region f4
        if (Input.GetKey(KeyCode.L))
        {
            if (FCircle4.position.y < minYtop && FCircle4.position.y > minYbot)
            {
                if (FCircle4.position.y < perfectYtop && FCircle4.position.y > perfectYbot)
                {
                    print("4 perfect");
                }
                else
                {
                    print("4 good");
                }
                FCircle4.position = new Vector3(FCircle4.position.x, startPos);
            }
        }
        #endregion f4
    }

    void Update()
    {
        MakeLevel(level);
        MoveCircles(level);
        Click();
    }
}
