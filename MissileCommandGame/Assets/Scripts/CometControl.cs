using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometControl : MonoBehaviour
{

    public int EnemyTraj;

    void Start()
    {
        EnemyTraj = Random.Range(1, 3);

        if (EnemyTraj == 1)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(2, -2);
        }

        if (EnemyTraj > 1)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-2, -2);
        }
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Explosion(Clone)")
        {
            GameManager.CurrentScore += 10;
            Destroy(gameObject);
        }
    }
}
