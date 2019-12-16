using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public int mCollectibleSize = 5;
    public GameObject collectiblePrefab;
    public float mSpawnRate = 10f;
    public float mMinRange = -4.32f;
    public float mMaxRange = -1.58f;
    public float minInitialPos = -4.37f;
    public float maxInitialPos = -1.55f;




    [SerializeField]
    private List<GameObject> mCollectibles = new List<GameObject>();
    private Vector2 mObjectPoolPosition;
    private float initialYPos = 8.19f;
    private float mTimeSinceLastSpawned;
    private float mSpawnYPosition = 11f;
    private int currentCollectible = 0;
    private float mSpawnSize;

    // Start is called before the first frame update
    void Start()
    {
        CreateCollectiblePrefab(collectiblePrefab);
    }

    // Update is called once per frame
    void Update()
    {
        mTimeSinceLastSpawned += Time.deltaTime;

        if (GameManager.instance.gameOver == false && GameManager.instance.gameStarted == true && mTimeSinceLastSpawned >= mSpawnRate)
        {
            mTimeSinceLastSpawned = 0f;
            SpawnCollectibles();
        }
    }

    public void CreateCollectiblePrefab(GameObject collectible)
    {
        float initialXPos = Random.Range(minInitialPos, maxInitialPos);
        mObjectPoolPosition = new Vector2(initialXPos, initialYPos);


        for (int i = 0; i < mCollectibleSize; i++)
        {
           var collectibleObj = Instantiate(collectible, mObjectPoolPosition, Quaternion.identity);
           mCollectibles.Add(collectibleObj);
        }
    }

    private void SpawnCollectibles()
    {
        
        float mSpawnXPosition = Random.Range(mMinRange, mMaxRange);
        mCollectibles[currentCollectible].SetActive(true);
        mCollectibles[currentCollectible].transform.position = new Vector2(mSpawnXPosition, mSpawnYPosition);
        currentCollectible++; 

        if (currentCollectible >= mCollectibleSize)
            currentCollectible = 0;

    }
}
