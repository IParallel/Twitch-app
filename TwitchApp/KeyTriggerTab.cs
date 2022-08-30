using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using TwitchApp.BDModels;
namespace TwitchApp
{
    public partial class KeyTriggerTab : Form
    {
        public KeyTriggerTab()
        {
            InitializeComponent();
        }

        private void addKeyChild(Form child)
        {
            child.TopLevel = false;
            child.Dock = DockStyle.Top;
            KeyTriggerContent.Controls.Add(child);
            KeyTriggerContent.Tag = child;
            child.Show();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            ChildKeysTab childKeysTab = new ChildKeysTab();
            addKeyChild(childKeysTab);
        }
        
        private void on_Load(object sender, EventArgs e)
        {
            //
            this.SuspendLayout();
            List<ChildKeyModel> childForms = Program.Ktriggers.GetAll();
            foreach (ChildKeyModel childForm in childForms)
            {
                addKeyChild(new ChildKeysTab(childForm.image, childForm.name, childForm.key, childForm.qty));
            }
            this.ResumeLayout();
        }
    }
}
