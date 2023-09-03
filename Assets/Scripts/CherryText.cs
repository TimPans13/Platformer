using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public Text coinText; 
    private void Update()
    {      
        coinText.text = CheryyScript.cherry.ToString(); 
    }
}