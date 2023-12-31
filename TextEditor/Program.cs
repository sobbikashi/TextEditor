﻿using DfEditor;
using System;
using System.Windows.Forms;
using TextEditor.BL;

namespace TextEditor
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm form = new MainForm();
            MessageService service = new MessageService();
            FileManager manager = new FileManager();

            var presenter = new MainPresenter<string>(form, manager, service);

            Application.Run(form);
        }
    }
}
