using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CloudSynth.Piano.Controls
{
    /// <summary>
    /// PianoControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PianoControl : UserControl
    {
        private bool _canExecute;
        private EventHandler _canExecuteChanged;

        public static readonly DependencyProperty KeyboardCommandProperty =
            DependencyProperty.Register("KeyboardCommand", typeof(ICommand), typeof(PianoControl),
                new PropertyMetadata(OnKeyboardCommandChanged));

        public PianoControl()
        {
            InitializeComponent();
        }

        public ICommand KeyboardCommand
        {
            get => (ICommand) GetValue(KeyboardCommandProperty);
            set => SetValue(KeyboardCommandProperty, value);
        }

        protected override bool IsEnabledCore => base.IsEnabledCore && _canExecute;

        public static void OnKeyboardCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var p = (PianoControl)d;
            p.HookUpCommand((ICommand) e.OldValue, (ICommand) e.NewValue);
        }

        private void AddCommand(ICommand command)
        {
            var handler = new EventHandler(CanExecuteChanged);
            _canExecuteChanged = handler;
            if (command != null)
                command.CanExecuteChanged += _canExecuteChanged;
        }

        private void CanExecuteChanged(object sender, EventArgs e)
        {
            if (KeyboardCommand != null)
                _canExecute = KeyboardCommand.CanExecute(null);

            CoerceValue(IsEnabledProperty);
        }
        
        private void HookUpCommand(ICommand oldCommand, ICommand newCommand)
        {
            if (oldCommand != null)
                RemoveCommand(oldCommand);

            AddCommand(newCommand);
        }
        
        private void RemoveCommand(ICommand command)
        {
            EventHandler handler = CanExecuteChanged;
            command.CanExecuteChanged -= handler;
        }
    }
}
