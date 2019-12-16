using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPool : MonoBehaviour
{
    public static BirdPool bInstance;
    public int birdPoolSize = 5;
    public GameObject enemyBirdPrefab;
    public float birdSpawnRate = 5f;
    private float lastBirdSpawned;


    [SerializeField] private List<GameObject> enemyBirdList;
    private Vector2 leftSpawnPos;
    private Vector2 rightSpawnPos; 
    private List<Vector2> possibleSpawnPos = new List<Vector2>();


    private int num = 0;


    void Awake()
    {
        if (bInstance == null)
            bInstance = this;

        else if (bInstance != this)
            Destroy(gameObject);


    }

    // Start is called before the first frame update
    void Start()
    {
        CreateBird(enemyBirdPrefab);
        
        possibleSpawnPos.Add(leftSpawnPos);
        possibleSpawnPos.Add(rightSpawnPos);
    }

    // Update is called once per frame
    void Update()
    {
        lastBirdSpawned += Time.deltaTime;

        if (GameManager.instance.gameOver == false && GameManager.instance.gameStarted == true && lastBirdSpawned >= birdSpawnRate)
        {
            lastBirdSpawned = 0f;
            PutInWorld();
        }
    }

    void CreateBird(GameObject bird)
    {
        for (int i = 0; i < birdPoolSize; i++)
        {
            var birdObj = Instantiate(bird, transform.position, Quaternion.identity);
            birdObj.SetActive(false);
            num++;
            birdObj.name = "Bird " + num.ToString();

            enemyBirdList.Add(birdObj);
        }
       

    }

    public void PutInList(GameObject gObj)
    {
        gObj.GetComponent<SpriteRenderer>().flipX = false;
        gObj.SetActive(false);
        enemyBirdList.Add(gObj);

    }

    public void PutInWorld()
    {
        ChangeRandomPos();
        int randomSpawnPos = Random.Range(0, possibleSpawnPos.Count);
        Vector2 randSpawn = possibleSpawnPos[randomSpawnPos];
        var count = (enemyBirdList.Count - 1);
        var birdObj = enemyBirdList[count];
      
        enemyBirdList.RemoveAt(count);
        birdObj.transform.position = randSpawn;
       
        if (randomSpawnPos == 1)
            birdObj.GetComponent<SpriteRenderer>().flipX = true;
        

        birdObj.SetActive(true);
    }

    void ChangeRandomPos()
    {
        float randomYPos = Random.Range(-1.6f, 1.2f);
        possibleSpawnPos[0] = new Vector2(-6.5f, randomYPos);
        possibleSpawnPos[1] = new Vector2(0.3f, randomYPos);
    }

}
