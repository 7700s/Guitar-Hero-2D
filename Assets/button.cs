using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    public void TaskOnClick()
    {
        if (SceneManager.loadedSceneCount == 2)
        {
            SceneManager.UnloadSceneAsync("Level1");
        }
        SceneManager.LoadScene("Level1");
    }
}
