using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    public float DeadEnemies;
    [SerializeField] TextMeshProUGUI LevelInfo2;
    [SerializeField] TextMeshProUGUI LevelInfo1;
    public TextMeshProUGUI EnemiesKilled;
    public int killCount;

    // Start is called before the first frame update
    
    void Start()
    {
        LevelInfo1.enabled = true;
        LevelInfo2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("Enemy") != null)
        {
            GameObject Enemy = GameObject.Find("Enemy");
            Enemy enemyScript = Enemy.GetComponent<Enemy>();
        }
        else
        {
            Debug.Log("Continue to next level");
            SceneManager.LoadScene("GameLevel2");
            LevelInfo2.enabled= true;
            LevelInfo1.enabled= false;
        }

    }

    public void increaseScore()
    {
        killCount++;
        EnemiesKilled.text = killCount.ToString();
    }
}
