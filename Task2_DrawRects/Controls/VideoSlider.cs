using Emgu.CV.CvEnum;
using EmvuCV_VideoPlayer.Infrustructure;
using EmvuCV_VideoPlayer.ViewModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

namespace EmvuCV_VideoPlayer.Controls
{
    public class VideoSlider : Slider
    {
        protected override void OnThumbDragStarted(DragStartedEventArgs e)
        {
            ResetBinding();
            base.OnThumbDragStarted(e);
        }

        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            ResetBinding();
            base.OnPreviewMouseDown(e);
        }

        protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
        {
            VideoViewModel vm = ((VideoSlider)e.Source).DataContext as VideoViewModel;
            RewindVideo(vm);
            base.OnPreviewMouseUp(e);
        }

        protected override void OnThumbDragCompleted(DragCompletedEventArgs e)
        {
            VideoViewModel vm = ((VideoSlider)e.Source).DataContext as VideoViewModel;
            RewindVideo(vm);

            base.OnThumbDragCompleted(e);
        }

        private void ResetBinding()
        {
            double value = this.Value;
            BindingOperations.ClearBinding(this, Slider.ValueProperty);
            this.Value = value;
        }

        private void SetSliderValueBinding(VideoViewModel source)
        {
            Binding myBinding = new Binding();
            myBinding.Source = source;
            myBinding.Path = new PropertyPath("Timestamp");
            myBinding.Mode = BindingMode.TwoWay;
            myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(this, Slider.ValueProperty, myBinding);
        }

        private void RewindVideo(VideoViewModel vm)
        {
            double fps = vm.Capture.GetCaptureProperty(CapProp.Fps);
            if (vm.Capture.GetGrabberThreadState() == GrabStates.Running)
            {
                vm.Capture.Pause();
                while (vm.Capture.GetGrabberThreadState() == GrabStates.Running) ;
                Thread.Sleep(10); //I don't know why but Emgu.CV.World.dll crashes without any delay
                vm.Capture.SetCaptureProperty(CapProp.PosFrames, this.Value * fps);
                vm.Capture.Start();
            }
            else
            {
                vm.Capture.SetCaptureProperty(CapProp.PosFrames, this.Value * fps);
            }

            double value = this.Value;
            SetSliderValueBinding(vm);
            vm.Timestamp = value * 1000;
        }
    }
}
