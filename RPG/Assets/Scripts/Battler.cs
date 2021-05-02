using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battler : MonoBehaviour
{
    public Texture2D battlerTexture;
    private float oldTime;
    private Sprite[] spriteList;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        var w = battlerTexture.width;
        var h = battlerTexture.height;
        var s = 64;
        var p = new Vector2(0.5f, 0.5f);

        spriteList = new Sprite[9*6];

        for(var y = 0; y<6; y++){
            for(var x = 0; x<9; x++){
                var sprite = Sprite.Create(battlerTexture, new Rect(s * x, h - s * (y + 1), s, s), p, s);
                spriteList[9*y + x] = sprite;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        var newTime = Time.time;

        if (newTime - oldTime >= 0.1)
        {
            index = (index + 1) % spriteList.Length;
            this.GetComponent<SpriteRenderer>().sprite = spriteList[index];
            oldTime = newTime;
        }
    }

    void UpdateSprite()
    {
        
    }
}
