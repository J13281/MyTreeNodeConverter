using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyTemplate_new38;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var mc = new
            {
                Age = 22,
                Name = "Daichi",
                Child = new
                {
                    Age = 22,
                    Name = "Taka",
                    Array = new[] { 1, 2, 3, 4, 5 }
                },
            };

            var converter = new MyTreeNodeConverter();
            var node = converter.ToTreeNode("Root", mc);

            treeView1.Nodes.Add(node);
            treeView1.ExpandAll();
        }
    }
}