﻿using System.ComponentModel;
using AnimFlex.Tweener;

namespace AnimFlex.Sequencer.Clips
{
    [DisplayName("Tweener Position")]
    [Category("Tweener/Transform/Position")]
    public class CTweenerPosition : CTweener<TweenerGeneratorPosition> { }
    [DisplayName("Tweener LocalPosition")]
    [Category("Tweener/Transform/LocalPosition")]
    public class CTweenerLocalPosition : CTweener<TweenerGeneratorLocalPosition> { }
    [DisplayName("Tweener Rotation")]
    [Category("Tweener/Transform/Rotation")]
    public class CTweenerRotation : CTweener<TweenerGeneratorRotation> { }
    [DisplayName("Tweener LocalRotation")]
    [Category("Tweener/Transform/LocalRotation")]
    public class CTweenerLocalRotation : CTweener<TweenerGeneratorLocalRotation> { }
    [DisplayName("Tweener Scale")]
    [Category("Tweener/Transform/Scale")]
    public class CTweenerScale : CTweener<TweenerGeneratorScale> { }
    [DisplayName("Tweener Transform")]
    [Category("Tweener/Transform/Transform")]
    public class CTweenerTransform : CTweener<TweenerGeneratorTransform> { }
    [DisplayName("Tweener Fade (Graphic)")]
    [Category("Tweener/Fade/Graphic")]
    public class CTweenerFadeGraphic : CTweener<TweenerGeneratorFadeGraphic> { }
    [DisplayName("Tweener Fade (Renderer)")]
    [Category("Tweener/Fade/Renderer")]
    public class CTweenerFadeRenderer : CTweener<TweenerGeneratorFadeRenderer> { }
    [DisplayName("Tweener Fade (CanvasGroup)")]
    [Category("Tweener/Fade/CanvasGroup")]
    public class CTweenerFadeCanvasGroup : CTweener<TweenerGeneratorFadeCanvasGroup> { }
    [Category("Tweener/Fade/TMP")]
    public class CTweenerFadeTMP : CTweener<TweenerGeneratorFadeTMP> { }
    [DisplayName("Tweener Color (Graphic)")]
    [Category("Tweener/Color/Graphic")]
    public class CTweenerColorGraphic : CTweener<TweenerGeneratorColorGraphic> { }
    [DisplayName("Tweener Color (Renderer)")]
    [Category("Tweener/Color/Renderer")]
    public class CTweenerColorRenderer : CTweener<TweenerGeneratorColorRenderer> { }
    [Category("Tweener/Color/TextMesh")]
    public class CTweenerColorTMP : CTweener<TweenerGeneratorColorTMP> { }
    [Category("Tweener/Light/Color")]
    public class CTweenerLightColor : CTweener<TweenerGeneratorLightColor> { }
    [Category("Tweener/Light/Intensity")]
    public class CTweenerLightIntensity : CTweener<TweenerGeneratorLightIntensity> { }
}