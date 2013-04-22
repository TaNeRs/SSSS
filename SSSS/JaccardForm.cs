using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SSSS {
    public partial class JaccardForm : Form {
        string[][] vectorTable;

        public JaccardForm() {
            InitializeComponent();
        }

        public JaccardForm(string[][] tempVectorTable)
            : base() {
            this.vectorTable = tempVectorTable;
        }
    }
}
