using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ce = FichesPays.fichePaysGeneralClass.CodeErreurs;
namespace FichesPays
{
    internal class fichePaysGeneralClass
    {
        #region Enumeration
        public enum CodeErreurs
        {
            CEErreurIndetermine,
            CEErreurExtension,
            CEErreurOuvrir,
            CEErreurEnregistrement,
            CEErreurEnregistrementSous,
            CEErreurMauvaiseExtension,
            CEEErreurModification,
            CEErreurEdition,
            CEErreurStyle,
            CEErreurAlignement,
            CEErreurPolice,
            CEErreurSelectionChanged,
        }
        #endregion

        #region Messages d'erreurs et initialisation des messages

        public static string[] tMessagesErreursStr = new string[12];

        public static void InitMessagesErreurs()
        {
            tMessagesErreursStr[(int)ce.CEErreurIndetermine] = "Une erreur indéterminée s'est produite. Veuillez contacter la personne ressource";
            tMessagesErreursStr[(int)ce.CEErreurExtension] = "L'extension .RFT doit etre utilisé.";
            tMessagesErreursStr[(int)ce.CEErreurMauvaiseExtension] = "Vous ne pouvez ouvrir que les fichiers portant l'extension .rtf avec l'application FichePays";
            tMessagesErreursStr[(int)ce.CEErreurOuvrir] = "Erreur lors de l'ouverture";
            tMessagesErreursStr[(int)ce.CEErreurEnregistrement] = "Erreur indéterminée s'est produite lors de l'enregistrement";
            tMessagesErreursStr[(int)ce.CEErreurEnregistrementSous] = "erreur indéterminée s'est produite lors de la sauvegarde";
            tMessagesErreursStr[(int)ce.CEEErreurModification] = "Le fichier n'a jamais été modifié.";
            tMessagesErreursStr[(int)ce.CEErreurEdition] = "Erreur lors de l'edition";
            tMessagesErreursStr[(int)ce.CEErreurStyle] = "Erreur lors de la modification du style";
            tMessagesErreursStr[(int)ce.CEErreurAlignement] = "Erreur lors de la modification de l'alignement";
            tMessagesErreursStr[(int)ce.CEErreurPolice] = "Erreur lors de la modification de la police";
            tMessagesErreursStr[(int)ce.CEErreurSelectionChanged] = "Erreur lors de la selection";
        }

        #endregion

        #region Menus mutellement exclusifs
        public static void EnleverCrochetSousMenus(ToolStripMenuItem parentMenu)
        {
            if (parentMenu != null)
            {
                foreach (ToolStripItem oToolStripItem in parentMenu.DropDownItems)
                {
                    if (oToolStripItem is ToolStripMenuItem)
                    {
                        ((ToolStripMenuItem)oToolStripItem).Checked = false;
                    }
                }
            }
        }
        #endregion
    }
}
