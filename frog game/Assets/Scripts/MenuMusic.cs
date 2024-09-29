using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public static MenuMusic instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
