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

    private lily Lily;


    private int[] numLillies = { 20, 14, 7 }; 
    private Vector3[] lilyScales = {
            new Vector3((float)0.3328913, (float)0.328198, 1),
            new Vector3((float)0.3505113, (float)0.3406977, 1),
            new Vector3((float)0.4058551, (float)0.394492, 1)}; 

    

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
        
        float[] circleRadii = { lillies[0].transform.position.x, lillies[1].transform.position.x, lillies[2].transform.position.x };

        
        for (int i = 0; i < numLillies.Length; i++)
        {
            
            for (int j = 1; j < numLillies[i]; j++)
            {
                
                float xPosLily = circleRadii[i] * Mathf.Cos(2 * j * Mathf.PI / numLillies[i]);
                float yPosLily = circleRadii[i] * Mathf.Sin(2 * j * Mathf.PI / numLillies[i]);

                
                GameObject lily = Instantiate(lillies[i], new Vector3(xPosLily, yPosLily, 1), Quaternion.identity);

                
                lily.transform.parent = waterRings[i].transform;
                lily.transform.localScale = lilyScales[i];
            }
        }
    }

    private void SpawnLevel2()
    {
        
        float[] circleRadii = { lillies[0].transform.position.x, lillies[1].transform.position.x, lillies[2].transform.position.x };

        
        for (int i = 0; i < numLillies.Length; i++)
        {
            
            for (int j = 1; j < numLillies[i]; j++)
            {
                
                float xPosLily = circleRadii[i] * Mathf.Cos(2 * j * Mathf.PI / numLillies[i]);
                float yPosLily = circleRadii[i] * Mathf.Sin(2 * j * Mathf.PI / numLillies[i]);

                GameObject lily = null;

                
                float lilySpawnProbability = Random.Range(0, 10);
                if (lilySpawnProbability < 7)
                {
                    lily = lillies[i];
                }

                if (lily != null)
                {
                    
                    lily = Instantiate(lillies[i], new Vector3(xPosLily, yPosLily, 1), Quaternion.identity);

                    
                    lily.transform.parent = waterRings[i].transform;
                    lily.transform.localScale = lilyScales[i];
                }
            }
        }
    }

    private void SpawnLevel3()
    {
        
        float[] circleRadii = { lillies[0].transform.position.x, lillies[1].transform.position.x, lillies[2].transform.position.x };

        
        for (int i = 0; i < numLillies.Length; i++)
        {
            
            for (int j = 1; j < numLillies[i]; j++)
            {
                
                float xPosLily = circleRadii[i] * Mathf.Cos(2 * j * Mathf.PI / numLillies[i]);
                float yPosLily = circleRadii[i] * Mathf.Sin(2 * j * Mathf.PI / numLillies[i]);

                GameObject lily = null;

                
                float lilySpawnProbability = Random.Range(0, 10);
                if (lilySpawnProbability < 7)
                {
                    lily = lillies[i];
                }
                if (lily != null)
                {
                    
                    lily = Instantiate(lillies[i], new Vector3(xPosLily, yPosLily, 1), Quaternion.identity);

                     
                    lily.transform.parent = waterRings[i].transform;
                    lily.transform.localScale = lilyScales[i];

                    Lily = lily.GetComponent<lily>();

                    bool isEvil = Random.Range(0, 10) < 7;

                    Lily.SetIsEvil(isEvil);
                }

            }
        }
    }

    private void SpawnLevel4()
    {
        
        List<GameObject> spawnedLillies = new List<GameObject>();

        
        float[] circleRadii = { lillies[0].transform.position.x, lillies[1].transform.position.x, lillies[2].transform.position.x };

        
        for (int i = 0; i < numLillies.Length; i++)
        {
            
            for (int j = 1; j < numLillies[i]; j++)
            {
                
                float xPosLily = circleRadii[i] * Mathf.Cos(2 * j * Mathf.PI / numLillies[i]);
                float yPosLily = circleRadii[i] * Mathf.Sin(2 * j * Mathf.PI / numLillies[i]);

                
                GameObject lily = Instantiate(lillies[i], new Vector3(xPosLily, yPosLily, 1), Quaternion.identity);

                
                lily.transform.parent = waterRings[i].transform;
                lily.transform.localScale = lilyScales[i];

                Lily = lily.GetComponent<lily>();

                bool isEvil = Random.Range(0, 10) < 3;

                Lily.SetIsEvil(isEvil);

                
                spawnedLillies.Add(lily);

                
            }
        }

        
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

            
            portalLily.SetActive(true);
            Destroy(newPortal);

            
            portalLily = lillies[(int)Mathf.Floor(Random.Range(0, lillies.Count - 1))];
            portalLily.SetActive(false);

            
            newPortal = Instantiate(portal, portalLily.transform.position, Quaternion.identity);
            newPortal.transform.parent = portalLily.transform.parent;
        }
    }

    private void SpawnLevel5()
    {
        
        List<GameObject> spawnedLillies = new List<GameObject>();

        
        float[] circleRadii = { lillies[0].transform.position.x, lillies[1].transform.position.x, lillies[2].transform.position.x };

        
        for (int i = 0; i < numLillies.Length; i++)
        {
            
            for (int j = 1; j < numLillies[i]; j++)
            {
                
                float xPos = circleRadii[i] * Mathf.Cos(2 * j * Mathf.PI / numLillies[i]);
                float yPos = circleRadii[i] * Mathf.Sin(2 * j * Mathf.PI / numLillies[i]);

                GameObject lily = null;

               
                float probLily = Random.Range(0, 10);
                if (probLily < 8.5)
                {
                    lily = lillies[i];
                }

                if (lily != null)
                {
                    
                    lily = Instantiate(lillies[i], new Vector3(xPos, yPos, 1), Quaternion.identity);

                    
                    lily.transform.parent = waterRings[i].transform;
                    lily.transform.localScale = lilyScales[i];

                    Lily = lily.GetComponent<lily>();

                    bool isEvil = Random.Range(0, 10) < 3;

                    Lily.SetIsEvil(isEvil);

                    spawnedLillies.Add(lily);
                }
            }
        }

         
        for (int k = 0; k < 2; k++)
        {
            
            GameObject starLily1 = spawnedLillies[(int)Mathf.Floor(Random.Range(0, spawnedLillies.Count - 1))]; 
            GameObject star1 = Instantiate(star, starLily1.transform.position, Quaternion.identity);
            star1.transform.parent = starLily1.transform;
        }
    }
}
