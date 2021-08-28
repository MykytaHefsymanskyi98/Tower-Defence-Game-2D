using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManagement : MonoBehaviour
{
    //conf param
    [SerializeField] Text coinAmmountText;
    [SerializeField] GameObject CoinPrefab;
    [SerializeField] float currentCoinAmmount = 400;

    //states
    float difficultyDelta = 50;
    
    Defender defender;

    // Start is called before the first frame update
    void Start()
    {
        currentCoinAmmount = currentCoinAmmount - difficultyDelta * PlayerPrefsController.GetDifficulty(); 
        ShowCoinAmmount();
    }

    private void ShowCoinAmmount()
    {
        coinAmmountText.text = currentCoinAmmount.ToString();
    }

    public float GetCurrentCoinAmmount()
    {
        return currentCoinAmmount;
    }

    public void BuyDefender(float amount)
    {
        if (currentCoinAmmount >= amount)
        {
            currentCoinAmmount -= amount;
            ShowCoinAmmount();
        }              
    }
   public void AddCoin(float amount)
    {
        currentCoinAmmount += amount;
        ShowCoinAmmount();
    }

    public GameObject GetCoinPrefab()
    {
        return CoinPrefab;
    }
}
