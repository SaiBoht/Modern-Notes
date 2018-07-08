namespace ClientAppliaction
{
    partial class ApplicationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_noteName = new System.Windows.Forms.TextBox();
            this.txt_noteContent = new System.Windows.Forms.RichTextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_New = new System.Windows.Forms.Button();
            this.btn_UpdateList = new System.Windows.Forms.Button();
            this.listView_notes = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // txt_noteName
            // 
            this.txt_noteName.Location = new System.Drawing.Point(155, 12);
            this.txt_noteName.Name = "txt_noteName";
            this.txt_noteName.Size = new System.Drawing.Size(223, 20);
            this.txt_noteName.TabIndex = 1;
            // 
            // txt_noteContent
            // 
            this.txt_noteContent.Location = new System.Drawing.Point(155, 38);
            this.txt_noteContent.Name = "txt_noteContent";
            this.txt_noteContent.Size = new System.Drawing.Size(491, 330);
            this.txt_noteContent.TabIndex = 2;
            this.txt_noteContent.Text = "";
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(409, 12);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 3;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_save_click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(490, 12);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 23);
            this.btn_Delete.TabIndex = 4;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_New
            // 
            this.btn_New.Location = new System.Drawing.Point(571, 12);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(75, 23);
            this.btn_New.TabIndex = 5;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btn_UpdateList
            // 
            this.btn_UpdateList.Location = new System.Drawing.Point(13, 345);
            this.btn_UpdateList.Name = "btn_UpdateList";
            this.btn_UpdateList.Size = new System.Drawing.Size(119, 23);
            this.btn_UpdateList.TabIndex = 6;
            this.btn_UpdateList.Text = "Update list";
            this.btn_UpdateList.UseVisualStyleBackColor = true;
            this.btn_UpdateList.Click += new System.EventHandler(this.btn_UpdateList_ClickAsync);
            // 
            // listView_notes
            // 
            this.listView_notes.FullRowSelect = true;
            this.listView_notes.Location = new System.Drawing.Point(11, 12);
            this.listView_notes.Name = "listView_notes";
            this.listView_notes.Size = new System.Drawing.Size(121, 327);
            this.listView_notes.TabIndex = 7;
            this.listView_notes.UseCompatibleStateImageBehavior = false;
            this.listView_notes.View = System.Windows.Forms.View.List;
            this.listView_notes.SelectedIndexChanged += new System.EventHandler(this.listView_notes_SelectedIndexChanged);
            // 
            // ApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 385);
            this.Controls.Add(this.listView_notes);
            this.Controls.Add(this.btn_UpdateList);
            this.Controls.Add(this.btn_New);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txt_noteContent);
            this.Controls.Add(this.txt_noteName);
            this.Name = "ApplicationForm";
            this.Text = "Note application ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_noteName;
        private System.Windows.Forms.RichTextBox txt_noteContent;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.Button btn_UpdateList;
        private System.Windows.Forms.ListView listView_notes;
    }
}

