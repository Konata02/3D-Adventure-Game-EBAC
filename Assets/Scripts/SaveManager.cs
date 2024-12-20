using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Singleton;
using Itens;
public class SaveManager : Singleton<SaveManager>
{
    [SerializeField]
    private SaveSetup _saveSetup;
    string path = Application.streamingAssetsPath + "/save.txt";
    public Action<SaveSetup> Fileloaded;

    public SaveSetup setup
    {
        get { return _saveSetup; }
    }
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);


    }

    private void Start()
    {
        Invoke(nameof(LoadFile), .5f);

    }


    [NaughtyAttributes.Button]
    private void Save()
    {

        string setupToJason = JsonUtility.ToJson(_saveSetup, true);
        SaveFile(setupToJason);
    }

    public void SaveLastLevel(int level)
    {
        _saveSetup.lastlevel = level;
        SaveItens();
        Save();
    }

    public void SaveName(string name)
    {
        _saveSetup.playerName = name;
        Save();

    }
    public void SaveItens()
    {
        _saveSetup.coins = CoinsManager.Instance.GetByTyoe(ItemType.COIN).soInt.value;
        _saveSetup.lifepack = CoinsManager.Instance.GetByTyoe(ItemType.LIFE_PACK).soInt.value;

    }



    public void SaveLastCheckpoint()
    {
        _saveSetup.lastCheckpointKey = CheckpointManager.Instance.GetLastCheckPointKey();
        SaveItens();
        SaveLastCloth();
        Save();

    }

    public void SaveLastCloth()
    {
        _saveSetup.id_cloth = ClothManager.Instance._currentEquippedCloth;
    }


    private void SaveFile(string json)
    {
        File.WriteAllText(path, json);
    }

    [NaughtyAttributes.Button]
    private void LoadFile()
    {
        string fileloaded = "";

        if (File.Exists(path))
        {
            fileloaded = File.ReadAllText(path);
            _saveSetup = JsonUtility.FromJson<SaveSetup>(fileloaded);
        }
        else
        {
            CreateNewFile();
            Save();
        }

        Fileloaded?.Invoke(_saveSetup);

    }
    private void CreateNewFile()
    {
        _saveSetup = new SaveSetup();
        _saveSetup.lastlevel = 0;
        _saveSetup.playerName = "";
        _saveSetup.id_cloth = 0;
    }

}

[System.Serializable]
public class SaveSetup
{
    public int lastlevel;
    public string playerName;
    public int coins;
    public int lifepack;
    public int lastCheckpointKey = 1;
    public int _currentLife = 10;

    public int id_cloth;


}
