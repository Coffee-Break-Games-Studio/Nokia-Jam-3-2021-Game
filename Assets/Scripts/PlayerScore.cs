using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerScore
{
    private static int bountyKills;

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

}