
using UnityEngine;

public class LoserScript : MonoBehaviour
{

    public GameObject respaun;

   void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "Player")
        {
            Other.transform.position = respaun.transform.position;
        }
    }
}
