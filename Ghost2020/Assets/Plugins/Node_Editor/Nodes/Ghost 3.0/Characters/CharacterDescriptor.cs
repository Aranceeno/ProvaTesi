using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using System;
using System.IO;
using UnityEditor;

[Node(false, "GHOST/Characters/1. Descriptor")]
public class CharacterDescriptor : Node
{
    public const string ID = "ghost_characterDescriptor";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "Character Descriptor"; } }
    public override Vector2 DefaultSize { get { return new Vector2(400, 265); } }
    
    [ValueConnectionKnob("Arc ", Direction.Out, "CharacterDescriptorType")]
    public ValueConnectionKnob arcOutputKnob;

    [ValueConnectionKnob("Circumplex", Direction.Out, "CircumplexSetupType", NodeSide.Bottom, 40)]
    public ValueConnectionKnob principalNameOutputKnob;

    [ValueConnectionKnob("Background", Direction.Out, "BackgroundType", NodeSide.Bottom, 140)]
    public ValueConnectionKnob bgOutputKnob;

    // enum done by Gualtieri in CharacterRole - values modified by Luca Uccellatori
    public enum Role
    {
        TheHero, MentorArchetype, Herald, TheTrickster, HeelFaceRevolvingDoor, ThresholdGuardians,
        ShadowArchetype, None
    }
    public Role role = Role.None;

    // enum done by Gualtieri in CharacterCharacteristic
    public enum HeroesAlignment
    {
        Hero, KnightInShineArmor, ChoosenOne, Determinator, GeniusBruiser,
        BadassBookworm, TechnicalPacifist, Ace, Captain, Gunslinger, Antihero, None
    }
    public HeroesAlignment good = HeroesAlignment.None;

    // enum done by Gualtieri in CharacterCharacteristic
    public enum VillainsAlignment
    {
        BigBad, EvilTwin, Archenemy, Empire, MagnificentBastard, ManipulativeBastard,
        EnemyWithin, Dragon, AntiVillain, VillainProtagonist, Mole, AmoralAttorney, Chessmaster, Virus, ForTheEvulz,
        CompleteMonster, EldritchAbomination, OmnicidialManiac, Brute, OneWingedAngel, KnightTemplar,
        CorruptCorporateExecutive, None
    }
    public VillainsAlignment evil = VillainsAlignment.None;

    public string textName = "";
    public string textAge = "";
    public string textGender = "";
    public string textRace = "";
    public string textDesc = "";

    public override void NodeGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();

        //principalNameOutputKnob.DisplayLayout();

        GUILayout.EndVertical();
        GUILayout.BeginVertical();
        
        //bgOutputKnob.DisplayLayout();

        GUILayout.EndVertical();
        arcOutputKnob.DisplayLayout();
        GUILayout.EndHorizontal();

        textName = RTEditorGUI.TextField(new GUIContent("Insert name", ""), textName);
        textAge = RTEditorGUI.TextField(new GUIContent("Insert age", ""), textAge);
        textGender = RTEditorGUI.TextField(new GUIContent("Insert gender", ""), textGender);
        textRace = RTEditorGUI.TextField(new GUIContent("Insert race", ""), textRace);

        RTEditorGUI.Seperator();
        
        role = (Role)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("Role", ""), role);

        if (role == Role.TheHero)
        {
            good = (HeroesAlignment)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("Hero Type", ""), good);
        }
        else if (role == Role.ShadowArchetype)
        {
            evil = (VillainsAlignment)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("Shadow Type", ""), evil);
        }
        /*else
        {
            plex = (Circumplex)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent(" Hero Relationship", infotexture,
            "this is a very long tooltip, I don't even know what to write to make it long as I need to to test this very tooltip."),
            plex);
        }*/

        RTEditorGUI.Seperator();

        RTEditorGUI.PrefixLabel(new Rect(3, 140, 100, 50), new GUIContent("Insert Description Here"), new GUIStyle());
        GUIStyle style = GUI.skin.box;
        textDesc = EditorGUI.TextArea(new Rect(3, 155, size.x - 6, style.CalcHeight(new GUIContent(textDesc), size.x - 3)), textDesc);
        
        if (GUI.Button(new Rect(10, 200, size.x - 20, 25), "Generate"))
            generate();

        GUI.Label(new Rect(10, 227, 100, 20), "Circumplex");
        GUI.Label(new Rect(110, 227, 100, 20), "Background");

        if (GUI.changed)
            NodeEditor.curNodeCanvas.OnNodeChange(this);
    }

    public override bool Calculate()
    {
        arcOutputKnob.SetValue<bool>(true);
        principalNameOutputKnob.SetValue<string>(textName);
        bgOutputKnob.SetValue<string>(textName);
        return true;
    }

    public void generate()
    {
        Role tmp2 = (Role)UnityEngine.Random.Range(0, 8);
        role = tmp2;

        if (role == Role.TheHero)
        {
            HeroesAlignment tmp4 = (HeroesAlignment)UnityEngine.Random.Range(0, 10);
            good = tmp4;
        }
        else if (role == Role.ShadowArchetype)
        {
            VillainsAlignment tmp5 = (VillainsAlignment)UnityEngine.Random.Range(0, 19);
            evil = tmp5;
        }
    }
}