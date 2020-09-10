using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manager for loading different game scenes.
/// </summary>
public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// Switches the current menu scene by unloading the current scene and loading a new one.
    /// </summary>
    /// <param name="sceneName">The name of the scene to load.</param>
    public void SwitchMenuScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(SceneManager.sceneCount - 1));
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }
}
