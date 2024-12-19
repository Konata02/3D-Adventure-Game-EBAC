using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  Boss; 
public class BossActually : BossBase
{
    public LookAtPlayer lookAtPlayer;
    private bool isWalking = false;

    private void Update()
    {
        if (lookAtPlayer.playerTransform != null)
        {
            StartCoroutine(HandlePlayerPresence());
        }
    }

    private IEnumerator HandlePlayerPresence()
    {
        while (lookAtPlayer.playerInArea)
        {
            yield return StartCoroutine(SwitchToAttack());
            yield return StartCoroutine(SwitchToWalk());
        }
    }

    private IEnumerator SwitchToWalk()
    {
        if (!isWalking) // Verifica se não está caminhando
        {
            isWalking = true; // Define que está caminhando
            GoToRandomPoint(); // Inicia a caminhada
            yield return new WaitForSeconds(5f); // Espera o tempo de caminhada
            isWalking = false; // Reseta o flag após a caminhada
        }
    }

    private IEnumerator SwitchToAttack()
    {
        SwitchAttack();
        yield return new WaitForSeconds(5f);
    }
}