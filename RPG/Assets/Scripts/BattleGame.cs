using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

enum BattleType
{
    Physical,
    Magic,
    Mental,
    Wind,
    Heat,
    Cold,
    Water,
    Electric,
}

class BattleCard
{
    public GameObject[] sourceList;
    public GameObject[] targetList;
    private BattleType[] typeList;
    private int value;
}

public class BattleGame : MonoBehaviour
{
    public static BattleGame current;
    public GameObject battleText;
    private float oldTime;
    private Stack<BattleCard> cardStack;

    // Start is called before the first frame update
    void Start()
    {
        current = this;
        cardStack = new Stack<BattleCard>();
    }

    // Update is called once per frame
    void Update()
    {
        var newTime = Time.time;

        if (newTime - oldTime > 1.0)
        {
            if (cardStack.Count == 0)
            {
                // end turn
            }
            else
            {
                var card = cardStack.Pop();
            }
            oldTime = newTime;
        }
    }

    public void BattleTextPressed()
    {
        Debug.Log("BattleTextPressed");

        var text = battleText.GetComponentInChildren(typeof(TMP_Text)) as TMP_Text;
        // Debug.Log(text.textInfo.pageCount);
        text.pageToDisplay = (text.pageToDisplay % text.textInfo.pageCount) + 1;
        Debug.Log(text.pageToDisplay + " of " + text.textInfo.pageCount);
    }
}
