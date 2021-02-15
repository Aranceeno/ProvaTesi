using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

namespace NodeEditorFramework.IO
{
    public class XmindImport : StructuredImportExportFormat
    {
        public override string FormatIdentifier { get { return "Xmind"; } }
        public override string FormatExtension { get { return "xmind"; } }

        public override void ExportData(CanvasData data, params object[] locationArgs)
        {
            // Export is not implemented yet, it could be (future development)
            throw new NotImplementedException();
        }

        public override CanvasData ImportData(params object[] args)
        {
            if (args == null || args.Length != 1 || args[0].GetType() != typeof(string))
                throw new ArgumentException("Location Arguments");
            string path = (string)args[0];

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                XmlDocument data = new XmlDocument();
                data.Load(fs);
            }

            // TODO
            throw new NotImplementedException();
        }
    }
}
