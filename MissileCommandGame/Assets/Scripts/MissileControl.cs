using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControl : MonoBehaviour
{
    public float TimeKeeper = 0;
    public float FractDist = .01f;

    public Transform Explosion;
    // Start is called before the first frame update

    private Vector2 TargetPos;

    void Start()
    {
        GameManager.TargetPosition = GameManager.ObjPosition;
        GetComponent<Transform>().eulerAngles = new Vector3(0, 0, -15);
        TargetPos = GameManager.TargetPosition;
    }

    // Update is called once per frame
    void Update()
    {
        TimeKeeper += Time.deltaTime;

        if (TimeKeeper > 0.4f)
        {
            FractDist = .04f;
            TimeKeeper = 0;
        }
        transform.position = Vector2.Lerp(transform.position, TargetPos, FractDist);
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
