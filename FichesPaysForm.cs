/*
Programmeurs: Bijoux Daouda, Adriano Kamgang, Michel Talla, Salifou Guindo
              
Date: Octobre 2024
Solution: FichePays.sln
Projet: FichePays.csproj
Classe: FichePaysForm.cs

But:            Devoir 02
*/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        #region Load
        private void Parent_Load(object sender, EventArgs e)
        {
            g.InitMessagesErreurs();

            this.IsMdiContainer = true;
            associerImages();
        }
        #endregion


        #region Methodes publiques
        //Methode pour associer les images aux controles
        void associerImages()
        {
            boldToolStripButton.Image = Properties.Resources.boldhs;
            italicToolStripButton.Image = Properties.Resources.ItalicHS;
            underlineToolStripButton.Image = Properties.Resources.underline;
            alignLeftoolStripButton.Image = Properties.Resources.AlignTableCellMiddleLeftJustHS;
            alignRighToolStripButton.Image = Properties.Resources.AlignTableCellMiddleRightHS;
            alignCenterToolStripButton.Image = Properties.Resources.AlignTableCellMiddleCenterHS;
            aideToolStripButton.Image = Properties.Resources.Help1;
        }


        //Méthode partagée pour le style de la barre des menus et de la barre d’outils
        private void styleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oTool= (ToolStripMenuItem)sender;
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

        //Méthode partagée pour nouvel enfant
        private void FichierNouveauDocument_Click(object sender, EventArgs e)
        {
            try
            {
                nbPaysForm += 1;
                // Instancier un nouvel enfant
                PaysForm enfant = new PaysForm();

                // Associer l’enfant au parent
                enfant.MdiParent = this;

                // Numérotation automatique
                enfant.Text = "Pays " + nbPaysForm;

                //Affichage du formulaire
                enfant.Show();
            }
            catch (Exception)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurIndetermine]);
            }
        }

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
            else if(control is ToolStrip toolStrip)
            {
                if(panel==leftToolStripPanel || panel == rightToolStripPanel)
                {
                    fichePaysToolStrip.Items[9].Visible = false;
                    fichePaysToolStrip.Items[10].Visible= false;
                }
                if(panel==topToolStripPanel || panel == bottomToolStripPanel)
                {
                    fichePaysToolStrip.Items[9].Visible = true;
                    fichePaysToolStrip.Items[10].Visible = true;
                }
            }

        
        }
    }
}
#endregion