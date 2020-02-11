﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MS-PL license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Reflection;
using AndroidX.AppCompat.Widget;
using AndroidX.DrawerLayout.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Presenters;
using MvvmCross.ViewModels;

namespace MvvmCross.DroidX.AppCompat
{
    public abstract class MvxAppCompatSetup : MvxAndroidSetup
    {
        protected override IEnumerable<Assembly> AndroidViewAssemblies =>
            new List<Assembly>(base.AndroidViewAssemblies)
            {
                typeof(Toolbar).Assembly,
                typeof(DrawerLayout).Assembly,
                typeof(MvxSwipeRefreshLayout).Assembly
            };

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            return new MvxAppCompatViewPresenter(AndroidViewAssemblies);
        }

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            MvxAppCompatSetupHelper.FillTargetFactories(registry);
            base.FillTargetFactories(registry);
        }

        protected override void FillBindingNames(IMvxBindingNameRegistry registry)
        {
            MvxAppCompatSetupHelper.FillDefaultBindingNames(registry);
            base.FillBindingNames(registry);
        }
    }

    public class MvxAppCompatSetup<TApplication> : MvxAppCompatSetup
        where TApplication : class, IMvxApplication, new()
    {
        protected override IMvxApplication CreateApp() => Mvx.IoCProvider.IoCConstruct<TApplication>();

        public override IEnumerable<Assembly> GetViewModelAssemblies()
        {
            return new[] { typeof(TApplication).GetTypeInfo().Assembly };
        }
    }
}
