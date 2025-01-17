﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SceneEditor : EditorWindow
{
    private readonly EditorGrid _grid = new EditorGrid();
    private LevelEditor _levelEditor;
    private Transform _parent;

    public void SetLevelEditor( LevelEditor levelEditor, Transform parent)
    {
        _levelEditor = levelEditor;
        _parent = parent;
    }

    public void OnSceneGUI(SceneView sceneView)
    {
        Event current = Event.current;
        if(current.type == EventType.MouseDown)
        {
            Vector3 point = sceneView.camera.ScreenToWorldPoint(new Vector3(current.mousePosition.x,
                sceneView.camera.pixelHeight - current.mousePosition.y,
                sceneView.camera.nearClipPlane));
            Debug.Log("world point" + point) ;
            Vector3 position = _grid.CheckPosition(point);

            if(position != Vector3.zero)
            {
                if (isEmpty(position))
                {
                    GameObject game = PrefabUtility.InstantiatePrefab(_levelEditor.GetBlock().Prefub, _parent) as GameObject;
                    game.transform.position = position;

                    if (game.TryGetComponent(out Block block))
                    {
                        block.BlockData = _levelEditor.GetBlock();
                        block.SetData(_levelEditor.GetBlock() as ColoredBlock);
                    }
                    if (game.TryGetComponent(out OtherBlock other))
                    {
                        other.BlockData = _levelEditor.GetBlock();
                    }
                }
            }
        }

        if(current.type == EventType.Layout)
        {
            HandleUtility.AddDefaultControl(GUIUtility.GetControlID(GetHashCode(), FocusType.Passive));

        }
    }
    private bool isEmpty(Vector3 position)
    {
        Collider2D collider = Physics2D.OverlapCircle(position, 0.01f);
        return collider == null;
    }
}
