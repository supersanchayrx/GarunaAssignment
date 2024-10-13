using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTracker : MonoBehaviour
{
    private static SceneTracker _instance;

    // had to add this to keep track of the scene
    public string LastScene { get; private set; }

    private void Awake()
    {
        // making it persistent
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); // duplicacy avoider
        }
    }

    public void LoadScene(string sceneName)
    {
        // storing current scene info
        LastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);



        Debug.Log("last scene" + LastScene);
    }
}
