using UnityEngine.SceneManagement;
using UnityEngine;

public class NewScene : MonoBehaviour
{
    public void NextScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
