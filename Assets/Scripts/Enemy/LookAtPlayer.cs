using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform targetTransform; // O Transform do objeto que deve olhar para o jogador
    public Transform playerTransform = null; // O Transform do jogador

    public bool playerInArea = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Armazena a referência ao Transform do jogador
            playerTransform = other.transform;
            playerInArea =true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Limpa a referência quando o jogador sai do trigger
            playerTransform = null;
            playerInArea = false;
        }
    }

    void Update()
    {
        // Se o jogador está dentro do trigger, faça o objeto específico olhar para ele
        if (playerTransform != null && targetTransform != null)
        {
            Vector3 directionToPlayer = playerTransform.position - targetTransform.position;
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            targetTransform.rotation = Quaternion.Slerp(targetTransform.rotation, lookRotation, Time.deltaTime * 5f); // 5f controla a velocidade de rotação
        }
    }
}