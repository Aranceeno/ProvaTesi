using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

[Node(false, "GHOST/Cards/Item - Storyline Confrontation Card")]
public class ItemStorylineConfrontationCard : Node
{
    public const string ID = "ghost_itemStorylineConfrontationCard";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "Storyline Confrontation Card"; } }
    public override Vector2 DefaultSize { get { return new Vector2(400, 150); } }

    [ValueConnectionKnob("", Direction.In, "CardStorylineType", NodeSide.Left, 30)]
    public ValueConnectionKnob inputKnob;

    public enum Item { Clothes, Command, Cure, Heart, Hole, Barrier, Eye, Wound, Bone, Book, Cauldron, Clock, Crown, Door, Key, Mirror, Ring, Spell, Weapon, Tree, Wand, Food, Money, Treasure, Trap, Boat, Fire }
    public Item it = Item.Clothes;

    public enum Aspect { Cursed, Disguised, Evil, Hidden, Insane, Invisible, Lost, Poisoned, Stolen, CanFly, CanTalk, Beautiful, Secret, FarAway, Ugly, Dying, Empty, Haunted, Diseased, None }
    public Aspect asp = Aspect.None;

    public string text = "";
    

    public override void NodeGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.Label("Choose the Item Card");

        GUILayout.EndVertical();
        GUILayout.BeginVertical();


        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

#if UNITY_EDITOR

#else
#endif
        it = (Item)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("", ""), it);

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

    public string getItem()
    {
        string ris = "";
        switch (it)
        {
            case Item.Clothes:
                ris = "Clothes";
                break;
            case Item.Command:
                ris = "Command";
                break;
            case Item.Cure:
                ris = "Cure";
                break;
            case Item.Heart:
                ris = "Heart";
                break;
            case Item.Hole:
                ris = "Hole";
                break;
            case Item.Barrier:
                ris = "Barrier";
                break;
            case Item.Eye:
                ris = "Eye";
                break;
            case Item.Wound:
                ris = "Wound";
                break;
            case Item.Bone:
                ris = "Bone";
                break;
            case Item.Book:
                ris = "Book";
                break;
            case Item.Cauldron:
                ris = "Cauldron";
                break;
            case Item.Clock:
                ris = "Clock";
                break;
            case Item.Crown:
                ris = "Crown";
                break;
            case Item.Door:
                ris = "Door";
                break;
            case Item.Key:
                ris = "Key";
                break;
            case Item.Mirror:
                ris = "Mirror";
                break;
            case Item.Ring:
                ris = "Ring";
                break;
            case Item.Spell:
                ris = "Spell";
                break;
            case Item.Weapon:
                ris = "Weapon";
                break;
            case Item.Tree:
                ris = "Tree";
                break;
            case Item.Wand:
                ris = "Wand";
                break;
            case Item.Food:
                ris = "Food";
                break;
            case Item.Money:
                ris = "Money";
                break;
            case Item.Treasure:
                ris = "Treasure";
                break;
            case Item.Trap:
                ris = "Trap";
                break;
            case Item.Boat:
                ris = "Boat";
                break;
            case Item.Fire:
                ris = "Fire";
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
        Item tmp = (Item)Random.Range(0, 27);
        it = tmp;

        Aspect tmp2 = (Aspect)Random.Range(0, 20);
        asp = tmp2;
    }
}