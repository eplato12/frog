using UnityEngine;

public class SpawnLilyPads : MonoBehaviour
{
    public GameObject[] waterRings;
    public GameObject[] lillies;

    private int[] numLillies = {20, 13, 8}; // array containing number of lillies for each water ring
    private Vector3[] lilyScales = {
        new Vector3((float)0.2685736, (float)0.2647871, 1),
        new Vector3((float)0.2746775, (float)0.270805, 1),
        new Vector3((float)0.3180476, (float)0.3135636, 1)};

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        // get radius of each circle by position of first lillies
        float[] radii = { lillies[0].transform.position.x, lillies[1].transform.position.x, lillies[2].transform.position.x };

        // loop through all three layers
        for (int i = 0; i < numLillies.Length; i++)
        {
            // to make the correct number of lillies in each layer
            for (int j = 1; j < numLillies[i]; j++)
            {
                float xPos = radii[i] * Mathf.Cos(2 * j * Mathf.PI / numLillies[i]);
                float yPos = radii[i] * Mathf.Sin(2* j * Mathf.PI / numLillies[i]);
                GameObject lily = Instantiate(lillies[i], new Vector3(xPos, yPos, 1), Quaternion.identity);
                lily.transform.parent = waterRings[i].transform;
                lily.transform.localScale = lilyScales[i];
            }
        }
    }
      
    // Update is called once per frame
    void Update()
    {
        
    }
}
