﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Optimization;

namespace Tesco.Com.Web.Core.UIAssets
{
    public static class BundleCollectionExtensions
    {
        public static string FingerprintsOf(this BundleCollection instance, params string[] virtualPaths)
        {
            if (!virtualPaths.Any())
            {
                return null;
            }

            var list = virtualPaths
                .Select(path => instance.ResolveBundleUrl(path, true))
                .Select(ExtractFingerprint)
                .Where(f => !string.IsNullOrWhiteSpace(f));

            var result = string.Join("|", virtualPaths);
            return result;
        }

        private static string ExtractFingerprint(string url)
        {
            var index = url.IndexOf('?');

            if (index < 1)
            {
                return null;
            }

            var queryString = url.Substring(index + 1);

            var parts = queryString.Split(new[] { '=' },
                StringSplitOptions.RemoveEmptyEntries);

            return parts.Length > 0 ? parts[1] : queryString;
        }
    }
}
