using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingControl : MonoBehaviour
{
    public Transform Explosion;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Comet(Clone)")
        {
            Instantiate(Explosion, transform.position, Explosion.rotation);
            gameObject.SetActive(false);
            GameManager.Life -= 1;
        }
    }
}
