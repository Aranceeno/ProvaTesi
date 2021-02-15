using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using System;
using System.IO;
using UnityEditor;
using System.Collections.Generic;

[Node(false, "GHOST/Characters/1b. Interpersonal Circumplex")]
public class InterpersonalCircumplex : Node
{

    public const string ID = "ghost_interpersonalCircumplex";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "Interpersonal Circumplex"; } }
    public override Vector2 DefaultSize { get { return new Vector2(402, 442); } }

    [ValueConnectionKnob("", Direction.In, "CircumplexSetupType", NodeSide.Left, 20)]
    public ValueConnectionKnob principalNameInputKnob;

    [ValueConnectionKnob("", Direction.In, "CircumplexSetupOutputType", NodeSide.Left, 40)]
    public ValueConnectionKnob otherInputKnob;
    
    private Texture2D circumplextexture;
    private Texture2D charpointstexture;

    private Rect textureArea;

    private List<CharacterCircumplexPosition> characterWeb = new List<CharacterCircumplexPosition>();

    private float xCoord = 0f;
    private float yCoord = 0f;

    private const int margin = 40;

    public void OnEnable()
    {
        Byte[] fileData;

        string filePath = Path.GetFullPath("Assets/Plugins/Node_Editor/Resources/Textures/circumplex.png");
        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            circumplextexture = new Texture2D(400, 400, TextureFormat.BGRA32, false);
            circumplextexture.LoadImage(fileData);
        }
        else
        {
            Debug.Log("circumplex texture doesn't exist");
        }

        filePath = Path.GetFullPath("Assets/Plugins/Node_Editor/Resources/Textures/char.png");
        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            charpointstexture = new Texture2D(8, 8, TextureFormat.BGRA32, false);
            charpointstexture.LoadImage(fileData);
        }
        else
        {
            Debug.Log("charpoint texture doesn't exist");
        }

        textureArea = new Rect(2, 22, 400, 400);
    }

    public override void NodeGUI()
    {
        GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();

        if(principalNameInputKnob.connected())
            GUI.Label(new Rect(0, 0, 400, 20), principalNameInputKnob.GetValue<string>() 
                + "'s Interpersonal Circumplex");
        
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        GUI.DrawTexture(textureArea, circumplextexture);

        if (otherInputKnob.connected())
        {
            if (!otherInputKnob.IsValueNull)
            {
                characterWeb = otherInputKnob.GetValue<List<CharacterCircumplexPosition>>();
                if (characterWeb.Count > 0)
                {
                    foreach (CharacterCircumplexPosition position in characterWeb)
                    {
                        xCoord = textureArea.center.x - 4 + 
                            (position.getPosition().x / 100) * (textureArea.width - margin) / 2;

                        yCoord = textureArea.center.y - 4 -
                            (position.getPosition().y / 100) * (textureArea.height - margin) / 2;

                        GUI.DrawTexture(new Rect(xCoord, yCoord, 8, 8), charpointstexture);

                        GUI.Label(new Rect(xCoord - 12, yCoord + 8, 200, 20), position.getName());
                    }
                }
            }
        }
    }

    public override bool Calculate(){return true;}
}
