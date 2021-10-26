using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehavior : MonoBehaviour
{
    public bool IsFlipped { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnMouseDown()
    {
        transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z *-1);
    }
}
