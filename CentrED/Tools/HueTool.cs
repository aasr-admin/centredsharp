﻿using CentrED.Map;
using static CentrED.Application;

namespace CentrED.Tools;

public class HueTool : Tool
{
    public override string Name => "HueTool";

    private bool _pressed;

    public override void OnActivated(TileObject? o)
    {
        CEDGame.UIManager.HuesWindow.Show = true;
    }

    public override void OnMouseEnter(TileObject? o)
    {
        if (o is StaticObject so)
        {
            so.Hue = (ushort)CEDGame.UIManager.HuesWindow.SelectedId;
        }
    }

    public override void OnMouseLeave(TileObject? o)
    {
        if (o is StaticObject so)
        {
            if (_pressed)
            {
                Apply(so);
            }
            else
            {
                so.Hue = so.StaticTile.Hue;
            }
        }
    }

    public override void OnMousePressed(TileObject? o)
    {
        if (!_pressed && o is StaticObject so)
        {
            _pressed = true;
        }
    }

    public override void OnMouseReleased(TileObject? o)
    {
        if (_pressed && o is StaticObject so )
        {
           Apply(so);
        }
        _pressed = false;
    }

    private void Apply(StaticObject o)
    {
        if (CEDGame.UIManager.HuesWindow.SelectedId != -1)
            o.StaticTile.Hue = (ushort)CEDGame.UIManager.HuesWindow.SelectedId;
    }
}