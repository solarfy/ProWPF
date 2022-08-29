using System.Windows.Media.Effects;
using System;

namespace ProWPF.Effects
{
    class GrayscaleEffect : ShaderEffect
    {
        public GrayscaleEffect()
        {
            Uri pixelShaderUri = new Uri("/Effects/Grayscale/GrayscaleEffect.ps", UriKind.Relative);
            base.PixelShader = new PixelShader() { UriSource = pixelShaderUri };            
        }
    }
}
