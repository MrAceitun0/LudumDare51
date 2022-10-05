using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    private const string IS_DEAD = "isDead";
    [SerializeField]
    Animator killScreenAnimator;

    bool isDead = false;

    public bool getIsDead()
    {
        return isDead;
    }

    public void setIsDead(bool isDead)
    {
        this.isDead = isDead;
    }

    private void Update()
    {
        if (isDead)
        {
            killScreenAnimator.SetBool(IS_DEAD, true);
        }
    }

    public IEnumerator respawnPlayer(Transform playerTransform)
    {
        yield return new WaitForSeconds(0.8f);
        playerTransform.position = transform.position;
        transform.rotation = transform.rotation;
        isDead = false;
        killScreenAnimator.SetBool(IS_DEAD, false);
    }
}
