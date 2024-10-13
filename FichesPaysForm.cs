/*
Programmeurs:   Bijoux Daouda, Adriano Kamgang, Michel Talla, Salifou Guindo
              
Date:           Octobre 2024

Solution:       FichePays.sln
Projet:         FichePays.csproj
Classe:         FichePaysForm.cs

But:            Devoir 02
*/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ce = FichesPays.fichePaysGeneralClass.CodeErreurs;
using g = FichesPays.fichePaysGeneralClass;

namespace FichesPays
{
    public partial class Parent : Form
    {
        #region Constructeur 
        int nbPaysForm = 0;
        ToolStripMenuItem oTool;

        public Parent()
        {
            InitializeComponent();
        }
        #endregion

        #region Variable

        private int nbPays = 1;
        private OpenFileDialog ofd;
        #endregion

        #region Load
        private void Parent_Load(object sender, EventArgs e)
        {
            g.InitMessagesErreurs();
            this.IsMdiContainer = true;
            associerImages();
            fichePaysOpenFileDialog.Filter = "Fichiers rtf (*.rtf)|*.rtf|Tous les fichiers(*.*)|*.*";
            fichePaysOpenFileDialog.DefaultExt = "rtf";
            fichePaysOpenFileDialog.AddExtension = true;
            fichePaysOpenFileDialog.CheckFileExists = true;
            fichePaysOpenFileDialog.CheckPathExists = true;

            DesactiverOperationsMenuBarreOutils();
        }
        #endregion

        #region Methodes publiques

        #region Association des images
        //Methode pour associer les images aux controles
        void associerImages()
        {
            boldToolStripButton.Image = Properties.Resources.boldhs;
            italicToolStripButton.Image = Properties.Resources.ItalicHS;
            underlineToolStripButton.Image = Properties.Resources.underline;
            alignLeftToolStripButton.Image = Properties.Resources.AlignTableCellMiddleLeftJustHS;
            alignRighToolStripButton.Image = Properties.Resources.AlignTableCellMiddleRightHS;
            alignCenterToolStripButton.Image = Properties.Resources.AlignTableCellMiddleCenterHS;
            aideToolStripButton.Image = Properties.Resources.Help1;
        }
        #endregion

        #region Barre de menus
        //Méthode partagée pour le style de la barre des menus et de la barre d’outils
        private void styleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oTool = (ToolStripMenuItem)sender;
            g.EnleverCrochetSousMenus(boutonOutilsToolStripMenuItem);
            oTool.Checked = true;
            //ToolStripMenuItem parentMenu = (ToolStripMenuItem)oTool.OwnerItem;

            int menuIndex = boutonOutilsToolStripMenuItem.DropDownItems.IndexOf(oTool) + 1;

            switch (menuIndex)
            {
                case 1:
                    fichePaysMenuStrip.RenderMode = ToolStripRenderMode.System;
                    break;
                case 2:
                    fichePaysMenuStrip.RenderMode = ToolStripRenderMode.Professional;
                    break;
                case 3:
                    fichePaysMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                    break;

            }

        }
        #endregion

