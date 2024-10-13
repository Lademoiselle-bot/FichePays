/*
Programmeurs:   Bijoux Daouda, Adriano Kamgang, Michel Talla, Salifou Guindo
              
Date:           Octobre 2024

Solution:       FichePays.sln
Projet:         FichePays.csproj
Classe:         PaysForm.cs

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

    public partial class PaysForm : Form
    {
        #region Variables

        private bool enregistrementBool = false;
        private bool modificationBool = false;
        private string nomFichierStr;

        #endregion

        #region Constructeur
        public PaysForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Propriétés

        public bool Enregistrement
        {
            get
            {
                return enregistrementBool;
            }
            set
            {
                enregistrementBool = value;
            }
        }

        public bool Modification
        {
            get
            {
                return modificationBool;
            }
            set
            {
                modificationBool = value;
            }
        }

        #endregion

        #region Formulaire ferme

        private void PaysForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DialogResult oDialogResult;

                if (Modification)
                {
                    oDialogResult = MessageBox.Show("Voulez vous enregistrer les modification?", "Modification", MessageBoxButtons.YesNoCancel);

                    switch (oDialogResult)
                    {
                        case DialogResult.Yes:
                            Enregistrer();
                            this.Dispose();
                            break;

                        case DialogResult.Cancel:
                            e.Cancel = true;
                            break;

                        case DialogResult.No:
                            this.Dispose();
                            break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurIndetermine]);
            }
        }

        #endregion

        #region Changement dans TextBox
        private void capitaleTextBox_TextChanged(object sender, EventArgs e)
        {
            Modification = true;
        }

        #endregion

        #region Enregistrer

        public void Enregistrer()
        {


            try
            {
                if (Modification)
                {
                    if (!Enregistrement)
                        EnregistrerSous();
                    else
                    {
                        // Utiliser une méthode pour Sauvegarder...

                        RichTextBox ortf = new RichTextBox();

                        ortf.Rtf = descriptionRichTextBox.Rtf;

                        ortf.SelectionStart = 0;
                        ortf.SelectionLength = 0;
                        ortf.SelectedText = nomTextBox.Text + Environment.NewLine
                                            + capitaleTextBox.Text + Environment.NewLine
                                            + superficieTextBox.Text + Environment.NewLine;

                        ortf.SaveFile(nomFichierStr, RichTextBoxStreamType.RichText);
                        this.Text = nomFichierStr;
                        // clientRichTextBox.SaveFile(this.Text);

                        // Pas de changement
                        Modification = false;
                    }
                }
                else
                {
                    MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEEErreurModification], "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurEnregistrement]);
            }
        }

        #endregion

        #region Enregistrer sous
        public void EnregistrerSous()
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Fichiers rtf (*.rtf)|*.rtf|Tous les fichiers(*.*)|*.*";
                sfd.DefaultExt = "rtf";
                sfd.AddExtension = true;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // Utiliser une méthode pour Sauvegarder...

                    if (System.IO.Path.GetExtension(sfd.FileName).ToLower() != ".rtf")
                    {
                        MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurExtension], "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        nomFichierStr = sfd.FileName;
                        Enregistrement = true;
                        Enregistrer();
                        Modification = false;
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurEnregistrementSous]);
            }

        }

        #endregion

        #region ChangerAttributsPolice
        public void ChangerAttributsPolice(FontStyle style)
        {
            try
            {
                if (descriptionRichTextBox.SelectionFont.FontFamily.IsStyleAvailable(style))
                {
                    if (descriptionRichTextBox.SelectionFont != null)
                    {
                        // Conserver les autres attributs
                        FontStyle nouveauStyle = descriptionRichTextBox.SelectionFont.Style;

                        if (descriptionRichTextBox.SelectionFont.Style.HasFlag(style))
                        {
                            nouveauStyle &= ~style;  // Désactiver le style
                        }
                        else
                        {
                            nouveauStyle |= style;   // Activer le style
                        }

                        // Appliquer le nouveau style de police à la sélection
                        descriptionRichTextBox.SelectionFont = new Font(descriptionRichTextBox.SelectionFont.FontFamily,
                            descriptionRichTextBox.SelectionFont.Size, nouveauStyle);
                    }
                }
            }catch(Exception)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurPolice]);
            }
        }
        #endregion

        #region Selection changed
        private void descriptionRichTextBox_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Parent oParent = this.MdiParent as Parent;

                oParent.boldToolStripButton.Checked = descriptionRichTextBox.SelectionFont.Bold;
                oParent.italicToolStripButton.Checked = descriptionRichTextBox.SelectionFont.Italic;
                oParent.underlineToolStripButton.Checked = descriptionRichTextBox.SelectionFont.Underline;

                //Le texte est aligne a gauche au depart
                descriptionRichTextBox.SelectionAlignment = HorizontalAlignment.Left;
                oParent.alignLeftToolStripButton.Checked = true;

                //Si il y a du contenu dans le clipboard on peut coller
                if (Clipboard.ContainsText() || Clipboard.ContainsImage())
                    oParent.collerToolStripMenuItem.Enabled = true;
                else
                    oParent.collerToolStripMenuItem.Enabled = false;


                oParent.copierToolStripMenuItem.Enabled = descriptionRichTextBox.SelectionLength > 0;
                oParent.couperToolStripMenuItem.Enabled = descriptionRichTextBox.SelectionLength > 0;



                //Assigner la propriété .Enable des menus au ToolStrip
                oParent.couperToolStripButton.Enabled = oParent.couperToolStripMenuItem.Enabled;
                oParent.copierToolStripButton.Enabled = oParent.copierToolStripMenuItem.Enabled;
                oParent.collerToolStripButton.Enabled = oParent.collerToolStripMenuItem.Enabled;

                //Alignement
                if (descriptionRichTextBox.SelectionAlignment == HorizontalAlignment.Left)
                {
                    oParent.alignLeftToolStripButton.Checked = true; // Gauche
                    oParent.alignCenterToolStripButton.Checked = false;
                    oParent.alignRighToolStripButton.Checked = false;
                }

                if (descriptionRichTextBox.SelectionAlignment == HorizontalAlignment.Right)
                {
                    oParent.alignRighToolStripButton.Checked = true; // Droite
                    oParent.alignCenterToolStripButton.Checked = false;
                    oParent.alignLeftToolStripButton.Checked = false;
                }

                if (descriptionRichTextBox.SelectionAlignment == HorizontalAlignment.Center)
                {
                    oParent.alignCenterToolStripButton.Checked = true; // Centrer
                    oParent.alignLeftToolStripButton.Checked = false;
                    oParent.alignRighToolStripButton.Checked = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurSelectionChanged]);
            }
        }
        #endregion

        #region Methode formulaire activated
        private void PaysForm_Activated(object sender, EventArgs e)
        {
            descriptionRichTextBox_SelectionChanged(sender, e);
        }
        #endregion
    }
}

