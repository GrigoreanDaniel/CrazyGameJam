using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainGameScene : MonoBehaviour {
    public string mainGameSceneName;

    public void LoadMainScene() {
        SceneManager.LoadScene(mainGameSceneName);
    }
}
