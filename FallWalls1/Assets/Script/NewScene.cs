using UnityEngine;
using UnityEngine.SceneManagement;

public class NewScene : MonoBehaviour
{
    public void NextScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
