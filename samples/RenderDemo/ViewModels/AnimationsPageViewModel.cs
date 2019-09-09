﻿using System;
using ReactiveUI;
using Avalonia.Animation;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using Avalonia.Collections;
using System.Reactive.Linq;
using Avalonia.Markup.Xaml.Templates;
using System.Linq.Expressions;
using System.Reflection;
using Avalonia.Controls;
using Avalonia.Layout;
using System.Collections.Specialized;
using System.Collections;
using Avalonia;

namespace RenderDemo.ViewModels
{
    public class SampleData : ReactiveObject
    {
        [DisplayName("Index")]
        public int Index { get; set; }



        private bool _Allow;

        [DisplayName("Allow")]

        public bool Allow
        {
            get => _Allow;
            set => this.RaiseAndSetIfChanged(ref _Allow, value);
        }

        [DisplayName("Some Text")]
        public string SomeText { get; set; }

        [DisplayName("Random Number 1")]
        public string RndNum1 { get; set; }

        [DisplayName("Random Number 2")]
        public string RndNum2 { get; set; }

        [DisplayName("Random Number 3")]
        public string RndNum3 { get; set; }
    }

    public class AnimationsPageViewModel : ReactiveObject
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public AnimationsPageViewModel()
        {
            var k = new List<SampleData>();
            var r = new Random();

            for (int i = 0; i < 1_000_000; i++)
            {
                var l = new SampleData()
                {
                    Index = i,
                    Allow = r.NextDouble() > 0.5,
                    SomeText = RandomString(10),
                    RndNum1 = r.NextDouble().ToString(),
                    RndNum2 = r.NextDouble().ToString(),
                    RndNum3 = r.NextDouble().ToString(),
                };

                k.Add(l);
            }

            DataRows = k;
        }

        IEnumerable dataRows;

        public IEnumerable DataRows
        {
            get => dataRows;
            set
            {
                this.RaiseAndSetIfChanged(ref dataRows, value);
            }
        }
    }
}
