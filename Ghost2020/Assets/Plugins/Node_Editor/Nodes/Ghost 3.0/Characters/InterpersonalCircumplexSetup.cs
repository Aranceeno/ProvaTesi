using UnityEngine;
using NodeEditorFramework;
using System.Collections.Generic;
using UnityEditor;
using System;
using NodeEditorFramework.Utilities;

[Node(false, "GHOST/Characters/1a. Interpersonal Circumplex Setup")]
public class InterpersonalCircumplexSetup : Node
{
    public const string ID = "ghost_interpersonalCircumplexSetup";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "Interpersonal Circumplex Setup"; } }
    public override Vector2 MinSize { get { return new Vector2(385, 10); } }
    public override bool AutoLayout { get { return true; } }

    [ValueConnectionKnob("Result ", Direction.Out, "CircumplexSetupOutputType")]
    public ValueConnectionKnob circumplexOutputKnob;

    private ValueConnectionKnobAttribute dynaCreationAttribute = 
                    new ValueConnectionKnobAttribute("", Direction.In, "CircumplexSetupType", NodeSide.Left);

    public List<string> characterNames = new List<string>();
    public List<int> fCharX = new List<int>();
    public List<int> fCharY = new List<int>();

    private List<CharacterCircumplexPosition> characterWeb = new List<CharacterCircumplexPosition>();

    public void OnEnable(){}

    public override void NodeGUI()
    {
        circumplexOutputKnob.DisplayLayout();

        if (dynamicConnectionPorts.Count != characterNames.Count)
        {
            while (dynamicConnectionPorts.Count > characterNames.Count)
                DeleteConnectionPort(dynamicConnectionPorts.Count - 1);
            while (dynamicConnectionPorts.Count < characterNames.Count)
                CreateValueConnectionKnob(dynaCreationAttribute);
        }

        if (GUILayout.Button("Add character"))
        {
            characterNames.Add("No character");
            fCharX.Add(0);
            fCharY.Add(0);
            CreateValueConnectionKnob(dynaCreationAttribute);
        }

        GUILayout.BeginVertical();

        for (int i = 0; i < characterNames.Count; i++)
        { // Display label and delete button
            GUILayout.BeginHorizontal();
            GUILayout.Label(characterNames[i], GUILayout.Width(180));
            GUILayout.Label("F-H", GUILayout.Width(28));
            fCharX[i] = Int32.Parse(RTEditorGUI.TextField(fCharX[i].ToString(), GUILayout.Width(50)));
            GUILayout.Label("D-S", GUILayout.Width(28));
            fCharY[i] = Int32.Parse(RTEditorGUI.TextField(fCharY[i].ToString(), GUILayout.Width(50)));
            
            if (fCharX[i] < -100)
            {
                fCharX[i] = -100;
            }
            else if (fCharX[i] > 100)
            {
                fCharX[i] = 100;
            }

            if (fCharY[i] < -100)
            {
                fCharY[i] = -100;
            }
            else if (fCharY[i] > 100)
            {
                fCharY[i] = 100;
            }
            
            ((ValueConnectionKnob)dynamicConnectionPorts[i]).SetPosition();
            if (GUILayout.Button("x", GUILayout.ExpandWidth(false)))
            { // Remove current label
                characterNames.RemoveAt(i);
                fCharX.RemoveAt(i);
                fCharY.RemoveAt(i);
                DeleteConnectionPort(i);
                i--;
            }
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();

        if (GUILayout.Button("Generate"))
        {
            if(fCharX.Count > 0)
            {
                for (int i = 0; i < fCharX.Count; i++)
                {
                    fCharX[i] = UnityEngine.Random.Range(-100, 100);
                    fCharY[i] = UnityEngine.Random.Range(-100, 100);
                }
            }
        }

        Calculate();
    }

    public override bool Calculate()
    {
        if(dynamicConnectionPorts.Count > 0)
        {
            characterWeb.Clear();
            for (int i = 0; i < dynamicConnectionPorts.Count; i++)
            {
                characterNames[i] = ((ValueConnectionKnob)dynamicConnectionPorts[i]).GetValue<string>();
                characterWeb.Add(new CharacterCircumplexPosition(characterNames[i], fCharX[i], fCharY[i]));
            }
            circumplexOutputKnob.SetValue<List<CharacterCircumplexPosition>>(characterWeb);
        }
        return true;
    }
}
