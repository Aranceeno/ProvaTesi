using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using UnityEditor;

[Node(false, "GHOST/Utility/CharacterHub")]
public class CharacterHub : Node
{
    public const string ID = "ghost_character_hub";
    public override string GetID { get { return ID; } }
    GUIStyle guiStyle = new GUIStyle();



    public override string Title { get { return "Character Hub"; } }
    public override Vector2 DefaultSize { get { return new Vector2(200, 180); } }


    [ValueConnectionKnob("Act", Direction.Out, "ActsType", NodeSide.Left, 20)]
    public ValueConnectionKnob structureConnection;
    [ValueConnectionKnob("Sidequest", Direction.Out, "ActsType", NodeSide.Left, 40)]
    public ValueConnectionKnob sidequestConnection;
    [ValueConnectionKnob("Character", Direction.In, "CharacterDescriptorType", NodeSide.Right, 20)]
    public ValueConnectionKnob firstCharacter;
    [ValueConnectionKnob("Character", Direction.In, "CharacterDescriptorType", NodeSide.Right, 40)]
    public ValueConnectionKnob secondCharacter;
    [ValueConnectionKnob("Character", Direction.In, "CharacterDescriptorType", NodeSide.Right, 60)]
    public ValueConnectionKnob thirdCharacter;
    [ValueConnectionKnob("Character", Direction.In, "CharacterDescriptorType", NodeSide.Right, 80)]
    public ValueConnectionKnob fourthCharacter;
    [ValueConnectionKnob("Character", Direction.In, "CharacterDescriptorType", NodeSide.Right, 100)]
    public ValueConnectionKnob fifthCharacter;
    [ValueConnectionKnob("Character", Direction.In, "CharacterDescriptorType", NodeSide.Right, 120)]
    public ValueConnectionKnob sixthCharacter;

    public override void NodeGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        structureConnection.DisplayLayout();
        sidequestConnection.DisplayLayout();
        firstCharacter.DisplayLayout();
        secondCharacter.DisplayLayout();
        thirdCharacter.DisplayLayout();
        fourthCharacter.DisplayLayout();
        fifthCharacter.DisplayLayout();
        sixthCharacter.DisplayLayout();
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
    }
}
