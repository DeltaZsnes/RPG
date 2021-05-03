using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WalkerGame : MonoBehaviour
{   
    public static WalkerGame current;
    public GameObject tweet;
    public GameObject tweetImage;
    public GameObject tweetName;
    public GameObject tweetText;

    public event Action tweetDone;

    // private Queue<(Sprite, string, string, Action)> tweetQueue = new Queue<(Sprite, string, string, Action)>();

    // Start is called before the first frame update
    void Start()
    {
        current = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    // public void QueueTweet(Sprite image, string name, string text, Action action)
    // {
    //     tweetQueue.Enqueue((image, name, text, action));
    // }

    public void Tweet(Sprite image, string name, string text)
    {
        var ti = tweetImage.GetComponent<SpriteRenderer>();
        ti.sprite = image;

        var tn = tweetName.GetComponent<TMP_Text>();
        tn.text = name;

        var tt = tweetText.GetComponent<TMP_Text>();
        tt.text = text;
        tt.pageToDisplay = 1;

        tweet.SetActive(true);
    }

    public void TweetPressed()
    {
        var tt = tweetText.GetComponent<TMP_Text>();
        tt.pageToDisplay = tt.pageToDisplay + 1;

        if(tt.pageToDisplay > tt.textInfo.pageCount)
        {
            tweet.SetActive(false);

            if(tweetDone != null)
            {
                tweetDone();
            }
        }
    }
}
