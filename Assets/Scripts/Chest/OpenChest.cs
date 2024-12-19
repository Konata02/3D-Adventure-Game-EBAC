using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpenChest : DetectionArea
{
    public Animator animator;
    public string triggerOpen = "Open";
    public KeyCode keyCode = KeyCode.K;
    public GameObject notification;
    public float tweenDuration = .2f;   
    public Ease tweenEase = Ease.OutBack;
    private float startScale; 
    public ChestItemCoin chestItemCoin;

    
    
    private void Update()
    {
        if (playerInArea == true)
        {
            notification.SetActive(true);
        }
        else
        {
            notification.SetActive(false);
        }

        if((playerInArea == true) && Input.GetKeyDown(keyCode))
        {
            animator.SetTrigger(triggerOpen);
            Invoke(nameof(ShowItem), 1f);
        }
    }

    private void ShowItem()
    {
        chestItemCoin.ShowItem();
        chestItemCoin.Collect();
    }
}
