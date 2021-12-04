using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DetectCovid
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Result result = new Result();
            this.Hide();
            result.ShowDialog();

        }
        public static Label SetPlaceholder(Control control, string text)
        {
            var placeholder = new Label
            {
                Text = text,
                Font = control.Font,
                ForeColor = Color.Gray,
                BackColor = Color.Transparent,
                Cursor = Cursors.IBeam,
                Margin = Padding.Empty,

                //get rid of the left margin that all labels have
                FlatStyle = FlatStyle.System,
                AutoSize = false,

                //Leave 1px on the left so we can see the blinking cursor
                Size = new Size(control.Size.Width - 1, control.Size.Height),
                Location = new Point(control.Location.X + 1, control.Location.Y)
            };

            //when clicking on the label, pass focus to the control
            placeholder.Click += (sender, args) => { 
                control.Focus();
            };

            //disappear when the user starts typing
            control.TextChanged += (sender, args) => {
                placeholder.Visible = string.IsNullOrEmpty(control.Text);
            };

            //stay the same size/location as the control
            EventHandler updateSize = (sender, args) => {
                placeholder.Location = new Point(control.Location.X + 1, control.Location.Y);
                placeholder.Size = new Size(control.Size.Width - 1, control.Size.Height);
            };

            control.SizeChanged += updateSize;
            control.LocationChanged += updateSize;

            control.Parent.Controls.Add(placeholder);
            placeholder.BringToFront();

            return placeholder;
        }

        private void Register_Load(object sender, EventArgs e)
        {
            SetPlaceholder(txtID, "ID");
            SetPlaceholder(txtName, "Name");
            SetPlaceholder(txtEmail, "Email");
            SetPlaceholder(txtImage, "Image link");
        }
    }
}
