using Core.Katas.Draughts;
using DraughtsPlayer.Logic;
using System.Windows.Forms;

namespace DraughtsPlayer
{
    public partial class Form1 : Form
    {
        private readonly GameService _gameService;

        public Form1()
        {
            InitializeComponent();
            _gameService = new GameService();
            _gameService.StartNewGame();

            RegisterBindings();
            ResetSelectLists();
        }

        private void bt_new_game_Click(object sender, System.EventArgs e)
        {
            _gameService.StartNewGame();
            RefreshBindings();
        }

        private void bt_play_Click(object sender, System.EventArgs e)
        {
            bt_play.Enabled = false;
            PlayPlayerRound();
            PlayBotRound();
        }

        private void PlayBotRound()
        {
            _gameService.PlayBotRound();
            ResetSelectLists();
            RefreshBindings();
        }

        private void PlayPlayerRound()
        {
            _gameService.PlayRound((Move)cb_moves.SelectedItem);
            ResetSelectLists();
            RefreshBindings();
        }

        private void cb_moves_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if (cb_moves.SelectedItem != null) bt_play.Enabled = true;
        }

        private void cb_pieces_SelectedValueChanged(object sender, System.EventArgs e)
        {
            ////if ((cb_pieces.SelectedItem != null) && _gameService.CanAct(cb_pieces.SelectedItem as Piece))
            ////{
            ////    cb_moves.Enabled = true;
            ////}
            ////else
            ////{
            ////    cb_moves.Enabled = false;
            ////}
        }

        private void RefreshBindings()
        {
            foreach (Binding dataBinding in tb_board.DataBindings)
            {
                dataBinding.ReadValue();
            }

            foreach (Binding dataBinding in cb_pieces.DataBindings)
            {
                dataBinding.ReadValue();
            }

            foreach (Binding dataBinding in cb_moves.DataBindings)
            {
                dataBinding.ReadValue();
            }
        }

        private void RegisterBindings()
        {
            lb_history.DataBindings.Add("DataSource", _gameService, "MovesHistory");
            tb_board.DataBindings.Add("Text", _gameService, "CurrentBoardRepresentation");
            cb_pieces.DataBindings.Add("DataSource", _gameService, "CurrentWhitePieces");
            cb_pieces.DataBindings.Add("SelectedItem", _gameService, "SelectedWhitePiece");
            cb_moves.DataBindings.Add("DataSource", _gameService, "PossibleMoves");
        }

        private void ResetSelectLists()
        {
            cb_pieces.SelectedItem = null;
            cb_moves.SelectedItem = null;
            cb_moves.Enabled = false;
        }

        private void cb_pieces_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cb_pieces.Items.Count == 0) return;
            if (cb_pieces.SelectedIndex < 0) return;

            object item = cb_pieces.Items[cb_pieces.SelectedIndex];
            if ((item != null) && _gameService.CanAct(item as Piece))
            {
                cb_moves.Enabled = true;
                cb_moves.Focus();
            }
            else
            {
                cb_moves.Enabled = false;
            }
        }
    }
}