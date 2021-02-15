using UnityEngine;
using System;
using System.Collections.Generic;
using System.Windows;

namespace NodeEditorFramework.Standard
{

    //GHOST 3.0 new types (Faro)

    public class PLotType : ValueConnectionType {
        public override string Identifier { get { return "PlotType"; } }
        public override Type Type { get { return typeof(String); } }
        public override Color Color { get { return Color.blue; } }
    }
    public class ActsType : ValueConnectionType
    {
        public override string Identifier { get { return "ActsType"; } }
        public override Type Type { get { return typeof(String); } }
        public override Color Color { get { return Color.yellow; } }
    }
    public class StructureType : ValueConnectionType
    {
        public override string Identifier { get { return "StructureType"; } }
        public override Type Type { get { return typeof(String); } }
        public override Color Color { get { return Color.white; } }
    }

    public class LoreType : ValueConnectionType
    {
        public override string Identifier { get { return "LoreType"; } }
        public override Type Type { get { return typeof(String); } }
        public override Color Color { get { return Color.grey; } }
    }


    //GHOST 2.0 new types (Uccellatori)
    public class XmindTopicType : ValueConnectionType
    {
        public override string Identifier { get { return "XmindTopicType"; } }
        public override Type Type { get { return typeof(string); } }
        public override Color Color { get { return new Color(0.1f, 0.1f, 0.9f); } }
    }

    public class BackgroundType : ValueConnectionType
    {
        public override string Identifier { get { return "BackgroundType"; } }
        public override Type Type { get { return typeof(string); } }
        public override Color Color { get { return new Color(0.8f, 0.8f, 0.4f); } }
    }

    public class CircumplexSetupOutputType : ValueConnectionType
    {
        public override string Identifier { get { return "CircumplexSetupOutputType"; } }
        public override Type Type { get { return typeof(List<CharacterCircumplexPosition>); } }
        public override Color Color { get { return new Color(0.5f, 0.5f, 0.5f); } }
    }

    public class CircumplexSetupType : ValueConnectionType
    {
        public override string Identifier { get { return "CircumplexSetupType"; } }
        public override Type Type { get { return typeof(String); } }
        public override Color Color { get { return new Color(0.913f, 0.913f, 0.913f); } }
    }

    public class SecondTurningPointType : ValueConnectionType
    {
        public override string Identifier { get { return "SecondTurningPointType"; } }
        public override Type Type { get { return typeof(int); } }
        public override Color Color { get { return new Color(0.463f, 0, 0.537f); } }
    }

    public class MidPointType : ValueConnectionType
    {
        public override string Identifier { get { return "MidPointType"; } }
        public override Type Type { get { return typeof(int); } }
        public override Color Color { get { return new Color(0, 0.267f, 1); } }
    }

    public class FirstTurningPointType : ValueConnectionType
    {
        public override string Identifier { get { return "FirstTurningPointType"; } }
        public override Type Type { get { return typeof(int); } }
        public override Color Color { get { return new Color(0, 0.506f, 0.121f); } }
    }

    public class TransformationalArcStartType : ValueConnectionType
    {
        public override string Identifier { get { return "TransformationalArcStartType"; } }
        public override Type Type { get { return typeof(bool); } }
        public override Color Color { get { return new Color(1, 0.937f, 0); } }
    }

    public class CharacterDescriptorType : ValueConnectionType
    {
        public override string Identifier { get { return "CharacterDescriptorType"; } }
        public override Type Type { get { return typeof(bool); } }
        public override Color Color { get { return new Color(0.905f, 0, 0); } }
    }

    // GHOST original types (Guarneri)
    public class PrequelType : ValueConnectionType
    {
        public override string Identifier { get { return "PrequelType"; } }
        public override Type Type { get { return typeof(bool); } }
        public override Color Color { get { return Color.blue; } }
    }

    public class BackStoryType : ValueConnectionType
    {
        public override string Identifier { get { return "BackStoryType"; } }
        public override Type Type { get { return typeof(bool); } }
        public override Color Color { get { return Color.white; } }
    }

    public class SecondType : ValueConnectionType
    {
        public override string Identifier { get { return "SecondType"; } }
        public override Type Type { get { return typeof(String); } }
        public override Color Color { get { return Color.red; } }
    }

    public class StorylineType : ValueConnectionType
    {
        public override string Identifier { get { return "StorylineType"; } }
        public override Type Type { get { return typeof(String); } }
        public override Color Color { get { return Color.green; } }
    }

    public class ClimaxType : ValueConnectionType
    {
        public override string Identifier { get { return "ClimaxType"; } }
        public override Type Type { get { return typeof(String); } }
        public override Color Color { get { return Color.grey; } }
    }

    public class FinalType : ValueConnectionType
    {
        public override string Identifier { get { return "FinalType"; } }
        public override Type Type { get { return typeof(String); } }
        public override Color Color { get { return Color.blue; } }
    }

    public class CardPreEventsType : ValueConnectionType
    {
        public override string Identifier { get { return "CardPreEventsType"; } }
        public override Type Type { get { return typeof(String); } }
        public override Color Color { get { return Color.magenta; } }
    }

    public class CardStorylineType : ValueConnectionType
    {
        public override string Identifier { get { return "CardStorylineType"; } }
        public override Type Type { get { return typeof(String); } }
        public override Color Color { get { return Color.magenta; } }
    }

    public class CardResolutionType : ValueConnectionType
    {
        public override string Identifier { get { return "CardResolutionType"; } }
        public override Type Type { get { return typeof(String); } }
        public override Color Color { get { return Color.magenta; } }
    }

    public class CardFinalType : ValueConnectionType
    {
        public override string Identifier { get { return "CardFinalType"; } }
        public override Type Type { get { return typeof(String); } }
        public override Color Color { get { return Color.magenta; } }
    }

    public class CardQuestType : ValueConnectionType
    {
        public override string Identifier { get { return "CardQuestType"; } }
        public override Type Type { get { return typeof(String); } }
        public override Color Color { get { return Color.magenta; } }
    }
}
