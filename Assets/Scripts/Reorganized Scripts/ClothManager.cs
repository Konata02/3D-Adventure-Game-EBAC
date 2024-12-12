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
    public ClothSetup GetSetupByType( ClothType clothType)
    {
        return clothSetups.Find(i => i.clothType == clothType);
    }

}

[System.Serializable]

public class ClothSetup
{
    public ClothType clothType;
    public Material material;

}

