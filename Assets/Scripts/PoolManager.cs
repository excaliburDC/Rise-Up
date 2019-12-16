using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager pInstance;
    public int poolSize = 15;
    public GameObject boxPrefab;
    // public List<GameObject> boxPrefab = new List<GameObject>();
    public float spawnRate = 5f;
    [SerializeField] private float minRange = -4.2f;
    [SerializeField] private float maxRange = -1.45f;
   

    [SerializeField]
    private List<GameObject> boxes = new List<GameObject>();
    private List<GameObject> tempBoxes = new List<GameObject>();
    private Vector2 objectPoolPosition;


    private float timeSinceLastSpawned;
    private Vector2 randomSize;
    private float xScale = 0.3f;
    private float yScale = 0.4f;
    private float spawnYPosition = 10f;
    public int currentBox = 0;
    private int spawnPrefabIndex;
    int temp = 0;
    int num = 0;
    float TempScale = 0f;

    void Awake()
    {
        if (pInstance == null)
            pInstance = this;

        else if (pInstance != this)
            Destroy(gameObject);


    }


    // Start is called before the first frame update
    void Start()
    {
        CreatePrefab();

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameManager.instance.gameOver == false && GameManager.instance.gameStarted == true && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;
            //PutInWorld();


            temp = Random.Range(1, 3);
            SpawnBoxes(temp);

        }

    }

    public void CreatePrefab()
    {
        objectPoolPosition = new Vector2(Random.Range(-4.2f, -1.8f), 6.5f);
        for (int i = 0; i < poolSize; i++)
        {
            //spawnPrefabIndex = Random.Range(0, boxPrefab.Count);
            var boxObj = Instantiate(boxPrefab, objectPoolPosition, Quaternion.identity);
           // boxObj.SetActive(false);
            boxObj.transform.localScale = Vector2.one * Random.Range(xScale, yScale);
            num++;
            boxObj.name = num.ToString();


            boxes.Add(boxObj);
        }
    }



    private void SpawnBoxes(int n)
    {
        float spawnXPosition = Random.Range(minRange, maxRange);

        switch (n)
        {
            case 1:
                currentBox++;
                boxes[currentBox].transform.position = new Vector2(spawnXPosition, spawnYPosition);
                // currentBox++;

                if (currentBox >= 12)
                    currentBox = 0;

                break;

            case 2:
                float spawnXPosition2 = Random.Range(minRange, -2.65f);
                currentBox++;
                var bObj = boxes[currentBox];
                bObj.name = "H1";
                TempScale = -1 * (bObj.transform.localScale.x / 2);
                bObj.transform.position = new Vector2(spawnXPosition2, spawnYPosition);
                currentBox++;


                var bObj1 = boxes[currentBox];
                bObj1.name = "H2";
                TempScale -= (bObj.transform.localScale.x * 2);
                bObj1.transform.position = new Vector2(spawnXPosition2 - TempScale-0.06f, spawnYPosition);
                // Debug.LogError("TWO BOXES " + bObj.name.ToString() + "  " + bObj1.name.ToString() );



                if (currentBox >= 12)
                    currentBox = 0;

                break;

               
        }


    }

}



