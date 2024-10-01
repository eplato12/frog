using UnityEngine;

public class tutorialscript : MonoBehaviour
{
    public GameObject UIElement;
    public KeyCode trigger;
    private static bool _hasInitialized = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(trigger))
        {
            Destroy(UIElement);
            _hasInitialized = true;
        }
    }

    private void Awake()
    {
        if (_hasInitialized)
        {
            UIElement.SetActive(false);
        }
    }
}
