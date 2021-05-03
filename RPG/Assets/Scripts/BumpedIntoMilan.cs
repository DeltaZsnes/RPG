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
        WalkerGame.current.QueueTweet(portrait, "?", "Hey!!! Want some drugs?", null);
        WalkerGame.current.QueueTweet(portrait, "Milan", "Im Milan!", null);
        WalkerGame.current.QueueTweet(portrait, "Milan", "Hey!!! Talk to me", ttt);
    }

    void ttt()
    {
        Debug.Log("Conversation Ended");
    }
}
