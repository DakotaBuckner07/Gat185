using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slendermanne : Agent
{
    public Character player;
    //public NavMovement mesh;
    public bool isSeen { get; set; }

    void Update()
    {
        if (player != null)
        {
            //mesh.Direction = player.transform.position - transform.position;
            //direction.y = 0;
            animator.SetBool("Seen", isSeen);
            if (!isSeen)
            {
                movement.Resume();
                animator.SetFloat("Speed", 2);
                //animator.SetTrigger("Flashed");
                //transform.position += mesh.Direction.normalized * 2 * Time.deltaTime;
                movement.MoveTowards(player.transform.position);
                //movement.Velocity = new Vector3(1, 1, 1);
                //transform.rotation = Quaternion.LookRotation(movement.Direction, Vector3.up);
            }
            else
            {
                movement.Stop();
                //animator.ResetTrigger("Flashed");
                transform.rotation = Quaternion.LookRotation(movement.Direction, Vector3.up);
                animator.SetFloat("Speed", 0);
            }

        }
    }
}
