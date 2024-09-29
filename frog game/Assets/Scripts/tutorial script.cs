using UnityEngine;

public class tutorialscript : MonoBehaviour
{
    public GameObject UIelement;
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
            Destroy(UIelement);
            _hasInitialized = true;
        }

        if (trigger == KeyCode.None)
        {
            _hasInitialized = true;
        }
    }

    private void Awake()
    {
        if (_hasInitialized)
        {
            UIelement.SetActive(false);
        }
    }
}
