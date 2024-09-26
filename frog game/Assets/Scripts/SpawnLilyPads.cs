using UnityEngine;

public class SpawnLilyPads : MonoBehaviour
{
    public GameObject[] waterRings;
    public GameObject[] lillies;
    public int level;

    private int[] numLillies = {20, 14, 7}; // array containing number of lillies for each water ring
    private Vector3[] lilyScales = {
        new Vector3((float)0.3328913, (float)0.328198, 1),
        new Vector3((float)0.3505113, (float)0.3406977, 1),
        new Vector3((float)0.4058551, (float)0.394492, 1)}; // array containing the local scales of each lily

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        if (level == 1)
        {
            SpawnLevel1();
        }
        else if (level == 2)
        {
            SpawnLevel2();
        }
        else if (level == 3)
        {
            SpawnLevel3();
        }
        else if (level == 4)
        {
            SpawnLevel4();
        }
    }


    private void SpawnLevel1()
    {
        // get radius of each circle by position of first lillies
        float[] radii = { lillies[0].transform.position.x, lillies[1].transform.position.x, lillies[2].transform.position.x };

        // loop through all three layers
        for (int i = 0; i < numLillies.Length; i++)
        {
            // to make the correct number of lillies in each layer
            for (int j = 1; j < numLillies[i]; j++)
            {
                // get x and y position of new lily (depends on number of lillies)
                float xPos = radii[i] * Mathf.Cos(2 * j * Mathf.PI / numLillies[i]);
                float yPos = radii[i] * Mathf.Sin(2 * j * Mathf.PI / numLillies[i]);

                // instantiate that object 
                GameObject lily = Instantiate(lillies[i], new Vector3(xPos, yPos, 1), Quaternion.identity);

                // set it as a child of the water rings to make it rotate 
                lily.transform.parent = waterRings[i].transform;
                lily.transform.localScale = lilyScales[i];
            }
        }
    }

    private void SpawnLevel2()
    {
        // get radius of each circle by position of first lillies
        float[] radii = {lillies[0].transform.position.x, lillies[1].transform.position.x, lillies[2].transform.position.x };

        // loop through all three layers
        for (int i = 0; i < numLillies.Length; i++)
        {
            // to make the correct number of lillies in each layer
            for (int j = 1; j < numLillies[i]; j++)
            {
                // get x and y position of new lily (depends on number of lillies)
                float xPos = radii[i] * Mathf.Cos(2 * j * Mathf.PI / numLillies[i]);
                float yPos = radii[i] * Mathf.Sin(2 * j * Mathf.PI / numLillies[i]);

                GameObject lily = null;

                // choose what to spawn (lily, water, etc.)
                float probLily = Random.Range(0, 10);
                if (probLily < 7)
                {
                    lily = lillies[i];
                }

                if (lily != null)
                {
                    // instantiate that object 
                    lily = Instantiate(lillies[i], new Vector3(xPos, yPos, 1), Quaternion.identity);

                    // set it as a child of the water rings to make it rotate 
                    lily.transform.parent = waterRings[i].transform;
                    lily.transform.localScale = lilyScales[i];
                }
            }
        }
    }

    private void SpawnLevel3()
    {
        SpawnLevel1();
    }

    private void SpawnLevel4()
    {
        SpawnLevel1();
    }
}
