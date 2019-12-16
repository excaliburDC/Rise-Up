using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D skyCollider;
    private float skyVerticalLength;

    // Start is called before the first frame update
    void Start()
    {
        skyCollider = GetComponent<BoxCollider2D>();
        skyVerticalLength = skyCollider.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -skyVerticalLength)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector2 offset = new Vector2(0, skyVerticalLength * 2f);
        transform.position = (Vector2)transform.position + offset;
    }
}
