﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
    /// 单例
    /// </summary>
    public abstract class Singleton<T> where T : Singleton<T>
    {
        private static T _instance;

        private static object _locker = new object();

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_locker)
                    {
                        if (_instance == null)
                        {
                            _instance = Activator.CreateInstance<T>();
                        }
                    }
                }

                return _instance;
            }
        }

        protected Singleton() { }
    }