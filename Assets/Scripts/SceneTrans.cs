using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneTrans : MonoBehaviour
{

    public void changeToScene(string sceneToChangeTo)
    {
        SceneManager.LoadScene(sceneToChangeTo);
    }
}
