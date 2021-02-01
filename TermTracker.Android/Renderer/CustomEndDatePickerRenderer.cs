﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TermTracker.Droid.Renderer;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using TermTracker.CustomRender;

[assembly: ExportRenderer(typeof(CustomEndDatePicker), typeof(CustomEndDatePickerRenderer))]
namespace TermTracker.Droid.Renderer
{
    class CustomEndDatePickerRenderer : DatePickerRenderer
    {
        public CustomEndDatePickerRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Text = "End Date";
            }
        }
    }
}