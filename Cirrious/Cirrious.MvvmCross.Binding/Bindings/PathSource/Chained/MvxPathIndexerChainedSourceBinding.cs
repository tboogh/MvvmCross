// MvxPathIndexerChainedSourceBinding.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System.Collections.Generic;
using Cirrious.MvvmCross.Binding.Parse.PropertyPath.PropertyTokens;

namespace Cirrious.MvvmCross.Binding.Bindings.PathSource.Chained
{
    public class MvxPathIndexerChainedSourceBinding
        : MvxPathChainedSourceBinding
    {
        private readonly MvxIndexerPropertyToken _indexerPropertyToken;

        public MvxPathIndexerChainedSourceBinding(object source, MvxIndexerPropertyToken indexerPropertyToken,
                                                  IList<MvxPropertyToken> childTokens)
            : base(source, "Item", childTokens)
        {
            _indexerPropertyToken = indexerPropertyToken;
            UpdateChildBinding();
        }

        protected override object[] PropertyIndexParameters()
        {
            return new[] {_indexerPropertyToken.Key};
        }
    }
}