using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSystem : MonoBehaviour
{
    public float DeadEnemies;
    // Start is called before the first frame update
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("Enemy") != null)
        {
            GameObject Enemy = GameObject.Find("Enemy");
            Enemy enemyScript = Enemy.GetComponent<Enemy>();
            DeadEnemies = enemyScript.numOfEnemyKilled;
        }
        else
        {
            Debug.Log("Continue to next level");
            SceneManager.LoadScene("GameLevel2");
        }

        
    }
}
