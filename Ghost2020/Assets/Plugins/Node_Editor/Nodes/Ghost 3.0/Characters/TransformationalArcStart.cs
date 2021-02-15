using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using System;
using System.IO;
using UnityEditor;

[Node(false, "GHOST/Characters/2. Transformational Arc Start")]
public class TransformationalArcStart : Node
{
    public const string ID = "ghost_transformationalArcStart";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "Transformational Arc Start"; } }
    public override Vector2 DefaultSize { get { return new Vector2(400, 200); } }

    [ValueConnectionKnob("", Direction.In, "CharacterDescriptorType", NodeSide.Left, 20)]
    public ValueConnectionKnob arcInputKnob;
    [ValueConnectionKnob("Unknown ", Direction.Out, "TransformationalArcStartType")]
    public ValueConnectionKnob unknownOutputKnob;

    public enum ThematicStructure
    {
        BothSidesHaveAPoint, CantGetAwayWithNuthin, ComesGreatResponsibility, ComingOfAgeStory, CrisisOfFaith, CuriosityIsACrapshoot,
        DarkAndTroubledPast, FantasticRacism, HeroicSpirit, HopeSpringsEternal, HumansAreSpecial, LegacyImmortality, LossOfIdentity,
        OrderVersusChaos, RedemptionQuest, RomanticismVersusEnlightenment, SlidingScaleOfUnavoidableVersusUnforgivable,
        TheChainOfHarm, TheNeedsOfTheMany, ThePowerOfLove, WeAllDieSomeday, YouCantFightFate, None
    }
    public ThematicStructure theme = ThematicStructure.None;

    public enum FatalFlaw
    {
        GreenEyedMonster, VillainousGlutton, Greed, Lust, Pride, LazyBum, Wrath,
        WoobieDestroyerOfWorlds, None
    }
    public FatalFlaw flaw = FatalFlaw.None;

    
    public string textDesc = "";

    private Texture2D infotexture;
    private bool textureset = false;
    private TextAsset tooltipText;

    public override void NodeGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();

        GUILayout.EndVertical();
        GUILayout.BeginVertical();

        unknownOutputKnob.DisplayLayout();

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        //#if UNITY_EDITOR
        if (!textureset)
        {
            Byte[] fileData;
            string filePath = Path.GetFullPath("Assets/Plugins/Node_Editor/Resources/Textures/infotexture.png");
            if (File.Exists(filePath))
            {
                fileData = File.ReadAllBytes(filePath);
                infotexture = new Texture2D(16, 16, TextureFormat.BGRA32, false);
                infotexture.LoadImage(fileData);
                textureset = true;
            }
            else
            {
                Debug.Log("file doesn't exist");
            }
        }

        if (!theme.Equals(ThematicStructure.None))
        {
            tooltipText = (TextAsset)AssetDatabase.LoadAssetAtPath("Assets/Plugins/Node_Editor/Default/Ghost 2.0/Theme Tooltips/" + 
                            theme.ToString() + ".txt", typeof(TextAsset));
        }
        else
        {
            tooltipText = new TextAsset();
        }
        

        theme = (ThematicStructure)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("Thematic Structure", infotexture, tooltipText.text), theme);
        flaw = (FatalFlaw)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("Fatal Flaw", ""), flaw);

        /*#else
		GUILayout.Label (new GUIContent ("Calculation Type: " + type.ToString (), 
			"The type of calculation performed on Input 1 and Input 2"));
#endif*/

        RTEditorGUI.Seperator();
        RTEditorGUI.PrefixLabel(new Rect(3, 65, 100, 50), new GUIContent("Insert Description Here"), new GUIStyle());
        GUIStyle style = GUI.skin.box;
        textDesc = EditorGUI.TextArea(new Rect(3, 80, size.x - 6, style.CalcHeight(new GUIContent(textDesc), size.x - 3)), textDesc);

        if (GUI.Button(new Rect(10, 150, size.x - 20, 25), "Generate"))
            generate();

        if (GUI.changed)
            NodeEditor.curNodeCanvas.OnNodeChange(this);
    }

    public override bool Calculate()
    {
        unknownOutputKnob.SetValue<bool>(true);
        return true;
    }

    public void generate()
    {
        ThematicStructure tmp = (ThematicStructure)UnityEngine.Random.Range(0, 23);
        theme = tmp;

        FatalFlaw tmp3 = (FatalFlaw)UnityEngine.Random.Range(0, 8);
        flaw = tmp3;
    }
}