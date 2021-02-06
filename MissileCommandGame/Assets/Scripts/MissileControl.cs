using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControl : MonoBehaviour
{
    public float TimeKeeper = 0;
    public float FractDist = .04f;

    public Transform Explosion;
    // Start is called before the first frame update

    private Vector2 TargetPos;

    void Start()
    {
        GameManager.TargetPosition = GameManager.ObjPosition;
        GetComponent<Transform>().eulerAngles = new Vector3(0, 0, -15);
        TargetPos = GameManager.TargetPosition;
        Destroy(gameObject, 7.0f);
    }

    // Update is called once per frame
    void Update()
    {
        TimeKeeper += Time.deltaTime;

        if (TimeKeeper > 0.2f)
        {
            FractDist = .06f;
            TimeKeeper = 0;
        }
        transform.position = Vector2.Lerp(transform.position, TargetPos, .07f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.name == "Target(Clone)")
        {
            Destroy(gameObject);
            Instantiate(Explosion, transform.position, Explosion.rotation);
        }
    }
}
