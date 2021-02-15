using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

[Node(false, "GHOST/Cards/Place - Storyline Confrontation Card")]
public class PlaceStorylineConfrontationCard : Node
{
    public const string ID = "ghost_placeStorylineConfrontationCard";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "Place - Storyline Confrontation Card"; } }
    public override Vector2 DefaultSize { get { return new Vector2(400, 150); } }

    [ValueConnectionKnob("", Direction.In, "CardStorylineType", NodeSide.Left, 30)]
    public ValueConnectionKnob inputKnob;

    public enum Place { City, Dungeon, Garden, Palace, Road, Tower, Church, Stairs, Kitchen,
            Home, Chapel, River, Island, Cottage, Village, Ruin, Cave, Night, Mountain, Kindom,
            Sea, Prison, Forest, Labyrint, Castle, Inn, Day, Farm, Market, Bed, ForeignLand,
            Grave, Well, Field }
    public Place pl = Place.City;

    public enum Aspect { Cursed, Disguised, Evil, Hidden, Insane, Invisible, Lost, Poisoned, Stolen,
            CanFly, CanTalk, Beautiful, Secret, FarAway, Ugly, Dying, Empty, Haunted, Diseased, None }
    public Aspect asp = Aspect.None;

    public string text = "";
    

    public override void NodeGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.Label("Choose the Place Card");

        GUILayout.EndVertical();
        GUILayout.BeginVertical();


        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

#if UNITY_EDITOR

#else
#endif
        pl = (Place)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("", ""), pl);

        GUILayout.Label("Choose the Aspect");
        asp = (Aspect)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("", ""), asp);

        if (GUI.Button(new Rect(10, 100, size.x - 20, 25), "Generate"))
            generate();

        if (GUI.changed)
            NodeEditor.curNodeCanvas.OnNodeChange(this);
    }

    public override bool Calculate()
    {
        return true;
    }

    public string getPlace()
    {
        string ris = "";
        switch (this.pl)
        {
            case Place.City:
                ris = "City";
                break;
            case Place.Dungeon:
                ris = "Dungeon";
                break;
            case Place.Garden:
                ris = "Garden";
                break;
            case Place.Palace:
                ris = "Palace";
                break;
            case Place.Road:
                ris = "Road";
                break;
            case Place.Tower:
                ris = "Tower";
                break;
            case Place.Church:
                ris = "Church";
                break;
            case Place.Stairs:
                ris = "Stairs";
                break;
            case Place.Kitchen:
                ris = "Kitchen";
                break;
            case Place.Home:
                ris = "Home";
                break;
            case Place.Chapel:
                ris = "Chapel";
                break;
            case Place.River:
                ris = "River";
                break;
            case Place.Island:
                ris = "Island";
                break;
            case Place.Cottage:
                ris = "Cottage";
                break;
            case Place.Village:
                ris = "Village";
                break;
            case Place.Ruin:
                ris = "Ruin";
                break;
            case Place.Cave:
                ris = "Cave";
                break;
            case Place.Night:
                ris = "Night";
                break;
            case Place.Mountain:
                ris = "Mountain";
                break;
            case Place.Kindom:
                ris = "Kindom";
                break;
            case Place.Sea:
                ris = "Sea";
                break;
            case Place.Prison:
                ris = "Prison";
                break;
            case Place.Forest:
                ris = "Forest";
                break;
            case Place.Labyrint:
                ris = "Labyrint";
                break;
            case Place.Castle:
                ris = "Castle";
                break;
            case Place.Inn:
                ris = "Inn";
                break;
            case Place.Day:
                ris = "Day";
                break;
            case Place.Farm:
                ris = "Farm";
                break;
            case Place.Market:
                ris = "Market";
                break;
            case Place.Bed:
                ris = "Bed";
                break;
            case Place.ForeignLand:
                ris = "Foreign Land";
                break;
            case Place.Grave:
                ris = "Grave";
                break;
            case Place.Well:
                ris = "Well";
                break;
            case Place.Field:
                ris = "Field";
                break;
        }
        return ris;
    }

    public string getAspect()
    {
        string ris = "";
        switch (asp)
        {
            case Aspect.Cursed:
                ris = "Cursed";
                break;
            case Aspect.Disguised:
                ris = "Disguised";
                break;
            case Aspect.Evil:
                ris = "Evil";
                break;
            case Aspect.Hidden:
                ris = "Hidden";
                break;
            case Aspect.Insane:
                ris = "Insane";
                break;
            case Aspect.Invisible:
                ris = "Invisible";
                break;
            case Aspect.Lost:
                ris = "Lost";
                break;
            case Aspect.None:
                ris = "None";
                break;
            case Aspect.Poisoned:
                ris = "Poisoned";
                break;
            case Aspect.Stolen:
                ris = "Stolen";
                break;
            case Aspect.CanFly:
                ris = "Can Fly";
                break;
            case Aspect.CanTalk:
                ris = "Can Talk";
                break;
            case Aspect.Beautiful:
                ris = "Beautiful";
                break;
            case Aspect.Secret:
                ris = "Secret";
                break;
            case Aspect.FarAway:
                ris = "Far Away";
                break;
            case Aspect.Ugly:
                ris = "Ugly";
                break;
            case Aspect.Dying:
                ris = "Dying";
                break;
            case Aspect.Empty:
                ris = "Empty";
                break;
            case Aspect.Haunted:
                ris = "Imprison";
                break;
            case Aspect.Diseased:
                ris = "Diseased";
                break;
        }
        return ris;
    }

    public void generate()
    {
        Place tmp = (Place)Random.Range(0, 34);
        pl = tmp;

        Aspect tmp2 = (Aspect)Random.Range(0, 20);
        asp = tmp2;
    }
}