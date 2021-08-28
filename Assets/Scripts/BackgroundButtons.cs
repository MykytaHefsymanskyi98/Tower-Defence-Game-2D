using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundButtons : MonoBehaviour
{
    //conf param
    [SerializeField] Defender defenderPrefab;
    [SerializeField] Text costText;

    private void Start()
    {
        costText.text = defenderPrefab.GetCoinCost().ToString();
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<BackgroundButtons>();
        foreach (BackgroundButtons button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(25, 25, 25, 226);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<GameArea>().SetDefender(defenderPrefab);
    }
}
