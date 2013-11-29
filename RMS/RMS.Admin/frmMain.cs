using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using TM.UI.WindowsForms;
using TM.UI.WindowsForms.Controls;
using TM.UI.WindowsForms.Utilities;
using TM.Utilities;
using TM.Utilities.Messages;

namespace RMS.Admin
{
    [FunctionId(GlobalConstants.FunctionIds.FormMain)]
    public partial class frmMain : Form
    {
        public IMessageManager MessageManager { get; set; }

        #region Forms

        public frmUser UserForm { get; set; }

        public frmBranch BranchForm { get; set; }

        public frmProductCategory ProductCategoryForm { get; set; }

        public frmProduct ProductForm { get; set; }

        public frmUnit UnitForm { get; set; }

        private readonly IDictionary<int, BaseForm> FormDict = new Dictionary<int, BaseForm>();

        #endregion

        #region Constructor(s)

        public frmMain()
        {
            Thread.CurrentThread.CurrentUICulture = Application.CurrentCulture;
            InitializeComponent();
        } 

        #endregion

        #region Private methods

        #region Flicker free Form activation

        const int WM_MDINEXT = 0x224;

        public new void ActivateMdiChild(Form childToActivate)
        {
            if (ActiveMdiChild == childToActivate) return;

            var mdiClient = GetMDIClient();

            var pos = mdiClient.Controls.IndexOf(childToActivate);
            if (pos < 0)
                throw new InvalidOperationException(Resources.Resource.Common_FormNotFound);

            var form = pos == 0 ? mdiClient.Controls[1] : mdiClient.Controls[pos - 1];

            var direction = new IntPtr(pos == 0 ? 1 : 0);

            SendMessage(mdiClient.Handle, WM_MDINEXT, form.Handle, direction);
        }

        public MdiClient GetMDIClient()
        {
            foreach (var c in Controls.OfType<MdiClient>())
                return c;

            throw new InvalidOperationException(Resources.Resource.Common_Unexpected_Error);
        }

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam); 

        #endregion

        private void ShowForm(Form childForm)
        {
            if(!IsAvailable(childForm))
                childForm.Show();
            else
                ActivateMdiChild(childForm);

            #region Workaround to fix maximize proplem

            childForm.WindowState = FormWindowState.Normal;
            childForm.WindowState = FormWindowState.Maximized; 

            #endregion
        } 

        private static bool IsAvailable(Form form)
        {
            return Application.OpenForms.Cast<object>().Any(openForm => openForm == form);
        }

        private void AssignParent()
        {
            foreach (var baseForm in FormDict)
                baseForm.Value.MdiParent = this;
        }

        private void BuildFormList()
        {
            FormDict.Add(BuildListItem(UserForm));
            FormDict.Add(BuildListItem(BranchForm));
            FormDict.Add(BuildListItem(ProductCategoryForm));
            FormDict.Add(BuildListItem(ProductForm));
            FormDict.Add(BuildListItem(UnitForm));
        }

        private KeyValuePair<int, BaseForm> BuildListItem(BaseForm form)
        {
            var att = form.GetType().GetCustomAttribute<FunctionIdAttribute>();
            var funcID = att == null ? 0 : att.FunctionID;
            return new KeyValuePair<int, BaseForm>(funcID, form);
        }

        #endregion

        #region Event methods

        private void mItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mItemLogout_Click(object sender, EventArgs e)
        {
            //TODO: logout code here
        }

        private void mItemForm_Click(object sender, EventArgs e)
        {
            var menuItem = sender as TMToolStripMenuItem;
            if (menuItem == null || FormDict[menuItem.FunctionID] == null)
                return;

            FormDict[menuItem.FunctionID].InitializeData();
            ShowForm(FormDict[menuItem.FunctionID]);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            BuildFormList();
            AssignParent();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x10) // WM_CLOSE
            {
                var ret = MessageManager.ShowQuestion(Resources.Resource.Common_Exit_Caption,
                                                      Resources.Resource.Common_Exit_Message);
                if (ret == DialogResult.No)
                    return;

                foreach (var mdiChild in MdiChildren)
                    mdiChild.Close();

                Application.Exit();
            }
            base.WndProc(ref m);
        }

        #endregion
    }
}
