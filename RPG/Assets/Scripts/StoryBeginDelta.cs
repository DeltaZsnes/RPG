using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryBeginDelta : MonoBehaviour
{
    public Sprite portrait;

    // Start is called before the first frame update
    void Start()
    {
        var name = "Delta";
        WalkerGame.current.QueueTweet(portrait, name, "Ohayo Sekai!!! Good morning world !!!", null);
        WalkerGame.current.QueueTweet(portrait, name, "Lets go on an adventure and explore what this world has to offer", null);
        WalkerGame.current.QueueTweet(portrait, name, "This town has some new problems to fix", null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
