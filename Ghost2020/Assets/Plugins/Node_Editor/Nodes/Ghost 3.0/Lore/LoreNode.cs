using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using UnityEditor;

[Node(false, "GHOST/Lore/Lore")]
public class LoreNode : Node
{
    public const string ID = "ghost_lorenode";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "Lore Node"; } }
    public override Vector2 DefaultSize { get { return new Vector2(400, 250); } }
    public enum Messages { Collectionable, Paint, Book, Letter, Photo, None }
    public Messages messages = Messages.None;

    [ValueConnectionKnob("Structure", Direction.Out, "StructureType")]
    public ValueConnectionKnob firstLevelOutputKnob;


    public string text = "";
    public string loreVechicles = "";


    public override void NodeGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();

        GUILayout.EndVertical();
        GUILayout.BeginVertical();

        firstLevelOutputKnob.DisplayLayout();

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
        RTEditorGUI.PrefixLabel(new Rect(3, 20, 100, 50), new GUIContent("Insert object/NPC lore that vehicles the message(Es: a book, a paint)"), new GUIStyle());
        GUIStyle styleVehicles = GUI.skin.box;
        loreVechicles = EditorGUI.TextArea(new Rect(3, 35, size.x - 6, 20), loreVechicles);

        RTEditorGUI.PrefixLabel(new Rect(3, 80, 100, 50), new GUIContent("Insert Lore Description Here"), new GUIStyle());

        GUIStyle style = GUI.skin.box;
        text = EditorGUI.TextArea(new Rect(3, 100, size.x - 6, 120), text);

        if (GUI.changed)
            NodeEditor.curNodeCanvas.OnNodeChange(this);
    }

  
}
