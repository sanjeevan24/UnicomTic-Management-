namespace UnicomTic_Management_System.Views
{
    partial class RoomForm
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
            lblRoomName = new Label();
            lblRoomType = new Label();
            cmbRoomType = new ComboBox();
            txtRoomName = new TextBox();
            btnAddRoom = new Button();
            btnUpdateRoom = new Button();
            btnDeleteRoom = new Button();
            dataGridViewRooms = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRooms).BeginInit();
            SuspendLayout();
            // 
            // lblRoomName
            // 
            lblRoomName.AutoSize = true;
            lblRoomName.Location = new Point(219, 75);
            lblRoomName.Name = "lblRoomName";
            lblRoomName.Size = new Size(107, 25);
            lblRoomName.TabIndex = 0;
            lblRoomName.Text = "RoomName";
            // 
            // lblRoomType
            // 
            lblRoomType.AutoSize = true;
            lblRoomType.Location = new Point(219, 127);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(97, 25);
            lblRoomType.TabIndex = 1;
            lblRoomType.Text = "RoomType";
            // 
            // cmbRoomType
            // 
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(334, 124);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(182, 33);
            cmbRoomType.TabIndex = 2;
            // 
            // txtRoomName
            // 
            txtRoomName.Location = new Point(334, 72);
            txtRoomName.Name = "txtRoomName";
            txtRoomName.Size = new Size(150, 31);
            txtRoomName.TabIndex = 3;
            // 
            // btnAddRoom
            // 
            btnAddRoom.Location = new Point(216, 187);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(112, 34);
            btnAddRoom.TabIndex = 4;
            btnAddRoom.Text = "Add";
            btnAddRoom.UseVisualStyleBackColor = true;
            btnAddRoom.Click += btnAddRoom_Click;
            // 
            // btnUpdateRoom
            // 
            btnUpdateRoom.Location = new Point(334, 187);
            btnUpdateRoom.Name = "btnUpdateRoom";
            btnUpdateRoom.Size = new Size(112, 34);
            btnUpdateRoom.TabIndex = 5;
            btnUpdateRoom.Text = "Update";
            btnUpdateRoom.UseVisualStyleBackColor = true;
            btnUpdateRoom.Click += btnUpdateRoom_Click;
            // 
            // btnDeleteRoom
            // 
            btnDeleteRoom.Location = new Point(465, 187);
            btnDeleteRoom.Name = "btnDeleteRoom";
            btnDeleteRoom.Size = new Size(112, 34);
            btnDeleteRoom.TabIndex = 6;
            btnDeleteRoom.Text = "Delete";
            btnDeleteRoom.UseVisualStyleBackColor = true;
            btnDeleteRoom.Click += btnDeleteRoom_Click;
            // 
            // dataGridViewRooms
            // 
            dataGridViewRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRooms.Location = new Point(227, 227);
            dataGridViewRooms.Name = "dataGridViewRooms";
            dataGridViewRooms.RowHeadersWidth = 62;
            dataGridViewRooms.Size = new Size(360, 225);
            dataGridViewRooms.TabIndex = 7;
            dataGridViewRooms.CellContentClick += dataGridViewRooms_CellContentClick;
            // 
            // RoomForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewRooms);
            Controls.Add(btnDeleteRoom);
            Controls.Add(btnUpdateRoom);
            Controls.Add(btnAddRoom);
            Controls.Add(txtRoomName);
            Controls.Add(cmbRoomType);
            Controls.Add(lblRoomType);
            Controls.Add(lblRoomName);
            Name = "RoomForm";
            Text = "RoomForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewRooms).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRoomName;
        private Label lblRoomType;
        private ComboBox cmbRoomType;
        private TextBox txtRoomName;
        private Button btnAddRoom;
        private Button btnUpdateRoom;
        private Button btnDeleteRoom;
        private DataGridView dataGridViewRooms;
    }
}