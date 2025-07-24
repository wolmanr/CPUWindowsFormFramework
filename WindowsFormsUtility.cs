using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPUWindowsFormFramework
{
    public partial class WindowsFormsUtility : UserControl
    {
        public WindowsFormsUtility()
        {
            InitializeComponent();
        }

        public static void SetListButtons(ComboBox lst, DataTable sourcedt, DataTable targetdt, string tablename, string displayColumn)
        {
            lst.DataSource = sourcedt;
            lst.ValueMember = tablename + "Id";
            lst.DisplayMember = displayColumn;
            lst.DataBindings.Add("SelectedValue", targetdt, lst.ValueMember, false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public  static void SetControlBinding(Control ctrl, BindingSource bindsource)
        {
            if (ctrl == null || bindsource == null) return;

            string propertyname = "Text";
            string controlname = ctrl.Name.ToLower();
            string controltype = controlname.Substring(0, 3);
            string columnname = controlname.Substring(3);
            switch (controltype)
            {
                case "txt":
                case "lbl":
                    propertyname = "Text";
                    break;
                case "dtp":
                    propertyname = "Value";
                    break;
            }

            if (propertyname != "" && columnname != "")
            {
                ctrl.DataBindings.Add(propertyname, bindsource, columnname, true, DataSourceUpdateMode.OnPropertyChanged);
            }


        }
        
        public static void FormatGridForSearchResults(DataGridView grid)
        {
            grid.AllowUserToAddRows = false;
            grid.ReadOnly = true;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
    }
