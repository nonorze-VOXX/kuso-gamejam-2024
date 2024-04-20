using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public static class DoTweenExtension
{
    public static Tween DoCanvasGroupAlpha(CanvasGroup CG, float endValue, float duration) //CanvasGroup Fading
    {
        return DOTween.To(() => CG.alpha, x => CG.alpha = x, endValue, duration);
    }

    public static Tween DoSpriteAlpha(SpriteRenderer SR, float endValue, float duration)  //SpriteRenderer DoFade
    {
        float alpha = SR.color.a;
        Color color = SR.color;
        return DOTween.To(() => alpha, x => alpha = x, endValue, duration).OnUpdate(() =>
        {
            SR.color = new Color(color.r, color.g, color.b, alpha);
        });
    }
}