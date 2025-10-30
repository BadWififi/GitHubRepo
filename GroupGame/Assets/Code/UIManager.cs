using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Instructions;
    [SerializeField] TextMeshProUGUI WelcomeText;
    [SerializeField] TextMeshProUGUI SecretArea;
    [SerializeField] TextMeshProUGUI LevelInfo1;
    [SerializeField] TextMeshProUGUI LevelInfo2;
    public Canvas LevelUI;

    public bool GameStarted = false;
    // Start is called before the first frame update

    void Start()
    {
        LevelUI.enabled = true;
        Instructions.enabled = false;
        WelcomeText.enabled = true;
        GameStarted = false;
        SecretArea.enabled = false;
        LevelInfo2.enabled = false;
        LevelInfo1.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) && GameStarted == false)
        {
            WelcomeText.enabled = false;
            Instructions.enabled = true;
            GameStarted = true;
        }
        if (GameStarted == true)
        {
            Invoke("SetFalse", 5.0f); // disable after 5 secondse;
        }
        if (SceneManager.GetActiveScene().name == "GameLevel")
        {
            Instructions.enabled = false;
            WelcomeText.enabled = true;
            GameStarted = false;
            SecretArea.enabled = false;
            LevelInfo1.enabled = true;
        }
        if (SceneManager.GetActiveScene().name == "SecretArea")
        {
            SecretArea.enabled = true;
            WelcomeText.enabled = false;
            Instructions.enabled = false;
            Invoke("SecretZone", 0.4f);
        }
        if (SceneManager.GetActiveScene().name == "GameLevel2")
        {
            Instructions.enabled = false;
            WelcomeText.enabled = false;
            GameStarted = false;
            SecretArea.enabled = false;
            LevelInfo1.enabled = true;
            LevelInfo2.enabled = false;
        }

    }
    void SetFalse()
    {
        LevelUI.enabled = false;
    }
    void SecretZone()
    {
        SecretArea.enabled = false;
    }


}
