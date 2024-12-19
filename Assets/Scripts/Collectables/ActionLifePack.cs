using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Itens;
using TMPro;

public class ActionLifePack : MonoBehaviour
{
    public SOInt soInt;
    public HealthBase healthBase;
    public KeyCode keyCode = KeyCode.L;
    public TextMeshProUGUI uiTextLife;

    private void Start()
    {
        soInt = CoinsManager.Instance.GetByTyoe(ItemType.LIFE_PACK).soInt;
    }

    private void RecoverLife()
    {
        CoinsManager.Instance.RemoveByType(ItemType.LIFE_PACK);
        healthBase.Recover();
        healthBase.UpdateUI();
    }

    private void Update()
    {
        if (soInt.value > 0)
        {
            if (Input.GetKeyDown(keyCode))
            {
                RecoverLife();

            }

        }

        if (healthBase._currentLife < (float)(healthBase.startLife / 2))
        {
            uiTextLife.gameObject.SetActive(true);
        }
        else uiTextLife.gameObject.SetActive(false);


    }
}
