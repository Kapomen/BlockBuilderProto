using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour
{

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        if (objs.Length > 1)
            Destroy(this.gameObject);



        DontDestroyOnLoad(this.gameObject);

    }

    void Update()
    {
        Scene sceneloadf = SceneManager.GetActiveScene();
        //Debug.Log("scenenumber " + sceneloadf.buildIndex);
        if (sceneloadf.buildIndex == 1 || sceneloadf.buildIndex == 2 || sceneloadf.buildIndex == 3 || sceneloadf.buildIndex == 5)
        {
            Destroy(this.gameObject);
        }
        else if (sceneloadf.buildIndex == 4)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
