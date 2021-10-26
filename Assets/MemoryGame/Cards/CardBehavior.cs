using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehavior : MonoBehaviour
{
    [SerializeField] private GameObject gm;
    
    private bool isMatched = false;
    public bool IsMatched {
        get {
            return isMatched;
        }
        set {
            isMatched = value;
            GetComponent<MeshCollider>().enabled = false;
        }
    }
    
    void OnMouseDown()
    {
        FlipCard();
        gm.GetComponent<MemoryGameGM>().CardSelected(gameObject);
    }

    public void FlipCard()
    {
        GetComponent<MeshCollider>().enabled = !GetComponent<MeshCollider>().enabled;
        transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z *-1);
    }
}
