﻿using Driving_School_Management_System.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Driving_School_Management_System
{
    public partial class MainForm : Form
    {
        int tabIndex = 1;
        int previousTabIndex = -1;
        MainWindow mainWindow = null;
        CondidatesWindow condidatesWindow = null;
        LessonsWindow lessonsForm = null;
        public MainForm()
        {
            InitializeComponent();
            ShowWindow<MainWindow>(mainWindow);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        bool SideBarExpand = true;
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (SideBarExpand)
            {
                UserNamePanel.Visible = false; 
                SideBar.Width =  52;             
                SideBarExpand = false;
            }
            else
            {
                UserNamePanel.Visible = true; 
                SideBar.Width = 237;
                SideBarExpand = true;
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; 
        }

       

        private void ShowWindow<FormType>(Form form) where FormType : Form , new()
        {
            if (form is null)
            {
                form = new FormType();
                form .MdiParent = this;
                form .Dock = DockStyle.Fill;
                form .Show();
                

            }
            else
            {
                form.Activate();
            }
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex; 
            tabIndex = 1;
            updateTabColor();
            //ShowMainWindow(); 
            ShowWindow<MainWindow>(mainWindow);

        }



        private void btnCondidtes_Click(object sender, EventArgs e)
        {

            previousTabIndex = tabIndex;
            tabIndex = 2;
            updateTabColor();
            //ShowCondidatesWindow(); 
            ShowWindow<CondidatesWindow>(condidatesWindow); 
        }



        private void updateTabColor()
        {
            ChangeTabPrevButtonColor();
            ChangeTabCurrentButtonColor(); 
        }

        private void ChangeTabCurrentButtonColor()
        {
            switch(tabIndex)
            {
                case 1:
                    btnMain.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;

                case 2:
                    btnCondidtes.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 3:
                    btnLessons.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
            }
        }


        private void ChangeTabPrevButtonColor()
        {
            switch (previousTabIndex)
            {
                case 1:
                    btnMain.BackColor = Color.Transparent;
                    break;

                case 2:
                    btnCondidtes.BackColor = Color.Transparent;
                    break;
                case 3:
                    btnLessons.BackColor = Color.Transparent;
                    break; 
            }
        }

        private void btnLessons_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex;
            tabIndex = 3;
            updateTabColor();
            ShowWindow<LessonsWindow>(lessonsForm); 

        }
    }
}
