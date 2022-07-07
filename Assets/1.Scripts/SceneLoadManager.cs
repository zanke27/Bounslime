using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    void Start()
    {
        EventManager.StartListening("ReStart", DoRestart);
    }

    private void DoRestart(EventParam eventParam)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameChoiceStart()
    {
        StartCoroutine(LoadChoiceScene());
    }

        IEnumerator LoadChoiceScene()
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("ChoiceScene");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private void OnDestroy()
    {
        EventManager.StopListening("ReStart", DoRestart);
    }
}
