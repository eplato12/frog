using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnLilyPads : MonoBehaviour


{
    public GameObject[] evilLillies;
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
            StartCoroutine(SpawnLevel3());
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



    private IEnumerator SpawnLevel3()
    {
        // Get radius of each circle by position of first lillies
        float[] radii = { lillies[0].transform.position.x, lillies[1].transform.position.x, lillies[2].transform.position.x };
        List<GameObject> spawnedLillies = new System.Collections.Generic.List<GameObject>();

        // Loop through all three layers
        for (int i = 0; i < numLillies.Length; i++)
        {
            // Spawn the correct number of lillies in each layer
            for (int j = 1; j < numLillies[i]; j++)
            {
                // Calculate x and y position of the new lily based on the number of lillies
                float xPos = radii[i] * Mathf.Cos(2 * j * Mathf.PI / numLillies[i]);
                float yPos = radii[i] * Mathf.Sin(2 * j * Mathf.PI / numLillies[i]);

                GameObject lily = Instantiate(lillies[i], new Vector3(xPos, yPos, 1), Quaternion.identity);

                // Set it as a child of the water ring to make it rotate
                lily.transform.parent = waterRings[i].transform;
                lily.transform.localScale = lilyScales[i];

                // Add lily to the list
                spawnedLillies.Add(lily);

                // Short delay before spawning the next lily
                yield return new WaitForSeconds(0.1f);
            }
        }

        // Wait for a short time before replacing some lilies with evil lilies
        yield return new WaitForSeconds(2f);

        // Shuffle the list and select approximately 1/3 of them
        int numToReplace = spawnedLillies.Count / 3;
        System.Random rand = new System.Random();
        spawnedLillies = spawnedLillies.OrderBy(x => rand.Next()).ToList();

        for (int k = 0; k < numToReplace; k++)
        {
            GameObject originalLily = spawnedLillies[k];
            Vector3 position = originalLily.transform.position;

            // Get the index `i` of the layer this lily belongs to for evilLily instantiation
            int layerIndex = originalLily.transform.parent.GetSiblingIndex();

            // Spawn the evilLily in the same position
            GameObject evilLily = Instantiate(evilLillies[layerIndex], position, Quaternion.identity);
            evilLily.transform.parent = waterRings[layerIndex].transform;
            evilLily.transform.localScale = lilyScales[layerIndex];

            // Destroy the original lily
            Destroy(originalLily);
        }
    }






    private void SpawnLevel4()
    {
        SpawnLevel1();
    }




}
