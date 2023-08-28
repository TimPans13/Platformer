using UnityEngine;

public class CheryyScript : MonoBehaviour
{
    public static int cherry = 0;

    private void Start()
    {
        cherry = 0;
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "Player")
        {
            cherry++;         
            Destroy(gameObject);
        }
    }
}
