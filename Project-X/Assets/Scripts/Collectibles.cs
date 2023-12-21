using TMPro;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private int collected = 0;

    [SerializeField] private TextMeshProUGUI collectiblesText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Collectibles"))
        {
            Destroy(collision.gameObject);
            
            collected++;
            collectiblesText.text = "Fruits: "+collected;
        }
    }
}
