using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SSSS {
    public partial class KNNForm : Form {

        string[][] vectorTable;

        public KNNForm() {
            InitializeComponent();
        }

        public KNNForm(string[][] tempVectorTable) : base () {
            this.vectorTable = tempVectorTable;
        }
    }
}
