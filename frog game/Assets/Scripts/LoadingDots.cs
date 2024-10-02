using UnityEngine;
using TMPro;
using System.Collections;

public class LoadingDots : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Reference to the TextMeshPro component
    public float dotAnimationDelay = 0.5f; // Delay between dot appearances

    private void Start()
    {
        // Start the loading dots animation
        StartCoroutine(AnimateLoadingDots());
    }

    private IEnumerator AnimateLoadingDots()
    {
        while (true) // Repeat indefinitely
        {
            // Show "Loading."
            textMeshPro.text = "Loading.";
            yield return new WaitForSeconds(dotAnimationDelay);

            // Show "Loading.."
            textMeshPro.text = "Loading..";
            yield return new WaitForSeconds(dotAnimationDelay);

            // Show "Loading..."
            textMeshPro.text = "Loading...";
            yield return new WaitForSeconds(dotAnimationDelay);
        }
    }
}
