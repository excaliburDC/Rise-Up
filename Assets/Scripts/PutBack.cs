using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutBack : MonoBehaviour
{
    public BirdPool PManager;

    private void OnEnable()
    {
        Invoke("PutBackInList", 5f);
    }

    public void PutBackInList()
    {
        if (PManager == null)
        {
            PManager = GameObject.Find("PoolManager").GetComponent<BirdPool>();
            PManager.PutInList(gameObject);
        }
        else
        {
            PManager.PutInList(gameObject);
        }
    }

}
