 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI MoneyText;
    public GameObject WeaponsShop;
    public GameObject AbilityShop;
    public GameObject UpgradeShop;
    public int Bread = 31;
    // Start is called before the first frame update
    void Start()
    {
        MoneyText.text = $"AUD {Bread}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void WeaponsMenu()
    {
       

        WeaponsShop.SetActive(true);
        AbilityShop.SetActive(false);
        UpgradeShop.SetActive(false);
    }

    public void AbilitysShop()
    {
        WeaponsShop.SetActive(false);
        AbilityShop.SetActive(true);
        UpgradeShop.SetActive(false);
    }

    public void UpgradesShop()
    {
        WeaponsShop.SetActive(false);
        AbilityShop.SetActive(false);
        UpgradeShop.SetActive(true);
    }

    public void BuySoul()
    {
        if (Bread - 10 < 0)
        {
            Debug.Log("in debt dumbass");
            
        }
        else
        {
            Bread -= 10;
            MoneyText.text = $"AUD {Bread}";
        }
    }

}