        #region Nouvel enfant
        //Méthode partagée pour nouvel enfant
        private void FichierNouveauDocument_Click(object sender, EventArgs e)
        {

            try
            {
                ActiverOperationsMenuBarreOutils();             //Activation des controles
                PaysForm oPaysForm = new PaysForm();
                oPaysForm.MdiParent = this;
                oPaysForm.Text = "Pays " + nbPays.ToString();
                nbPays++;
                oPaysForm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurIndetermine]);
            }
        }
        #endregion

        #region Layout
        //Méthode partagée pour le layout des enfants
        private void FenetreMDILayout(object sender, EventArgs e)
        {
            oTool = (ToolStripMenuItem)sender;
            g.EnleverCrochetSousMenus(fenetreToolStripMenuItem);
            oTool.Checked = true;
            //ToolStripMenuItem parentMenu = (ToolStripMenuItem)clickedItem.OwnerItem;

            int menuIndex = fenetreToolStripMenuItem.DropDownItems.IndexOf(oTool);

            switch (menuIndex)
            {
                case 0:
                    this.LayoutMdi(MdiLayout.Cascade);
                    break;
                case 1:
                    this.LayoutMdi(MdiLayout.TileHorizontal);
                    break;
                case 2:
                    this.LayoutMdi(MdiLayout.TileVertical);
                    break;
                case 3:
                    this.LayoutMdi(MdiLayout.ArrangeIcons);
                    break;
            }

        }
        #endregion

        #region Panneau
        //Méthode partagée pour le déplacement de la barre de menus et de la barre d’outils
        private void QuatrePaneaux_ControlAdded(object sender, ControlEventArgs e)
        {
            Control control = e.Control;
            ToolStripPanel panel = sender as ToolStripPanel;

            // Vérifier si le contrôle ajouté est un MenuStrip ou une ToolStrip (barre d'outils)
            if (control is MenuStrip menuStrip)
            {
                if (panel == topToolStripPanel || panel == bottomToolStripPanel)
                {
                    menuStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
                    menuStrip.TextDirection = ToolStripTextDirection.Horizontal;
                    (fichePaysMenuStrip.Items[7]).Visible = true;
                }
                else if (panel == leftToolStripPanel || panel == rightToolStripPanel)
                {
                    menuStrip.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
                    menuStrip.TextDirection = ToolStripTextDirection.Vertical90;
                    (fichePaysMenuStrip.Items[7]).Visible = false;
                }



                //unToolStripComboBox.Visible = true; 
            }
            else if (control is ToolStrip toolStrip)
            {
                if (panel == leftToolStripPanel || panel == rightToolStripPanel)
                {
                    fichePaysToolStrip.Items[9].Visible = false;
                    fichePaysToolStrip.Items[10].Visible = false;
                }
                if (panel == topToolStripPanel || panel == bottomToolStripPanel)
                {
                    fichePaysToolStrip.Items[9].Visible = true;
                    fichePaysToolStrip.Items[10].Visible = true;
                }
            }


        }
        #endregion

        #region Nouveau Client

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Ouvrir client
        private void ouvrirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                ActiverOperationsMenuBarreOutils();                          //Activation des controles

                if (fichePaysOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (System.IO.Path.GetExtension(fichePaysOpenFileDialog.FileName).ToLower() != ".rtf")
                    {
                        MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurMauvaiseExtension], "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    PaysForm oPaysForm = new PaysForm();

                    oPaysForm.MdiParent = this;
                    oPaysForm.Text = fichePaysOpenFileDialog.FileName;

                    RichTextBox ortf = new RichTextBox();

                    ortf.LoadFile(fichePaysOpenFileDialog.FileName);

                    oPaysForm.nomTextBox.Text = ortf.Lines[0];
                    oPaysForm.capitaleTextBox.Text = ortf.Lines[1];
                    oPaysForm.superficieTextBox.Text = ortf.Lines[2];

                    ortf.SelectionStart = 0;
                    ortf.SelectionLength = ortf.Lines[0].Length + ortf.Lines[1].Length + ortf.Lines[2].Length + 3; // ne pas oublier changement de ligne
                    ortf.SelectedText = String.Empty;

                    oPaysForm.descriptionRichTextBox.Rtf = ortf.Rtf;

                    oPaysForm.Enregistrement = true;
                    oPaysForm.Modification = false;

                    oPaysForm.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurOuvrir]);
            }



        }
        #endregion

        #region Enregistrer ou Enregistrer sous
        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {


            try
            {
                if (this.ActiveMdiChild != null)
                {
                    PaysForm oPaysForm;
                    oPaysForm = (PaysForm)this.ActiveMdiChild;
                    if (sender == enregistrerSousToolStripMenuItem)
                        oPaysForm.EnregistrerSous();
                    else
                        oPaysForm.Enregistrer();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurIndetermine]);
            }

        }
        #endregion

        #region Fermer un enfant
        private void fermerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            PaysForm oPaysForm = new PaysForm();

            if (oPaysForm.Modification)
                oPaysForm.Enregistrer();
            this.ActiveMdiChild?.Close();
        }

        #endregion

        #region Fermer l'application

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaysForm oPaysForm = new PaysForm();
            if (oPaysForm.Modification)
                oPaysForm.Enregistrer();
            this.Close();
        }

        #endregion

        #region Edition
        private void Edition(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveMdiChild != null)
                {
                    RichTextBox oRichTextBox = this.ActiveMdiChild.Controls[0] as RichTextBox;
                    if (sender == couperToolStripMenuItem || sender == couperToolStripButton)
                    {
                        oRichTextBox.Cut();
                    }
                    else if (sender == copierToolStripMenuItem || sender == copierToolStripButton)
                    {
                        oRichTextBox.Copy();
                    }
                    else if (sender == collerToolStripMenuItem || sender == collerToolStripButton)
                    {
                        oRichTextBox.Paste();
                    }
                    else if (sender == effacerToolStripMenuItem)
                    {
                        oRichTextBox.Clear();
                    }
                    else if (sender == sélectionnerToolStripMenuItem)
                    {
                        oRichTextBox.SelectAll();
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurEdition]);
            }
        }

        #endregion

        #region Style police
        private void StylePolice(object sender, EventArgs e)
        {
            try
            {
                PaysForm oPaysForm = (PaysForm)this.ActiveMdiChild;
                if (this.ActiveMdiChild != null)
                {
                    RichTextBox oRichTextBox = this.ActiveMdiChild.Controls[0] as RichTextBox;
                    if (sender == boldToolStripButton)
                    {
                        oPaysForm.ChangerAttributsPolice(FontStyle.Bold);
                    }
                    else if (sender == italicToolStripButton)
                    {
                        oPaysForm.ChangerAttributsPolice(FontStyle.Italic);
                    }
                    else if (sender == underlineToolStripButton)
                    {
                        oPaysForm.ChangerAttributsPolice(FontStyle.Underline);
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurStyle]);
            }
        }

        #endregion

        #region DesactiverOperationsMenuBarreOutils
        public void DesactiverOperationsMenuBarreOutils()
        {
            foreach (var oMainToolStripItem in fichePaysMenuStrip.Items)
            {
                if (oMainToolStripItem is ToolStripMenuItem mainMenuItem)
                {
                    foreach (var oCourantToolStripItem in mainMenuItem.DropDownItems)
                    {
                        if (oCourantToolStripItem is ToolStripMenuItem courantMenuItem)
                        {
                            courantMenuItem.Enabled = false;
                        }
                    }

                }
            }
            nouveauToolStripMenuItem.Enabled = true;
            ouvrirToolStripMenuItem.Enabled = true;
            quitterToolStripMenuItem.Enabled = true;
            

            // Désactiver les boutons de la barre d'outils 
            foreach (var boutonToolStripItem in fichePaysToolStrip.Items)
            {
                if (boutonToolStripItem is ToolStripButton toolStripButton)
                {
                    // Désactiver tous les boutons
                    toolStripButton.Enabled = false;
                }

                if (boutonToolStripItem == nouveauToolStripButton || boutonToolStripItem == ouvrirToolStripButton)
                {
                    (boutonToolStripItem as ToolStripItem).Enabled = true;
                }
            }
        }
        #endregion

        #region ActiverOperationsMenuBarreOutils
        public void ActiverOperationsMenuBarreOutils()
        {
            foreach (var oMainToolStripItem in fichePaysMenuStrip.Items)
            {
                if (oMainToolStripItem is ToolStripMenuItem mainMenuItem)
                {
                    foreach (var oCourantToolStripItem in mainMenuItem.DropDownItems)
                    {
                        if (oCourantToolStripItem is ToolStripMenuItem courantMenuItem)
                        {
                            courantMenuItem.Enabled = true;
                        }
                    }

                }
            }

            //couper et copier ne sont pas accessibles
            couperToolStripMenuItem.Enabled = false;
            copierToolStripButton.Enabled = false;

            // Reactiver les boutons de la barre d'outils 
            foreach (var boutonToolStripItem in fichePaysToolStrip.Items)
            {
                if (boutonToolStripItem is ToolStripButton toolStripButton)
                {
                    // Reactiver tous les boutons
                    toolStripButton.Enabled = true;
                }

                couperToolStripButton.Enabled = false;
                copierToolStripButton.Enabled = false;
            }


        }

        #endregion

        #region Alignement
        private void Alignement(object sender, EventArgs e)
        {
            try
            {
                PaysForm oPaysForm = (PaysForm)this.ActiveMdiChild;
                if (this.ActiveMdiChild != null)
                {
                    RichTextBox oRichTextBox = this.ActiveMdiChild.Controls[0] as RichTextBox;
                    if (sender == alignLeftToolStripButton)
                    {
                        oRichTextBox.SelectionAlignment = HorizontalAlignment.Left;

                        alignRighToolStripButton.Checked = false;
                        alignCenterToolStripButton.Checked = false;
                    }
                    if (sender == alignRighToolStripButton)
                    {
                        oRichTextBox.SelectionAlignment = HorizontalAlignment.Right;

                        alignLeftToolStripButton.Checked = false;
                        alignCenterToolStripButton.Checked = false;
                    }
                    if (sender == alignCenterToolStripButton)
                    {
                        oRichTextBox.SelectionAlignment = HorizontalAlignment.Center;

                        alignRighToolStripButton.Checked = false;
                        alignLeftToolStripButton.Checked = false;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurAlignement]);
            }
        }

        #endregion

        #region Parent_MdiChildActivate
        public void Parent_MdiChildActivate()
        {
            // Désactiver les menus quand tous les documents sont fermés.
            if (this.ActiveMdiChild == null)
                DesactiverOperationsMenuBarreOutils();
        }
        #endregion


        #endregion
    }
}
