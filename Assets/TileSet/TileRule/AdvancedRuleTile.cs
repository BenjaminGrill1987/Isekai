using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Runtime.InteropServices.WindowsRuntime;

[CreateAssetMenu(menuName = "Custom Tiles/Advanced Rule Tile")]
public class AdvancedRuleTile : RuleTile<AdvancedRuleTile.Neighbor>
{
    public bool customField;
    public bool alwayConnected;
    public TileBase[] tilesToConnect;
    public bool checkSelf;

    public class Neighbor : RuleTile.TilingRule.Neighbor
    {

        public const int Any = 3;
        public const int Specified = 4;
        public const int Nothing = 5;
    }

    public override bool RuleMatch(int neighbor, TileBase tile)
    {
        switch (neighbor)
        {
            case Neighbor.This: return Check_This(tile);
            case Neighbor.NotThis: return Check_NotThis(tile);
            case Neighbor.Any: return Check_Any(tile);
            case Neighbor.Specified: return Check_Specified(tile);
            case Neighbor.Nothing: return Check_Nothing(tile);

        }
        return base.RuleMatch(neighbor, tile);
    }

    private bool Check_This(TileBase tile)
    {
        if (!alwayConnected) return tile == this;
        else return tilesToConnect.Contains(this) || tile == this ;
    }

    private bool Check_NotThis(TileBase tile)
    {
        return tile != this;
    }

    private bool Check_Any(TileBase tile)
    {
        if (checkSelf) return tile != null;
        else return tile != null && tile != this;

    }

    private bool Check_Specified(TileBase tile)
    {
        return tilesToConnect.Contains(tile);
    }

    private bool Check_Nothing(TileBase tile)
    {
        return tile == null;
    }
}