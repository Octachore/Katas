namespace DraughtsPlayer
{
    partial class Form1
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
            this.tb_board = new System.Windows.Forms.TextBox();
            this.lb_history = new System.Windows.Forms.ListBox();
            this.cb_pieces = new System.Windows.Forms.ComboBox();
            this.cb_moves = new System.Windows.Forms.ComboBox();
            this.bt_play = new System.Windows.Forms.Button();
            this.bt_new_game = new System.Windows.Forms.Button();
            this.lbl_pieces = new System.Windows.Forms.Label();
            this.lbl_mouves = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_board
            // 
            this.tb_board.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_board.Location = new System.Drawing.Point(12, 12);
            this.tb_board.Multiline = true;
            this.tb_board.Name = "tb_board";
            this.tb_board.Size = new System.Drawing.Size(200, 200);
            this.tb_board.TabIndex = 0;
            this.tb_board.TabStop = false;
            // 
            // lb_history
            // 
            this.lb_history.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_history.FormattingEnabled = true;
            this.lb_history.Location = new System.Drawing.Point(218, 12);
            this.lb_history.Name = "lb_history";
            this.lb_history.Size = new System.Drawing.Size(231, 199);
            this.lb_history.TabIndex = 1;
            // 
            // cb_pieces
            // 
            this.cb_pieces.FormattingEnabled = true;
            this.cb_pieces.Location = new System.Drawing.Point(58, 218);
            this.cb_pieces.Name = "cb_pieces";
            this.cb_pieces.Size = new System.Drawing.Size(154, 21);
            this.cb_pieces.TabIndex = 0;
            this.cb_pieces.SelectedIndexChanged += new System.EventHandler(this.cb_pieces_SelectedIndexChanged);
            this.cb_pieces.SelectedValueChanged += new System.EventHandler(this.cb_pieces_SelectedValueChanged);
            // 
            // cb_moves
            // 
            this.cb_moves.FormattingEnabled = true;
            this.cb_moves.Location = new System.Drawing.Point(58, 245);
            this.cb_moves.Name = "cb_moves";
            this.cb_moves.Size = new System.Drawing.Size(154, 21);
            this.cb_moves.TabIndex = 3;
            this.cb_moves.SelectedValueChanged += new System.EventHandler(this.cb_moves_SelectedValueChanged);
            // 
            // bt_play
            // 
            this.bt_play.Enabled = false;
            this.bt_play.Location = new System.Drawing.Point(225, 218);
            this.bt_play.Name = "bt_play";
            this.bt_play.Size = new System.Drawing.Size(70, 23);
            this.bt_play.TabIndex = 4;
            this.bt_play.Text = "Play";
            this.bt_play.UseVisualStyleBackColor = true;
            this.bt_play.Click += new System.EventHandler(this.bt_play_Click);
            // 
            // bt_new_game
            // 
            this.bt_new_game.Location = new System.Drawing.Point(301, 218);
            this.bt_new_game.Name = "bt_new_game";
            this.bt_new_game.Size = new System.Drawing.Size(70, 23);
            this.bt_new_game.TabIndex = 5;
            this.bt_new_game.Text = "New game";
            this.bt_new_game.UseVisualStyleBackColor = true;
            this.bt_new_game.Click += new System.EventHandler(this.bt_new_game_Click);
            // 
            // lbl_pieces
            // 
            this.lbl_pieces.AutoSize = true;
            this.lbl_pieces.Location = new System.Drawing.Point(13, 223);
            this.lbl_pieces.Name = "lbl_pieces";
            this.lbl_pieces.Size = new System.Drawing.Size(39, 13);
            this.lbl_pieces.TabIndex = 6;
            this.lbl_pieces.Text = "Pieces";
            this.lbl_pieces.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_mouves
            // 
            this.lbl_mouves.AutoSize = true;
            this.lbl_mouves.Location = new System.Drawing.Point(9, 248);
            this.lbl_mouves.Name = "lbl_mouves";
            this.lbl_mouves.Size = new System.Drawing.Size(45, 13);
            this.lbl_mouves.TabIndex = 7;
            this.lbl_mouves.Text = "Mouves";
            this.lbl_mouves.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 281);
            this.Controls.Add(this.lbl_mouves);
            this.Controls.Add(this.lbl_pieces);
            this.Controls.Add(this.bt_new_game);
            this.Controls.Add(this.bt_play);
            this.Controls.Add(this.cb_moves);
            this.Controls.Add(this.cb_pieces);
            this.Controls.Add(this.lb_history);
            this.Controls.Add(this.tb_board);
            this.Name = "Form1";
            this.Text = "Draughts player";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_board;
        private System.Windows.Forms.ListBox lb_history;
        private System.Windows.Forms.ComboBox cb_pieces;
        private System.Windows.Forms.ComboBox cb_moves;
        private System.Windows.Forms.Button bt_play;
        private System.Windows.Forms.Button bt_new_game;
        private System.Windows.Forms.Label lbl_pieces;
        private System.Windows.Forms.Label lbl_mouves;
    }
}

