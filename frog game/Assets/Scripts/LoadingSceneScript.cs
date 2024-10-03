using UnityEngine;

public class LoadingSceneScript : MonoBehaviour
{
    public AdvanceScene advanceScene;

    void Start()
    {
        Invoke("ToNextLevel", 3.0f);
    }

    public void ToNextLevel()
    {
        string nextScene = SceneTransitionInfo.NextSceneName;
        if (!string.IsNullOrEmpty(nextScene))
        {
            advanceScene.toLevel(nextScene);
        }
    }
}
