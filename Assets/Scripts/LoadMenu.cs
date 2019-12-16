using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMenu : MonoBehaviour
{
    public static LoadMenu mInstance;
    // Start is called before the first frame update
    void Awake()
    {
        if (mInstance == null)
            mInstance = this;

        else if (mInstance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

    
}
