using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttonlogic : MonoBehaviour
{
    public void StartButtonClicked()
    {
        SceneManager.LoadSceneAsync("Present");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
