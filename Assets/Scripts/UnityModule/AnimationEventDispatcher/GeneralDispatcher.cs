﻿using System;
using UniRx;
using UnityEngine;

namespace UnityModule.AnimationEventDispatcher {

    /// <summary>
    /// 汎用ディスパッチャ
    /// </summary>
    public class GeneralDispatcher : Base {

        /// <summary>
        /// 汎用イベント名: アニメーション開始
        /// </summary>
        private const string ANIMATION_EVENT_NAME_BEGIN = "Begin";

        /// <summary>
        /// 汎用イベント名: アニメーション終了
        /// </summary>
        private const string ANIMATION_EVENT_NAME_END = "End";

        /// <summary>
        /// AnimationEvent を Dispatch する
        /// </summary>
        /// <param name="animationEvent">Inspector で設定する情報を含んだ AnimationEvent</param>
        public void Dispatch(AnimationEvent animationEvent) {
            this.StreamAnimationEvent.OnNext(animationEvent);
        }

        /// <summary>
        /// アニメーション開始を表す AnimationEvent を Dispatch する
        /// </summary>
        /// <param name="animationEvent">Inspector で設定する情報を含んだ AnimationEvent</param>
        public void DispatchBegin(AnimationEvent animationEvent) {
            animationEvent.stringParameter = ANIMATION_EVENT_NAME_BEGIN;
            this.StreamAnimationEvent.OnNext(animationEvent);
        }

        /// <summary>
        /// アニメーション終了を表す AnimationEvent を Dispatch する
        /// </summary>
        /// <param name="animationEvent">Inspector で設定する情報を含んだ AnimationEvent</param>
        public void DispatchEnd(AnimationEvent animationEvent) {
            animationEvent.stringParameter = ANIMATION_EVENT_NAME_END;
            this.StreamAnimationEvent.OnNext(animationEvent);
        }

        /// <summary>
        /// Dispatch されたアニメーション開始を表す AnimationEvent を UniRx ストリームとして返す
        /// </summary>
        /// <returns>AnimationEvent のストリーム</returns>
        public IObservable<AnimationEvent> OnDispatchBeginAsObservable() {
            return this.OnDispatchAsObservable(ANIMATION_EVENT_NAME_BEGIN);
        }

        /// <summary>
        /// Dispatch されたアニメーション開始を表す AnimationEvent を UniRx ストリームとして返す
        /// </summary>
        /// <param name="animationClipName">Animation State 名</param>
        /// <returns>AnimationEvent のストリーム</returns>
        public IObservable<AnimationEvent> OnDispatchBeginAsObservable(string animationClipName) {
            return this.OnDispatchBeginAsObservable().Where(x => x.animatorClipInfo.clip.name == animationClipName);
        }

        /// <summary>
        /// Dispatch されたアニメーション終了を表す AnimationEvent を UniRx ストリームとして返す
        /// </summary>
        /// <returns>AnimationEvent のストリーム</returns>
        public IObservable<AnimationEvent> OnDispatchEndAsObservable() {
            return this.OnDispatchAsObservable(ANIMATION_EVENT_NAME_END);
        }

        /// <summary>
        /// Dispatch されたアニメーション終了を表す AnimationEvent を UniRx ストリームとして返す
        /// </summary>
        /// <param name="animationClipName">Animation State 名</param>
        /// <returns>AnimationEvent のストリーム</returns>
        public IObservable<AnimationEvent> OnDispatchEndAsObservable(string animationClipName) {
            return this.OnDispatchEndAsObservable().Where(x => x.animatorClipInfo.clip.name == animationClipName);
        }

    }

}
