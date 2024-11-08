using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerCutsceneOnCollision : MonoBehaviour {
    public string cutsceneSceneName = "EndCutscene"; // Set the cutscene scene name here

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            SceneManager.LoadScene(2);
        }
    }
}
