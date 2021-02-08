using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    private static int bountyKills;
    private static int bountyNum; // the random num assigned in IntroSceneController.cs

    public static int BountySuccess
    {
        get
        {
            return bountyKills;
        }
        set
        {
            bountyKills = value;
        }
    }

    public static int CorrectBountyTargetNumber
    {
        get
        {
            return bountyNum;
        }
        set
        {
            bountyNum = value;
        }
    }


}