using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    public Texture2D walkingTexture;
    private Sprite downA;
    private Sprite downStop;
    private Sprite downB;
    private Sprite leftA;
    private Sprite leftStop;
    private Sprite leftB;
    private Sprite rightA;
    private Sprite rightStop;
    private Sprite rightB;
    private Sprite upA;
    private Sprite upStop;
    private Sprite upB;
    private float oldTime;
    private AnimationState animationState;
    public float inputVertical;
    public float inputHorizontal;

    private enum AnimationState
    {
        DownStop,
        DownWalk,
        LeftStop,
        LeftWalk,
        RightStop,
        RightWalk,
        UpStop,
        UpWalk,
    }

    // Start is called before the first frame update
    void Start()
    {
        var w = walkingTexture.width;
        var h = walkingTexture.height;
        var s = 48;
        var p = new Vector2(0.5f, 0.5f);
        
        downA = Sprite.Create(walkingTexture, new Rect(s * 0, h - s * 1, s, s), p, s);
        downStop = Sprite.Create(walkingTexture, new Rect(s * 1, h - s * 1, s, s), p, s);
        downB = Sprite.Create(walkingTexture, new Rect(s * 2, h - s * 1, s, s), p, s);

        leftA = Sprite.Create(walkingTexture, new Rect(s * 0, h - s * 2, s, s), p, s);
        leftStop = Sprite.Create(walkingTexture, new Rect(s * 1, h - s * 2, s, s), p, s);
        leftB = Sprite.Create(walkingTexture, new Rect(s * 2, h - s * 2, s, s), p, s);

        rightA = Sprite.Create(walkingTexture, new Rect(s * 0, h - s * 3, s, s), p, s);
        rightStop = Sprite.Create(walkingTexture, new Rect(s * 1, h - s * 3, s, s), p, s);
        rightB = Sprite.Create(walkingTexture, new Rect(s * 2, h - s * 3, s, s), p, s);

        upA = Sprite.Create(walkingTexture, new Rect(s * 0, h - s * 4, s, s), p, s);
        upStop = Sprite.Create(walkingTexture, new Rect(s * 1, h - s * 4, s, s), p, s);
        upB = Sprite.Create(walkingTexture, new Rect(s * 2, h - s * 4, s, s), p, s);

        oldTime = Time.time;
        animationState = AnimationState.DownStop;
        UpdateSprite();
    }

    // Update is called once per frame
    void Update()
    {
        var newTime = Time.time;
        var v = inputVertical;
        var h = inputHorizontal;
        GetComponent<Rigidbody2D>().velocity = new Vector2(h, v) * 4.0f;

        if(h == 0 && v == 0)
        {
            if(animationState == AnimationState.DownWalk){
                animationState = AnimationState.DownStop;
            }
            else if(animationState == AnimationState.LeftWalk){
                animationState = AnimationState.LeftStop;
            }
            else if(animationState == AnimationState.RightWalk){
                animationState = AnimationState.RightStop;
            }
            else if(animationState == AnimationState.UpWalk){
                animationState = AnimationState.UpStop;
            }
        }
        else if(Mathf.Abs(v) > Mathf.Abs(h))
        {
            if(v < 0.0){
                animationState = AnimationState.DownWalk;
            }
            else{
                animationState = AnimationState.UpWalk;
            }
        }
        else{
            if(h < 0.0){
                animationState = AnimationState.LeftWalk;
            }
            else{
                animationState = AnimationState.RightWalk;
            }
        }

        // if(v < 0.0 && animationState != AnimationState.DownWalk){
        //     animationState = AnimationState.DownWalk;
        //     UpdateSprite();
        // }
        // else if(h < 0.0 && Mathf.Abs(h) > Mathf.Abs(v) && animationState != AnimationState.LeftWalk){
        //     animationState = AnimationState.LeftWalk;
        //     UpdateSprite();
        // }
        // else if(h > 0.0 && Mathf.Abs(h) > Mathf.Abs(v) && animationState != AnimationState.RightWalk){
        //     animationState = AnimationState.RightWalk;
        //     UpdateSprite();
        // }
        // else if(v > 0.0 && animationState != AnimationState.UpWalk){
        //     animationState = AnimationState.UpWalk;
        //     UpdateSprite();
        // }

        if (newTime - oldTime >= 0.5)
        {
            UpdateSprite();
            oldTime = newTime;
        }
    }

    void UpdateSprite()
    {
        var sprite = this.GetComponent<SpriteRenderer>().sprite;

        if(animationState == AnimationState.DownStop)
        {
            sprite = downStop;
        }
        else if(animationState == AnimationState.DownWalk)
        {
            if (sprite == downA)
            {
                sprite = downB;
            }
            else if (sprite == downB)
            {
                sprite = downA;
            }
            else
            {
                sprite = downA;
            }
        }
        else if(animationState == AnimationState.LeftStop)
        {
            sprite = leftStop;
        }
        else if(animationState == AnimationState.LeftWalk)
        {
            if (sprite == leftA)
            {
                sprite = leftB;
            }
            else if (sprite == leftB)
            {
                sprite = leftA;
            }
            else
            {
                sprite = leftA;
            }
        }
        else if(animationState == AnimationState.RightStop)
        {
            sprite = rightStop;
        }
        else if(animationState == AnimationState.RightWalk)
        {
            if (sprite == rightA)
            {
                sprite = rightB;
            }
            else if (sprite == rightB)
            {
                sprite = rightA;
            }
            else
            {
                sprite = rightA;
            }
        }
        else if(animationState == AnimationState.UpStop)
        {
            sprite = upStop;
        }
        else if(animationState == AnimationState.UpWalk)
        {
            if (sprite == upA)
            {
                sprite = upB;
            }
            else if (sprite == upB)
            {
                sprite = upA;
            }
            else
            {
                sprite = upA;
            }
        }
        else{
            throw new System.Exception("Unexpected State");
        }

        this.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
