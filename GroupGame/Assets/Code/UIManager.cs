using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Instructions;
    [SerializeField] TextMeshProUGUI WelcomeText;
    public Canvas LevelUI;

    public bool GameStarted = false;
    // Start is called before the first frame update

    void Start()
    {
        LevelUI.enabled = true;
        Instructions.enabled = false;
        WelcomeText.enabled = true;
        GameStarted = false;
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
    }
    void SetFalse()
    {
        LevelUI.enabled = false;
    }

}
