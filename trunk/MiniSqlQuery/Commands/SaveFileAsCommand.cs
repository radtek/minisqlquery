﻿using System;
using System.Windows.Forms;
using MiniSqlQuery.Core.Commands;
using MiniSqlQuery.Core;

namespace MiniSqlQuery.Commands
{
	public class SaveFileAsCommand
        : CommandBase
    {
		public SaveFileAsCommand()
            : base("Save File &As...")
        {
        }

        public override void Execute()
        {
			IEditor editor = HostWindow.Instance.ActiveMdiChild as IEditor;
			if (editor != null)
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
				saveFileDialog.Filter = editor.FileFilter;
				if (saveFileDialog.ShowDialog(HostWindow.Instance) == DialogResult.OK)
				{
					// what if this filename covers an existing open window?
					editor.FileName = saveFileDialog.FileName;
					editor.SaveFile();
				}
			}
        }
    }
}
