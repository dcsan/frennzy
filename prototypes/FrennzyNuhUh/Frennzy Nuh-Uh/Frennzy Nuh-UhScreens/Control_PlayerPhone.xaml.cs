using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Frennzy_Nuh_UhScreens
{
	public partial class Control_PlayerPhone : UserControl
	{
        private VM_Player _vm_Player;

        public VM VM
        {
            get { return VM.StaticVM; }
        }
        

		public Control_PlayerPhone()
		{
			// Required to initialize variables
			InitializeComponent();
            Loaded += new RoutedEventHandler(Control_PlayerPhone_Loaded);
		}

        void Control_PlayerPhone_Loaded(object sender, RoutedEventArgs e)
        {
            _vm_Player = (VM_Player)LayoutRoot.DataContext;
            _vm_Player.Visual = this;
            PlayerStateChanged(_vm_Player);
            _vm_Player.SubscribeToChange(() => _vm_Player.State, PlayerStateChanged);
        }


        private void Button_RemovePlayer_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FrameworkElement button = (FrameworkElement)sender;
            VM_Player player = (VM_Player)button.DataContext;
            VM.RemovePlayer(player);
        }

        private void Button_AddPhone_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FrameworkElement button = (FrameworkElement)sender;
            VM_Player player = (VM_Player)button.DataContext;
            VM.GoTo_AddPhone(player);
        }

        private void PlayerStateChanged(VM_Player player)
        {
            VisualStateManager.GoToState(player.Visual, player.State.ToString(), true);
        }

        private void Button_GuessTrue_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            VM.CurrentGame.CurrentRound.EnterVote(_vm_Player, true);
        }

        private void Button_GuessLie_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            VM.CurrentGame.CurrentRound.EnterVote(_vm_Player, false);
        }

        private void JoinGame_PhoneApp_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            FrameworkElement button = (FrameworkElement)sender;
            VM_Player player = (VM_Player)button.DataContext;
            player.State = GameStates.AddPlayers;
            VM.CheckPlayersReady();
        }
	}
}