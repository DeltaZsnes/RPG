using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpedIntoMilan : MonoBehaviour
{
    public Sprite portrait;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D _)
    {
        WalkerGame.current.Tweet(portrait, "?", "Hey!!! Want some drugs?");
        WalkerGame.current.Tweet(portrait, "Milan", "Im Milan!");
        WalkerGame.current.Tweet(portrait, "Milan", "Hey!!! Talk to me");
        WalkerGame.current.tweetDone += ttt;
    }

    void ttt()
    {
        Debug.Log("Conversation Ended");
        WalkerGame.current.tweetDone -= ttt;
    }
}
