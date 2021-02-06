using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Texture2D DefaultTexture;
    public CursorMode CurMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public Vector2 MousePosition;
    public static Vector2 ObjPosition;
    public static Vector2 TargetPosition;

    public Transform MissileObj;

    public Transform MissileBase1;

    public Transform LockOnTraget;

    public Transform Comet;

    public Transform ScoreObj;

    public float SpawnTimer;

    public int SpawnPos;

    public static int Life = 9;

    public static int CurrentScore=0;

    public List<Transform> MissileBases;

    public List<GameObject> Buildings;

    private bool GameStart = false;

    public GameObject MainMenu;

    public GameObject GameOverMenu;

    public Text LastScoreText;

    public Text HighScoreText;

    private int HighScore=0;

    // Update is called once per frame'

    private void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore");
    }
    void Update()
    {
        if (GameManager.Life <= 0)
        {
            GameStart = false;
            GameOver();
        }
        if (GameStart)
        {
            EnemySpawn();

            MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            ObjPosition = Camera.main.ScreenToWorldPoint(MousePosition);

            ScoreObj.GetComponent<TextMesh>().text = "Score:" + CurrentScore;

            if (Input.GetMouseButtonDown(0))
            {
                //GetClosestEnemy(ObjPosition);
                Instantiate(MissileObj, GetClosestEnemy(ObjPosition).position, MissileObj.rotation);
                Instantiate(LockOnTraget, ObjPosition, LockOnTraget.rotation);

            }
        }
    }

    void EnemySpawn()
    {
        SpawnTimer += Time.deltaTime;

        if (SpawnTimer > 1)
        {
            SpawnPos = Random.Range(-9, 9);
            SpawnTimer = 0;
            Instantiate(Comet, new Vector2(SpawnPos, 6), Comet.rotation);
        }
    }

    Transform GetClosestEnemy(Vector2 fromThis)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = fromThis;
        foreach (Transform potentialTarget in MissileBases)
        {
            if (!potentialTarget.gameObject.activeSelf) continue;
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }

    private void GameOver()
    {
        if (CurrentScore >= HighScore)
        {
            HighScore = CurrentScore;
            PlayerPrefs.SetInt("HighScore", CurrentScore);
        }

        LastScoreText.text = "Last Score:" + CurrentScore;
        HighScoreText.text = "High Score:" + HighScore;

        GameOverMenu.SetActive(true);
    }

    public void StartGame()
    {
        foreach (GameObject o in Buildings)
        {
            o.SetActive(true);
        }
        MainMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        GameStart = true;
        CurrentScore = 0;
        Life = 9;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
