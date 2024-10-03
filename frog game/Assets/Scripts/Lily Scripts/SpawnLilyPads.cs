using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class SpawnLilyPads : MonoBehaviour

   
{
    [Header("Lilypad Objects")]
    public GameObject[] waterRings;
    public GameObject[] lillies;

    [Header("Other Objects")]
    public GameObject portal;
    public GameObject star;

    [Header("Level Indicator")]
    public int level;

    private lily lilies;


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
        else if (level == 5)
        {
            SpawnLevel5();
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

                    lilies = lily.GetComponent<lily>();

                    bool isEvil = Random.Range(0, 10) < 6;

                    lilies.SetIsEvil(isEvil);
                }

            }
        }
    }

    private void SpawnLevel4()
    {
        // this level will choose a location to spawn the portal at multiple times throughout the game
        List<GameObject> spawnedLillies = new List<GameObject>();

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

                lilies = lily.GetComponent<lily>();

                bool isEvil = Random.Range(0, 10) < 6;

                lilies.SetIsEvil(isEvil);

                // add lily to array to access later
                spawnedLillies.Add(lily);
            }
        }

        // spawn the portal at random locations throughout the game
        StartCoroutine(RespawnPortal(spawnedLillies));
    }

    private IEnumerator RespawnPortal(List<GameObject> lillies)
    {
        GameObject portalLily = lillies[35];
        portalLily.SetActive(false);

        GameObject newPortal = Instantiate(portal, portalLily.transform.position, Quaternion.identity);
        newPortal.transform.parent = portalLily.transform.parent;

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(6, 10));

            // reactivate portalLily + remove portal
            portalLily.SetActive(true);
            Destroy(newPortal);

            // choose a new lily to replace with portal
            portalLily = lillies[(int)Mathf.Floor(Random.Range(0, lillies.Count - 1))];
            portalLily.SetActive(false);

            // create a portal at that location
            newPortal = Instantiate(portal, portalLily.transform.position, Quaternion.identity);
            newPortal.transform.parent = portalLily.transform.parent;
        }
    }

    private void SpawnLevel5()
    {
        // create a list to store the lily game objects to spawn stars on
        List<GameObject> spawnedLillies = new List<GameObject>();

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

                GameObject lily = null;

                // choose what to spawn (lily, water, etc.)
                float probLily = Random.Range(0, 10);
                if (probLily < 8.5)
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

                    spawnedLillies.Add(lily);
                }
            }
        }

        // spawn stars 
        for (int k = 0; k < 2; k++)
        {
            // randomly select lillies to spawn a star on
            GameObject starLily1 = spawnedLillies[(int)Mathf.Floor(Random.Range(0, spawnedLillies.Count - 1))];
            // spawn a star on that lily 
            GameObject star1 = Instantiate(star, starLily1.transform.position, Quaternion.identity);
            star1.transform.parent = starLily1.transform;
        }
    }
}
