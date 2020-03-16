using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Hermes.Resources.Behaviors
{
	public static class ResizeBehavior
	{
		public static readonly DependencyProperty LeftResize = DependencyProperty.RegisterAttached("LeftResize", typeof(Window), typeof(ResizeBehavior), new UIPropertyMetadata(null, OnLeftResizeChanged));
		public static readonly DependencyProperty RightResize = DependencyProperty.RegisterAttached("RightResize", typeof(Window), typeof(ResizeBehavior), new UIPropertyMetadata(null, OnRightResizeChanged));
		public static readonly DependencyProperty TopResize = DependencyProperty.RegisterAttached("TopResize", typeof(Window), typeof(ResizeBehavior), new UIPropertyMetadata(null, OnTopResizeChanged));
		public static readonly DependencyProperty BottomResize = DependencyProperty.RegisterAttached("BottomResize", typeof(Window), typeof(ResizeBehavior), new UIPropertyMetadata(null, OnBottomResizeChanged));
		public static readonly DependencyProperty TopLeftResize = DependencyProperty.RegisterAttached("TopLeftResize", typeof(Window), typeof(ResizeBehavior), new UIPropertyMetadata(null, OnTopLeftResizeChanged));
		public static readonly DependencyProperty TopRightResize = DependencyProperty.RegisterAttached("TopRightResize", typeof(Window), typeof(ResizeBehavior), new UIPropertyMetadata(null, OnTopRightResizeChanged));
		public static readonly DependencyProperty BottomLeftResize = DependencyProperty.RegisterAttached("BottomLeftResize", typeof(Window), typeof(ResizeBehavior), new UIPropertyMetadata(null, OnBottomLeftResizeChanged));
		public static readonly DependencyProperty BottomRightResize = DependencyProperty.RegisterAttached("BottomRightResize", typeof(Window), typeof(ResizeBehavior), new UIPropertyMetadata(null, OnBottomRightResizeChanged));

		public static Window GetLeftResize(DependencyObject obj) => (Window)obj.GetValue(LeftResize);
		public static Window GetRightResize(DependencyObject obj) => (Window)obj.GetValue(RightResize);
		public static Window GetTopResize(DependencyObject obj) => (Window)obj.GetValue(TopResize);
		public static Window GetBottomResize(DependencyObject obj) => (Window)obj.GetValue(BottomResize);
		public static Window GetTopLeftResize(DependencyObject obj) => (Window)obj.GetValue(TopLeftResize);
		public static Window GetTopRightResize(DependencyObject obj) => (Window)obj.GetValue(TopRightResize);
		public static Window GetBottomLeftResize(DependencyObject obj) => (Window)obj.GetValue(BottomLeftResize);
		public static Window GetBottomRightResize(DependencyObject obj) => (Window)obj.GetValue(BottomRightResize);

		public static void SetLeftResize(DependencyObject obj, Window window) => obj.SetValue(LeftResize, window);
		public static void SetRightResize(DependencyObject obj, Window window) => obj.SetValue(RightResize, window);
		public static void SetTopResize(DependencyObject obj, Window window) => obj.SetValue(TopResize, window);
		public static void SetBottomResize(DependencyObject obj, Window window) => obj.SetValue(BottomResize, window);
		public static void SetTopLeftResize(DependencyObject obj, Window window) => obj.SetValue(TopLeftResize, window);
		public static void SetTopRightResize(DependencyObject obj, Window window) => obj.SetValue(TopRightResize, window);
		public static void SetBottomLeftResize(DependencyObject obj, Window window) => obj.SetValue(BottomLeftResize, window);
		public static void SetBottomRightResize(DependencyObject obj, Window window) => obj.SetValue(BottomRightResize, window);

		private static void OnLeftResizeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) => Drag(sender, DragLeft);
		private static void OnRightResizeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) => Drag(sender, DragRight);
		private static void OnTopResizeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) => Drag(sender, DragTop);
		private static void OnBottomResizeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) => Drag(sender, DragBottom);
		private static void OnTopLeftResizeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) => Drag(sender, DragTopLeft);
		private static void OnTopRightResizeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) => Drag(sender, DragTopRight);
		private static void OnBottomLeftResizeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) => Drag(sender, DragBottomLeft);
		private static void OnBottomRightResizeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) => Drag(sender, DragBottomRight);

		private static void Drag(DependencyObject sender, DragDeltaEventHandler handler)
		{
			var thumb = sender as Thumb;

			if (thumb != null)
				thumb.DragDelta += handler;
		}

		private static void DragLeft(object sender, DragDeltaEventArgs e)
		{
			var window = ((Thumb)sender).GetValue(LeftResize) as Window;

			if (window != null)
			{
				var horizontalChange = window.SafeWidthChange(e.HorizontalChange, false);

				window.Width -= horizontalChange;
				window.Left += horizontalChange;
			}
		}

		private static void DragRight(object sender, DragDeltaEventArgs e)
		{
			var window = ((Thumb)sender).GetValue(RightResize) as Window;

			if (window != null)
				window.Width += window.SafeWidthChange(e.HorizontalChange);
		}

		private static void DragTop(object sender, DragDeltaEventArgs e)
		{
			var window = ((Thumb)sender).GetValue(TopResize) as Window;

			if (window != null)
			{
				var verticalChange = window.SafeHeightChange(e.VerticalChange, false);

				window.Height -= verticalChange;
				window.Top += verticalChange;
			}
		}


		private static void DragBottom(object sender, DragDeltaEventArgs e)
		{
			var window = ((Thumb)sender).GetValue(BottomResize) as Window;

			if (window != null)
				window.Height += window.SafeHeightChange(e.VerticalChange);
		}

		private static void DragTopLeft(object sender, DragDeltaEventArgs e)
		{
			var window = ((Thumb)sender).GetValue(TopLeftResize) as Window;

			if (window != null)
			{
				var horizontalChange = window.SafeWidthChange(e.HorizontalChange, false);
				var verticalChange = window.SafeHeightChange(e.VerticalChange, false);

				window.Width -= horizontalChange;
				window.Height -= verticalChange;
				window.Left += horizontalChange;
				window.Top += verticalChange;
			}
		}

		private static void DragTopRight(object sender, DragDeltaEventArgs e)
		{
			var window = ((Thumb)sender).GetValue(TopRightResize) as Window;

			if (window != null)
			{
				var verticalChange = window.SafeHeightChange(e.VerticalChange, false);

				window.Width += window.SafeWidthChange(e.HorizontalChange);
				window.Height -= verticalChange;
				window.Top += verticalChange;
			}
		}

		private static void DragBottomLeft(object sender, DragDeltaEventArgs e)
		{
			var window = ((Thumb)sender).GetValue(BottomLeftResize) as Window;

			if (window != null)
			{
				var horizontalChange = window.SafeWidthChange(e.HorizontalChange, false);

				window.Width -= horizontalChange;
				window.Left += horizontalChange;
				window.Height += window.SafeHeightChange(e.VerticalChange);
			}
		}

		private static void DragBottomRight(object sender, DragDeltaEventArgs e)
		{
			var window = ((Thumb)sender).GetValue(BottomRightResize) as Window;

			if (window != null)
			{
				window.Width += window.SafeWidthChange(e.HorizontalChange);
				window.Height += window.SafeHeightChange(e.VerticalChange);
			}
		}

		private static double SafeWidthChange(this Window window, double change, bool positive = true)
		{
			var result = positive ? (window.Width + change) : (window.Width - change);

			return (result <= window.MinWidth || result >= window.MaxWidth || result < 0) ? 0 : change;
		}

		private static double SafeHeightChange(this Window window, double change, bool positive = true)
		{
			var result = positive ? (window.Height + change) : (window.Height - change);

			return (result <= window.MinHeight || result >= window.MaxHeight || result < 0) ? 0 : change;
		}
	}
}
