using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Identifier otherIdentifier = collision.gameObject.GetComponent<Identifier>();
        if (otherIdentifier != null)
        {
            if (otherIdentifier.identifiers.Contains("Ground")) playerMovement.SetJumps();
            else if (otherIdentifier.identifiers.Contains("NoJump")) playerMovement.SetJumps(0);
        }
    }
}
