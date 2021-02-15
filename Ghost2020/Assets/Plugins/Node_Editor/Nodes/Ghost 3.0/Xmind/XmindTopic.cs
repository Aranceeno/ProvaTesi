using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using System;
using System.IO;
using UnityEditor;

[Node(false, "GHOST/Xmind/Central Argument")]
public class XmindTopic : Node
{
    public const string ID = "ghost_xmindtopic";
    public override string GetID { get { return ID; } }
    public override string Title { get { return "Xmind Topic"; } }
    public override bool AutoLayout{ get{ return true; } }
    public override Vector2 MinSize { get { return new Vector2(200, 50); } }

    public string label = "";
    public int nOutputs = 0;

    private ValueConnectionKnobAttribute dynaCreationAttribute =
                    new ValueConnectionKnobAttribute("", Direction.Out, "XmindTopicType", NodeSide.Right);

    public override void NodeGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();

        if (dynamicConnectionPorts.Count != nOutputs)
        {
            while (dynamicConnectionPorts.Count > nOutputs)
                DeleteConnectionPort(dynamicConnectionPorts.Count - 1);
            while (dynamicConnectionPorts.Count < nOutputs)
                CreateValueConnectionKnob(dynaCreationAttribute);
        }
        
        label = GUILayout.TextArea(label);
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
    }

    public override bool Calculate()
    {
        return base.Calculate();
    }
}
