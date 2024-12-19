using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    
    public int startLife = 10;
    public int _currentLife;
    public bool destroyOnKill = false;
    private bool _isDead = false;
    public Animator ANIM_Player;
    public string ani_death = "death";
    public string ani_revive = "Revive";

    public float delayToKill = 0f;
    public ParticleSystem particles;
    public List<UIUdapter> uiHpBar;

    public CharacterController characterController;
    

    

    //public Action OnKill;
    
    private void Awake(){
        Init();
    }



    private void PlayerDeath(){
        if (CompareTag("Player")){
           if( _isDead == true) {
                
                if (characterController != null) {
                    characterController.enabled = false;
                }
                
                StartCoroutine(HandleRespawn());
                _currentLife = startLife;
                _isDead = false;
                UpdateUI();

           }
        
        }


    }

    private void Init(){
        _isDead = false;
        if ( SaveManager.Instance.setup._currentLife == startLife) _currentLife = startLife;
        else {_currentLife = SaveManager.Instance.setup._currentLife; UpdateUI();}
        
    }

    public virtual void Damage(int damage){
        
       
        if (_isDead) return;

        _currentLife -= damage;
        if (CompareTag("Player")) SaveManager.Instance.setup._currentLife = _currentLife;
        UpdateUI();


        if(_currentLife <=0){
            Kill();
        }
    }


    public void Recover(){
        _currentLife = startLife;
    }


    private void Kill(){
        _isDead = true;

        if(ANIM_Player != null) ANIM_Player.SetTrigger(ani_death);
        PlayerDeath();
        if(destroyOnKill){
            if(particles != null )particles.Play();
         Destroy(gameObject,delayToKill);
        }
    
    }

    public void UpdateUI()
    {
        if (uiHpBar != null)
        {
            uiHpBar.ForEach(i => i.UpdateValue((float)_currentLife/startLife));
        }
    }


    private IEnumerator HandleRespawn() {
        
        yield return new WaitForSeconds(delayToKill); // Ajuste se necessário
        if(ANIM_Player != null) ANIM_Player.SetTrigger(ani_revive);
        PlayerDeath(); // Agora chamamos a função de morte
        Respawn();
    }

    [NaughtyAttributes.Button]
    public void Respawn()
        {
            Debug.Log("valasPuto");
            if (CheckpointManager.Instance.HasCheckpoint()) {
                Vector3 checkpointPosition = CheckpointManager.Instance.GetPositionFromLastCheckpoint();
                Debug.Log($"Respawning at checkpoint position: {checkpointPosition}");
                if (transform.position != checkpointPosition) transform.position = checkpointPosition;

                if (characterController != null) {
                    characterController.enabled = true;
                }

            } 
            else {
                Debug.Log("No checkpoint available for respawn.");
            }
        }

}
