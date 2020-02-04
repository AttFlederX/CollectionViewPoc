using System;
using System.Collections.Generic;
using System.Text;
using FFImageLoading.Forms;
using Xamarin.Forms;

namespace CollectionViewTest.Controls
{
    public class SquareImage : CachedImage
    {
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            HeightRequest = width;
        }
    }
}
