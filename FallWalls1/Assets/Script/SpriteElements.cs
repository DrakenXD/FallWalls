using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteElements : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    // Start is called before the first frame update
    

    public void SetSpriteElement(Sprite _s)
    {
        sprite.enabled = true;

        sprite.sprite = _s;
    }
}
