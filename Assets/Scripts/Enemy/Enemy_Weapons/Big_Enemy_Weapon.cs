using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_Enemy_Weapon : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    Color[] _colors =
    {
        Color.red,
        Color.black
    };


    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.Log("Sprite Rendered is NULL");
        }

        spriteRenderer.color = _colors[Random.Range(0, 2)];
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -37)
        {
            Destroy(this.gameObject);
        }
    }


}
