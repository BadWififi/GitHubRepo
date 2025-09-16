 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI MoneyText;
    public GameObject WeaponsShop;
    public GameObject AbilityShop;
    public GameObject UpgradeShop;
    public int Bread = 31;
    public GameObject Shopifi;
    public float slidertime = 0;
    public Slider timer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        MoneyText.text = $"GEO {Bread}";
        WeaponsShop.SetActive(false);
        Shopifi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OpenShop();
            StartCoroutine(ShopClosedTimer()); 
            
            StartCoroutine(ShopTimerSlider());
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopAllCoroutines();
            timer.value = 0;
            slidertime = 0;
        }
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

    public void BuySoul(Weapon weapon)
    {
        if (Bread - weapon.pricing < 0)
        {
            Debug.Log("in debt dumbass");
            
        }
        else
        {
            Bread -= weapon.pricing;
            MoneyText.text = $"GEO {Bread}";
        }
    }

    public void BuySpecialPower(Abilitys ability)
    {
        if (Bread - ability.pricing < 0)
        {
            Debug.Log("in debt dumbass");

        }
        else
        {
            Bread -= ability.pricing;
            MoneyText.text = $"GEO {Bread}";
        }
    }
    public void BuyPowerLevel(Upgrades upgrades)
    {
        if (Bread - upgrades.pricing < 0)
        {
            Debug.Log("in debt dumbass");

        }
        else
        {
            Bread -= upgrades.pricing;
            MoneyText.text = $"GEO {Bread}";
        }
    }

    public void OpenShop()
    {
        Shopifi.SetActive(true);

    }

    public void ClosedShop()
    {
        WeaponsShop.SetActive(false);
        AbilityShop.SetActive(false);
        UpgradeShop.SetActive(false);
        Shopifi.SetActive(false);
    }

    IEnumerator ShopClosedTimer()
    {
        yield return new WaitForSeconds(4);
        ClosedShop();

    }

    IEnumerator ShopTimerSlider()
    {

        while (slidertime < 4)
        {
            Debug.Log(Time.deltaTime);
            slidertime += Time.deltaTime;
            timer.value = slidertime;
            yield return null;
        }
        
    }
}
