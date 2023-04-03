using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public Movement charMove;
    public void PlayerAttack()
    {
        Debug.Log("Player Attacked!");
       charMove.DoAttack();

    }
    public void PlayerDamage()
    {
        transform.GetComponentInParent<enemyMovement>().DamagePlayer();
    }

    public void MoveSound()
    {
        LevelManager.instance.PlaySound(LevelManager.instance.levelSounds[0], LevelManager.instance.player.position);
    }
}
