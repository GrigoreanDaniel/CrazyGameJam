using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainGameScene : MonoBehaviour {
    public string SceneName;

    public void LoadMainScene() {
        SceneManager.LoadScene(1);
    }
}
