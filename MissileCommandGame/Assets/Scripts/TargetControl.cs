using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControl : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 7.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Missile(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
