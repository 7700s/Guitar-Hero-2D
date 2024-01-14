using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform FCircle1, FCircle2, FCircle3, FCircle4;
    private float startPos;
    private float endPos;
    private float speed = 2.0f;
    private float minYtop;
    private float minYbot;
    private float perfectYtop;
    private float perfectYbot;
 

    void Start()
    {
        speed *= -1f;
        startPos = FCircle1.position.y;
        endPos = -5.29f;
        minYtop =  -3.9f;
        minYbot = -4.61f;
        perfectYtop = -4.14f;
        perfectYbot = -4.34f;
    }


    void MoveCircles()
    {
        FCircle1.position += new Vector3(0, speed * Time.deltaTime);
        if (FCircle1.position.y < endPos) FCircle1.position = new Vector3(FCircle1.position.x,startPos);
        
    }

    void Click()
    {
        #region f1
        if (Input.GetKey(KeyCode.H))
        {
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
            if (FCircle2.position.y < minYtop && FCircle1.position.y > minYbot)
            {
                if (FCircle2.position.y < perfectYtop && FCircle2.position.y > perfectYbot)
                {
                    print("2 perfect");
                }
                else
                {
                    print("2 good");
                }
                FCircle2.position = FCircle2.position = new Vector3(FCircle2.position.x, startPos);
            }
        }
        #endregion f2

    }

    // Update is called once per frame
    void Update()
    {
        MoveCircles();
        Click();
    }
}
