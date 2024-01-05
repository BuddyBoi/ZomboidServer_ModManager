using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZomboidServerModManager
{
    public partial class Form1 : Form
    {
        public CModManager ModManager = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void buttonModEnable_Click(object sender, EventArgs e)
        {
            string strSelected = listboxModsAvailable.SelectedItem.ToString();
            ModManager.SetEnabled(strSelected, true);
            UpdateAvailableMods();
        }

        private void buttonModDisable_Click(object sender, EventArgs e)
        {
            string strSelected = listboxModsEnabled.SelectedItem.ToString();
            ModManager.SetEnabled(strSelected, false);
            UpdateAvailableMods();
        }

        private void listboxModsAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listboxModsAvailable.SelectedItem == null)
                return;

            listboxModSelectedPreview.Items.Clear();
            if (listboxModsAvailable.SelectedItem.ToString().Count() == 0)
                return;

            CModItem mod = ModManager.GetModByName(listboxModsAvailable.SelectedItem.ToString());
            listboxModSelectedPreview.Items.Add("Workshop ID: " + mod.workshopId);
            foreach( string s in mod.modIDs)
            {
                if( s.Count() > 0)
                {
                    listboxModSelectedPreview.Items.Add("Mod ID: " + s);
                }
            }
        }

        private void UpdateAvailableMods()
        {
            //clear both lists
            listboxModsAvailable.Items.Clear();
            listboxModsEnabled.Items.Clear();

            //disabled
            foreach (CModItem etx in ModManager.modListDisabled)
            {
                if (etx.name.Count() == 0)
                    continue;

                listboxModsAvailable.Items.Add(etx.name);
            }

            //enabled
            foreach ( CModItem etx in ModManager.modListEnabled)
            {
                if (etx.name.Count() == 0)
                    continue;

                listboxModsEnabled.Items.Add(etx.name);
            }
        }

        private void buttonModSetupList_Click(object sender, EventArgs e)
        {
            string configWorkshopID = "WorkshopItems=";
            string configModIDs = "Mods=";

            foreach ( CModItem mod in ModManager.modListEnabled)
            {
                //workshopID
                configWorkshopID += (mod.workshopId + ";");

                //mod IDs
                foreach( string s in mod.modIDs)
                {
                    configModIDs += (s + ";");
                }
            }

            richtextGeneratedConfig.Text = configWorkshopID + "\n" + configModIDs;

            List<string> listStringConfig = File.ReadAllLines("pzserver.ini").ToList();
            if (listStringConfig.Count() == 0)
                return;

            for (int i = 0; i != listStringConfig.Count(); i++)
            {
                string strCurrent = listStringConfig[i];
                if (strCurrent.Count() == 0)
                    continue;

                if (strCurrent.Contains("Mods="))
                {
                    listStringConfig[i] = configModIDs;
                    continue;
                }

                if (strCurrent.Contains("WorkshopItems="))
                {
                    listStringConfig[i] = configWorkshopID;
                    continue;
                }
            }

            File.WriteAllLines("pzserver.ini", listStringConfig);
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            ModManager = new CModManager(files[0]);
            if (!ModManager.isSetup)
            {
                MessageBox.Show("Failed to load mod file");
                return;
            }

            //add items to list
            UpdateAvailableMods();
        }
    }

    public class CModItem
    {
        public int index = 0;
        public string name = "invalid";
        public string workshopId = "";
        public List<string> modIDs = new List<string>();
        public bool isSetup = false;
        public CModItem(string inputName)
        {
            name = inputName;

            if (!Init())
                return;
            isSetup = true;
        }
        private bool Init()
        {
            return false;
        }
    }

    public class CModManager
    {
        string modFilePath = "INVALID";
        List<string> modFile = new List<string>();
        private List<CModItem> modList = new List<CModItem>();
        public List<CModItem> modListDisabled = new List<CModItem>();
        public List<CModItem> modListEnabled = new List<CModItem>();
        public bool isSetup = false;

        public CModManager()
        {
            MessageBox.Show("Empty setup");
        }

        public CModManager(string modListFile)
        {
            if (modListFile == null)
                return;

            modFilePath = modListFile;
            if (!Init())
                return;

            isSetup = true;
        }

        public void SetEnabled(string modName, bool newEnabled)
        {
            CModItem mod = GetModByName(modName, !newEnabled);
            if (mod == null)
                return;

            //remove from both
            modListDisabled.Remove(mod);
            modListEnabled.Remove(mod);

            //add to selected
            if( newEnabled)
            {
                modListEnabled.Add(mod);
            }
            else
            {
                modListDisabled.Add(mod);
            }
        }

        public CModItem GetModByName(string name, bool itemsEnabled = false)
        {
            if( !itemsEnabled)
            {
                foreach (CModItem etx in modListDisabled)
                {
                    if (etx.name == name)
                        return etx;
                }
            } else
            {
                foreach (CModItem etx in modListEnabled)
                {
                    if (etx.name == name)
                        return etx;
                }
            }
            
            

            return null;
        }

        private bool Init()
        {
            List<string> modFile = File.ReadAllLines(modFilePath).ToList();
            if (modFile.Count() == 0)
                return false;

            for( int i =0; i!= modFile.Count(); i++)
            {                
                string sCurrent = modFile[i];

                //skip empty lines
                if (sCurrent.Count() == 0)
                    continue;

                //new mod table
                if (sCurrent.StartsWith("-"))
                {
                    CModItem mod = new CModItem(sCurrent.Substring(1, sCurrent.Count() - 1));
                    modList.Add(mod);
                    continue;
                }
                
                //add workshop ID to last item
                else if( sCurrent.StartsWith("Workshop ID: "))
                {
                    modList.Last().workshopId = sCurrent.Substring(12).Trim();
                    continue;
                }

                //add mod IDs to last item
                else if (sCurrent.StartsWith("Mod ID: "))
                {
                    modList.Last().modIDs.Add(sCurrent.Substring(8).Trim());
                    continue;
                }
            }

            //set temp list
            modListDisabled = modList;

            return true;
        }
    }
}
