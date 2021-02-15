using System.Collections.Generic;
using UnityEngine;

namespace NodeEditorFramework.Standard
{
    [NodeCanvasType("GHOST 3.0")]
    public class GhostCanvasType : NodeCanvas
    {
        private string[] underscoreSeparator = { "_" };
        private string ghostFirstChunk = "ghost";

        public override string canvasName { get { return "Graph"; } }
        
        protected override void OnCreate()
        {
            Traversal = new GhostTraversal(this);
        }

        private void OnEnable()
        {
            if (Traversal == null)
                Traversal = new GhostTraversal(this);
        }

        protected override void ValidateSelf()
        {
            
        }

        public override bool CanAddNode(string nodeID)
        {
            string[] nodeIDChunks = nodeID.Split(underscoreSeparator, System.StringSplitOptions.None);
            
            return nodeIDChunks[0].Equals(ghostFirstChunk);
        }
    }
 }
