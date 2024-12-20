using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Singleton;


public enum ClothType
{
    SPEED,
    POWERUP,
}

public class ClothManager : Singleton<ClothManager>
{

    public List<ClothSetup> clothSetups;
    public int _currentEquippedCloth;
    public Player player;
    public SOInt bulletsdamage;

    public void InitCloth()
    {
        _currentEquippedCloth = SaveManager.Instance.setup.id_cloth;

        if (_currentEquippedCloth == 0) return;
        var cloth = GetSetupById(_currentEquippedCloth);

        ClothChangerV2.Instance.ChangeMaterials(cloth.material);
        cloth.Initialize(player, bulletsdamage);

    }
    public ClothSetup GetSetupByType(ClothType clothType)
    {
        return clothSetups.Find(i => i.clothType == clothType);
    }

    public ClothSetup GetSetupById(int id)
    {
        return clothSetups.Find(i => i.id == id);
    }

}

[System.Serializable]

public class ClothSetup
{
    public ClothType clothType;
    public Material material;
    public int id;
    public float force;

    public void Initialize(Player player, SOInt damage = null)
    {
        if (clothType == ClothType.SPEED)
        {
            ChangePlayerSpeed(player);
        }
        else if (clothType == ClothType.POWERUP)
        {
            ChangePlayerDamageBullets(damage);
        }
    }
    public void ChangePlayerSpeed(Player player)
    {
        player.speed = force;
    }

    public void ChangePlayerDamageBullets(SOInt damage)
    {
        damage.value = (int)force;
    }


}

