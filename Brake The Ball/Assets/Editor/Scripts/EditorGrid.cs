﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorGrid
{
    private const float _leftPosition = -7.5f;
    private const float _upPosition = 4.25f;
    private const float _offsetDown = 0.5f;
    private const float _offsetRight = 1f;
    private const int _columnCount = 16;
    private const int _lineCount = 10;

    public Vector3 CheckPosition (Vector3 position)
    {
        float tempX = 0;
        float tempY = 0;
        float x = _leftPosition - _offsetRight / 2;
        float y = _upPosition + _offsetDown / 2;

        if(position.x > x && position.x < (x + _offsetRight * _columnCount )&&
            position.y  < y && position.y > (y - _offsetDown * _lineCount))
        {
            for (int i = 0; i < _columnCount; i++)
            {
                if (position.x > x && position.x < (x + _offsetRight))
                {
                    tempX = x + _offsetRight / 2;
                    break;
                }
                else
                {
                    x += _offsetRight;
                }
            }
            for(int i = 0; i < _lineCount; i++)
            { 
                if (position.y < y && position.y > (y - _offsetDown))
                {
                    tempY = y - _offsetDown / 2;
                    break;
                }
                else
                {
                    y -= _offsetDown;
                }
            }
        }
        else
        {
            Debug.Log("out of zone");
        }
        return new Vector3(tempX,tempY);
    }
}
