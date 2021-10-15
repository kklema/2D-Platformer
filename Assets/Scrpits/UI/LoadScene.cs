using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void ChooseTheScene()
    {
        SceneManager.LoadScene(1);
    }
}
