using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Singleton;

public class CheckpointManager : Singleton<CheckpointManager>
    // Start is called before the first frame update
{

    public int lastCheckpointKey = 0;
    public List<CheckpointBase> checkpoints;

    public void SaveCheckpoint(int i){

        if (i > lastCheckpointKey)lastCheckpointKey = i;

    }

    public Vector3 GetPositionFromLastCheckpoint (){

        var checkpoint = checkpoints.Find( i => i.key == lastCheckpointKey);
        return checkpoint.transform.position;

    }

    public bool HasCheckpoint (){
        return lastCheckpointKey > 0;
    
    }


}    
    

