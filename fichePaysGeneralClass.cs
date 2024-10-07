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
            CEErreurIndetermine
        }
        #endregion

        #region Messages d'erreurs et initialisation des messages

        public static string[] tMessagesErreursStr = new string[1];

        public static void InitMessagesErreurs()
        {
            tMessagesErreursStr[(int)ce.CEErreurIndetermine] = "Une erreur indéterminée s'est produite. Veuillez contacter la personne ressource";
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
