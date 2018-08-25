using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneTrans : MonoBehaviour
{

    public void changeToScene(string sceneToChangeTo)
    {
        GameManager.Instance.ResetBlocks();
        SceneManager.LoadScene(sceneToChangeTo);
    }
}
