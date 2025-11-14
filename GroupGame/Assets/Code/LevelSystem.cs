using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI LevelInfo2;
    [SerializeField] TextMeshProUGUI LevelInfo1;

    // Start is called before the first frame update
    
    void Start()
    {
        LevelInfo1.enabled = true;
        LevelInfo2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        Scene activeScene = SceneManager.GetActiveScene();

        if (GameObject.Find("Enemy") != null)
        {
            GameObject Enemy = GameObject.Find("Enemy");
            Enemy enemyScript = Enemy.GetComponent<Enemy>();
        }
        if (activeScene.name == "InfiniteLevel" && GameObject.Find("Enemy") == null)
        {
            return;
        }
        if (GameObject.Find("Enemy") == null && activeScene.name == "GameLevel")
        {
            Debug.Log("Continue to next level");
            SceneManager.LoadScene("GameLevel2");
            LevelInfo2.enabled= true;
            LevelInfo1.enabled= false;
        }
        if (GameObject.Find("Enemy") == null && activeScene.name == "GameLevel2")
        {
            SceneManager.LoadScene("InfiniteLevel");
            LevelInfo1.enabled = false;
            LevelInfo2.enabled = false;
        }

    }
}
