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

    public enum Biomes { Tundra, Taiga, Tropical_Forest, Grassland, Savanna, Marine, Ice, Forest, Desert, None }
    public Biomes biomes = Biomes.None;
    public enum Architecture { Temple, City, Village, Ruins, None }
    public Architecture architecture = Architecture.None;
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
        loreVechicles = EditorGUI.TextArea(new Rect(3, 35, size.x - 6, 20), text);

        RTEditorGUI.PrefixLabel(new Rect(3, 80, 100, 50), new GUIContent("Insert Lore Description Here"), new GUIStyle());

        GUIStyle style = GUI.skin.box;
        text = EditorGUI.TextArea(new Rect(3, 100, size.x - 6, 120), text);

        if (GUI.changed)
            NodeEditor.curNodeCanvas.OnNodeChange(this);
    }

    public override bool Calculate()
    {
        switch (biomes)
        {
            case Biomes.Desert:
                firstLevelOutputKnob.SetValue<string>("Desert");
                break;
            case Biomes.Taiga:
                firstLevelOutputKnob.SetValue<string>("Taiga");
                break;
            case Biomes.Tundra:
                firstLevelOutputKnob.SetValue<string>("Tundra");
                break;
            case Biomes.Tropical_Forest:
                firstLevelOutputKnob.SetValue<string>("Tropical_Forest");
                break;
            case Biomes.Forest:
                firstLevelOutputKnob.SetValue<string>("Forest");
                break;
            case Biomes.Grassland:
                firstLevelOutputKnob.SetValue<string>("Grassland");
                break;
            case Biomes.Ice:
                firstLevelOutputKnob.SetValue<string>("Ice");
                break;
            case Biomes.Savanna:
                firstLevelOutputKnob.SetValue<string>("Savanna");
                break;
            case Biomes.None:
                firstLevelOutputKnob.SetValue<string>("None");
                break;

        }

        return true;

    }

    public string getValue()
    {
        string ris = "";
        switch (this.biomes)
        {
            case Biomes.Desert:
                ris = "Desert";
                break;
            case Biomes.Taiga:
                ris = "Taiga";
                break;
            case Biomes.Tundra:
                ris = "Tundra";
                break;
            case Biomes.Tropical_Forest:
                ris = "Tropical_Forest";
                break;
            case Biomes.Forest:
                ris = "Forest";
                break;
            case Biomes.Grassland:
                ris = "Grassland";
                break;
            case Biomes.Ice:
                ris = "Ice";
                break;
            case Biomes.Savanna:
                ris = "Savanna";
                break;
            case Biomes.None:
                ris = "None";
                break;

        }
        return ris;
    }

}
