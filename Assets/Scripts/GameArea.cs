using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArea : MonoBehaviour
{
    //references
    Defender defender;
    CoinManagement coinManagement;
    GameObject defenderParent;

    //states
    bool isPlaceForDefender;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        coinManagement = FindObjectOfType<CoinManagement>();
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if(!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }
    public void SetDefender(Defender defenderSelected)
    {
        defender = defenderSelected;
    }
    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newPosX = Mathf.RoundToInt(rawWorldPos.x);
        float newPosY = Mathf.RoundToInt(rawWorldPos.y);
        Vector2 worldPosUnits = new Vector2(newPosX, newPosY);
        return worldPosUnits;
    }
    private Vector2 GetSqare()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 newObjectPos = SnapToGrid(worldPos);
        return newObjectPos;
    }
   
    private void SpawnDefender(Vector2 newWorldPos)
    {
        if (coinManagement.GetCurrentCoinAmmount() >= defender.GetCoinCost())
        {
            coinManagement.BuyDefender(defender.GetCoinCost());
            Defender newDefenderSpawn = Instantiate(defender, newWorldPos, Quaternion.identity) as Defender;
            newDefenderSpawn.transform.parent = defenderParent.transform;
        }
    }
    private void OnMouseDown()
    {
        if(!defender)
        {
            return;
        }
        else
        {
            SpawnDefender(GetSqare());
        }
        
    }
}
