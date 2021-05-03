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

    private Queue<TweetItem> tweetQueue;

    public WalkerGame()
    {
        current = this;
        tweetQueue = new Queue<TweetItem>();
    }

    class TweetItem
    {
        public Sprite image;
        public string name;
        public string text;
        public Action callback;
    }

    public void QueueTweet(Sprite image, string name, string text, Action callback)
    {
        tweetQueue.Enqueue(new TweetItem(){
            image = image,
            name = name,
            text = text,
            callback = callback,
        });

        if(tweetQueue.Count == 1)
        {
            NextTweet();
            return;
        }
    }

    void NextTweet()
    {
        if(tweetQueue.Count == 0)
        {
            return;
        }

        var item = tweetQueue.Peek();

        var ti = tweetImage.GetComponent<SpriteRenderer>();
        ti.sprite = item.image;

        var tn = tweetName.GetComponent<TMP_Text>();
        tn.text = item.name;

        var tt = tweetText.GetComponent<TMP_Text>();
        tt.text = item.text;
        tt.pageToDisplay = 1;

        tweet.SetActive(true);
    }

    public void TweetContinue()
    {
        var tt = tweetText.GetComponent<TMP_Text>();
        tt.pageToDisplay = tt.pageToDisplay + 1;

        if(tt.pageToDisplay > tt.textInfo.pageCount)
        {
            tweet.SetActive(false);

            if(tweetQueue.Count != 0)
            {
                var item = tweetQueue.Dequeue();
                
                if(item.callback != null)
                {
                    item.callback();
                }
            }
            
            NextTweet();
        }
    }
}
