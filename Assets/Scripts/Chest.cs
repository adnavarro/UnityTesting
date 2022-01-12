using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectible
{
    [SerializeField] private Sprite emptyChest;
    private int moneyAmount = 5;

    protected override void OnCollect()
    {
        if (!collected)
        {
            base.OnCollect();
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            Debug.Log("Grant" + moneyAmount + "Money");
        }
    }
}
