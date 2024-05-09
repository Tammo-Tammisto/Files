namespace ToDoApplicationMVP
{
    partial class ToDoListsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ToDoListsListBox = new ListBox();
            label1 = new Label();
            IdField = new TextBox();
            label2 = new Label();
            TitleField = new TextBox();
            SaveButton = new Button();
            DeleteButton = new Button();
            AddButton = new Button();
            SuspendLayout();
            // 
            // ToDoListsListBox
            // 
            ToDoListsListBox.DisplayMember = "Title";
            ToDoListsListBox.FormattingEnabled = true;
            ToDoListsListBox.ItemHeight = 15;
            ToDoListsListBox.Location = new Point(12, 12);
            ToDoListsListBox.Name = "ToDoListsListBox";
            ToDoListsListBox.Size = new Size(300, 274);
            ToDoListsListBox.TabIndex = 0;
            ToDoListsListBox.SelectedIndexChanged += ToDoListsListBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(335, 19);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 1;
            label1.Text = "ID:";
            // 
            // IdField
            // 
            IdField.Location = new Point(374, 16);
            IdField.Name = "IdField";
            IdField.ReadOnly = true;
            IdField.Size = new Size(278, 23);
            IdField.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(335, 60);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 3;
            label2.Text = "Title:";
            // 
            // TitleField
            // 
            TitleField.Location = new Point(374, 57);
            TitleField.Name = "TitleField";
            TitleField.Size = new Size(278, 23);
            TitleField.TabIndex = 4;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(374, 106);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(88, 32);
            SaveButton.TabIndex = 5;
            SaveButton.Text = "&Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(564, 106);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(88, 32);
            DeleteButton.TabIndex = 6;
            DeleteButton.Text = "&Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(468, 106);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(88, 32);
            AddButton.TabIndex = 7;
            AddButton.Text = "&New";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // ToDoListsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(691, 303);
            Controls.Add(AddButton);
            Controls.Add(DeleteButton);
            Controls.Add(SaveButton);
            Controls.Add(TitleField);
            Controls.Add(label2);
            Controls.Add(IdField);
            Controls.Add(label1);
            Controls.Add(ToDoListsListBox);
            Name = "ToDoListsForm";
            Text = "ToDo Lists";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox ToDoListsListBox;
        private Label label1;
        private TextBox IdField;
        private Label label2;
        private TextBox TitleField;
        private Button SaveButton;
        private Button DeleteButton;
        private Button AddButton;
    }
}
