using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using CloudSynth.Core.Models;

namespace CloudSynth.Piano.Controls
{
    /// <summary>
    /// PianoControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PianoControl : UserControl
    {
        private bool _canExecute;
        private EventHandler _canExecuteChanged;
        protected override bool IsEnabledCore => base.IsEnabledCore && _canExecute;

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command",
            typeof(ICommand), typeof(PianoControl), new PropertyMetadata(OnCommandChanged));

        public PianoControl()
        {
            InitializeComponent();
        }

        public ICommand Command
        {
            get => (ICommand) GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var p = (PianoControl)d;
            p.HookUpCommand((ICommand) e.OldValue, (ICommand) e.NewValue);
        }

        private void HookUpCommand(ICommand oldCommand, ICommand newCommand)
        {
            if (oldCommand != null)
                RemoveCommand(oldCommand);

            AddCommand(newCommand);
        }

        private void CanExecuteChanged(object sender, EventArgs e)
        {
            if (Command != null)
                _canExecute = Command.CanExecute(null);

            CoerceValue(IsEnabledProperty);
        }

        private void AddCommand(ICommand command)
        {
            var handler = new EventHandler(CanExecuteChanged);
            _canExecuteChanged = handler;
            if (command != null)
                command.CanExecuteChanged += _canExecuteChanged;
        }

        private void RemoveCommand(ICommand command)
        {
            EventHandler handler = CanExecuteChanged;
            command.CanExecuteChanged -= handler;
        }

        #region White key event handlers

        private void OnWhiteKeyMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var key = (Rectangle) sender;
            key.Fill = new SolidColorBrush(Colors.Yellow);
            Command.Execute((Tonic)key.Tag);
        }

        private void OnWhiteKeyMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var key = (Rectangle) sender;
            key.Fill = new SolidColorBrush(Colors.Ivory);
            Command.Execute((Tonic)key.Tag);
        }

        private void OnWhiteKeyMouseEnter(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var key = (Rectangle) sender;
                key.Fill = new SolidColorBrush(Colors.Yellow);
                Command.Execute((Tonic) key.Tag);
            }
        }

        private void OnWhiteKeyMouseLeave(object sender, MouseEventArgs e)
        {
            var key = (Rectangle) sender;
            key.Fill = new SolidColorBrush(Colors.Ivory);
            if(e.LeftButton == MouseButtonState.Pressed)
                Command.Execute((Tonic)key.Tag);
        }

        #endregion

        #region Black key event handlers

        private void OnBlackKeyMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var key = (Rectangle) sender;
            key.Fill = new SolidColorBrush(Colors.DarkGray);
            Command.Execute((Tonic)key.Tag);
        }

        private void OnBlackKeyMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var key = (Rectangle) sender;
            key.Fill = new SolidColorBrush(Colors.Black);
            Command.Execute((Tonic)key.Tag);
        }

        private void OnBlackKeyMouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void OnBlackKeyMouseLeave(object sender, MouseEventArgs e)
        {

        }

        #endregion
    }
}
