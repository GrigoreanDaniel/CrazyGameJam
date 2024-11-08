using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStartScene : MonoBehaviour {
    public string SceneName;

    public void LoadMainScene() {
        SceneManager.LoadScene(0);
    }
}
