using UnityEngine;

public class LoserScript : MonoBehaviour
{
   public GameObject respawn;

   void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "Player")
        {
            Other.transform.position = respawn.transform.position;
            HealthSystem.health--;
        }
    }
}
