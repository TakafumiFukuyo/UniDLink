﻿using System;
using System.Collections.Generic;

namespace UniDLink
{
    public class UniDLinker<T> : IUniDSignalizable, IUniDSignalModdable<T>, IUniDLinkable<T>, IUniDDualLinkable<T> 
    {
        private T linkedValue;
        private List<Action<T>> onSignaledActions = new List<Action<T>>();

        public UniDLinker()
        {
        }

        public UniDLinker(T defaultValue)
        {
            LinkedValue = defaultValue;
        }

        public T LinkedValue
        {
            get
            {
                return linkedValue;
            }
            set
            {
                linkedValue = value;
                Signaling();
            }
        }

        public Action<T> AddOnSignaled(Action<T> act)
        {
            onSignaledActions.Add(act);
            return act;
        }

        public void RemoveOnSignaled(Action<T> act)
        {
            onSignaledActions.Remove(act);
        }

        public void Signaling()
        {
            foreach (Action<T> act in onSignaledActions)
            {
                act(linkedValue);
            }
        }
    }
}