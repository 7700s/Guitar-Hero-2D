using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform FCircle1, FCircle2, FCircle3, FCircle4;
    private Vector3 startPos;
    private float endPos;
    private float speed = 2.0f;
    private float minYtop;
    private float minYbot;
    private float perfectYtop;
    private float perfectYbot;
 

    void Start()
    {
        speed *= -1f;
        startPos = FCircle1.position;
        endPos = -5.29f;
        minYtop =  -3.9f;
        minYbot = -4.61f;
        perfectYtop = -4.14f;
        perfectYbot = -4.34f;
    }


    void MoveCircles()
    {
        FCircle1.position += new Vector3(0, speed * Time.deltaTime);
        if (FCircle1.position.y < endPos) FCircle1.position = startPos;
        
    }

    void Click()
    {
        if (Input.GetKey(KeyCode.A))
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
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveCircles();
        Click();
    }
}
