using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Defender : MonoBehaviour
{
    //conf param
    [SerializeField] float coinCost = 0;
    [SerializeField] float coinPlus = 0;
    
    //references
    CoinManagement coinAdd;

    //states
    bool getCoins = false;

    public float GetCoinCost()
    {
        return coinCost;
    }

    public void AddNewCoin()
    {
        coinAdd = FindObjectOfType<CoinManagement>();
        coinAdd.AddCoin(coinPlus);
        GameObject coin = Instantiate(coinAdd.GetCoinPrefab(), transform.position, Quaternion.identity) as GameObject;
        Vector2 coinMovement = new Vector2(coin.transform.position.x * 2f * Time.deltaTime, coin.transform.position.y /* 1f * Time.deltaTime8*/);
        coin.GetComponent<Rigidbody2D>().velocity = coinMovement;
        Destroy(coin, 0.5f);
    }
}
