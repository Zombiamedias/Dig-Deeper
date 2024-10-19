using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("IntroVideoScene"); 
    }
    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}