using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class Form1 : Form
    {
        private List<TaskItem> tasks = new();
        private ListBox listBox;
        private TextBox textBox;
        private Button addBtn, completeBtn, deleteBtn;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Task Manager";
            this.Size = new System.Drawing.Size(400, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            listBox = new ListBox { Dock = DockStyle.Fill };
            textBox = new TextBox { Dock = DockStyle.Top, Height = 30 };
            addBtn = new Button { Text = "Add", Dock = DockStyle.Top, Height = 30 };
            completeBtn = new Button { Text = "Mark Complete", Dock = DockStyle.Top, Height = 30 };
            deleteBtn = new Button { Text = "Delete", Dock = DockStyle.Top, Height = 30 };

            addBtn.Click += AddBtn_Click;
            completeBtn.Click += CompleteBtn_Click;
            deleteBtn.Click += DeleteBtn_Click;
            listBox.DoubleClick += ListBox_DoubleClick;

            this.Controls.Add(listBox);
            this.Controls.Add(textBox);
            this.Controls.Add(addBtn);
            this.Controls.Add(completeBtn);
            this.Controls.Add(deleteBtn);
            RefreshList();
        }

        private void RefreshList()
        {
            listBox.Items.Clear();
            foreach (var task in tasks)
            {
                string status = task.IsCompleted ? "[X] " : "[ ] ";
                listBox.Items.Add(status + task.Description);
            }
        }

        private void AddBtn_Click(object? sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                tasks.Add(new TaskItem(textBox.Text));
                textBox.Clear();
                RefreshList();
            }
        }

        private void CompleteBtn_Click(object? sender, EventArgs e)
        {
            if (listBox.SelectedIndex >= 0)
            {
                tasks[listBox.SelectedIndex].IsCompleted = true;
                RefreshList();
            }
        }

        private void DeleteBtn_Click(object? sender, EventArgs e)
        {
            if (listBox.SelectedIndex >= 0)
            {
                tasks.RemoveAt(listBox.SelectedIndex);
                RefreshList();
            }
        }

        private void ListBox_DoubleClick(object? sender, EventArgs e)
        {
            CompleteBtn_Click(sender, e);
        }
    }

    class TaskItem
    {
        public string Description { get; }
        public bool IsCompleted { get; set; }
        public TaskItem(string desc) { Description = desc; IsCompleted = false; }
    }

    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.Run(new Form1());
        }
    }
}
