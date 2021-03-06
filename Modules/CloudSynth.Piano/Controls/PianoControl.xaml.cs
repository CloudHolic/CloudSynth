using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using CloudSynth.Core.Models;
using CloudSynth.Core.Utils;

namespace CloudSynth.Piano.Controls
{
    /// <summary>
    /// PianoControl.xaml에 대한 상호 작용 논리
    /// </summary>
    internal partial class PianoControl : UserControl
    {
        private bool _canExecutePlay, _canExecuteStop;
        private EventHandler _canExecutePlayChanged, _canExecuteStopChanged;
        private static readonly Tonic[] BlackKeys = { Tonic.CSharp, Tonic.DSharp, Tonic.FSharp, Tonic.GSharp, Tonic.ASharp };

        protected override bool IsEnabledCore => base.IsEnabledCore && (_canExecutePlay || _canExecuteStop);

        #region Dependency properties
        
        public static readonly DependencyProperty PlayCommandProperty = DependencyProperty.Register("PlayCommand",
            typeof(ICommand), typeof(PianoControl), new PropertyMetadata(OnCommandChanged));

        public static readonly DependencyProperty StopCommandProperty = DependencyProperty.Register("StopCommand",
            typeof(ICommand), typeof(PianoControl), new PropertyMetadata(OnCommandChanged));

        public static readonly DependencyProperty OctaveProperty = DependencyProperty.Register("Octave",
            typeof(int), typeof(PianoControl), new FrameworkPropertyMetadata(OnOctaveChanged)
            {
                BindsTwoWayByDefault = true,
                DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });

        #endregion

        public PianoControl()
        {
            InitializeComponent();
        }

        #region Properties

        public ICommand PlayCommand
        {
            get => (ICommand) GetValue(PlayCommandProperty);
            set => SetValue(PlayCommandProperty, value);
        }

        public ICommand StopCommand
        {
            get => (ICommand) GetValue(StopCommandProperty);
            set => SetValue(StopCommandProperty, value);
        }

        public int Octave
        {
            get => (int) GetValue(OctaveProperty);
            set => SetValue(OctaveProperty, value);
        }

        #endregion

        #region Property callback methods
        
        public static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var p = (PianoControl)d;
            p.HookUpCommand(e.Property, (ICommand)e.OldValue, (ICommand)e.NewValue);
        }

        public static void OnOctaveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var p = (PianoControl) d;
            p.Octave = (int)e.NewValue;
        }

        #endregion

        #region Method about command bindings

        private void HookUpCommand(DependencyProperty property, ICommand oldCommand, ICommand newCommand)
        {
            if (oldCommand != null)
                RemoveCommand(property, oldCommand);

            AddCommand(property, newCommand);
        }

        private void AddCommand(DependencyProperty property, ICommand command)
        {
            if (property == PlayCommandProperty)
            {
                var handler = new EventHandler(CanExecutePlayChanged);
                _canExecutePlayChanged = handler;
                if (command != null)
                    command.CanExecuteChanged += _canExecutePlayChanged;
            }
            else if (property == StopCommandProperty)
            {
                var handler = new EventHandler(CanExecuteStopChanged);
                _canExecuteStopChanged = handler;
                if (command != null)
                    command.CanExecuteChanged += _canExecuteStopChanged;
            }
        }
        
        private void RemoveCommand(DependencyProperty property, ICommand command)
        {
            EventHandler handler = property == PlayCommandProperty ? CanExecutePlayChanged : CanExecuteStopChanged;
            command.CanExecuteChanged -= handler;
        }

        #endregion

        #region PropertyChanged event handlers

        // Should CanExecuteChanged event handlers be splitted? Idk...
        private void CanExecutePlayChanged(object sender, EventArgs e)
        {
            if (PlayCommand != null)
                _canExecutePlay = PlayCommand.CanExecute(null);

            CoerceValue(IsEnabledProperty);
        }

        private void CanExecuteStopChanged(object sender, EventArgs e)
        {
            if (StopCommand != null)
                _canExecuteStop = StopCommand.CanExecute(null);

            CoerceValue(IsEnabledProperty);
        }

        #endregion

        #region OnSizeChanged event handler

        private void PianoControl_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (var child in UiHelper.FindVisualChildren<Rectangle>(this))
            {
                if (!BlackKeys.Contains((Tonic) child.Tag))
                    continue;

                child.Height = e.NewSize.Height * 0.6;
                child.Width = e.NewSize.Width * 0.1;
            }
        }

        #endregion

        #region White key event handlers

        private void OnWhiteKeyMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var key = (Rectangle) sender;
            key.Fill = new SolidColorBrush(Colors.Yellow);
            PlayCommand?.Execute(new PianoCommandParameter((Tonic) key.Tag, Octave));
        }

        private void OnWhiteKeyMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var key = (Rectangle) sender;
            key.Fill = new SolidColorBrush(Colors.Ivory);
            StopCommand?.Execute(new PianoCommandParameter((Tonic)key.Tag, Octave));
        }

        private void OnWhiteKeyMouseEnter(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var key = (Rectangle) sender;
                key.Fill = new SolidColorBrush(Colors.Yellow);
                PlayCommand?.Execute(new PianoCommandParameter((Tonic)key.Tag, Octave));
            }
        }

        private void OnWhiteKeyMouseLeave(object sender, MouseEventArgs e)
        {
            var key = (Rectangle) sender;
            key.Fill = new SolidColorBrush(Colors.Ivory);
            if(e.LeftButton == MouseButtonState.Pressed)
                StopCommand?.Execute(new PianoCommandParameter((Tonic)key.Tag, Octave));
        }

        #endregion

        #region Black key event handlers

        private void OnBlackKeyMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var key = (Rectangle) sender;
            key.Fill = new SolidColorBrush(Colors.DarkGray);
            PlayCommand?.Execute(new PianoCommandParameter((Tonic)key.Tag, Octave));
        }

        private void OnBlackKeyMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var key = (Rectangle) sender;
            key.Fill = new SolidColorBrush(Colors.Black);
            StopCommand?.Execute(new PianoCommandParameter((Tonic)key.Tag, Octave));
        }

        private void OnBlackKeyMouseEnter(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var key = (Rectangle)sender;
                key.Fill = new SolidColorBrush(Colors.DarkGray);
                PlayCommand?.Execute(new PianoCommandParameter((Tonic)key.Tag, Octave));
            }
        }

        private void OnBlackKeyMouseLeave(object sender, MouseEventArgs e)
        {
            var key = (Rectangle)sender;
            key.Fill = new SolidColorBrush(Colors.Black);
            if (e.LeftButton == MouseButtonState.Pressed)
                StopCommand?.Execute(new PianoCommandParameter((Tonic)key.Tag, Octave));
        }

        #endregion
    }
}
